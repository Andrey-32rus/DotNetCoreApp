using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthLib
{
    [BsonIgnoreExtraElements]
    public class TokenMongo
    {
        [BsonId]
        public ObjectId Id;
        public ObjectId UserId;
        public string AppGuid;

        public string AccessToken;
        public DateTime AccessTokenExpires;
        public string RefreshToken;
        public DateTime RefreshTokenExpires;
    }
}
