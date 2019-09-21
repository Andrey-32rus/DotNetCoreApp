using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace CurrencyService.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MyAuthorization : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isHeaderPresent =
                context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues headerValues);

            if (isHeaderPresent == true && headerValues.Count == 1)
            {
                var headerVal = headerValues[0].Split(' ');
                if (headerVal.Length == 2 && headerVal[0] == "Bearer")
                {
                    string token = headerVal[1];
                    if (token == "token")
                    {
                        return;
                    }
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
