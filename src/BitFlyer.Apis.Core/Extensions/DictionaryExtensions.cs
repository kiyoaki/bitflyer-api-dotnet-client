using System;
using System.Collections.Generic;
using System.Linq;

namespace BitFlyer.Apis
{
    public static class DictionaryExtensions
    {
        public static string ToQueryString(this Dictionary<string, object> source)
        {
            if (source == null) throw new ArgumentNullException();
            return "?" + string.Join("&", source.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}
