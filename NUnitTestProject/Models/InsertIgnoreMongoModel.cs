using System;
using MongoDB.Bson.Serialization.Attributes;

namespace NUnitTestProject.Models
{
    [BsonIgnoreExtraElements]
    public class InsertIgnoreMongoKey
    {
        [BsonElement("UI")]
        public uint UserId;
        public DateTime Dt;
    }

    [BsonIgnoreExtraElements]
    public class InsertIgnoreMongoModel
    {
        [BsonId]
        public InsertIgnoreMongoKey Id;
        [BsonElement("TId")]
        public ulong TransactionId;
        [BsonElement("IU")]
        public bool IsUsed;
    }

    public class InsertIgnoreAggregated
    {
        public uint UserId;
        public DateTime[] Dates;
    }
}