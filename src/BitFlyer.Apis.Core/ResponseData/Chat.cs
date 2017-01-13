using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis.Core.ResponseData
{
    public struct Chat
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
