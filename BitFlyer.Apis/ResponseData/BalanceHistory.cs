using System;
using System.Text.Json.Serialization;

namespace BitFlyer.Apis
{
    public class BalanceHistory
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "trade_date")]
        public DateTime TradeDate { get; set; }

        [JsonPropertyName( "product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName( "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonPropertyName( "trade_type")]
        public TradeType TradeType { get; set; }

        [JsonPropertyName( "price")]
        public double Price { get; set; }

        [JsonPropertyName( "amount")]

        public double Amount { get; set; }

        [JsonPropertyName( "quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName( "commission")]
        public double Commission { get; set; }

        [JsonPropertyName( "balance")]
        public double Balance { get; set; }

        [JsonPropertyName( "order_id")]
        public string OrderId { get; set; }
    }
}

