using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace HostLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(Startup.ConfigureServices)
                .Build();

            host.Run();
        }
    }
}
