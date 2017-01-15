using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public struct PostResult
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        [JsonProperty("child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }
    }
}
