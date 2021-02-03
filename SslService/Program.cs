using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
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
                //webBuilder.ConfigureKestrel(opt =>
                //{
                //    opt.ConfigureHttpsDefaults(https =>
                //    {
                //        var password = new NetworkCredential(string.Empty, "12345").SecurePassword;
                //        password.MakeReadOnly();

                //        //только pfx серт можно из файла достать. Это баг
                //        string certBase64 = File.ReadAllText("./cert");
                //        var certBytes = Convert.FromBase64String(certBase64);
                //        var cert = new X509Certificate2(certBytes);
                //        https.ServerCertificate = cert;
                //    });
                //});
            });
        }
    }
}
