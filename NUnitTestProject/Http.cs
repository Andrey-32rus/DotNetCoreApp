using System;
using System.Collections.Generic;
using System.Text;
using AuthLib;
using NUnit.Framework;
using UtilsLib;

namespace NUnitTestProject
{
    public class Http
    {
        [Test]
        public void Post()
        {
            CheckTokenRequest req = new CheckTokenRequest
            {
                Token =
                    "Azm43nqYqUqNXnULTCC/OWba4ZSEroNMkCLkpTPjPlTFiNoKaA8GQKIEpmXzeCa/C7I" +
                    "zkXln30qNXye/MiWU+0wE9W/HmIpNmrXg10FFr59H6NO9tnGKRJ2hkVIOWNjh1JCNWHL/vkCMg3vwK" +
                    "kHPmcd4ZUMgxmJOqSultqnV5WAo8Zsp+TEZTITiUVanJz8/OK5AvlhfhUyivjNB9A5i+g==",
            };
            string res = HttpUtils.Post("https://localhost:6001/api/auth/checktoken", req.ToJson());
        }
    }
}
