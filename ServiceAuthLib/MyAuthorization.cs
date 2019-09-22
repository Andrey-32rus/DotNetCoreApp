using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoWrapper;

namespace ServiceAuthLib
{
    [BsonIgnoreExtraElements]
    public class Token
    {
        public string AccessToken;
        public DateTime AccessTokenExpires;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MyAuthorization : Attribute, IAuthorizationFilter
    {
        private static readonly IMongoCollection<Token> MongoColl =
            MongoWrap.FromConfig("MongoConnection").GetCollection<Token>("Auth", "Token");

        private static Token FindToken(string accessToken)
        {
            return MongoColl.FindSync(x => x.AccessToken == accessToken).FirstOrDefault();
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
                    var tokenModel = FindToken(token);
                    if (tokenModel != null && DateTime.UtcNow < tokenModel.AccessTokenExpires)
                    {
                        return;
                    }
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
