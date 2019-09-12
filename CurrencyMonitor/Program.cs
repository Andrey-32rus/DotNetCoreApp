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
                .WithUrl("https://localhost:5001/ChatHub")
                .Build();

            connection.StartAsync().Wait();

            while (true)
            {
                Thread.Sleep(500);
            }
        }
    }
}
