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
            return Client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json")).Result.Content
                .ReadAsStringAsync().Result;
        }
    }
}
