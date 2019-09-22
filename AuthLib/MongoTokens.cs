using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace AuthLib
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
    }
}
