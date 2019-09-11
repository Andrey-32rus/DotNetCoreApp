using System;
using CurrencyLib;
using NUnit.Framework;
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
            string json = NetUtils.Get("https://www.cbr-xml-daily.ru/daily_json.js");
            Console.WriteLine(json);
            Assert.IsNotNull(json);
        }
    }
}