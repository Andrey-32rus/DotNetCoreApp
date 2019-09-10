using System;
using System.Collections.Generic;
using CurrencyLib;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UtilsLib;

namespace CurrencyParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = NetUtils.Get("https://www.cbr-xml-daily.ru/daily_json.js");
            //var js = JObject.Parse(json);
            //var res = js.SelectTokens("$.Valute.*").ToJson();
            string jsonCurs = Fnc.JsonPath(json, "$.Valute.*");
            Console.WriteLine(jsonCurs);
            var listCurs = JsonConvert.DeserializeObject<List<CurrencyModel>>(jsonCurs);
            foreach (var cur in listCurs)
            {
                cur.BaseRate = 1m / cur.Value / cur.Nominal;
            }
            MongoDao.ReplaceAllCurrencies(listCurs);
        }
    }
}
