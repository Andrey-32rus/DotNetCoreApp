using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public struct Point
    {
        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
