using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Consent : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _name;
        private string _text;
        private string _url;

        /// <summary>
        /// Name of the data source requiring consent
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
        /// Text outlining how the user is consenting for their data to be used
        /// </summary>
        [JsonProperty("Text")]
        public string Text 
        { 
            get => _text;
            set 
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        /// <summary>
        /// URL where the user can find more information about how the data source will use their data
        /// </summary>
        [JsonProperty("Url")]
        public string Url 
        { 
            get => _url;
            set 
            {
                _url = value;
                OnPropertyChanged("Url");
            }
        }
    }
} 