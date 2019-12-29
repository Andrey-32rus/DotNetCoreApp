using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NUnitTestProject.Models
{
    [BsonIgnoreExtraElements]
    public class DateMongo
    {
        [BsonId]
        public ObjectId Id;
        public DateTime Dt;
    }
}
