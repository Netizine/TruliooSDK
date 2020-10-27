using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Communication : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string mobileNumber;
        private string telephone;
        private string telephone2;
        private string emailAddress;

        /// <summary>
        /// Mobile phone number of the individual to be verified.
        /// </summary>
        [JsonProperty("MobileNumber")]
        public string MobileNumber 
        { 
            get => mobileNumber;
            set 
            {
                mobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        /// <summary>
        /// Telephone number of the individual to be verified.
        /// </summary>
        [JsonProperty("Telephone")]
        public string Telephone 
        { 
            get => telephone;
            set 
            {
                telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        /// <summary>
        /// Additional Phone/Mobile Number of the individual to be verified.
        /// </summary>
        [JsonProperty("Telephone2")]
        public string Telephone2 
        { 
            get => telephone2;
            set 
            {
                telephone2 = value;
                OnPropertyChanged("Telephone2");
            }
        }

        /// <summary>
        /// Email address of the individual to be verified.
        /// </summary>
        [JsonProperty("EmailAddress")]
        public string EmailAddress 
        { 
            get => emailAddress;
            set 
            {
                emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }
    }
} 