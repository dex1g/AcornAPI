using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AcornAPI.Configurations;
using Swashbuckle.AspNetCore.Swagger;

namespace AcornAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ModuleConfiguration moduleConfiguration = new ModuleConfiguration(services, Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Acorn API",
                    Description = "API of the Acorn bot management system",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Huan Carlos",
                        Email = "email@address.com",
                        Url = "https://github.com/dex1g/"
                    }
                });
                c.DescribeAllEnumsAsStrings();
            });

            moduleConfiguration.AddDatabaseContext();

            moduleConfiguration.CreateNpsqlEnumMappings();

            moduleConfiguration.ConfigureServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Acorn API V1");
            });
        }
    }
}
