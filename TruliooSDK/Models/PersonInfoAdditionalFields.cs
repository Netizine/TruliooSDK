
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class PersonInfoAdditionalFields : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string fullName;

        /// <summary>
        /// Full name of the individual to be verified.
        /// </summary>
        [JsonProperty("FullName")]
        public string FullName 
        { 
            get => fullName;
            set 
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }
    }
} 