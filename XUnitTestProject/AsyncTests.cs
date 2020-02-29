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
        private Task SleepAsync(TimeSpan timespan)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(timespan);
            });
        }

        [Fact]
        public async Task TestAsync()
        {
            await SleepAsync(TimeSpan.FromSeconds(5));
        }

        [Fact]
        public async Task AsyncDisposableTest()
        {
            await using (AsyncDisposable obj = new AsyncDisposable())
            {

            }

            await SleepAsync(TimeSpan.FromSeconds(5));
        }
    }
}
