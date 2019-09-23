using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AuthLib
{
    [JsonObject]
    public class UserInfoResponse
    {
        [JsonProperty(PropertyName = "UI")]
        public string UserId;
    }
}
