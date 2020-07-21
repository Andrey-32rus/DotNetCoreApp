using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpClientLearning
{
    class Program
    {
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<MyHttpClient>().SetHandlerLifetime(TimeSpan.FromSeconds(1));
        }
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices).Build();

            var client = host.Services.GetRequiredService<MyHttpClient>();
            var res = await client.Req(100);
        }
    }
}
