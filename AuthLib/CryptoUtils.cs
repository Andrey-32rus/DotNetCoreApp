using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using JWT.Algorithms;
using JWT.Builder;

namespace AuthLib
{
    public static class CryptoUtils
    {
        private static readonly SHA512 Sha512 = SHA512.Create();
        private static readonly IJwtAlgorithm Algorithm = new HMACSHA512Algorithm();
        private static readonly RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();

        public static string GenerateJwt()
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

        public static string GetSha512(string source)
        {
            var bytes = Sha512.ComputeHash(Encoding.UTF8.GetBytes(source));
            return Convert.ToBase64String(bytes);
        }

        public static string GenerateGuidToken(int countOfGuids = 1)
        {
            List<byte> bytes = new List<byte>(16 * countOfGuids);
            for (int i = 0; i < countOfGuids; i++)
            {
                var guid = Guid.NewGuid().ToByteArray();
                bytes.AddRange(guid);
            }

            return Convert.ToBase64String(bytes.ToArray());
        }
    }
}
