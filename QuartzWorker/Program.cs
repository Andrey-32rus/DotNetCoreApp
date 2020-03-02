using System;
using ALogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz.Spi;
using QuartzWorker.Jobs;
using QuartzWorker.Jobs.Utils;

namespace QuartzWorker
{
    class Program
    {
        static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<ProgramService>();

            //Logger
            services.AddSingleton<ALog>(new ALog("QuartzWorker"));

            //Quartz
            services.AddSingleton<IJobFactory, JobFactory>();

            //Jobs
            services.AddSingleton<HelloWorldJob>();
        }

        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .ConfigureServices(ConfigureServices)
                .Build();

            var program = host.Services.GetRequiredService<ProgramService>();
            program.Main(args);
        }
    }
}
