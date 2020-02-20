using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject
{
    public class HttpTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private HttpClient client;

        public HttpTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            SocketsHttpHandler handler = new SocketsHttpHandler()
            {
                //максимальное кол-во соединений к серверу
                MaxConnectionsPerServer = int.MaxValue, 

                //время жизни соединения
                PooledConnectionLifetime = TimeSpan.FromSeconds(10),

                //время жизни соединения в случае бездействия.
                //Если больше чем PooledConnectionLifetime, то не играет роли
                PooledConnectionIdleTimeout = TimeSpan.FromSeconds(60), 

            };
            client = new HttpClient(handler);
        }

        [Fact]
        public void ManyRequests()
        {
            int countOfRequests = 500;


            var timer = Stopwatch.StartNew();
            List<Task> taskList = new List<Task>(countOfRequests);
            for (int i = 0; i < countOfRequests; i++)
            {
                var task = client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
                taskList.Add(task);
            }
            

            Task.WaitAll(taskList.ToArray());

            timer.Stop();
            long time = timer.ElapsedMilliseconds;
            testOutputHelper.WriteLine(time.ToString());
        }

        [Fact]
        public void PostJson()
        {
            SimpleContract body = new SimpleContract()
            {
                Field1 = "aaa",
                Field2 = "bbb"
            };
            var response = client.PostAsJsonAsync("https://localhost:44327/weatherforecast", body).Result;
            var result = response.Content.ReadAsAsync<SimpleContract>().Result;
        }

        private Task SleepAsync(TimeSpan timespan)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(timespan);
            });
        }

        [Fact]
        public async Task TestAsync()
        {
            await SleepAsync(TimeSpan.FromSeconds(5));
        }
    }
}
