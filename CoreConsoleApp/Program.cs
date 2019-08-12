using StandardClassLibrary;
using System;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppConfig.GetConnectionString("Connection1"));
            Console.WriteLine(AppConfig.GetValue("Family"));
            Console.WriteLine(AppConfig.GetValue("Name"));
        }
    }
}
