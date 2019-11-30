using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using NUnitTestProject.Models;

namespace NUnitTestProject
{
    public class DisposeTest
    {
        [Test]
        public void TestAsyncDispose()
        {
            DisposableClass obj = null;
            try
            {
                obj = new DisposableClass();
            }
            finally
            {
                obj?.DisposeAsync();
            }
        }
    }
}
