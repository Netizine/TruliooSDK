using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DataFieldsKYC : BaseModel 
    {
        // These fields hold the values for the public properties.
        private PersonInfo _personInfo;
        private Location _location;
        private Communication _communication;
        private DriverLicence _driverLicence;
        private List<NationalId> _nationalIds;
        private Passport _passport;
        private Dictionary<string, string> _countrySpecific;

        /// <summary>
        /// Personal Information
        /// </summary>
        [JsonProperty("PersonInfo")]
        public PersonInfo PersonInfo 
        { 
            get => _personInfo;
            set 
            {
                _personInfo = value;
                OnPropertyChanged("PersonInfo");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Location")]
        public Location Location 
        { 
            get => _location;
            set 
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Communication")]
        public Communication Communication 
        { 
            get => _communication;
            set 
            {
                _communication = value;
                OnPropertyChanged("Communication");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DriverLicence")]
        public DriverLicence DriverLicence 
        { 
            get => _driverLicence;
            set 
            {
                _driverLicence = value;
                OnPropertyChanged("DriverLicence");
            }
        }

        /// <summary>
        /// National Identification Information.
        /// Supported Types: NationalID, Health, SocialService, TaxIDNumber.
        ///  See <a class="link-to-api" href="https://developer.trulioo.com/docs/national-ids-supported-types">Supported NationalIDs</a> to understand the Type to send with the ID number.
        /// </summary>
        [JsonProperty("NationalIds")]
        public List<NationalId> NationalIds 
        { 
            get => _nationalIds;
            set 
            {
                _nationalIds = value;
                OnPropertyChanged("NationalIds");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Passport")]
        public Passport Passport 
        { 
            get => _passport;
            set 
            {
                _passport = value;
                OnPropertyChanged("Passport");
            }
        }

        /// <summary>
        /// CountrySpecific fields
        /// "CountryCode": {
        /// 	"Field1" : "Value",
        /// 	"Field2" : "Value"
        /// } 
        /// Call <a class="link-to-api" href="#getfields-2">Get Fields</a> to get the list of fields that are valid for your configuration.
        /// </summary>
        [JsonProperty("CountrySpecific")]
        public Dictionary<string, string> CountrySpecific 
        { 
            get => _countrySpecific;
            set 
            {
                _countrySpecific = value;
                OnPropertyChanged("CountrySpecific");
            }
        }
    }
} 