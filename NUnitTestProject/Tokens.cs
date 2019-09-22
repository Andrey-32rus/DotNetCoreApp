using System;
using System.Collections.Generic;
using System.Text;
using AuthLib;
using NUnit.Framework;

namespace NUnitTestProject
{

    public class Tokens
    {
        [Test]
        public void GenerateToken()
        {
            string token = CryptoUtils.GenerateJwt();
            Assert.NotNull(token);
            Console.WriteLine(token);
        }

        [Test]
        public void GuidToken()
        {
            string token = CryptoUtils.GenerateGuidToken(10);
            Console.WriteLine(token);
        }
    }
}
