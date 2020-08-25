using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace HostLearning
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseConsoleLifetime(options =>
                {
                    options.SuppressStatusMessages = true;
                })
                .Build();

            await host.RunAsync().ConfigureAwait(false);
        }
    }
}
