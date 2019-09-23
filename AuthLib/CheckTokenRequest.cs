using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AuthLib
{
    [JsonObject]
    public class CheckTokenRequest
    {
        [JsonProperty(PropertyName = "TT")]
        public string Token;
    }
}
