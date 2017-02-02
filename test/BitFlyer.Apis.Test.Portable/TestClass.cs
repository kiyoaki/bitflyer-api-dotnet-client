using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BitFlyer.Apis.Test.Portable
{
    [TestFixture]
    public class TestClass
    {
        private readonly PrivateApi _apiClient = new PrivateApi("xxxxxxxxxxx", "xxxxxxxxxxx");

        [Test]
        public async Task GetBoard()
        {
            var res1 = await PublicApi.GetBoard(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await PublicApi.GetBoard(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await PublicApi.GetBoard(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [Test]
        public async Task GetTicker()
        {
            var res1 = await PublicApi.GetTicker(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await PublicApi.GetTicker(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await PublicApi.GetTicker(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [Test]
        public async Task GetPublicExecutions()
        {
            var res1 = await PublicApi.GetExecutions(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await PublicApi.GetExecutions(ProductCode.FxBtcJpy, 500, 272500, 272000);
            Assert.AreNotEqual(res2, null);

            var res3 = await PublicApi.GetExecutions(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [Test]
        public async Task GetHealth()
        {
            var res1 = await PublicApi.GetHealth();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetChat()
        {
            var res1 = await PublicApi.GetChat(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task ApiKeyNotFound()
        {
            var apiClient = new PrivateApi("xxxxxxxxxxx", "xxxxxxxxxxx");
            try
            {
                await apiClient.GetPermissions();
            }
            catch (BitFlyerApiException ex)
            {
                Assert.AreEqual(ex.ErrorResponse.Status, -500);
                Assert.AreEqual(ex.ErrorResponse.ErrorMessage, "Key not found");
            }
        }

        [Test]
        public async Task GetPermissions()
        {
            var res1 = await _apiClient.GetPermissions();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetBalance()
        {
            var res1 = await _apiClient.GetBalance();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetCollateral()
        {
            var res1 = await _apiClient.GetCollateral();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetAddresses()
        {
            var res1 = await _apiClient.GetAddresses();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetCoinIns()
        {
            var res1 = await _apiClient.GetCoinIns();
            Assert.AreNotEqual(res1, null);
        }

        /*
        [Test]
        public async Task SendCoin()
        {
            var res1 = await _apiClient.SendCoin(new SendCoinParameter
            {
                CurrencyCode = CurrencyCode.Btc,
                Amount = 0.001,
                AdditionalFee = 0,
                Address = "xxxxxx",
                Code = 123456
            });
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetCoinOut()
        {
            var res1 = await _apiClient.GetCoinOut("xxxxx");
            Assert.AreNotEqual(res1, null);
        }
        */

        [Test]
        public async Task GetCoinOuts()
        {
            var res1 = await _apiClient.GetCoinOuts();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetBankAccounts()
        {
            var res1 = await _apiClient.GetBankAccounts();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetDeposits()
        {
            var res1 = await _apiClient.GetDeposits();
            Assert.AreNotEqual(res1, null);
        }

        /*
        [Test]
        public async Task Withdraw()
        {
            var res1 = await _apiClient.Withdraw(new WithdrawParameter
            {
                CurrencyCode = CurrencyCode.Jpy,
                Amount = 1,
                BankAccountId = 1234567890,
                Code = 123456
            });
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetWithdrawal()
        {
            var res1 = await _apiClient.GetWithdrawal("xxxxx");
            Assert.AreNotEqual(res1, null);
        }
        */

        [Test]
        public async Task GetWithdrawals()
        {
            var res1 = await _apiClient.GetWithdrawals();
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task ChildOrder()
        {
            await _apiClient.CancelAllOrders(new CancelAllOrdersParameter
            {
                ProductCode = ProductCode.FxBtcJpy
            });

            var res1 = await _apiClient.SendChildOrder(new SendChildOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ChildOrderType = ChildOrderType.Limit,
                Side = Side.Buy,
                Price = 90000,
                Size = 0.01,
                MinuteToExpire = 10000,
                TimeInForce = TimeInForce.GoodTilCanceled
            });
            var childOrderAcceptanceId = res1?.ChildOrderAcceptanceId;
            Assert.AreNotEqual(childOrderAcceptanceId, null);

            Task.Delay(1000).Wait();

            var res2 = await _apiClient.GetChildOrders(ProductCode.FxBtcJpy);
            Assert.True(res2.Any(x => x.ProductCode == ProductCode.FxBtcJpy
                                        && x.ChildOrderState == ChildOrderState.Active));

            await _apiClient.CancelChildOrder(new CancelChildOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ChildOrderAcceptanceId = childOrderAcceptanceId
            });

            await Task.WhenAll(Enumerable.Range(0, 3).Select(_ => _apiClient.SendChildOrder(new SendChildOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ChildOrderType = ChildOrderType.Limit,
                Side = Side.Buy,
                Price = 90000,
                Size = 0.01,
                MinuteToExpire = 10000,
                TimeInForce = TimeInForce.GoodTilCanceled
            })));

            Task.Delay(1000).Wait();

            await _apiClient.CancelAllOrders(new CancelAllOrdersParameter
            {
                ProductCode = ProductCode.FxBtcJpy
            });

            Task.Delay(1000).Wait();

            var res3 = await _apiClient.GetChildOrders(ProductCode.FxBtcJpy);
            Assert.True(res3.Count(x => x.ProductCode == ProductCode.FxBtcJpy
                                          && x.ChildOrderState == ChildOrderState.Active) == 0);
        }

        [Test]
        public async Task ParentOrder()
        {
            await _apiClient.CancelAllOrders(new CancelAllOrdersParameter
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
                        Price = 90000,
                        Size = 0.01
                    },
                    new ParentOrderDetailParameter
                    {
                        ProductCode = ProductCode.FxBtcJpy,
                        ConditionType = ConditionType.Stop,
                        Side = Side.Sell,
                        TriggerPrice = 95000,
                        Size = 0.01
                    }
                }
            };

            var res1 = await _apiClient.SendParentOrder(parameter);
            var parentOrderAcceptanceId = res1?.ParentOrderAcceptanceId;
            Assert.AreNotEqual(parentOrderAcceptanceId, null);

            Task.Delay(1000).Wait();

            var res2 = await _apiClient.GetParentOrder(ProductCode.FxBtcJpy, parentOrderAcceptanceId: parentOrderAcceptanceId);
            Assert.AreNotEqual(res2, null);

            await _apiClient.CancelParentOrder(new CancelParentOrderParameter
            {
                ProductCode = ProductCode.FxBtcJpy,
                ParentOrderAcceptanceId = parentOrderAcceptanceId
            });

            Task.Delay(1000).Wait();

            await Task.WhenAll(Enumerable.Range(0, 3).Select(_ => _apiClient.SendParentOrder(parameter)));

            Task.Delay(1000).Wait();

            await _apiClient.CancelAllOrders(new CancelAllOrdersParameter
            {
                ProductCode = ProductCode.FxBtcJpy
            });

            Task.Delay(1000).Wait();

            var res3 = await _apiClient.GetParentOrders(ProductCode.FxBtcJpy);
            Assert.True(res3.Count(x => x.ProductCode == ProductCode.FxBtcJpy
                                          && x.ParentOrderState == ParentOrderState.Active) == 0);
        }

        [Test]
        public async Task GetExecutions()
        {
            var res1 = await _apiClient.GetExecutions(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res1, null);
        }

        [Test]
        public async Task GetPositions()
        {
            var res1 = await _apiClient.GetPositions(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res1, null);
        }
    }
}
