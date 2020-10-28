using System;
using Newtonsoft.Json;
using TruliooSDK.Enums;

namespace TruliooSDK.Utilities
{
    public class CountryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Country) || t == typeof(Country?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            if (value != null)
            {
                if (value == "AU")
                    return Country.Australia;
                else if (value == "AT")
                    return Country.Austria;
                else if (value == "DK")
                    return Country.Denmark;
                else if (value == "NO")
                    return Country.Norway;
                else if (value == "SE")
                    return Country.Sweden;
                else if (value == "TR")
                    return Country.Turkey;
                else if (value == "BR")
                    return Country.Brazil;
                else if (value == "BE")
                    return Country.Belgium;
                else if (value == "DE")
                    return Country.Germany;
                else if (value == "NL")
                    return Country.Netherlands;
                else if (value == "GB")
                    return Country.GreatBritain;
                else if (value == "US")
                    return Country.UnitedStates;
                else if (value == "MY")
                    return Country.Malaysia;
                else if (value == "RU")
                    return Country.Russia;
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
            var value = (Country)untypedValue;
            serializer.Serialize(writer, value.ToAlpha2CodeString());
        }
    }
}
