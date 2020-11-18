using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace WebApplicationNet5.Authorization
{
    public class MyAuthorizationMiddleware
    {
        private readonly RequestDelegate next;
        public MyAuthorizationMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var endpoint = context.GetEndpoint();

            if (endpoint == null)
            {
                // EndpointRoutingMiddleware uses this flag to check if the Authorization middleware processed auth metadata on the endpoint.
                // The Authorization middleware can only make this claim if it observes an actual endpoint.

                //context.Items[AuthorizationMiddlewareInvokedWithEndpointKey] = AuthorizationMiddlewareWithEndpointInvokedValue;

                return;
            }

            // IMPORTANT: Changes to authorization logic should be mirrored in MVC's AuthorizeFilter
            var attr = endpoint?.Metadata.GetOrderedMetadata<MyAuth>().FirstOrDefault();
            if(attr == null)
                return;

            if (attr.Role == "OK")
            {
                await next(context);
                return;
            }

            context.Response.StatusCode = 401;
        }
    }
}
