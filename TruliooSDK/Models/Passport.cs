
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Passport : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string mrz1;
        private string mrz2;
        private string number;
        private int? dayOfExpiry;
        private int? monthOfExpiry;
        private int? yearOfExpiry;

        /// <summary>
        /// Line 1 of the passport MRZ.
        /// </summary>
        [JsonProperty("Mrz1")]
        public string Mrz1 
        { 
            get => mrz1;
            set 
            {
                mrz1 = value;
                OnPropertyChanged("Mrz1");
            }
        }

        /// <summary>
        /// Line 2 of the passport MRZ.
        /// </summary>
        [JsonProperty("Mrz2")]
        public string Mrz2 
        { 
            get => mrz2;
            set 
            {
                mrz2 = value;
                OnPropertyChanged("Mrz2");
            }
        }

        /// <summary>
        /// Passport Number.
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
        /// Passport's Licence day of expiry of the individual to be verified.
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
        /// Passport's Licence month of expiry of the individual to be verified.
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
        /// Passport's Licence year of expiry of the individual to be verified.
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