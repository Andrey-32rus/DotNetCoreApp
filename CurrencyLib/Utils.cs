using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyLib
{
    public static class Utils
    {
        public static void WriteCurrenciesToConsole(List<CurrencyResponse> currencies)
        {
            Console.Clear();
            foreach (var cur in currencies)
            {
                Console.WriteLine($"{cur.Id} {cur.CharCode} {cur.Name} {cur.BaseRate}");
            }
        }
    }
}
