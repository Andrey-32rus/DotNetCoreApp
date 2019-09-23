using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UtilsLib
{
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
    }
}
