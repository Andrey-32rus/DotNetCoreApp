﻿using System;
using Microsoft.Extensions.Configuration;

namespace StandardClassLibrary
{
    public static class AppConfig
    {
        public static string EnvVar { get; } = Environment.GetEnvironmentVariable("EnvVar");
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