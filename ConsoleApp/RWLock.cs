using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    class RWLock : IDisposable
    {
        public struct WriteLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim rw;
            public WriteLockToken(ReaderWriterLockSlim rw)
            {
                this.rw = rw;
                rw.EnterWriteLock();
            }
            public void Dispose()
            {
                rw.ExitWriteLock();
            }
        }

        public struct ReadLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim rw;
            public ReadLockToken(ReaderWriterLockSlim rw)
            {
                this.rw = rw;
                rw.EnterReadLock();
            }
            public void Dispose()
            {
                rw.ExitReadLock();
            }
        }

        private readonly ReaderWriterLockSlim rw = new ReaderWriterLockSlim();

        public ReadLockToken ReadLock()
        {
            return new ReadLockToken(rw);
        }

        public WriteLockToken WriteLock()
        {
            return new WriteLockToken(rw);
        }

        public void Dispose()
        {
            rw.Dispose();
        }
    }
}
