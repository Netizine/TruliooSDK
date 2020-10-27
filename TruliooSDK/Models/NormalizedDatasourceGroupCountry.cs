
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class NormalizedDataSourceGroupCountry : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _name;
        private string _description;
        private List<NormalizedDatasourceField> _requiredFields;
        private List<NormalizedDatasourceField> _optionalFields;
        private List<NormalizedDatasourceField> _appendedFields;
        private List<NormalizedDatasourceField> _outputFields;
        private string _sourceType;
        private string _updateFrequency;
        private string _coverage;

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("Name")]
        public string Name 
        { 
            get => _name;
            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("Description")]
        public string Description 
        { 
            get => _description;
            set 
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Required Fields
        /// </summary>
        [JsonProperty("RequiredFields")]
        public List<NormalizedDatasourceField> RequiredFields 
        { 
            get => _requiredFields;
            set 
            {
                _requiredFields = value;
                OnPropertyChanged("RequiredFields");
            }
        }

        /// <summary>
        /// Optional Fields
        /// </summary>
        [JsonProperty("OptionalFields")]
        public List<NormalizedDatasourceField> OptionalFields 
        { 
            get => _optionalFields;
            set 
            {
                _optionalFields = value;
                OnPropertyChanged("OptionalFields");
            }
        }

        /// <summary>
        /// Appended Fields
        /// </summary>
        [JsonProperty("AppendedFields")]
        public List<NormalizedDatasourceField> AppendedFields 
        { 
            get => _appendedFields;
            set 
            {
                _appendedFields = value;
                OnPropertyChanged("AppendedFields");
            }
        }

        /// <summary>
        /// Output Fields
        /// </summary>
        [JsonProperty("OutputFields")]
        public List<NormalizedDatasourceField> OutputFields 
        { 
            get => _outputFields;
            set 
            {
                _outputFields = value;
                OnPropertyChanged("OutputFields");
            }
        }

        /// <summary>
        /// Source Type
        /// </summary>
        [JsonProperty("SourceType")]
        public string SourceType 
        { 
            get => _sourceType;
            set 
            {
                _sourceType = value;
                OnPropertyChanged("SourceType");
            }
        }

        /// <summary>
        /// Update Frequency
        /// </summary>
        [JsonProperty("UpdateFrequency")]
        public string UpdateFrequency 
        { 
            get => _updateFrequency;
            set 
            {
                _updateFrequency = value;
                OnPropertyChanged("UpdateFrequency");
            }
        }

        /// <summary>
        /// Coverage
        /// </summary>
        [JsonProperty("Coverage")]
        public string Coverage 
        { 
            get => _coverage;
            set 
            {
                _coverage = value;
                OnPropertyChanged("Coverage");
            }
        }
    }
} 