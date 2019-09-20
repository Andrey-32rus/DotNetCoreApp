using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ServiceUtils.Middleware
{
    public static class MyAuthorizationExtensions
    {
        public static IApplicationBuilder UseMyAuthorization(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<MyAuthorizationMiddleware>();
        }
    }

    public class MyAuthorizationMiddleware
    {
        private readonly RequestDelegate next;

        public MyAuthorizationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);
        }
    }
}
