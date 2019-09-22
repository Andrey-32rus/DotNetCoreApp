using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;

namespace AuthLib
{
    public static class TokenUtils
    {
        private static readonly IJwtAlgorithm Algorithm = new HMACSHA512Algorithm();
        private static readonly RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();

        public static string GenerateToken()
        {
            byte[] key = new byte[512];
            Rng.GetNonZeroBytes(key);

            string token = new JwtBuilder()
                .WithAlgorithm(Algorithm)
                .IssuedAt(DateTime.UtcNow)
                .WithSecret(key)
                .Build();

            return token;
        }
    }
}
