
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DriverLicence : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string number;
        private string state;
        private int? dayOfExpiry;
        private int? monthOfExpiry;
        private int? yearOfExpiry;

        /// <summary>
        /// Driver's Licence Number of the individual to be verified.
        /// </summary>
        [JsonProperty("Number")]
        public string Number 
        { 
            get => number;
            set 
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        /// <summary>
        /// State of issue for driver's Licence.
        /// </summary>
        [JsonProperty("State")]
        public string State 
        { 
            get => state;
            set 
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        /// <summary>
        /// Driver's Licence day of expiry of the individual to be verified.
        /// </summary>
        [JsonProperty("DayOfExpiry")]
        public int? DayOfExpiry 
        { 
            get => dayOfExpiry;
            set 
            {
                dayOfExpiry = value;
                OnPropertyChanged("DayOfExpiry");
            }
        }

        /// <summary>
        /// Driver's Licence month of expiry of the individual to be verified.
        /// </summary>
        [JsonProperty("MonthOfExpiry")]
        public int? MonthOfExpiry 
        { 
            get => monthOfExpiry;
            set 
            {
                monthOfExpiry = value;
                OnPropertyChanged("MonthOfExpiry");
            }
        }

        /// <summary>
        /// Driver's Licence year of expiry of the individual to be verified.
        /// </summary>
        [JsonProperty("YearOfExpiry")]
        public int? YearOfExpiry 
        { 
            get => yearOfExpiry;
            set 
            {
                yearOfExpiry = value;
                OnPropertyChanged("YearOfExpiry");
            }
        }
    }
} 