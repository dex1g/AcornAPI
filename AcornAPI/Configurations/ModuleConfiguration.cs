using Acorn.BL.Enums;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Services;
using Acorn.DAL;
using Acorn.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace AcornAPI.Configurations
{
    public class ModuleConfiguration
    {
        private IServiceCollection _services;

        private IConfiguration _configuration;

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
            _services.AddScoped<IAccountService, AccountService>();
            _services.AddScoped<IBotService, BotService>();
            _services.AddScoped<IConfigService, ConfigService>();
            _services.AddScoped<IFreshAccountService, FreshAccountService>();
            _services.AddScoped<ILogService, LogService>();
            _services.AddScoped<IReadyAccountService, ReadyAccountService>();
        }

        public void CreateNpsqlEnumMappings()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<AiConfigs>("ai_configs");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BotOrders>("bot_orders");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<QueueTypes>("queue_types");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Regions>("regions");
        }

        public void AddDatabaseContext()
        {
            _services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(_configuration.GetConnectionString("AcornDatabase")));

            _services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>().BuildServiceProvider();
        }

        public void AddDatabaseSeed()
        {
            _services.AddTransient<SeedDatabase>();
        }

    }
}
