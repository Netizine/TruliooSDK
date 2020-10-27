using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class AppendedField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string fieldName;
        private string data;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("FieldName")]
        public string FieldName 
        { 
            get => fieldName;
            set 
            {
                fieldName = value;
                OnPropertyChanged("FieldName");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Data")]
        public string Data 
        { 
            get => data;
            set 
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }
    }
} 