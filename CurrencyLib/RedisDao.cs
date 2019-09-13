using System;
using System.Collections.Generic;
using System.Text;
using RedisWrapper;
using StackExchange.Redis;
using UtilsLib;

namespace CurrencyLib
{
    public static class RedisDao
    {
        private static readonly string channelName = "CurrencyChannel";
        private static RedisWrap redis = new RedisWrap(AppConfig.GetConnectionString("RedisConnection"));

        public static void UpdateCurrencies(List<CurrencyModel> currencies)
        {
            redis.Publish(channelName, currencies.ToJson());
        }

        public static void SubscribeService(Action<RedisChannel, RedisValue> handler)
        {
            redis.Subscribe(channelName, handler);
        }
    }
}
