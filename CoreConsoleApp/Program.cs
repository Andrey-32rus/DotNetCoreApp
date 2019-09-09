using System;
using System.Linq.Expressions;
using System.Threading;
using NLog;
using RedisWrapper;
using StackExchange.Redis;
using UtilsLib;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLogger.Log("Start", LogLevel.Info);

            string chanelName = "chanel";
            var redis = new RedisWrap("localhost");
            var db0 = redis.GetDataBase(0);
            redis.Subscribe(chanelName, (chanel, value) => Console.WriteLine($"Chanel: {chanel}\tValue: {value}"));
            redis.Subscribe(chanelName, (chanel, value) => Console.WriteLine($"SB2 Chanel: {chanel}\tValue: {value}"));
            long res = redis.Publish(chanelName, "Hello World!!!");

            while (true)
            {
                Thread.Sleep(500);
            }
        }
    }
}
