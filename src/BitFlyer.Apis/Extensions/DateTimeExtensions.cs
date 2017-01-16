using System;

namespace BitFlyer.Apis
{
    internal static class DateTimeExtensions
    {
        private static readonly DateTimeOffset UnixEpochDateTimeOffset = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTime UnixEpochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        internal static long ToUnixTime(this DateTimeOffset datetime)
        {
            return (long)datetime.ToUniversalTime().Subtract(UnixEpochDateTimeOffset).TotalSeconds;
        }

        internal static long ToUnixTime(this DateTime datetime)
        {
            return (long)datetime.ToUniversalTime().Subtract(UnixEpochDateTime).TotalSeconds;
        }
    }
}
