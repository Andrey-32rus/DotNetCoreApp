using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WebApplicationNet5.Authorization
{
    public static class MyAuthorizationExtensions
    {
        /// <summary>
        /// Adds the <see cref="MyAuthorizationMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables authorization capabilities.
        /// <para>
        /// When authorizing a resource that is routed using endpoint routing, this call must appear between the calls to
        /// <c>app.UseRouting()</c> and <c>app.UseEndpoints(...)</c> for the middleware to function correctly.
        /// </para>
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to <paramref name="app"/> after the operation has completed.</returns>
        public static IApplicationBuilder UseMyAuthorization(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<MyAuthorizationMiddleware>();
        }
    }
}
