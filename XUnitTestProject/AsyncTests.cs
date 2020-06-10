using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.Models;

namespace XUnitTestProject
{
    public class AsyncTests
    {
        [Fact]
        public void TestMethod()
        {
            TestAsync().Wait();
        }

        [Fact]
        public async Task TestAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

        [Fact]
        public async Task AsyncDisposableTest()
        {
            await using (AsyncDisposable obj = new AsyncDisposable())
            {

            }

            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}
