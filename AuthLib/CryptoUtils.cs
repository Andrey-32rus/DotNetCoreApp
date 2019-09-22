using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AuthLib
{
    public static class CryptoUtils
    {
        private static readonly SHA512 Sha512 = SHA512.Create();

        public static string GetSha512Base64Encoded(string source)
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
