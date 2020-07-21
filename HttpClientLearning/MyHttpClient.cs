using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientLearning
{
    public class MyHttpClient
    {
        private HttpClient client;
        public MyHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<string>> Req(int count)
        {
            List<string> contents = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                var task = client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
                var respMessage = await task;
                string content = await respMessage.Content.ReadAsStringAsync();
                contents.Add(content);
            }

            return contents;
        }
    }
}
