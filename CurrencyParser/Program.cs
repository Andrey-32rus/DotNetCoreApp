using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CurrencyLib;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using UtilsLib;

namespace CurrencyParser
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string json = HttpUtils.Get("https://www.cbr-xml-daily.ru/daily_json.js");
                    Console.WriteLine($"Currecies Downloaded DT:{DateTime.Now}");

                    string jsonCurs = Fnc.JsonPath(json, "$.Valute.*");
                    var listCurs = JsonConvert.DeserializeObject<List<CurrencyMongo>>(jsonCurs);
                    foreach (var cur in listCurs)
                    {
                        cur.BaseRate = 1m / cur.Value / cur.Nominal;
                    }

                    MongoDao.ReplaceAllCurrencies(listCurs);
                    var listResp = listCurs.Select(x => new CurrencyResponse(x)).ToList();
                    RedisDao.UpdateCurrencies(listResp);
                    
                    Console.WriteLine($"Currecies Updated DT:{DateTime.Now}");
                }
                catch (Exception e)
                {
                    MyLogger.Log(e.ToString(), LogLevel.Error);
                }
              

                Thread.Sleep(15 * 1000);
            }

        }
    }
}
