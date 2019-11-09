using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NUnitTestProject.Models
{
    [BsonIgnoreExtraElements]
    public class TransactionsModel
    {
        [BsonId]
        public ObjectId Id;
        public int Counter;
        public ObjectId TrxLock;
    }
}
