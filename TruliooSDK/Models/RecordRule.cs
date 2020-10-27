
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class RecordRule : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _ruleName;
        private string _note;

        /// <summary>
        /// Name of RecordRule.
        /// </summary>
        [JsonProperty("RuleName")]
        public string RuleName 
        { 
            get => _ruleName;
            set 
            {
                _ruleName = value;
                OnPropertyChanged("RuleName");
            }
        }

        /// <summary>
        /// Rule Description.
        /// </summary>
        [JsonProperty("Note")]
        public string Note 
        { 
            get => _note;
            set 
            {
                _note = value;
                OnPropertyChanged("Note");
            }
        }
    }
} 