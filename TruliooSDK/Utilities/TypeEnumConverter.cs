using System;
using Newtonsoft.Json;
using TruliooSDK.Enums;

namespace TruliooSDK.Utilities
{
    public class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "int":
                case "integer":
                    return TypeEnum.Int;
                case "string":
                    return TypeEnum.String;
                case "object":
                    return TypeEnum.Object;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Int:
                case TypeEnum.Integer:
                    serializer.Serialize(writer, "int");
                    return;
                case TypeEnum.String:
                    serializer.Serialize(writer, "string");
                    return;
                case TypeEnum.Object:
                    serializer.Serialize(writer, "object");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
