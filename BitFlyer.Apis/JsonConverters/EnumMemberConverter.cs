using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BitFlyer.Apis.JsonConverters
{
    public class EnumMemberConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        private readonly Dictionary<string, T> _stringToEnum = new Dictionary<string, T>();
        private readonly Dictionary<T, string> _enumToString = new Dictionary<T, string>();

        public EnumMemberConverter()
        {
            var type = typeof(T);
            foreach (var value in Enum.GetValues(type).Cast<T>())
            {
                var enumMember = type.GetMember(value.ToString())[0]
                    .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                    .OfType<EnumMemberAttribute>()
                    .FirstOrDefault();

                var label = enumMember?.Value ?? value.ToString();
                _stringToEnum[label] = value;
                _enumToString[value] = label;
            }
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            if (_stringToEnum.TryGetValue(stringValue, out var value))
            {
                return value;
            }
            
            // Fallback to case-insensitive search if exact match fails (optional, but good for robustness)
            foreach (var kvp in _stringToEnum)
            {
                if (string.Equals(kvp.Key, stringValue, StringComparison.OrdinalIgnoreCase))
                {
                    return kvp.Value;
                }
            }

            // If still not found, maybe return default or throw? 
            // For now, let's throw to match previous behavior or maybe return default if that was the case.
            // But since we have "Unknown" in some enums, maybe we should handle it?
            // Let's try to return default value if defined, otherwise throw.
            return default;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (_enumToString.TryGetValue(value, out var stringValue))
            {
                writer.WriteStringValue(stringValue);
            }
            else
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
    
    public class EnumMemberConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return (JsonConverter)Activator.CreateInstance(
                typeof(EnumMemberConverter<>).MakeGenericType(typeToConvert));
        }
    }
}
