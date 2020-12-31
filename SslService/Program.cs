using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Https;

namespace SslService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(opt =>
                {
                    opt.Listen(IPAddress.Loopback, 5000);
                    opt.Listen(IPAddress.Loopback, 5001, listOpt =>
                    {
                        var cert = X509Certificate2.CreateFromEncryptedPemFile(@"D:\ssl\cert.crt", "asd12345",
                            @"D:\ssl\key.key");
                        listOpt.UseHttps(cert);
                    });
                    //opt.ConfigureEndpointDefaults(listenOptions =>
                    //{
                    //    listenOptions.UseHttps();
                    //});
                    //opt.ConfigureHttpsDefaults(https =>
                    //{
                    //    var cert = X509Certificate2.CreateFromEncryptedPemFile(@"D:\ssl\cert.crt", "asd12345",
                    //        @"D:\ssl\key.key");
                    //    https.ServerCertificate = cert;
                    //});
                });
            });
        }
           
    }
}
