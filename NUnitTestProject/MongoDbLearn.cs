using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoWrapper;
using NUnit.Framework;
using NUnitTestProject.Models;

namespace NUnitTestProject
{
    public class MongoDbLearn
    {
        [Test]
        public void ForkDocs()
        {
            var wrap = new MongoWrap("mongodb://localhost:27017");
            var col = wrap.GetCollection<RatingAggMongo>("Test", "RatingAgg");
            var all = col.Find(FilterDefinition<RatingAggMongo>.Empty).Limit(2048).ToList();
            foreach (var rt in all)
            {
                rt.Id = ObjectId.Empty;
                rt.user = 5;
            }

            col.InsertMany(all);
        }

        [Test]
        public void Trx()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var col = client.GetDatabase("Test").GetCollection<TransactionsModel>( "Transactions");

            var filter = Builders<TransactionsModel>.Filter.Eq(x => x.Id, ObjectId.Parse("5dc6ecb496709870ec8ffbdf"));
            var lockUpdate = Builders<TransactionsModel>.Update.Set(x => x.TrxLock, ObjectId.GenerateNewId());
            var update = Builders<TransactionsModel>.Update.Inc(x => x.Counter, 1);

            using (var session = client.StartSession())
            {
                session.StartTransaction();
                try
                {
                    col.UpdateOne(session, filter, lockUpdate);
                    Thread.Sleep(6);
                    col.UpdateOne(session, filter, update);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    session.AbortTransaction();
                }
                session.CommitTransaction();
            }
        }
    }
}
