using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoWrapper;

namespace CurrencyLib
{
    public static class MongoDao
    {
        private static readonly MongoWrap Mongo;

        static MongoDao()
        {
            Mongo = MongoWrap.FromConfig("MongoConnection");
        }

        public static void ReplaceAllCurrencies(List<CurrencyMongo> currencies)
        {
            var coll = Mongo.GetCollection<CurrencyMongo>("CurrencyParser", "Currencies");

            List<ReplaceOneModel<CurrencyMongo>> replaceModel = new List<ReplaceOneModel<CurrencyMongo>>(currencies.Count);
            foreach (var cur in currencies)
            {
                var model = new ReplaceOneModel<CurrencyMongo>(Builders<CurrencyMongo>.Filter.Eq(x => x.Id, cur.Id), cur);
                model.IsUpsert = true;
                replaceModel.Add(model);
            }

            var res = coll.BulkWrite(replaceModel);
        }

        public static List<CurrencyMongo> GetAllCurrencies()
        {
            var coll = Mongo.GetCollection<CurrencyMongo>("CurrencyParser", "Currencies");
            return coll.FindSync(FilterDefinition<CurrencyMongo>.Empty).ToList();
        }

        public static CurrencyMongo GetCurrencyById(int id)
        {
            var coll = Mongo.GetCollection<CurrencyMongo>("CurrencyParser", "Currencies");
            var filter = Builders<CurrencyMongo>.Filter.Eq(x => x.Id, id);
            return coll.FindSync(filter).FirstOrDefault();
        }
    }
}
