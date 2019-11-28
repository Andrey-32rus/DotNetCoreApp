using System;
using System.Collections.Generic;
using CurrencyLib;
using NUnit.Framework;
using NUnitTestProject.Models;
using UtilsLib;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //test bitbucket
        }

        [Test]
        public void JsonPathTest()
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

            Assert.Pass();
        }

        [Test]
        public void GetRequest()
        {
            string json = HttpUtils.Get("https://www.cbr-xml-daily.ru/daily_json.js");
            Console.WriteLine(json);
            Assert.IsNotNull(json);
        }

        [Test]
        public void TestDictionary()
        {
            //(int first, int second)
            //(int, int)
            Dictionary<int, (int first, int second)> dict = new Dictionary<int, (int, int)>();
            dict.Add(0, (5, 6));
            Console.WriteLine(dict[0].first);
            Console.WriteLine(dict[0].second);
        }
    }
}