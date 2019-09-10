using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CurrencyLib
{
    [BsonIgnoreExtraElements]
    public class CurrencyModel
    {
        [BsonId]
        [JsonProperty(PropertyName = "ID")]
        public string Id;
        public int NumCode;
        public string CharCode;
        public decimal Nominal;
        public string Name;
        public decimal Value;
        public decimal Previous;
    }
}
