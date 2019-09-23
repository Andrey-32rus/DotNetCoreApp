using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AuthLib
{
    [JsonObject]
    public class AuthResponse
    {
        [JsonProperty(PropertyName = "AT")]
        public string AccessToken;
        [JsonProperty(PropertyName = "ET")]
        public ulong ExpireTime;
        [JsonProperty(PropertyName = "RT")]
        public string RefreshToken;
    }
}
