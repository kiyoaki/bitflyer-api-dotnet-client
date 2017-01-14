using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public struct PostResult
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        [JsonProperty("child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonIgnore]
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}
