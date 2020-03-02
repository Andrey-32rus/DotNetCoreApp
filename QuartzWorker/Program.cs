using System;
using System.Threading.Tasks;
using ALogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz.Spi;
using QuartzUtilities;
using QuartzWorker.Jobs;

namespace QuartzWorker
{
    class Program
    {
        static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            var configuration = host.Configuration;
            services.AddSingleton<QuartzSchedulerService>();
            services.AddOptions<QuartzConfiguration>().Bind(configuration.GetSection(nameof(QuartzConfiguration)));

            //Logger
            services.AddSingleton<ALog>(new ALog("QuartzWorker"));

            //Quartz
            services.AddSingleton<IJobFactory, JobFactory>();

            //Jobs
            services.AddSingleton<HelloWorldJob>();
        }

        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .ConfigureServices(ConfigureServices)
                .Build();

            var quartz = host.Services.GetRequiredService<QuartzSchedulerService>();

            await quartz.RunProgram();
            Console.ReadLine();
            await quartz.ShutDown();
        }
    }
}
