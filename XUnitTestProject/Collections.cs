using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class Collections
    {
        private void ListIteration<T>(IReadOnlyCollection<T> list)
        {
            foreach (var elem in list)
            {
                
            }
        }

        [Fact]
        public void ArrayImplementsIList()
        {
            var arr = new string[]
            {
                "a",
                "b",
                "c"
            };

            var list = new List<string>(arr);

            ListIteration(arr);
        }
    }
}
