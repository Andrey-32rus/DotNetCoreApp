using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthLib
{
    [BsonIgnoreExtraElements]
    public class TokenMongoPrimaryKey
    {
        public ObjectId UserId;
        public string AppGuid;
    }
}
