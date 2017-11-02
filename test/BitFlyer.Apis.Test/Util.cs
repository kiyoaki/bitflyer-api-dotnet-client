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
                    waitMilliSeconds = 4000;
                    break;
                case BitflyerSystemHealth.Busy:
                    waitMilliSeconds = 8000;
                    break;
                case BitflyerSystemHealth.VeryBusy:
                    waitMilliSeconds = 12000;
                    break;
                case BitflyerSystemHealth.SuperBusy:
                    waitMilliSeconds = 16000;
                    break;
                case BitflyerSystemHealth.Stop:
                    waitMilliSeconds = 20000;
                    break;
                default:
                    waitMilliSeconds = 24000;
                    break;
            }

            Thread.Sleep(waitMilliSeconds);
        }
    }
}
