using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;

namespace ConsoleApp
{
    class Program
    {
        static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<ProgramService>();
        }

        static void ConfigureAppConfiguration(HostBuilderContext host, IConfigurationBuilder configuration)
        {
            configuration
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", true, false)
                .AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", true, false);
        }


        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging(logBuilder => logBuilder.AddNLog())
                .Build();

            var program = host.Services.GetRequiredService<ProgramService>();
            program.Main(args);

            //host.Run();
        }
    }
}
