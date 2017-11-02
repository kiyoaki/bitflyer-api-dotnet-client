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
                    waitMilliSeconds = 7000;
                    break;
                case BitflyerSystemHealth.VeryBusy:
                    waitMilliSeconds = 9000;
                    break;
                case BitflyerSystemHealth.SuperBusy:
                    waitMilliSeconds = 11000;
                    break;
                case BitflyerSystemHealth.Stop:
                    waitMilliSeconds = 13000;
                    break;
                default:
                    waitMilliSeconds = 15000;
                    break;
            }

            Thread.Sleep(waitMilliSeconds);
        }
    }
}
