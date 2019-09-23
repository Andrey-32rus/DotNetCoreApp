using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using UtilsLib;

namespace NUnitTestProject
{
    public class Crypto
    {
        [Test]
        public void TestSha512()
        {
            string src = "asd12345";
            string hash = CryptoUtils.GetSha512Base64Encoded(src);
            Console.WriteLine(hash);
        }
    }
}
