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

        [Test]
        public void FromHexToBase64()
        {
            string src = "asd12345";
            string sha512HexString = "ef2c7b78cc9cacfb1826" +
                                     "2d2ed698cdcca598d413946" +
                                     "ed0d743285d889c87ad29ecbf3f9" +
                                     "de43338dd1c06d33dfbb43a4bc95aa" +
                                     "c2301e63a426bdd3e2a582f2da7";
            int hexLength = sha512HexString.Length;

            string sha512Base64 = CryptoUtils.GetSha512Base64Encoded(src);
            int base64Length = sha512Base64.Length;

            string toBase64 = CryptoUtils.HexStringToBase64(sha512HexString);
            Assert.AreEqual(sha512Base64, toBase64);
        }
    }
}
