using System;
using StackExchange.Redis;

namespace RedisWrapper
{
    public class RedisWrap
    {
        private ConnectionMultiplexer redis;

        public RedisWrap(string connection)
        {
            redis = ConnectionMultiplexer.Connect(connection);
        }

        public IDatabase GetDataBase(int db = -1)
        {
            return redis.GetDatabase(db);
        }
    }
}
