using System;
using Microsoft.Extensions.Hosting;

namespace HostLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseConsoleLifetime(options =>
                {
                    options.SuppressStatusMessages = true;
                })
                .Build();

            host.Run();
        }
    }
}
