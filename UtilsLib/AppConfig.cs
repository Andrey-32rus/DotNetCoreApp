using System;
using Microsoft.Extensions.Configuration;
using NLog;

namespace UtilsLib
{
    public static class AppConfig
    {
        private static readonly string EnvVar = Environment.GetEnvironmentVariable("EnvVar");
        private static readonly IConfigurationRoot Config = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true)
            .AddJsonFile($"appsettings.{EnvVar}.json", true)
            .Build();

        public static T GetValue<T>(string path)
        {
            try
            {
                return Config.GetValue<T>(path);
            }
            catch (Exception e)
            {
                MyLogger.Log(e.ToString(), LogLevel.Error);
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
                MyLogger.Log(e.ToString(), LogLevel.Error);
                return null;
            }
        }

        #region Environment Getters

        public static bool IsDevelopment()
        {
            return EnvVar == EnvironmentType.Development;
        }

        public static bool IsStaging()
        {
            return EnvVar == EnvironmentType.Staging;
        }

        public static bool IsProduction()
        {
            return EnvVar == EnvironmentType.Production;
        }

        public static bool IsEnvironment(string environmentName)
        {
            return EnvVar == environmentName;
        }
        #endregion
    }
}
