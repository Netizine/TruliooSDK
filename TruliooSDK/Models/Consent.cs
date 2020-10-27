using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Consent : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string name;
        private string text;
        private string url;

        /// <summary>
        /// Name of the data source requiring consent
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
        /// Text outlining how the user is consenting for their data to be used
        /// </summary>
        [JsonProperty("Text")]
        public string Text 
        { 
            get => text;
            set 
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        /// <summary>
        /// URL where the user can find more information about how the data source will use their data
        /// </summary>
        [JsonProperty("Url")]
        public string Url 
        { 
            get => url;
            set 
            {
                url = value;
                OnPropertyChanged("Url");
            }
        }
    }
} 