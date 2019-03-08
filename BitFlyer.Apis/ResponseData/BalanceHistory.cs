using System;
using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class BalanceHistory
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "trade_date")]
        public DateTime TradeDate { get; set; }

        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [DataMember(Name = "trade_type")]
        public TradeType TradeType { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "amount")]

        public double Amount { get; set; }

        [DataMember(Name = "quantity")]
        public double Quantity { get; set; }

        [DataMember(Name = "commission")]
        public double Commission { get; set; }

        [DataMember(Name = "balance")]
        public double Balance { get; set; }

        [DataMember(Name = "order_id")]
        public string OrderId { get; set; }
    }
}
