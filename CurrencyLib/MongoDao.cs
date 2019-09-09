using System;
using MongoWrapper;

namespace CurrencyLib
{
    public static class MongoDao
    {
        private static readonly MongoWrap Mongo = MongoWrap.FromConfig("MongoConnection");

    }
}
