using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace WebApiOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var app = WebApp.Start<Startup>(@"http://+:5000"))
            {
                Console.WriteLine("WebHost is started");
                Console.ReadLine();
            }
        }
    }
}
