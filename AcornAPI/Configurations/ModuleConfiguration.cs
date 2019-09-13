using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Acorn.BL.Enums;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Services;
using Acorn.DAL;
using Acorn.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Swashbuckle.AspNetCore.Swagger;

namespace AcornAPI.Configurations
{
    public class ModuleConfiguration
    {
        private readonly IServiceCollection _services;

        private readonly IConfiguration _configuration;

        public ModuleConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }


        public void ConfigureServices()
        {
            _services.AddScoped<IAccountsRepository, AccountsRepository>();
            _services.AddScoped<IBotsRepository, BotsRepository>();
            _services.AddScoped<IConfigsRepository, ConfigsRepository>();
            _services.AddScoped<IFreshAccountsRepository, FreshAccountsRepository>();
            _services.AddScoped<ILogsRepository, LogsRepository>();
            _services.AddScoped<IReadyAccountsRepository, ReadyAccountsRepository>();
            _services.AddScoped<IUsersRepository, UsersRepository>();
            _services.AddScoped<IAccountService, AccountService>();
            _services.AddScoped<IBotService, BotService>();
            _services.AddScoped<IConfigService, ConfigService>();
            _services.AddScoped<IFreshAccountService, FreshAccountService>();
            _services.AddScoped<ILogService, LogService>();
            _services.AddScoped<IReadyAccountService, ReadyAccountService>();
            _services.AddScoped<IUserService, UserService>();
        }

        public void CreateNpsqlEnumMappings()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<AiConfig>("ai_config");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BotOrder>("bot_order");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<QueueType>("queue_type");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Region>("region");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<LevelingModel>("leveling_model");
        }

        public void AddDatabaseContext()
        {
            _services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(_configuration.GetConnectionString("TestAcornDatabase")));

            _services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>().BuildServiceProvider();
        }

        public void AddSwagger()
        {
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Acorn API",
                    Description = "API of the Acorn bot management system"
                });

                c.DescribeAllEnumsAsStrings();

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", Array.Empty<string>()},
                });
            });
        }

        public void AddJwtAuthentication()
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            _services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            _services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            var userId = int.Parse(context.Principal.Identity.Name, CultureInfo.InvariantCulture);
                            var user = userService.GetById(userId);
                            if (user == null)
                            {
                                // return unauthorized if user no longer exists
                                context.Fail("Unauthorized");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public void AddDatabaseSeed()
        {
            _services.AddTransient<SeedDatabase>();
        }

    }
}
