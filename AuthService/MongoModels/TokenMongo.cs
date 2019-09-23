using System;
using AuthLib;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthService.MongoModels
{
    [BsonIgnoreExtraElements]
    public class TokenMongo
    {
        [BsonId]
        public TokenMongoPrimaryKey Id;
        public string AccessToken;
        public DateTime AccessTokenExpires;
        public string RefreshToken;
        public DateTime RefreshTokenExpires;
    }
}
