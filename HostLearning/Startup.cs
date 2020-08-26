using System;
using System.Collections.Generic;
using System.Text;
using HostLearning.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostLearning
{
    public static class Startup
    {
        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddHostedService<MainService>();
        }
    }
}
