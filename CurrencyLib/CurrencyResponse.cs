using Newtonsoft.Json;

namespace CurrencyLib
{
    [JsonObject]
    public class CurrencyResponse
    {
        [JsonProperty(PropertyName = "ID")]
        public int Id;
        [JsonProperty(PropertyName = "CC")]
        public string CharCode;
        [JsonProperty(PropertyName = "NM")]
        public string Name;
        [JsonProperty(PropertyName = "BR")]
        public decimal BaseRate;

        //Для дессериализации
        public CurrencyResponse()
        {
        }

        public CurrencyResponse(CurrencyMongo m)
        {
            Id = m.Id;
            CharCode = m.CharCode;
            Name = m.Name;
            BaseRate = m.BaseRate;
        }
    }
}