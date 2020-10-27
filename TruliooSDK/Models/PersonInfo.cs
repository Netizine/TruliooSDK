
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class PersonInfo : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _firstGivenName;
        private string _middleName;
        private string _firstSurName;
        private string _secondSurname;
        private string _iSoLatin1Name;
        private int? _dayOfBirth;
        private int? _monthOfBirth;
        private int? _yearOfBirth;
        private int? _minimumAge;
        private string _gender;
        private PersonInfoAdditionalFields _additionalFields;

        /// <summary>
        /// First name of the individual to be verified. Dual purpose First Name or Initial.
        /// </summary>
        [JsonProperty("FirstGivenName")]
        public string FirstGivenName 
        { 
            get => _firstGivenName;
            set 
            {
                _firstGivenName = value;
                OnPropertyChanged("FirstGivenName");
            }
        }

        /// <summary>
        /// Second given name of the individual to be verified. Dual purpose Middle Name or Initial.
        /// </summary>
        [JsonProperty("MiddleName")]
        public string MiddleName 
        { 
            get => _middleName;
            set 
            {
                _middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// First (paternal) family name of the individual to be verified.
        /// </summary>
        [JsonProperty("FirstSurName")]
        public string FirstSurName 
        { 
            get => _firstSurName;
            set 
            {
                _firstSurName = value;
                OnPropertyChanged("FirstSurName");
            }
        }

        /// <summary>
        /// Second family name of the individual to be verified.
        /// </summary>
        [JsonProperty("SecondSurname")]
        public string SecondSurname 
        { 
            get => _secondSurname;
            set 
            {
                _secondSurname = value;
                OnPropertyChanged("SecondSurname");
            }
        }

        /// <summary>
        /// Enter full name in ISO Latin-1 character set. Used for data sources that require the person’s name in ISO Latin-1 format (i.e. as Passport MRZ).
        /// </summary>
        [JsonProperty("ISOLatin1Name")]
        public string ISOLatin1Name 
        { 
            get => _iSoLatin1Name;
            set 
            {
                _iSoLatin1Name = value;
                OnPropertyChanged("ISOLatin1Name");
            }
        }

        /// <summary>
        /// Day of birth date (i.e. 23 for a date of birth of 23/11/1975).
        /// </summary>
        [JsonProperty("DayOfBirth")]
        public int? DayOfBirth 
        { 
            get => _dayOfBirth;
            set 
            {
                _dayOfBirth = value;
                OnPropertyChanged("DayOfBirth");
            }
        }

        /// <summary>
        /// Month of birth date (i.e. 11 for a date of birth of 23/11/1975).
        /// </summary>
        [JsonProperty("MonthOfBirth")]
        public int? MonthOfBirth 
        { 
            get => _monthOfBirth;
            set 
            {
                _monthOfBirth = value;
                OnPropertyChanged("MonthOfBirth");
            }
        }

        /// <summary>
        /// Year of birth date (i.e. 1975 for a date of birth of 23/11/1975).
        /// </summary>
        [JsonProperty("YearOfBirth")]
        public int? YearOfBirth 
        { 
            get => _yearOfBirth;
            set 
            {
                _yearOfBirth = value;
                OnPropertyChanged("YearOfBirth");
            }
        }

        /// <summary>
        /// Minimum permitted age of the individual. GlobalGateway calculates age of individual and compares it to this number.
        /// </summary>
        [JsonProperty("MinimumAge")]
        public int? MinimumAge 
        { 
            get => _minimumAge;
            set 
            {
                _minimumAge = value;
                OnPropertyChanged("MinimumAge");
            }
        }

        /// <summary>
        /// Single character M / F (M = Male, F = Female).
        /// </summary>
        [JsonProperty("Gender")]
        public string Gender 
        { 
            get => _gender;
            set 
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("AdditionalFields")]
        public PersonInfoAdditionalFields AdditionalFields 
        { 
            get => _additionalFields;
            set 
            {
                _additionalFields = value;
                OnPropertyChanged("AdditionalFields");
            }
        }
    }
} 