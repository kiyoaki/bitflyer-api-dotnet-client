using System;
using System.Collections.Generic;

namespace BitFlyer.Apis.Core
{
    internal static class BitFlyerConstants
    {
        internal static readonly Uri BaseUri = new Uri("https://api.bitflyer.jp");

        internal static readonly Dictionary<string, BitflyerSystemHealth> Healths = new Dictionary<string, BitflyerSystemHealth>
        {
            { "NORMAL", BitflyerSystemHealth.Normal },
            { "BUSY", BitflyerSystemHealth.Normal },
            { "VERY BUSY", BitflyerSystemHealth.VeryBusy },
            { "STOP", BitflyerSystemHealth.Stop }
        };
    }
}
