using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;

namespace XUnitTestProject
{
    public class DictionarySpeed
    {
        private int countOfGetIterations = (int)Math.Pow(10, 6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DictGetCicle<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key)
        {
            for (int i = 0; i < countOfGetIterations; i++)
            {
                var val = dict[key];
            }
        }

        [Fact]
        public void ValueKey()
        {
            Dictionary<(int key1, int key2), string> dict = new Dictionary<(int key1, int key2), string>();
            var key = (1, 1);
            dict.Add(key, "value");

            DictGetCicle(dict, key);
        }

        [Fact]
        public void RefKey()
        {
            Dictionary<Tuple<int, int>, string> dict = new Dictionary<Tuple<int, int>, string>();
            var key = new Tuple<int, int>(1, 1);
            dict.Add(key, "value");

            DictGetCicle(dict, key);
        }
    }
}
