using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class LinqTests
    {
        [Test]
        public void Order()
        {
            List<int> list = new List<int> {525, 323, 99, 123, 52};
            list.Sort((left, right) =>
            {
                if (left > right)
                    return 1;
                if (left < right)
                    return -1;

                return 0;
            });
            var ordered = list.OrderByDescending(x => x);
        }
    }
}
