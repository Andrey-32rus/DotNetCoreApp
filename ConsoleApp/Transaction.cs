using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    internal sealed class Transaction : IDisposable
    {
        private readonly ReaderWriterLockSlim rw = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private DateTime m_timeOfLastTrans;

        public void PerformTransaction()
        {
            rw.EnterWriteLock();
            // Этот код имеет монопольный доступ к данным...
            m_timeOfLastTrans = DateTime.Now;
            rw.ExitWriteLock();
        }
        public DateTime LastTransaction
        {
            get
            {
                rw.EnterReadLock();
                // Этот код имеет совместный доступ к данным...
                DateTime temp = m_timeOfLastTrans;
                rw.ExitReadLock();
                return temp;
            }
        }

        public void Dispose()
        {
            rw?.Dispose();
        }
    }
}
