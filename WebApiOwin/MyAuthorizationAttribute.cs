using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApiOwin
{
    public class MyAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.TryGetValues("Authorization", out var values))
            {
                var header = values.First().Split(' ').ToArray();
                if (header[0] == "Basic")
                {
                    string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes("asd:asd"));
                    if (header[1] == base64)
                        return true;
                }
            }

            return false;
        }
    }
}
