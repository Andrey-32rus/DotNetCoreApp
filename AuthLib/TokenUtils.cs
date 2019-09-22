using System;
using System.Collections.Generic;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;

namespace AuthLib
{
    public class TokenUtils
    {
        public static string GenerateToken()
        {
            string secret = Guid.NewGuid().ToString();

            string token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .IssuedAt(DateTime.UtcNow)
                .WithSecret(secret)
                //.AddClaim("guid1", Guid.NewGuid().ToString())
                //.AddClaim("guid2", Guid.NewGuid().ToString())
                .Build();

            return token;
        }
    }
}
