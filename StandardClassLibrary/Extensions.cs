using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace StandardClassLibrary
{
    public static class Extensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static ulong ToUnixTimestamp(this DateTime dt)
        {
            return (ulong)(dt.ToUniversalTime() - Epoch).TotalSeconds;
        }

        public static string ToJson<T>(this T src)
        {
            return JsonConvert.SerializeObject(src);
        }

        public static T DeepClone<T>(this T src) where T : class
        {
            return JsonConvert.DeserializeObject<T>(src.ToJson());
        }
    }
}
