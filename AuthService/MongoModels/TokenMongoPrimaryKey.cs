using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthService.MongoModels
{
    [BsonIgnoreExtraElements]
    public class TokenMongoPrimaryKey
    {
        public ObjectId UserId;
        public string AppGuid;
    }
}
