using StandardClassLibrary;
using System;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppConfig.GetConnectionString("Connection1"));
            Console.WriteLine(AppConfig.GetValue<string>("Family"));
            Console.WriteLine(AppConfig.GetValue<string>("Name"));
            Console.WriteLine(AppConfig.GetValue<int>("Age"));
        }
    }
}
