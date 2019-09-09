using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CurrencyLib
{
    public class CurrencyMongo
    {
        [BsonId]
        public ObjectId Id;
    }
}
