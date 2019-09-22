using System;
using System.Collections.Generic;
using System.Text;
using MongoWrapper;

namespace AuthLib
{
    internal static class MongoDao
    {
        public static readonly MongoWrap Mongo;

        static MongoDao()
        {
            Mongo = MongoWrap.FromConfig("MongoConnection");
        }
    }
}
