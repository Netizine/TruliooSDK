
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DatasourceField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string fieldName;
        private string status;
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
        [JsonProperty("Status")]
        public string Status 
        { 
            get => status;
            set 
            {
                status = value;
                OnPropertyChanged("Status");
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