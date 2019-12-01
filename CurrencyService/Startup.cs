using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyLib;
using CurrencyService.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceUtils.Middleware;
using UtilsLib;

namespace CurrencyService
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (AppConfig.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDisableHttp();

            app.UseCors(config =>
            {
                config
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHub<CurrenciesHub>("/push/currencies");
            });

            var hubContext = app.ApplicationServices.GetService<IHubContext<CurrenciesHub>>();

            RedisDao.SubscribeService((channel, value) =>
            {
                hubContext.Clients.All.SendAsync("CurrenciesUpdate", value.ToString());
            });

            Console.WriteLine($"EnvVar: {AppConfig.EnvVar}");
        }
    }
}
