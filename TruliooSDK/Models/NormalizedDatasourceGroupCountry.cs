
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class NormalizedDatasourceGroupCountry : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string name;
        private string description;
        private List<NormalizedDatasourceField> requiredFields;
        private List<NormalizedDatasourceField> optionalFields;
        private List<NormalizedDatasourceField> appendedFields;
        private List<NormalizedDatasourceField> outputFields;
        private string sourceType;
        private string updateFrequency;
        private string coverage;

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("Name")]
        public string Name 
        { 
            get => name;
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("Description")]
        public string Description 
        { 
            get => description;
            set 
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Required Fields
        /// </summary>
        [JsonProperty("RequiredFields")]
        public List<NormalizedDatasourceField> RequiredFields 
        { 
            get => requiredFields;
            set 
            {
                requiredFields = value;
                OnPropertyChanged("RequiredFields");
            }
        }

        /// <summary>
        /// Optional Fields
        /// </summary>
        [JsonProperty("OptionalFields")]
        public List<NormalizedDatasourceField> OptionalFields 
        { 
            get => optionalFields;
            set 
            {
                optionalFields = value;
                OnPropertyChanged("OptionalFields");
            }
        }

        /// <summary>
        /// Appended Fields
        /// </summary>
        [JsonProperty("AppendedFields")]
        public List<NormalizedDatasourceField> AppendedFields 
        { 
            get => appendedFields;
            set 
            {
                appendedFields = value;
                OnPropertyChanged("AppendedFields");
            }
        }

        /// <summary>
        /// Output Fields
        /// </summary>
        [JsonProperty("OutputFields")]
        public List<NormalizedDatasourceField> OutputFields 
        { 
            get => outputFields;
            set 
            {
                outputFields = value;
                OnPropertyChanged("OutputFields");
            }
        }

        /// <summary>
        /// Source Type
        /// </summary>
        [JsonProperty("SourceType")]
        public string SourceType 
        { 
            get => sourceType;
            set 
            {
                sourceType = value;
                OnPropertyChanged("SourceType");
            }
        }

        /// <summary>
        /// Update Frequency
        /// </summary>
        [JsonProperty("UpdateFrequency")]
        public string UpdateFrequency 
        { 
            get => updateFrequency;
            set 
            {
                updateFrequency = value;
                OnPropertyChanged("UpdateFrequency");
            }
        }

        /// <summary>
        /// Coverage
        /// </summary>
        [JsonProperty("Coverage")]
        public string Coverage 
        { 
            get => coverage;
            set 
            {
                coverage = value;
                OnPropertyChanged("Coverage");
            }
        }
    }
} 