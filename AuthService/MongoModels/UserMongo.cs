using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthService.MongoModels
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
