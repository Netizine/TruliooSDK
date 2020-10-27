
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class RecordRule : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string ruleName;
        private string note;

        /// <summary>
        /// Name of RecordRule.
        /// </summary>
        [JsonProperty("RuleName")]
        public string RuleName 
        { 
            get => ruleName;
            set 
            {
                ruleName = value;
                OnPropertyChanged("RuleName");
            }
        }

        /// <summary>
        /// Rule Description.
        /// </summary>
        [JsonProperty("Note")]
        public string Note 
        { 
            get => note;
            set 
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }
    }
} 