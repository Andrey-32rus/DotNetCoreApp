using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ServiceUtils.Middleware;

namespace WeatherService
{
    public static class MaxContentLengthExtensions
    {
        public static IApplicationBuilder UseMaxContentLength(this IApplicationBuilder app, long maxContentLength, int statusCode, string text)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<MaxContentLengthMiddleware>(maxContentLength, statusCode, text);
        }
    }

    public class MaxContentLengthMiddleware
    {
        private readonly RequestDelegate next;
        private readonly long maxContentLength;
        private readonly int statusCode;
        private readonly string text;

        public MaxContentLengthMiddleware(RequestDelegate next, long maxContentLength, int statusCode, string text)
        {
            this.next = next;
            this.maxContentLength = maxContentLength;
            this.statusCode = statusCode;
            this.text = text;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var contentLength = context.Request.ContentLength;
            bool hasValue = contentLength.HasValue;

            if (hasValue == false)
            {
                await next(context);
            }
            else
            {
                long length = contentLength.Value;
                if (length <= maxContentLength)
                {
                    await next(context);
                }
                else
                {
                    //context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(text);
                }
            }
        }
    }
}
