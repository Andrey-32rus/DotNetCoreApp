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
    }
}
