
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DriverLicence : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _number;
        private string _state;
        private int? _dayOfExpiry;
        private int? _monthOfExpiry;
        private int? _yearOfExpiry;

        /// <summary>
        /// Driver's Licence Number of the individual to be verified.
        /// </summary>
        [JsonProperty("Number")]
        public string Number 
        { 
            get => _number;
            set 
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        /// <summary>
        /// State of issue for driver's Licence.
        /// </summary>
        [JsonProperty("State")]
        public string State 
        { 
            get => _state;
            set 
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        /// <summary>
        /// Driver's Licence day of expiry of the individual to be verified.
        /// </summary>
        [JsonProperty("DayOfExpiry")]
        public int? DayOfExpiry 
        { 
            get => _dayOfExpiry;
            set 
            {
                _dayOfExpiry = value;
                OnPropertyChanged("DayOfExpiry");
            }
        }

        /// <summary>
        /// Driver's Licence month of expiry of the individual to be verified.
        /// </summary>
        [JsonProperty("MonthOfExpiry")]
        public int? MonthOfExpiry 
        { 
            get => _monthOfExpiry;
            set 
            {
                _monthOfExpiry = value;
                OnPropertyChanged("MonthOfExpiry");
            }
        }

        /// <summary>
        /// Driver's Licence year of expiry of the individual to be verified.
        /// </summary>
        [JsonProperty("YearOfExpiry")]
        public int? YearOfExpiry 
        { 
            get => _yearOfExpiry;
            set 
            {
                _yearOfExpiry = value;
                OnPropertyChanged("YearOfExpiry");
            }
        }
    }
} 