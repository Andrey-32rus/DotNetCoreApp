using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace UtilsLib
{
    public static class CryptoUtils
    {
        private static readonly SHA512 Sha512 = SHA512.Create();

        public static string GetSha512Base64Encoded(string source)
        {
            var bytes = Sha512.ComputeHash(Encoding.UTF8.GetBytes(source));
            return Convert.ToBase64String(bytes);
        }
    }
}
