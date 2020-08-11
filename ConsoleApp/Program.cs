using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Fluent;

namespace ConsoleApp
{
    class Program
    {
        static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            //services.AddHostedService<HostedService>();
            services.AddHostedService<ProgramService>();
            services.AddSingleton<ALog>(new ALog("ConsoleApp"));

            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Warning);
                if (host.HostingEnvironment.IsDevelopment() == false)
                    builder.ClearProviders();
                builder.AddNLog();
            });
        }

        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .ConfigureServices(ConfigureServices)
                .UseConsoleLifetime(options =>
                {
                    options.SuppressStatusMessages = true;
                })
                .Build();

            host.Run();
        }
    }
}
