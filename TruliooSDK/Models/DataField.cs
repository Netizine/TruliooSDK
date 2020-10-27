using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DataField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string fieldName;
        private string fieldValue;
        private string fieldGroup;

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
        [JsonProperty("Value")]
        public string Value 
        { 
            get => fieldValue;
            set 
            {
                fieldValue = value;
                OnPropertyChanged("Value");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("FieldGroup")]
        public string FieldGroup 
        { 
            get => fieldGroup;
            set 
            {
                fieldGroup = value;
                OnPropertyChanged("FieldGroup");
            }
        }
    }
} 