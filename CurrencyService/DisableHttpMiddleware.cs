using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CurrencyService
{
    public static class DisableHttpExtensions
    {
        public static IApplicationBuilder UseDisableHttp(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<DisableHttpMiddleware>();
        }
    }

    public class DisableHttpMiddleware
    {
        private readonly RequestDelegate next;

        public DisableHttpMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.IsHttps == false)
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotAcceptable;
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
