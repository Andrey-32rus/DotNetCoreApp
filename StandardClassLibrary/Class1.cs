using System;
using System.Collections.Generic;

namespace StandardClassLibrary
{
    public class Class1
    {
        public static void Immutable()
        {
            List<int> a = new List<int>(5) {1, 2, 3, 4, 5};
            var readOnly = a.AsReadOnly();
        }
    }
}
