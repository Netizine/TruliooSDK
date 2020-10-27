
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class ServiceError : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _code;
        private string _message;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Code")]
        public string Code 
        { 
            get => _code;
            set 
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Message")]
        public string Message 
        { 
            get => _message;
            set 
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
    }
} 