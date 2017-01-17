using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class Deposit
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("status")]
        public DepositStatus Status { get; set; }

        [JsonProperty("event_date")]
        public DateTime EventDate { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
