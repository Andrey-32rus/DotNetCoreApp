using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace UtilsLib
{
    public class HttpResponse<T>
    {
        public HttpResponseMessage HttpResponseMessage;
        public T ResponseBody;
    }

    public static class HttpUtils
    {
        private static readonly HttpClient Client = new HttpClient();

        public static string Get(string url)
        {
            return Client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        public static string Post(string url, string body)
        {
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var result = Client.PostAsync(url, content).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        public static HttpResponse<TResp> Post<TReq, TResp>(string url, TReq body)
        {
            var content = new StringContent(body.ToJson(), Encoding.UTF8, "application/json");
            var httpResponseMessage = Client.PostAsync(url, content).Result;
            var responseBodyString = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var responseBody = JsonConvert.DeserializeObject<TResp>(responseBodyString);
            return new HttpResponse<TResp>
            {
                HttpResponseMessage = httpResponseMessage,
                ResponseBody = responseBody,
            };
        }
    }
}
