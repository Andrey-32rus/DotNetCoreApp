using System;
using Microsoft.Extensions.Configuration;

namespace StandardClassLibrary
{
    public static class AppConfig
    {
        private static readonly IConfigurationRoot Config = new ConfigurationBuilder().AddJsonFile($"appsettings.json").Build();

        public static T GetValue<T>(string path)
        {
            try
            {
                return Config.GetValue<T>(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }

        public static string GetConnectionString(string name)
        {
            try
            {
                return Config.GetConnectionString(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
