using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Closure
    {
        public int Ariphmetic(int left, int right, Func<int, int, int> fnc)
        {
            return fnc.Invoke(left, right);
        }

        [Test]
        public void ClosureDisAsm()
        {
            int x = 3;
            int result = Ariphmetic(5, 2, (left, right) => left + right + x);
        }
    }
}
