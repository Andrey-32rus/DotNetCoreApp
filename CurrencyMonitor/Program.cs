using System;
using System.Threading;
using Microsoft.AspNetCore.SignalR.Client;

namespace CurrencyMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/push/currencies")
                .Build();
            
            while (true)
            {
                try
                {
                    connection.StartAsync().Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }

                Console.WriteLine("registered");
                break;
            }
            

            while (true)
            {
                Thread.Sleep(500);
            }
        }
    }
}
