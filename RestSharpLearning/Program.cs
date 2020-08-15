using System;
using RestSharp;

namespace RestSharpLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient();
            var request = new RestRequest("https://www.cbr-xml-daily.ru/daily_json.js");
            var response = client.Get(request);
            string content = response.Content;
            Console.WriteLine(content);
        }
    }
}
