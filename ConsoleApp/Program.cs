using System;
using ALogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    class Program
    {
        static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<ProgramService>();
            services.AddSingleton<ALog>(new ALog("ConsoleApp"));
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
