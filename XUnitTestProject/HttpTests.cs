using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class HttpTests
    {
        private HttpClient client;

        public HttpTests()
        {
            HttpMessageHandler handler = new SocketsHttpHandler()
            {
                MaxConnectionsPerServer = int.MaxValue,
            };
            client = new HttpClient(handler, true);
        }

        [Fact]
        public void PostJson()
        {
            client.PostAsJsonAsync()
            string yandex = client.GetStringAsync("https://yandex.ru").Result;
            yandex = client.GetStringAsync("https://yandex.ru").Result;
        }
    }
}
