using AuthLib;
using AuthService.MongoModels;
using MongoDB.Driver;

namespace AuthService.DAO
{
    public static class MongoTokens
    {
        private static readonly IMongoCollection<TokenMongo> Coll;

        static MongoTokens()
        {
            Coll = MongoDao.Mongo.GetCollection<TokenMongo>("Auth", "Tokens");
        }

        public static void ReplaceTokenByUserAndAppGuid(TokenMongo token)
        {
            var filter = Builders<TokenMongo>.Filter.And(new[]
            {
                Builders<TokenMongo>.Filter.Eq(x => x.Id, token.Id),
                //Builders<TokenMongo>.Filter.Eq(x => x.AppGuid, token.AppGuid),
            });

            Coll.ReplaceOne(filter, token, new UpdateOptions {IsUpsert = true});
        }

        public static TokenMongo FindByRefreshToken(string refreshToken)
        {
            return Coll.FindSync(x => x.RefreshToken == refreshToken).FirstOrDefault();
        }

        public static TokenMongo FindByAccessToken(string accessToken)
        {
            return Coll.FindSync(x => x.AccessToken == accessToken).FirstOrDefault();
        }
    }
}
