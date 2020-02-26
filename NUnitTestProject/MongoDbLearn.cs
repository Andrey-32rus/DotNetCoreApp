using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private MongoWrap wrap;

        public MongoDbLearn()
        {
            wrap = new MongoWrap("mongodb://localhost:27017");
        }

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
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var col = client.GetDatabase("Test").GetCollection<TransactionsModel>("Transactions");

            var filter = Builders<TransactionsModel>.Filter.Eq(x => x.Id, ObjectId.Parse("5dc6ecb496709870ec8ffbdf"));
            var lockUpdate = Builders<TransactionsModel>.Update.Set(x => x.TrxLock, ObjectId.GenerateNewId());
            var update = Builders<TransactionsModel>.Update.Inc(x => x.Counter, 1);
            
            using (var session = client.StartSession())
            {
                Stopwatch trx = new Stopwatch();
                trx.Start();
                session.WithTransaction((ses, token) =>
                {
                    try
                    {
                        var obj = col.FindOneAndUpdate(ses, filter, lockUpdate);
                        col.UpdateOne(ses, filter, update);
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                });
                trx.Stop();
                Console.WriteLine($"TRX: {trx.ElapsedMilliseconds}ms");
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
            timer.Stop();
            Console.WriteLine($"TIMER: {timer.ElapsedMilliseconds}ms");
        }

        [Test]
        public void TrxTest()
        {
            //var connSettings = new MongoClientSettings
            //{
            //    ConnectionMode = ConnectionMode.ReplicaSet,
            //    ReadPreference = ReadPreference.Primary,
            //    ReplicaSetName = "rs0",
            //    Servers = new MongoServerAddress[]
            //    {
            //        new MongoServerAddress("localhost", 27017), 
            //    }
            //};
            //var client = new MongoClient(connSettings);
            var client = new MongoClient("mongodb://localhost:27017/?replicaSet=rs0&readPreference=primary");

            Task.Run(() => Trx(client));
            //Thread.Sleep(1000);
            Task.Run(() => Trx(client));

            Thread.Sleep(5000);
        }

        [Test]
        public void Sum()
        {
            var col = wrap.GetCollection<RatingAggMongo>("Test", "RatingAgg");

            var match = new BsonDocument
            {
                {
                    "$match",
                    new BsonDocument
                    {
                        {"user", 5}
                    }
                }
            };
            var group = new BsonDocument
            {
                {
                    "$group",
                    new BsonDocument
                    {
                        {"_id", "null"},
                        {
                            "total", new BsonDocument
                            {
                                {"$sum", "$Rating"}
                            }
                        }
                    }
                }
            };


            var definition = PipelineDefinition<RatingAggMongo, BsonDocument>.Create(match, group);
            var doc = col.Aggregate(definition).Single();

            long total = doc["total"].AsInt64;

            Assert.AreNotEqual(total, 0L);
        }

        [Test]
        public void Date()
        {
            var col = wrap.GetCollection<DateMongo>("Test", "DateColl");
            DateTime dt = DateTime.Now;
            DateMongo obj = new DateMongo {Dt = dt};
            col.InsertOne(obj);
        }

        [Test]
        public void InsertIgnore()
        {
            var col = wrap.GetCollection<InsertIgnoreMongoModel>("Test", "IsertIgnore");
            int countOfDays = 500000;
            var now = DateTime.UtcNow.Date.AddDays((double)-countOfDays);
            List<InsertIgnoreMongoModel> list = new List<InsertIgnoreMongoModel>(countOfDays);


            for (int i = 0; i < countOfDays; i++)
            {
                var dt = now.AddDays(i);
                InsertIgnoreMongoModel doc = new InsertIgnoreMongoModel
                {
                    Id = new InsertIgnoreMongoKey
                    {
                        UserId = Convert.ToUInt32(i),
                        Dt = dt,
                    },
                    TransactionId = Convert.ToUInt64(i),
                    IsUsed = false,
                };

                list.Add(doc);
            }

            try
            {
                col.InsertMany(list, new InsertManyOptions { IsOrdered = false });
            }
            catch (MongoBulkWriteException<InsertIgnoreMongoModel>)
            {
                //Console.WriteLine(e);
            }

        }

        [Test]
        public void Group()
        {
            var col = wrap.GetCollection<InsertIgnoreMongoModel>("Test", "IsertIgnore");
            var filter = Builders<InsertIgnoreMongoModel>.Filter.And(
                Builders<InsertIgnoreMongoModel>.Filter.Eq(x => x.IsUsed, false),
                Builders<InsertIgnoreMongoModel>.Filter.Gte(x => x.Id.Dt, new DateTime(2005,2,26,03,00,00))
            );
            var array = col.Find(filter).ToList();
            var res = array.GroupBy(x => x.Id.UserId,
                (key, enumerable) => new InsertIgnoreAggregated
                    {UserId = key, Dates = enumerable.Select(x => x.Id.Dt).ToArray()}).ToArray();
        }
    }
}
