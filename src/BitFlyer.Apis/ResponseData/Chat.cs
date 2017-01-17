using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class Chat
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
