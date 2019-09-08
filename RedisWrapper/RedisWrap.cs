using System;
using StackExchange.Redis;

namespace RedisWrapper
{
    public class RedisWrap : IDisposable
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

        public void Subscribe(string channelName, Action<RedisChannel, RedisValue> messageHandler)
        {
            redis.GetSubscriber().Subscribe(channelName, messageHandler);
        }

        public void Unsubscribe(string channelName)
        {
            redis.GetSubscriber().Unsubscribe(channelName);
        }

        public long Publish(string channelName, string message)
        {
            return redis.GetSubscriber().Publish(channelName, message);
        }

        public void Dispose()
        {
            redis?.Dispose();
        }
    }
}
