using System;
using System.Collections.Generic;
using System.Linq;

namespace BitFlyer.Apis
{
    internal static class DictionaryExtensions
    {
        internal static string ToQueryString(this Dictionary<string, object> source)
        {
            if (source == null) throw new ArgumentNullException();
            if (source.Count == 0) return string.Empty;
            return "?" + string.Join("&", source.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}
