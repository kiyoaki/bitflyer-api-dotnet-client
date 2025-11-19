using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class CoinIn
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName( "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonPropertyName( "amount")]
        public double Amount { get; set; }

        [JsonPropertyName( "address")]
        public string Address { get; set; }

        [JsonPropertyName( "tx_hash")]
        public string TransactionHash { get; set; }

        [JsonPropertyName( "status")]
        public DepositStatus Status { get; set; }

        [JsonPropertyName( "event_date")]
        public DateTime EventDate { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

