using System;
using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class CoinOut
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "order_id")]
        public string OrderId { get; set; }

        [DataMember(Name = "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "tx_hash")]
        public string TransactionHash { get; set; }

        [DataMember(Name = "additional_fee")]
        public double AdditionalFee { get; set; }

        [DataMember(Name = "status")]
        public DepositStatus Status { get; set; }

        [DataMember(Name = "event_date")]
        public DateTime EventDate { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }

    }
}
