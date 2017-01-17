using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class PostResult
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        [JsonProperty("child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [JsonProperty("parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
