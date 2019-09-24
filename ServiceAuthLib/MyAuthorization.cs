using System;
using System.Net;
using System.Threading.Tasks;
using AuthLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson.Serialization.Attributes;
using UtilsLib;

namespace ServiceAuthLib
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MyAuthorization : Attribute, IAuthorizationFilter
    {
        public static UserInfoResponse GetUserInfo(HttpContext httpContext)
        {
            return (UserInfoResponse) httpContext.Items["UserInfo"];
        }

        private static UserInfoResponse CheckToken(string accessToken)
        {
            CheckTokenRequest req = new CheckTokenRequest {Token = accessToken};
            var res = HttpUtils.Post<CheckTokenRequest, UserInfoResponse>("https://localhost:6001/api/auth/checktoken", req);
            if (res.HttpResponseMessage.StatusCode == HttpStatusCode.OK && res.ResponseBody != null)
            {
                return res.ResponseBody;
            }

            return null;
        }

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
                    var userInfo = CheckToken(token);
                    if (userInfo != null)
                    {
                        context.HttpContext.Items.Add("UserInfo", userInfo);
                        return;
                    }
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
