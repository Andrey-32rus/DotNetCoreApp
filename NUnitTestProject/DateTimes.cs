using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class DateTimes
    {
        [Test]
        public void Datetime()
        {
            var now = DateTimeOffset.Now;
            var utcNow = DateTimeOffset.UtcNow;

            var dt = DateTime.UtcNow;
        }

        [Test]
        public void Substract()
        {
            var dt = DateTimeOffset.Now;

            var local = dt.ToLocalTime();
            var utc = dt.ToUniversalTime();

            var sub = local - utc;
            Assert.AreEqual(sub.TotalMilliseconds, 0d);
        }
    }
}
