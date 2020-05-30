using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Discord.Bot
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
        [JsonProperty("restUri")]
        public string RestUri { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("webSocketUri")]
        public string WebSocketUri { get; set; }
    }
}
