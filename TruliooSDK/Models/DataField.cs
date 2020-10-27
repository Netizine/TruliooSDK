using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DataField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _fieldName;
        private string _fieldValue;
        private string _fieldGroup;

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
        [JsonProperty("Value")]
        public string Value 
        { 
            get => _fieldValue;
            set 
            {
                _fieldValue = value;
                OnPropertyChanged("Value");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("FieldGroup")]
        public string FieldGroup 
        { 
            get => _fieldGroup;
            set 
            {
                _fieldGroup = value;
                OnPropertyChanged("FieldGroup");
            }
        }
    }
} 