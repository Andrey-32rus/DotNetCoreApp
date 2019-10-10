using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class TPL
    {
        [Test]
        public void ParallelTest()
        {
            List<int> list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var res = Parallel.ForEach(list, new ParallelOptions() {MaxDegreeOfParallelism = 3},
                param =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"DT: {DateTime.Now}; param: {param}");
                });
        }
    }
}
