
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class PersonInfo : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string firstGivenName;
        private string middleName;
        private string firstSurName;
        private string secondSurname;
        private string iSoLatin1Name;
        private int? dayOfBirth;
        private int? monthOfBirth;
        private int? yearOfBirth;
        private int? minimumAge;
        private string gender;
        private PersonInfoAdditionalFields additionalFields;

        /// <summary>
        /// First name of the individual to be verified. Dual purpose First Name or Initial.
        /// </summary>
        [JsonProperty("FirstGivenName")]
        public string FirstGivenName 
        { 
            get => firstGivenName;
            set 
            {
                firstGivenName = value;
                OnPropertyChanged("FirstGivenName");
            }
        }

        /// <summary>
        /// Second given name of the individual to be verified. Dual purpose Middle Name or Initial.
        /// </summary>
        [JsonProperty("MiddleName")]
        public string MiddleName 
        { 
            get => middleName;
            set 
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// First (paternal) family name of the individual to be verified.
        /// </summary>
        [JsonProperty("FirstSurName")]
        public string FirstSurName 
        { 
            get => firstSurName;
            set 
            {
                firstSurName = value;
                OnPropertyChanged("FirstSurName");
            }
        }

        /// <summary>
        /// Second family name of the individual to be verified.
        /// </summary>
        [JsonProperty("SecondSurname")]
        public string SecondSurname 
        { 
            get => secondSurname;
            set 
            {
                secondSurname = value;
                OnPropertyChanged("SecondSurname");
            }
        }

        /// <summary>
        /// Enter full name in ISO Latin-1 character set. Used for data sources that require the person’s name in ISO Latin-1 format (i.e. as Passport MRZ).
        /// </summary>
        [JsonProperty("ISOLatin1Name")]
        public string ISOLatin1Name 
        { 
            get => iSoLatin1Name;
            set 
            {
                iSoLatin1Name = value;
                OnPropertyChanged("ISOLatin1Name");
            }
        }

        /// <summary>
        /// Day of birth date (i.e. 23 for a date of birth of 23/11/1975).
        /// </summary>
        [JsonProperty("DayOfBirth")]
        public int? DayOfBirth 
        { 
            get => dayOfBirth;
            set 
            {
                dayOfBirth = value;
                OnPropertyChanged("DayOfBirth");
            }
        }

        /// <summary>
        /// Month of birth date (i.e. 11 for a date of birth of 23/11/1975).
        /// </summary>
        [JsonProperty("MonthOfBirth")]
        public int? MonthOfBirth 
        { 
            get => monthOfBirth;
            set 
            {
                monthOfBirth = value;
                OnPropertyChanged("MonthOfBirth");
            }
        }

        /// <summary>
        /// Year of birth date (i.e. 1975 for a date of birth of 23/11/1975).
        /// </summary>
        [JsonProperty("YearOfBirth")]
        public int? YearOfBirth 
        { 
            get => yearOfBirth;
            set 
            {
                yearOfBirth = value;
                OnPropertyChanged("YearOfBirth");
            }
        }

        /// <summary>
        /// Minimum permitted age of the individual. GlobalGateway calculates age of individual and compares it to this number.
        /// </summary>
        [JsonProperty("MinimumAge")]
        public int? MinimumAge 
        { 
            get => minimumAge;
            set 
            {
                minimumAge = value;
                OnPropertyChanged("MinimumAge");
            }
        }

        /// <summary>
        /// Single character M / F (M = Male, F = Female).
        /// </summary>
        [JsonProperty("Gender")]
        public string Gender 
        { 
            get => gender;
            set 
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("AdditionalFields")]
        public PersonInfoAdditionalFields AdditionalFields 
        { 
            get => additionalFields;
            set 
            {
                additionalFields = value;
                OnPropertyChanged("AdditionalFields");
            }
        }
    }
} 