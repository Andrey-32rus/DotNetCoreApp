using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public void Trx(MongoClient client)
        {
            var col = client.GetDatabase("Test").GetCollection<TransactionsModel>("Transactions");

            var filter = Builders<TransactionsModel>.Filter.Eq(x => x.Id, ObjectId.Parse("5dc6ecb496709870ec8ffbdf"));
            var lockUpdate = Builders<TransactionsModel>.Update.Set(x => x.TrxLock, ObjectId.GenerateNewId());
            var update = Builders<TransactionsModel>.Update.Inc(x => x.Counter, 1);
            
            using (var session = client.StartSession())
            {
                session.WithTransaction((ses, token) =>
                {
                    try
                    {
                        col.UpdateOne(ses, filter, lockUpdate);
                        col.UpdateOne(ses, filter, update);
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                });
                //session.StartTransaction();
                //try
                //{
                //    col.UpdateOne(session, filter, lockUpdate);
                //    //Thread.Sleep(5);
                //    col.UpdateOne(session, filter, update);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //    session.AbortTransaction();
                //    throw;
                //}
                //session.CommitTransaction();
            }
        }

        [Test]
        public void TrxTest()
        {
            var connSettings = new MongoClientSettings
            {
                ConnectionMode = ConnectionMode.ReplicaSet,
                ReadPreference = ReadPreference.Primary,
                ReplicaSetName = "rs0",
                Servers = new MongoServerAddress[]
                {
                    new MongoServerAddress("localhost", 27017), 
                }
            };
            
            //var client = new MongoClient("mongodb://localhost:27017");
            var client = new MongoClient(connSettings);
            Task.Run(() => Trx(client));
            Thread.Sleep(1000);
            Task.Run(() => Trx(client));

            Thread.Sleep(5000);
        }
    }
}
