using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthLib
{
    [BsonIgnoreExtraElements]
    public class UserMongo
    {
        [BsonId]
        public ObjectId Id;
        public string Login;
        public string PasswordHash;
    }
}
