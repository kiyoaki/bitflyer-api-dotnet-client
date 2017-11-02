using Newtonsoft.Json;
using System;

namespace BitFlyer.Apis
{
    public class CollateralHistory
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("change")]
        public double Change { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("reason_code")]
        public CollateralReasonCode ResonCode { get; set; }

        [JsonProperty("date")]
        public DateTime date { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
