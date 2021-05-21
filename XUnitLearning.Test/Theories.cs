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
    }
}
