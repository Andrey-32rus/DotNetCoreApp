using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AuthLib
{
    [JsonObject]
    public class RefreshRequest
    {
        [JsonProperty(PropertyName = "RT")]
        public string RefreshToken;
    }
}
