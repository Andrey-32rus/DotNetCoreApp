using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DI
    {
        private static readonly ServiceProvider ServProvider;

        static DI()
        {
            var conf = typeof(IServiceConfigurator);
            var types = Assembly.GetEntryAssembly().GetExportedTypes();
            IServiceConfigurator configurator = null;
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var inter in interfaces)
                {
                    if (inter.FullName == conf.FullName)
                    {
                        configurator = (IServiceConfigurator)Activator.CreateInstance(type);
                        break;
                    }
                }
            }

            // create service collection
            var services = new ServiceCollection();
            configurator.ConfigureServices(services);

            // create service provider
            ServProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return ServProvider.GetService<T>();
        }
    }
}
