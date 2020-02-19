using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XUnitTestProject
{
    public ref struct HttpResponse<T>
    {
        public HttpResponseMessage HttpResponseMessage;
        public T ResponseBody;
    }

    public class HttpWrapper : IDisposable, IAsyncDisposable
    {
        private bool isDisposed = false;
        public HttpClient Client { get; }//геттер на случай если нужно без враппера обойтись

        public HttpWrapper(HttpMessageHandler handler, bool disposeHandler = true)
        {
            Client = new HttpClient(handler, disposeHandler);
        }


        public string Get(string url)
        {
            return Client.GetStringAsync(url).Result;
        }

        public HttpResponse<TResp> PostJson<TReq, TResp>(string url, TReq body, params (string name, string value)[] headers)
        {
            ObjectContent<TReq> content = new ObjectContent<TReq>(body, new JsonMediaTypeFormatter());
            foreach (var header in headers)
            {
                content.Headers.Add(header.name, header.value);
            }

            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            var httpResponseMessage = Client.SendAsync(reqMessage).Result;
            var responseBodyString = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var responseBody = JsonConvert.DeserializeObject<TResp>(responseBodyString);
            return new HttpResponse<TResp>
            {
                HttpResponseMessage = httpResponseMessage,
                ResponseBody = responseBody,
            };
        }

        private void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                Client.Dispose();
                // Free any other managed objects here.
                //
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.Run(Dispose));
        }

        ~HttpWrapper()
        {
            Dispose(false);
        }
    }
}
