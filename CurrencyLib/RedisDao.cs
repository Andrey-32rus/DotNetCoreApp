﻿using System;
using System.Collections.Generic;
using System.Text;
using RedisWrapper;
using UtilsLib;

namespace CurrencyLib
{
    public static class RedisDao
    {
        private static readonly string channelName = "CurrencyChannel";
        private static RedisWrap redis = new RedisWrap("localhost");

        public static void UpdateCurrencies(List<CurrencyModel> currencies)
        {
            redis.Publish(channelName, currencies.ToJson());
        }
    }
}
