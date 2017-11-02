using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class TradingCommission
    {
        [JsonProperty("commission_rate")]
        public double CommissionRate { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
