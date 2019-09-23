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
    }
}
