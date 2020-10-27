
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Passport : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _mrz1;
        private string _mrz2;
        private string _number;
        private int? _dayOfExpiry;
        private int? _monthOfExpiry;
        private int? _yearOfExpiry;

        /// <summary>
        /// Line 1 of the passport MRZ.
        /// </summary>
        [JsonProperty("Mrz1")]
        public string Mrz1 
        { 
            get => _mrz1;
            set 
            {
                _mrz1 = value;
                OnPropertyChanged("Mrz1");
            }
        }

        /// <summary>
        /// Line 2 of the passport MRZ.
        /// </summary>
        [JsonProperty("Mrz2")]
        public string Mrz2 
        { 
            get => _mrz2;
            set 
            {
                _mrz2 = value;
                OnPropertyChanged("Mrz2");
            }
        }

        /// <summary>
        /// Passport Number.
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
        /// Passport's Licence day of expiry of the individual to be verified.
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
        /// Passport's Licence month of expiry of the individual to be verified.
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
        /// Passport's Licence year of expiry of the individual to be verified.
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