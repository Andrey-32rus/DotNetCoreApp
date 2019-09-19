using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurrencyLib;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using UtilsLib;

namespace CurrencyMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var jsonCurs = NetUtils.Get("https://localhost:5001/api/currencies");
                        var curs = JsonConvert.DeserializeObject<List<CurrencyResponse>>(jsonCurs);
                        Utils.WriteCurrenciesToConsole(curs);
                    }
                    catch (Exception e)
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    break;
                }
            });

            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/push/currencies", x =>
                {
                    x.AccessTokenProvider = () => Task.FromResult("token");
                })
                .Build();

            Task.Run(() =>
            {
                connection.On<string>("CurrenciesUpdate", param =>
                {
                    var list = JsonConvert.DeserializeObject<List<CurrencyResponse>>(param);
                    Utils.WriteCurrenciesToConsole(list);
                });

                while (true)
                {
                    try
                    {
                        connection.StartAsync().Wait();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Thread.Sleep(500);
                        continue;
                    }

                    break;
                }
            });


            while (true)
            {
                string str = Console.ReadLine();
                connection.SendAsync("Method", str);
            }
        }
    }
}
