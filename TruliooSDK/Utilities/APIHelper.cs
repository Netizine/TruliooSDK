using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TruliooSDK.Utilities
{
    public static class APIHelper
    {
        //DateTime format to use for parsing and converting dates
        public static string DateTimeFormat { get; set; } = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        /// <summary>
        /// JSON Serialization of a given object.
        /// </summary>
        /// <param name="obj">The object to serialize into JSON</param>
        /// <returns>The serialized Json string representation of the given object</returns>
        public static string JsonSerialize(object obj)
        {
            return JsonSerialize(obj, null);
        }

        /// <summary>
        /// JSON Serialization of a given object.
        /// </summary>
        /// <param name="obj">The object to serialize into JSON</param>
        /// <param name="converter">The converter to use for date time conversion</param>
        /// <returns>The serialized Json string representation of the given object</returns>
        public static string JsonSerialize(object obj, JsonConverter converter)
        {
            if (null == obj)
            {
                return null;
            }

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            settings.Converters.Add(converter ?? new IsoDateTimeConverter());

            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        /// JSON Deserialization of the given json string.
        /// </summary>
        /// <param name="json">The json string to deserialize</param>
        /// <typeparam name="T">The type of the object to deserialize into</typeparam>
        /// <returns>The deserialized object</returns>
        public static T JsonDeserialize<T>(string json)
        {
            return JsonDeserialize<T>(json, null);
        }

        /// <summary>
        /// JSON Deserialization of the given json string.
        /// </summary>
        /// <param name="json">The json string to deserialize</param>
        /// <param name="converter">The converter to use for date time conversion</param>
        /// <typeparam name="T">The type of the object to deserialize into</typeparam>
        /// <returns>The deserialized object</returns>
        public static T JsonDeserialize<T>(string json, JsonConverter converter)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return default;
            }
            var converters = new List<JsonConverter>
            {
                new CountryConverter(),
                //new CountrySpecificFieldsConverter()
            };
            if (converter == null)
            {
                converters.Add(new IsoDateTimeConverter());
                return JsonConvert.DeserializeObject<T>(json, converters.ToArray());
            }
            else
            {
                converters.Add(converter);
                return JsonConvert.DeserializeObject<T>(json, converters.ToArray());
            }
        }

        /// <summary>
        /// Replaces template parameters in the given url
        /// </summary>
        /// <param name="queryBuilder">The query url string to replace the template parameters</param>
        /// <param name="parameters">The parameters to replace in the url</param>
        public static void AppendUrlWithTemplateParameters
            (StringBuilder queryBuilder, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            //perform parameter validation
            if (null == queryBuilder)
                throw new ArgumentNullException(nameof(queryBuilder));

            if (null == parameters)
                return;

            //iterate and replace parameters
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                string replaceValue;

                switch (pair.Value)
                {
                    //load element value as string
                    case null:
                        replaceValue = "";
                        break;
                    case ICollection value:
                        replaceValue = FlattenCollection(value, ArrayDeserialization.None, '/', false);
                        break;
                    case DateTime time:
                        replaceValue = time.ToString(DateTimeFormat);
                        break;
                    case DateTimeOffset offset:
                        replaceValue = offset.ToString(DateTimeFormat);
                        break;
                    default:
                        replaceValue = pair.Value.ToString();
                        break;
                }

                replaceValue = Uri.EscapeUriString(replaceValue);

                //find the template parameter and replace it with its value
                queryBuilder.Replace($"{{{pair.Key}}}", replaceValue);
            }
        }

        /// <summary>
        /// Validates and processes the given query Url to clean empty slashes
        /// </summary>
        /// <param name="queryBuilder">The given query Url to process</param>
        /// <returns>Clean Url as string</returns>
        public static string CleanUrl(StringBuilder queryBuilder)
        {
            //convert to immutable string
            var url = queryBuilder.ToString();

            //ensure that the urls are absolute
            Match match = Regex.Match(url, "^https?://[^/]+");
            if (!match.Success)
                throw new ArgumentException("Invalid Url format.");

            //remove redundant forward slashes
            var index = url.IndexOf('?');
            var protocol = match.Value;
            var query = url.Substring(protocol.Length, (index == -1 ? url.Length : index) - protocol.Length);
            query = Regex.Replace(query, "//+", "/");
            var parameters = index == -1 ? "" : url.Substring(index);

            //return process url
            return string.Concat(protocol, query, parameters);
        }

        /// <summary>
        /// Used for flattening a collection of objects into a string 
        /// </summary>
        /// <param name="array">Array of elements to flatten</param>
        /// <param name="fmt">Format string to use for array flattening</param>
        /// <param name="separator">Separator to use for string concat</param>
        /// <param name="urlEncode">Url Encode</param>
        /// <returns>Representative string made up of array elements</returns>
        private static string FlattenCollection(ICollection array, ArrayDeserialization fmt, char separator,
            bool urlEncode)
        {
            return FlattenCollection(array, fmt, separator, urlEncode, "");
        }

        /// <summary>
        /// Used for flattening a collection of objects into a string 
        /// </summary>
        /// <param name="array">Array of elements to flatten</param>
        /// <param name="fmt">Format string to use for array flattening</param>
        /// <param name="separator">Separator to use for string concat</param>
        /// <param name="urlEncode">Url Encode</param>
        /// <param name="key">Key</param>
        /// <returns>Representative string made up of array elements</returns>
        private static string FlattenCollection(ICollection array, ArrayDeserialization fmt, char separator,
            bool urlEncode, string key)
        {
            var builder = new StringBuilder();

            string format;
            switch (fmt)
            {
                case ArrayDeserialization.UnIndexed:
                    format = $"{key}[]={{0}}{{1}}";
                    break;
                case ArrayDeserialization.Indexed:
                    format = $"{key}[{{2}}]={{0}}{{1}}";
                    break;
                case ArrayDeserialization.Plain:
                    format = $"{key}={{0}}{{1}}";
                    break;
                case ArrayDeserialization.Csv:
                case ArrayDeserialization.Psv:
                case ArrayDeserialization.Tsv:
                    builder.Append($"{key}=");
                    format = "{0}{1}";
                    break;
                default:
                    format = "{0}{1}";
                    break;
            }

            //append all elements in the array into a string
            var index = 0;
            foreach (object element in array)
            {
                builder.AppendFormat(format, GetElementValue(element, urlEncode), separator, index++);
            }
            //remove the last separator, if appended
            if ((builder.Length > 1) && (builder[builder.Length - 1] == separator))
            {
                builder.Length -= 1;
            }

            return builder.ToString();
        }

        private static string GetElementValue(object element, bool urlEncode)
        {
            string elemValue;

            switch (element)
            {
                //replace null values with empty string to maintain index order
                case null:
                    elemValue = string.Empty;
                    break;
                case DateTime time:
                    elemValue = time.ToString(DateTimeFormat);
                    break;
                case DateTimeOffset offset:
                    elemValue = offset.ToString(DateTimeFormat);
                    break;
                default:
                    elemValue = element.ToString();
                    break;
            }

            if (urlEncode)
                elemValue = Uri.EscapeDataString(elemValue);
            return elemValue;
        }

        /// <summary>
        /// Add/update entries with the new dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="dictionary2"></param>
        public static void Add(this Dictionary<string, object> dictionary, Dictionary<string, object> dictionary2)
        {
            foreach (KeyValuePair<string, object> kvp in dictionary2)
            {
                dictionary[kvp.Key] = kvp.Value;
            }
        }

    }
}
