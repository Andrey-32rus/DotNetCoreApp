using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    public class ProgramService
    {
        private IConfiguration Configuration;
        private IHostEnvironment Host;

        public ProgramService(IConfiguration cfg, IHostEnvironment host)
        {
            Configuration = cfg;
            Host = host;
        }

        public void Main(string[] args)
        {
            string envStr = Host.EnvironmentName;
            Console.WriteLine(envStr);
            Console.WriteLine("Hello World!!!");
        }
    }
}
