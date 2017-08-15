using System.Threading;

namespace BitFlyer.Apis.Test
{
    public static class Util
    {
        public static void ThreadSleep(BitflyerSystemHealth health)
        {
            int waitMilliSeconds;
            switch (health)
            {
                case BitflyerSystemHealth.Normal:
                    waitMilliSeconds = 5000;
                    break;
                case BitflyerSystemHealth.Busy:
                    waitMilliSeconds = 10000;
                    break;
                case BitflyerSystemHealth.VeryBusy:
                    waitMilliSeconds = 15000;
                    break;
                case BitflyerSystemHealth.SuperBusy:
                    waitMilliSeconds = 30000;
                    break;
                case BitflyerSystemHealth.Stop:
                    waitMilliSeconds = 60000;
                    break;
                default:
                    waitMilliSeconds = 90000;
                    break;
            }

            Thread.Sleep(waitMilliSeconds);
        }
    }
}
