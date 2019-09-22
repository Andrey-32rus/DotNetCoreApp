using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AuthLib
{
    [JsonObject]
    public class AuthRequest
    {
        [JsonProperty(PropertyName = "LN")]
        public string Login;
        [JsonProperty(PropertyName = "PW")]
        public string Password;
        [JsonProperty(PropertyName = "AG")]
        public string AppGuid;
    }
}
