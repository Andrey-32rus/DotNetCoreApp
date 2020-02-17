using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using UtilsLib;

namespace XUnitTestProject
{
    public ref struct HttpResponse<T>
    {
        public HttpResponseMessage HttpResponseMessage;
        public T ResponseBody;
    }

    public class HttpWrapper
    {
        private HttpClient httpClient;

        public HttpWrapper(HttpMessageHandler handler, bool disposeHandler = true)
        {
            httpClient = new HttpClient(handler, disposeHandler);
        }

        public string Get(string url)
        {
            return httpClient.GetStringAsync(url).Result;
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
                Version = HttpVersion.Version11, 
                Content = content
            };

            var httpResponseMessage = httpClient.SendAsync(reqMessage).Result;
            var responseBodyString = httpResponseMessage.Content.ToString();
            var responseBody = JsonConvert.DeserializeObject<TResp>(responseBodyString);
            return new HttpResponse<TResp>
            {
                HttpResponseMessage = httpResponseMessage,
                ResponseBody = responseBody,
            };
        }
    }
}
