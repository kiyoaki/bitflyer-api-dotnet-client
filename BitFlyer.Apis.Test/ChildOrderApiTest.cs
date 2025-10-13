using System.Collections.Generic;
using Xunit;

namespace BitFlyer.Apis.Test
{
    public class ChildOrderApiTest
    {
        [Fact]
        public void CreateGetChildOrdersQuery_IncludesChildOrderId()
        {
            var query = CreateQuery(childOrderId: "CO123");

            Assert.Equal("CO123", query["child_order_id"]);
        }

        [Fact]
        public void CreateGetChildOrdersQuery_IncludesChildOrderAcceptanceId()
        {
            var query = CreateQuery(childOrderAcceptanceId: "ACCEPT123");

            Assert.Equal("ACCEPT123", query["child_order_acceptance_id"]);
        }

        [Fact]
        public void CreateGetChildOrdersQuery_IncludesParentOrderId()
        {
            var query = CreateQuery(parentOrderId: "PO123");

            Assert.Equal("PO123", query["parent_order_id"]);
        }

        private static Dictionary<string, object> CreateQuery(string childOrderId = null, string childOrderAcceptanceId = null,
            string parentOrderId = null)
        {
            return PrivateApi.CreateGetChildOrdersQuery("BTC_JPY", null, null, null, null, childOrderId,
                childOrderAcceptanceId, parentOrderId);
        }
    }
}
