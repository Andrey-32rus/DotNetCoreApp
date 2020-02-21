using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XUnitTestProject
{
    public class AsyncDisposable : IDisposable, IAsyncDisposable
    {
        private bool isDisposed = false;

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.Run(Dispose));
        }

        public void Dispose()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            isDisposed = true;
        }
    }
}
