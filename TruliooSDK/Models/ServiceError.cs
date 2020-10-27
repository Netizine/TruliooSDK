
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class ServiceError : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string code;
        private string message;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Code")]
        public string Code 
        { 
            get => code;
            set 
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Message")]
        public string Message 
        { 
            get => message;
            set 
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
    }
} 