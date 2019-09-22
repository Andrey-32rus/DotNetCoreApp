using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AuthLib
{
    public static class CryptoUtils
    {
        private static readonly SHA512 Sha512 = SHA512.Create();

        public static string GetSha512(string source)
        {
            var bytes = Sha512.ComputeHash(Encoding.UTF8.GetBytes(source));

            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
