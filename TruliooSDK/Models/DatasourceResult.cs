
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DatasourceResult : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string datasourceStatus;
        private string datasourceName;
        private List<DatasourceField> datasourceFields;
        private List<AppendedField> appendedFields;
        private List<ServiceError> errors;
        private List<string> fieldGroups;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DatasourceStatus")]
        public string DatasourceStatus 
        { 
            get => datasourceStatus;
            set 
            {
                datasourceStatus = value;
                OnPropertyChanged("DatasourceStatus");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DatasourceName")]
        public string DatasourceName 
        { 
            get => datasourceName;
            set 
            {
                datasourceName = value;
                OnPropertyChanged("DatasourceName");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DatasourceFields")]
        public List<DatasourceField> DatasourceFields 
        { 
            get => datasourceFields;
            set 
            {
                datasourceFields = value;
                OnPropertyChanged("DatasourceFields");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("AppendedFields")]
        public List<AppendedField> AppendedFields 
        { 
            get => appendedFields;
            set 
            {
                appendedFields = value;
                OnPropertyChanged("AppendedFields");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Errors")]
        public List<ServiceError> Errors 
        { 
            get => errors;
            set 
            {
                errors = value;
                OnPropertyChanged("Errors");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("FieldGroups")]
        public List<string> FieldGroups 
        { 
            get => fieldGroups;
            set 
            {
                fieldGroups = value;
                OnPropertyChanged("FieldGroups");
            }
        }
    }
} 