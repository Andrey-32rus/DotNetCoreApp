using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthLib
{
    public static class MongoUsers
    {
        private static readonly IMongoCollection<UserMongo> Coll;

        static MongoUsers()
        {
            Coll = MongoDao.Mongo.GetCollection<UserMongo>("Auth", "Users");
        }

        public static UserMongo FindUserById(string id)
        {
            return Coll.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefault();
        }

        public static UserMongo FindUserByLogin(string login)
        {
            return Coll.Find(x => x.Login == login.ToLower()).FirstOrDefault();
        }

        public static void InsertUser(UserMongo user)
        {
            Coll.InsertOne(user);
        }
    }
}
