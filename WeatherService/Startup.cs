using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ALogger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceUtils.Middleware;
using WeatherService.Warmup;

namespace WeatherService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void WarmupLogic()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));//5 ��� ��������
        }

        private void StartWarmup(IServiceProvider sp)
        {
            var warmup = sp.GetRequiredService<WarmupContainer>();
            warmup.WarmUp();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(new ALog("ALog"));
            services.AddSingleton(svcColl =>
            {
                WarmupContainer hc = new WarmupContainer(WarmupLogic);
                return hc;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseDisableHttp();

            long maxContentLengthBytes = 5 * 1024;
            //string maxContentLengthText = "Maximal contentLength exceeded";
            app.UseMaxContentLength(maxContentLengthBytes, (int)HttpStatusCode.RequestEntityTooLarge, string.Empty);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            StartWarmup(app.ApplicationServices);
        }
    }
}
