using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject.Models
{
    [Serializable]
    public class RefModel
    {
        public int Int1;
        public long Long1;
        public double Double1;
        public decimal Decimal1;

        public int Int2;
        public long Long2;
        public double Double2;
        public decimal Decimal2;
    }

    [Serializable]
    public struct ValueModel
    {
        public int Int1;
        public long Long1;
        public double Double1;
        public decimal Decimal1;

        public int Int2;
        public long Long2;
        public double Double2;
        public decimal Decimal2;
    }
}
