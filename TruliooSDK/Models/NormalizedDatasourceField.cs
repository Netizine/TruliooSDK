
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class NormalizedDatasourceField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _fieldName;
        private string _type;

        /// <summary>
        /// Field Name
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
        /// Type
        /// </summary>
        [JsonProperty("Type")]
        public string Type 
        { 
            get => _type;
            set 
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
    }
} 