using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CoreClassLibrary
{
    public static class Extensions
    {
        public static void Immutable()
        {
            List<int> a = new List<int>(5) { 1, 2, 3, 4, 5 };
            var readOnly = a.AsReadOnly();
        }
    }
}
