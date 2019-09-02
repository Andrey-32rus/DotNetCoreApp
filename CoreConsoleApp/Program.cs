﻿using StandardClassLibrary;
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

        private static void Test()
        {
            var res = Function((x, y) => x + y, 2, 3);

            Console.WriteLine($"EnvVar: {AppConfig.EnvVar}");
            Console.WriteLine(AppConfig.GetConnectionString("Connection1"));
            Console.WriteLine(AppConfig.GetValue<string>("Family"));
            Console.WriteLine(AppConfig.GetValue<string>("Name"));
            Console.WriteLine(AppConfig.GetValue<int>("Age"));
            Console.WriteLine($"Now is: {DateTime.Now.ToUnixTimestamp()}");
        }

        static void Main(string[] args)
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
            Console.ReadLine();
        }
    }
}
