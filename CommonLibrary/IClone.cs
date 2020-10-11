using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IClone<out T> where T : class
    {
        T GetClone();
    }

    public class Cloneable : IClone<Cloneable>
    {
        private int field;

        public Cloneable(int field)
        {
            this.field = field;
        }

        public Cloneable(Cloneable clone)
        {
            this.field = clone.field;
        }

        public Cloneable GetClone()
        {
            return new Cloneable(this);
        }
    }
}
