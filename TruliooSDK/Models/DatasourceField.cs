
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DatasourceField : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _fieldName;
        private string _status;
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
        [JsonProperty("Status")]
        public string Status 
        { 
            get => _status;
            set 
            {
                _status = value;
                OnPropertyChanged("Status");
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