using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using Contracts;
using Xunit;

namespace XUnitTestProject
{
    public class HttpTests
    {
        private HttpWrapper wrapper;

        public HttpTests()
        {
            HttpMessageHandler handler = new SocketsHttpHandler()
            {
                MaxConnectionsPerServer = int.MaxValue,
            };
            wrapper = new HttpWrapper(handler);
        }

        [Fact]
        public void PostJson()
        {
            SimpleContract body = new SimpleContract()
            {
                Field1 = "aaa",
                Field2 = "bbb"
            };
            var result = wrapper.PostJson<SimpleContract, SimpleContract>("https://localhost:44327/weatherforecast", body);
        }
    }
}
