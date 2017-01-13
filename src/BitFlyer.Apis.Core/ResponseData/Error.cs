using Newtonsoft.Json;

namespace BitFlyer.Apis.Core.ResponseData
{
    public class Error
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
