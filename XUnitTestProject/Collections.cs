using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject
{
    public class Collections
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Collections(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Immutable()
        {
            var immutableArray = new int[] {1, 2, 3, 4, 5}.ToImmutableArray();
            testOutputHelper.WriteLine(immutableArray.ToString());
        }

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
