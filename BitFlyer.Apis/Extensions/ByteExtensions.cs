using System;

namespace BitFlyer.Apis
{
    internal static class ByteExtensions
    {
        internal static string ToHexString(this byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

#if NET5_0_OR_GREATER
            return Convert.ToHexString(bytes);
#else
            return ToHexString(bytes.AsSpan());
#endif
        }

        internal static string ToHexString(ReadOnlySpan<byte> bytes)
        {
#if NET5_0_OR_GREATER
            return Convert.ToHexString(bytes);
#else
            if (bytes.IsEmpty) return string.Empty;

            const string hex = "0123456789ABCDEF";
            var chars = new char[bytes.Length * 2];

            int ci = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                byte b = bytes[i];
                chars[ci++] = hex[b >> 4];
                chars[ci++] = hex[b & 0xF];
            }

            return new string(chars);
#endif
        }
    }
}
