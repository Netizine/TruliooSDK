using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class AppendedField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _fieldName;
        private string _data;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("FieldName")]
        public string FieldName 
        { 
            get => _fieldName;
            set 
            {
                _fieldName = value;
                OnPropertyChanged("FieldName");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Data")]
        public string Data 
        { 
            get => _data;
            set 
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }
    }
} 