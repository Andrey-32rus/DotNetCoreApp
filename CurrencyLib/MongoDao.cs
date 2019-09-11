using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoWrapper;

namespace CurrencyLib
{
    public static class MongoDao
    {
        private static readonly MongoWrap Mongo = MongoWrap.FromConfig("MongoConnection");

        public static void ReplaceAllCurrencies(List<CurrencyModel> currencies)
        {
            var coll = Mongo.GetCollection<CurrencyModel>("CurrencyParser", "Currencies");

            List<ReplaceOneModel<CurrencyModel>> replaceModel = new List<ReplaceOneModel<CurrencyModel>>(currencies.Count);
            foreach (var cur in currencies)
            {
                var model = new ReplaceOneModel<CurrencyModel>(Builders<CurrencyModel>.Filter.Eq(x => x.Id, cur.Id), cur);
                model.IsUpsert = true;
                replaceModel.Add(model);
            }

            var res = coll.BulkWrite(replaceModel);
        }

        public static List<CurrencyModel> GetAllCurrencies()
        {
            var coll = Mongo.GetCollection<CurrencyModel>("CurrencyParser", "Currencies");
            return coll.FindSync(FilterDefinition<CurrencyModel>.Empty).ToList();
        }
    }
}
