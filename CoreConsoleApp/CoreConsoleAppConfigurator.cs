using System;
using DependencyInjection;
using DependencyInjection.WriterDI;
using Microsoft.Extensions.DependencyInjection;

namespace CoreConsoleApp
{
    public class CoreConsoleAppConfigurator : IServiceConfigurator
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IWriter, Writer>();
        }
    }
}