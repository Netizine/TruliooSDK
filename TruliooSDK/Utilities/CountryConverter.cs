using System;
using Newtonsoft.Json;
using TruliooSDK.Enums;
using TruliooSDK.Exceptions;

namespace TruliooSDK.Utilities
{
    public class CountryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Country) || t == typeof(Country?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            var value = serializer.Deserialize<string>(reader);
            if (value != null)
            {
                switch (value)
                {
                    case "AU":
                        return Country.Australia;
                    case "AT":
                        return Country.Austria;
                    case "DK":
                        return Country.Denmark;
                    case "NO":
                        return Country.Norway;
                    case "SE":
                        return Country.Sweden;
                    case "TR":
                        return Country.Turkey;
                    case "BR":
                        return Country.Brazil;
                    case "BE":
                        return Country.Belgium;
                    case "DE":
                        return Country.Germany;
                    case "NL":
                        return Country.Netherlands;
                    case "GB":
                        return Country.GreatBritain;
                    case "US":
                        return Country.UnitedStates;
                    case "MY":
                        return Country.Malaysia;
                    case "RU":
                        return Country.Russia;
                    default:
                        throw new APIException("Cannot unmarshal type Country", null);
                }
            }
            throw new APIException("Cannot unmarshal type CountryCode");
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
