using System;
using MongoDB.Driver;
using UtilsLib;

namespace MongoWrapper
{
    public class MongoWrap
    {
        private readonly MongoClient client;

        public static MongoWrap FromConfig(string connectionName)
        {
            return new MongoWrap(AppConfig.GetConnectionString(connectionName));
        }

        public MongoWrap(string connectionString)
        {
            client = new MongoClient(connectionString);
        }

        public IMongoCollection<T> GetCollection<T>(string dbName, string collectionName)
        {
            return client.GetDatabase(dbName).GetCollection<T>(collectionName);
        }
    }
}
