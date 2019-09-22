using System;
using System.Collections.Generic;
using System.Text;
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

        public static string FindUserId(string login, string password)
        {
            string passwordHash = password;//TODO
            return Coll.Find(x => x.Login == login && x.PasswordHash == passwordHash)
                .Project(x => x.Id.ToString())
                .FirstOrDefault();
        }
    }
}
