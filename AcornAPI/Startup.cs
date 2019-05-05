﻿using AutoMapper;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Services;
using Acorn.DAL;
using Acorn.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AcornAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddEntityFrameworkSqlite().AddDbContext<DatabaseContext>();

            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IBotsRepository, BotsRepository>();
            services.AddScoped<IBotOrdersRepository, BotOrdersRepository>();
            services.AddScoped<IConfigsRepository, ConfigsRepository>();
            services.AddScoped<IFreshAccountsRepository, FreshAccountsRepository>();
            services.AddScoped<ILogsRepository, LogsRepository>();
            services.AddScoped<IReadyAccountsRepository, ReadyAccountsRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBotService, BotService>();
            services.AddScoped<IBotOrderService, BotOrderService>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IFreshAccountService, FreshAccountService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IReadyAccountService, ReadyAccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}