using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CurrencyLib
{
    public static class NetUtils
    {
        private static readonly HttpClient Client = new HttpClient();

        public static string Get(string url)
        {
            return Client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
