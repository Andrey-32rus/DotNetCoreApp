using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApplicationNet5.Authorization;
using WebApplicationNet5.Healthchecks;

namespace WebApplicationNet5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks().AddCheck<SimpleHealthCheck>("Simple");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseMyAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                var hcOptions = new HealthCheckOptions
                {
                    ResponseWriter = (httpCtx, hcReport) => Task.CompletedTask,

                    AllowCachingResponses = false,
                    ResultStatusCodes = new Dictionary<HealthStatus, int>
                    {
                        {HealthStatus.Healthy, 200},
                        {HealthStatus.Degraded, 429},
                        {HealthStatus.Unhealthy, 500},
                    }
                };
                endpoints.MapHealthChecks("/hc", hcOptions);
            });
        }
    }
}
