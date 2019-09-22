using System;
using System.Collections.Generic;
using System.Text;
using AuthLib;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Crypto
    {
        [Test]
        public void TestSha512()
        {
            string src = "asd12345";
            string hash = CryptoUtils.GetSha512(src);
            Console.WriteLine(hash);
        }
    }
}
