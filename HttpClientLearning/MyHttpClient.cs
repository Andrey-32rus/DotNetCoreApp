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

        public void Req(int count)
        {
            List<Task> tasks = new List<Task>(count);
            for (int i = 0; i < count; i++)
            {
                var task = client.GetAsync("https://vk.com");
                tasks.Add(task);
            }

            var resTask = Task.WhenAll(tasks);
            resTask.Wait();
        }
    }
}
