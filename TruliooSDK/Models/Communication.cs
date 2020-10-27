using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Communication : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _mobileNumber;
        private string _telephone;
        private string _telephone2;
        private string _emailAddress;

        /// <summary>
        /// Mobile phone number of the individual to be verified.
        /// </summary>
        [JsonProperty("MobileNumber")]
        public string MobileNumber 
        { 
            get => _mobileNumber;
            set 
            {
                _mobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        /// <summary>
        /// Telephone number of the individual to be verified.
        /// </summary>
        [JsonProperty("Telephone")]
        public string Telephone 
        { 
            get => _telephone;
            set 
            {
                _telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        /// <summary>
        /// Additional Phone/Mobile Number of the individual to be verified.
        /// </summary>
        [JsonProperty("Telephone2")]
        public string Telephone2 
        { 
            get => _telephone2;
            set 
            {
                _telephone2 = value;
                OnPropertyChanged("Telephone2");
            }
        }

        /// <summary>
        /// Email address of the individual to be verified.
        /// </summary>
        [JsonProperty("EmailAddress")]
        public string EmailAddress 
        { 
            get => _emailAddress;
            set 
            {
                _emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }
    }
} 