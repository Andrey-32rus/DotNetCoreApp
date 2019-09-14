using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CurrencyLib
{
    [BsonIgnoreExtraElements]
    public class CurrencyMongo
    {
        [BsonId]
        [JsonProperty(PropertyName = "NumCode")]
        public int Id;
        public string CharCode;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Nominal;
        public string Name;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Value;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Previous;
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal BaseRate;
    }
}
