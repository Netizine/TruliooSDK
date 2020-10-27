
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DatasourceResult : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _datasourceStatus;
        private string _datasourceName;
        private List<DatasourceField> _datasourceFields;
        private List<AppendedField> _appendedFields;
        private List<ServiceError> _errors;
        private List<string> _fieldGroups;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DatasourceStatus")]
        public string DatasourceStatus 
        { 
            get => _datasourceStatus;
            set 
            {
                _datasourceStatus = value;
                OnPropertyChanged("DatasourceStatus");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DatasourceName")]
        public string DatasourceName 
        { 
            get => _datasourceName;
            set 
            {
                _datasourceName = value;
                OnPropertyChanged("DatasourceName");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DatasourceFields")]
        public List<DatasourceField> DatasourceFields 
        { 
            get => _datasourceFields;
            set 
            {
                _datasourceFields = value;
                OnPropertyChanged("DatasourceFields");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("AppendedFields")]
        public List<AppendedField> AppendedFields 
        { 
            get => _appendedFields;
            set 
            {
                _appendedFields = value;
                OnPropertyChanged("AppendedFields");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Errors")]
        public List<ServiceError> Errors 
        { 
            get => _errors;
            set 
            {
                _errors = value;
                OnPropertyChanged("Errors");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("FieldGroups")]
        public List<string> FieldGroups 
        { 
            get => _fieldGroups;
            set 
            {
                _fieldGroups = value;
                OnPropertyChanged("FieldGroups");
            }
        }
    }
} 