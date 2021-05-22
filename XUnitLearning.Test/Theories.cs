using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitLearning.Test
{
    public class Theories
    {
        [Theory]
        [InlineData(2, 4)]
        [InlineData(3, 9)]
        public void SquareEquals(int srcValue, int expected)
        {
            int actually = srcValue * srcValue;
            Assert.Equal(expected, actually);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(2, 5)]
        [InlineData(3, 19)]
        public void SquareNotEquals(int srcValue, int expected)
        {
            int actually = srcValue * srcValue;
            Assert.NotEqual(expected, actually);
        }
    }
}
