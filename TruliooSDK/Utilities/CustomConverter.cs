using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TruliooSDK.Enums;

namespace TruliooSDK.Utilities
{
    internal static class CustomConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CountryCodeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        internal class CountryCodeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CountryCode) || t == typeof(CountryCode?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;
                var value = serializer.Deserialize<string>(reader);
                if (value != null)
                {
                    if (value == "AU")
                        return CountryCode.Australia;
                    else if (value == "AT")
                        return CountryCode.Austria;
                    else if (value == "DK")
                        return CountryCode.Denmark;
                    else if (value == "NO")
                        return CountryCode.Sweden;
                    else if (value == "TR")
                        return CountryCode.Turkey;
                    else if (value == "BR")
                        return CountryCode.Brazil;
                    else if (value == "BE")
                        return CountryCode.Belgium;
                    else if (value == "DE")
                        return CountryCode.Germany;
                    else if (value == "NL")
                        return CountryCode.Netherlands;
                    else if (value == "GB")
                        return CountryCode.GreatBritain;
                    else if (value == "US")
                        return CountryCode.UnitedStates;
                    else if (value == "MY")
                        return CountryCode.Malaysia;
                    else if (value == "RU") return CountryCode.Russia;
                }
                throw new Exception("Cannot unmarshal type CountryCode");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (CountryCode)untypedValue;
                serializer.Serialize(writer, value.ToFriendlyString());
                return;
                throw new Exception("Cannot marshal type Country");
            }
            public static readonly CountryCodeConverter Singleton = new CountryCodeConverter();
        }
    }
}
