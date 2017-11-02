using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BitFlyer.Apis.Test
{
    public class PrivateApiTest
    {
        private readonly PrivateApi apiClient;
        private readonly int buyPrice;
        private readonly int sellPrice;

        public PrivateApiTest()
        {
            var apiKey = Environment.GetEnvironmentVariable("BITFLYER_API_KEY");
            var apiSecret = Environment.GetEnvironmentVariable("BITFLYER_API_SECRET");
            if (apiKey == null || apiSecret == null)
            {
                throw new Exception("BITFLYER_API_KEY or BITFLYER_API_SECRET is null.");
            }

            apiClient = new PrivateApi(apiKey, apiSecret);

            var ticker = PublicApi.GetTicker(ProductCode.FxBtcJpy).Result;
            var latestPrice = ticker.LatestPrice;
            buyPrice = (int)(latestPrice * 0.96);
            sellPrice = (int)(latestPrice * 1.04);
        }

        [Fact]
        public async Task ApiKeyNotFound()
        {
            var apiClient = new PrivateApi("xxxxxxxxxxx", "xxxxxxxxxxx");
            try
            {
                await apiClient.GetPermissions();
            }
            catch (BitFlyerApiException ex)
            {
                Assert.Equal(ex.ErrorResponse.Status, -500);
                Assert.Equal("Key not found", ex.ErrorResponse.ErrorMessage);
            }
        }

        [Fact]
        public async Task GetPermissions()
        {
            var res1 = await apiClient.GetPermissions();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetBalance()
        {
            var res1 = await apiClient.GetBalance();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetCollateral()
        {
            var res1 = await apiClient.GetCollateral();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetAddresses()
        {
            var res1 = await apiClient.GetAddresses();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetCoinIns()
        {
            var res1 = await apiClient.GetCoinIns();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetCoinOuts()
        {
            var res1 = await apiClient.GetCoinOuts();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetBankAccounts()
        {
            var res1 = await apiClient.GetBankAccounts();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetDeposits()
        {
            var res1 = await apiClient.GetDeposits();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetWithdrawals()
        {
            var res1 = await apiClient.GetWithdrawals();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task ChildOrder()
        {
            await apiClient.CancelAllOrders(new CancelAllOrdersParameter
            {
                ProductCode = ProductCode.FxBtcJpy
            });

            var res1 = await apiClient.SendChildOrder(new SendChildOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ChildOrderType = ChildOrderType.Limit,
                Side = Side.Buy,
                Price = buyPrice,
                Size = 0.01,
                MinuteToExpire = 10000,
                TimeInForce = TimeInForce.GoodTilCanceled
            });
            var childOrderAcceptanceId = res1?.ChildOrderAcceptanceId;
            Assert.NotNull(childOrderAcceptanceId);

            var health = await PublicApi.GetHealth();
            Util.ThreadSleep(health.Status);

            var res2 = await apiClient.GetChildOrders(ProductCode.FxBtcJpy);
            Assert.Contains(res2, x => x.ProductCode == ProductCode.FxBtcJpy
                                        && x.ChildOrderState == ChildOrderState.Active);

            await apiClient.CancelChildOrder(new CancelChildOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ChildOrderAcceptanceId = childOrderAcceptanceId
            });

            await Task.WhenAll(Enumerable.Range(0, 3).Select(_ => apiClient.SendChildOrder(new SendChildOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ChildOrderType = ChildOrderType.Limit,
                Side = Side.Buy,
                Price = buyPrice,
                Size = 0.01,
                MinuteToExpire = 10000,
                TimeInForce = TimeInForce.GoodTilCanceled
            })));

            Util.ThreadSleep(health.Status);

            await apiClient.CancelAllOrders(new CancelAllOrdersParameter
            {
                ProductCode = ProductCode.FxBtcJpy
            });

            Util.ThreadSleep(health.Status);

            var res3 = await apiClient.GetChildOrders(ProductCode.FxBtcJpy);
            Assert.True(res3.Count(x => x.ProductCode == ProductCode.FxBtcJpy
                                          && x.ChildOrderState == ChildOrderState.Active) == 0);
        }

        [Fact]
        public async Task ParentOrder()
        {
            await apiClient.CancelAllOrders(new CancelAllOrdersParameter
            {
                ProductCode = ProductCode.FxBtcJpy
            });

            var parameter = new SendParentOrderParameter
            {
                OrderMethod = OrderMethod.IfDone,
                MinuteToExpire = 10000,
                TimeInForce = TimeInForce.GoodTilCanceled,
                Parameters = new[]
                {
                    new ParentOrderDetailParameter
                    {
                        ProductCode = ProductCode.FxBtcJpy,
                        ConditionType = ConditionType.Limit,
                        Side = Side.Buy,
                        Price = buyPrice,
                        Size = 0.01
                    },
                    new ParentOrderDetailParameter
                    {
                        ProductCode = ProductCode.FxBtcJpy,
                        ConditionType = ConditionType.Stop,
                        Side = Side.Sell,
                        TriggerPrice = sellPrice,
                        Size = 0.01
                    }
                }
            };

            var res1 = await apiClient.SendParentOrder(parameter);
            var parentOrderAcceptanceId = res1?.ParentOrderAcceptanceId;
            Assert.NotNull(parentOrderAcceptanceId);

            var health = await PublicApi.GetHealth();
            Util.ThreadSleep(health.Status);

            var trail = new SendParentOrderParameter
            {
                Parameters = new[]
                {
                    new ParentOrderDetailParameter
                    {
                        ProductCode = ProductCode.FxBtcJpy,
                        ConditionType = ConditionType.Trail,
                        Side = Side.Buy,
                        Offset = 10000,
                        Size = 0.01
                    }
                }
            };

            var resTrail = await apiClient.SendParentOrder(trail);
            var trailParentOrderAcceptanceId = resTrail?.ParentOrderAcceptanceId;
            Assert.NotNull(trailParentOrderAcceptanceId);

            Util.ThreadSleep(health.Status);

            var resAll = await apiClient.GetParentOrders(ProductCode.FxBtcJpy, 10);
            Assert.NotNull(resAll);

            Util.ThreadSleep(health.Status);

            var res2 = await apiClient.GetParentOrder(ProductCode.FxBtcJpy, parentOrderAcceptanceId: parentOrderAcceptanceId);
            Assert.NotNull(res2);

            await apiClient.CancelParentOrder(new CancelParentOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ParentOrderAcceptanceId = parentOrderAcceptanceId
            });

            Util.ThreadSleep(health.Status);

            var resTrail2 = await apiClient.GetParentOrder(ProductCode.FxBtcJpy, parentOrderAcceptanceId: trailParentOrderAcceptanceId);
            Assert.NotNull(resTrail2);

            await apiClient.CancelParentOrder(new CancelParentOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ParentOrderAcceptanceId = trailParentOrderAcceptanceId
            });

            Util.ThreadSleep(health.Status);

            await Task.WhenAll(Enumerable.Range(0, 3).Select(_ => apiClient.SendParentOrder(parameter)));

            Util.ThreadSleep(health.Status);

            await apiClient.CancelAllOrders(new CancelAllOrdersParameter
            {
                ProductCode = ProductCode.FxBtcJpy
            });

            Util.ThreadSleep(health.Status);

            var res3 = await apiClient.GetParentOrders(ProductCode.FxBtcJpy);
            Assert.True(res3.Count(x => x.ProductCode == ProductCode.FxBtcJpy
                                        && x.ParentOrderState == ParentOrderState.Active) == 0);
        }

        [Fact]
        public async Task GetExecutions()
        {
            var res1 = await apiClient.GetExecutions(ProductCode.FxBtcJpy);
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetPositions()
        {
            var res1 = await apiClient.GetPositions(ProductCode.FxBtcJpy);
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetCollateralHistory()
        {
            var res1 = await apiClient.GetCollateralHistory();
            Assert.NotNull(res1);

            res1 = await apiClient.GetCollateralHistory(100);
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetTradingCommission()
        {
            var res1 = await apiClient.GetTradingCommission(ProductCode.BtcJpy);
            Assert.NotNull(res1);
        }
    }
}
