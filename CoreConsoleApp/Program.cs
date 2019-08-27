using StandardClassLibrary;
using System;
using System.Linq.Expressions;

namespace CoreConsoleApp
{
    class Program
    {
        static T Function<T>(Func<T, T, T> fnc, T left, T right)
        {
            return fnc.Invoke(left, right);
        }

        static void Main(string[] args)
        {
            var res = Function((x, y) => x + y, 2, 3);

            Console.WriteLine($"EnvVar: {AppConfig.EnvVar}");
            Console.WriteLine(AppConfig.GetConnectionString("Connection1"));
            Console.WriteLine(AppConfig.GetValue<string>("Family"));
            Console.WriteLine(AppConfig.GetValue<string>("Name"));
            Console.WriteLine(AppConfig.GetValue<int>("Age"));
            Console.WriteLine($"Now is: {DateTime.Now.ToUnixTimestamp()}");

            MyLogger.Log("LOG");

            Console.ReadLine();
        }
    }
}
