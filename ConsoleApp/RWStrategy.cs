using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RwStrategy : IDisposable, IAsyncDisposable
    {
        private readonly ReaderWriterLockSlim rw = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        public void SurroundReadLock(Action action)
        {
            rw.EnterReadLock();
            try
            {
                action.Invoke();
            }
            finally
            {
                rw.ExitReadLock();
            }
        }

        public void SurroundWriteLock(Action action)
        {
            rw.EnterWriteLock();
            try
            {
                action.Invoke();
            }
            finally
            {
                rw.ExitWriteLock();
            }
        }

        public void Dispose()
        {
            rw?.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.Run(Dispose));
        }
    }
}
