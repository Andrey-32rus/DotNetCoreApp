using System;
using System.Linq.Expressions;
using System.Threading;
using DependencyInjection;
using DependencyInjection.WriterDI;
using RedisWrapper;
using StackExchange.Redis;
using UtilsLib;

namespace CoreConsoleApp
{
    class Program
    {
        static T Function<T>(Func<T, T, T> fnc, T left, T right)
        {
            return fnc.Invoke(left, right);
        }

        private static void JsonPathTest()
        {
            string json = @"{
                              'Stores': [
                                'Lambton Quay',
                                'Willis Street'
                              ],
                              'Manufacturers': [
                                {
                                  'Name': 'Acme Co',
                                  'Products': [
                                    {
                                      'Name': 'Anvil',
                                      'Price': 50
                                    }
                                  ]
                                },
                                {
                                  'Name': 'Contoso',
                                  'Products': [
                                    {
                                      'Name': 'Elbow Grease',
                                      'Price': 99.95
                                    },
                                    {
                                      'Name': 'Headlight Fluid',
                                      'Price': 4
                                    }
                                  ]
                                }
                              ]
                            }";

            string res = Fnc.JsonPath(json, "$.Manufacturers[?(@.Name == 'Contoso')].Products");
            Console.WriteLine(res);
        }

        private static void DITest()
        {
            var writer = DI.GetService<IWriter>();
            writer.Write();
        }


        static void Main(string[] args)
        {
            string chanelName = "chanel";
            var redis = new RedisWrap("localhost");
            var db0 = redis.GetDataBase(0);
            var subscriber = redis.GetSubscriber();
            subscriber.Subscribe(chanelName, (chanel, value) =>
            {
                Console.WriteLine($"Chanel: {chanel}\tValue: {value}");
            });
            long res = subscriber.Publish(chanelName, "Hello World!!!");

            while (true)
            {
                Thread.Sleep(500);
            }

            Console.ReadLine();
        }
    }
}
