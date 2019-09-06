using System;
using Newtonsoft.Json.Linq;

namespace UtilsLib
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

        public static string JsonPath(string json, string jsonPath)
        {
            var js = JObject.Parse(json);
            return js.SelectToken(jsonPath).ToString();
        }
    }
}
