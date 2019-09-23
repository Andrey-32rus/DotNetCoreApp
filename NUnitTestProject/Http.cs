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
                    "Q0+cqGhDHEKA/3yPavkGKASoYygqB59BiCzjVSU8+WiLj" +
                    "TvjdRZ6S6UdaVaReK6DErkGbfpAmkKZ119s2TvzBoHoIbOX" +
                    "foZKpDxP9ABN1OSYljJxIx/cRrR7DwPHSjbjTxQkVPauN0ikea" +
                    "e8gr3FoVJGC7P8KPBFidBI/RjjIMFEVR1hc9vERac6oHafz7bGXB" +
                    "DQRlySEUCh8HXeBGT0SA==",
            };
            var res = HttpUtils.Post<CheckTokenRequest, UserInfoResponse>("https://localhost:6001/api/auth/checktoken", req);
            Console.WriteLine(res.ResponseBody.ToJson());
        }
    }
}
