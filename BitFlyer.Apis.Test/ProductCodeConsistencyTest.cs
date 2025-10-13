using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BitFlyer.Apis;
using Xunit;

namespace BitFlyer.Apis.Test
{
    public class ProductCodeConsistencyTest
    {
        private static readonly string[] DocumentedProductCodes =
        {
            ProductCode.BtcJpy,
            ProductCode.FxBtcJpy,
            ProductCode.EthBtc,
            ProductCode.EthJpy,
            ProductCode.BchBtc,
            ProductCode.BchJpy,
            ProductCode.BtcUsd,
            ProductCode.BtcEur,
            ProductCode.MonaJpy,
            ProductCode.MonaBtc,
            ProductCode.LtcBtc,
            ProductCode.XrpJpy,
            ProductCode.XrpBtc,
            ProductCode.XlmJpy,
            ProductCode.XlmBtc,
            ProductCode.XemJpy,
            ProductCode.XemBtc,
            ProductCode.BatJpy,
            ProductCode.BatBtc,
            ProductCode.OmgJpy,
            ProductCode.OmgBtc,
        };

        [Fact]
        public void ProductCode_AllConstantsMatchDocumentedList()
        {
            Assert.Equal(DocumentedProductCodes, ProductCode.All);

            var constantValues = typeof(ProductCode)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
                .Select(field => (string)field.GetRawConstantValue())
                .OrderBy(value => value, StringComparer.Ordinal)
                .ToArray();

            var documentedValues = DocumentedProductCodes
                .OrderBy(value => value, StringComparer.Ordinal)
                .ToArray();

            Assert.Equal(documentedValues, constantValues);
        }

        [Fact]
        public void RealtimeChannelsExistForEveryProductCode()
        {
            var channelFields = typeof(RealtimeChannel)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
                .ToDictionary(field => field.Name, field => (string)field.GetRawConstantValue(), StringComparer.Ordinal);

            var channelDefinitions = new (string Suffix, string Prefix)[]
            {
                ("BoardSnapshot", RealtimeChannel.BoardSnapshotPrefix),
                ("Board", RealtimeChannel.BoardPrefix),
                ("Ticker", RealtimeChannel.TickerPrefix),
                ("Executions", RealtimeChannel.ExecutionPrefix),
            };

            foreach (var productField in typeof(ProductCode)
                         .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                         .Where(field => field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string)))
            {
                var productCodeName = productField.Name;
                var productCodeValue = (string)productField.GetRawConstantValue();

                foreach (var (suffix, prefix) in channelDefinitions)
                {
                    var channelConstantName = suffix + productCodeName;
                    Assert.True(channelFields.TryGetValue(channelConstantName, out var channelValue),
                        $"RealtimeChannel.{channelConstantName} is missing.");

                    var expectedValue = prefix + productCodeValue;

                    Assert.Equal(expectedValue, channelValue);
                }
            }
        }
    }
}
