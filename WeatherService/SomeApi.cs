using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherService
{
    public interface ISomeApiClient
    {
        Task<string> GetSomethingAsync(string query);
    }

    public class SomeApiClient : ISomeApiClient
    {
        private readonly HttpClient _client;

        public SomeApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetSomethingAsync(string query)
        {
            var response = await _client.GetAsync($"?querystring={query}");
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsStringAsync();
                return model;
            }

            return string.Empty;
        }
    }
}
