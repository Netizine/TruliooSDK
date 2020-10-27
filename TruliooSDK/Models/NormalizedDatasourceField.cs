
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class NormalizedDatasourceField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string fieldName;
        private string type;

        /// <summary>
        /// Field Name
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
        /// Type
        /// </summary>
        [JsonProperty("Type")]
        public string Type 
        { 
            get => type;
            set 
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
    }
} 