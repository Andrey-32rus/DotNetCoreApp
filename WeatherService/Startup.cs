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
using NLog.Extensions.Logging;
using ServiceUtils.Middleware;
using WeatherService.Filters;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(options =>
            {
                options.SetMinimumLevel(LogLevel.Warning);
                options.AddNLog();
            });

            var mvcBuilder = services.AddControllers();
            mvcBuilder.ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressMapClientErrors = true; //Выключает стандартное тело ответа при ошибках
            });
            var alog = new ALog("ALog");
            mvcBuilder.AddMvcOptions(opt =>
            {
                opt.Filters.Add(new ExceptionFilter(alog));
                opt.RequireHttpsPermanent = true;
            });
            services.AddSingleton(alog);
            services.AddSingleton<IWarmup, Warmup.Warmup>();

            services.AddHttpClient<SomeApiClient>();
            //services.AddHttpClient();
            //services.AddSingleton<SomeApiClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            //app.UseDisableHttp();

            long maxContentLength = 5 * 1024;
            //string maxContentLengthText = "Maximal contentLength exceeded";
            app.UseMaxContentLength(maxContentLength, (int)HttpStatusCode.RequestEntityTooLarge, string.Empty);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
