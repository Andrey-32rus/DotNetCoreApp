using System;
using Microsoft.Extensions.Configuration;

namespace StandardClassLibrary
{
    public static class AppConfig
    {
        private static readonly IConfigurationRoot Config = new ConfigurationBuilder().AddJsonFile($"conf.json").Build();

        public static string GetValue(string path)
        {
            try
            {
                return Config[path];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
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
