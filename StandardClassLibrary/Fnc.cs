using System;
using System.Collections.Generic;
using System.Text;

namespace StandardClassLibrary
{
    public static class Fnc
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public static ulong ToUnixTimestamp(DateTime dt)
        {
            return (ulong)(dt.ToUniversalTime() - Epoch).TotalSeconds;
        }

        public static DateTime FromUnixTimestamp(ulong timestamp)
        {
            return Epoch.AddSeconds(timestamp);
        }

        public static DateTime FromUnixTimestampToLocal(ulong timestamp)
        {
            return FromUnixTimestamp(timestamp).ToLocalTime();
        }
    }
}
