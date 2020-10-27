using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class DataFields : BaseModel 
    {
        // These fields hold the values for the public properties.
        private PersonInfo personInfo;
        private Location location;
        private Communication communication;
        private DriverLicence driverLicence;
        private List<NationalId> nationalIds;
        private Passport passport;
        private Dictionary<string, string> countrySpecific;

        /// <summary>
        /// Personal Information
        /// </summary>
        [JsonProperty("PersonInfo")]
        public PersonInfo PersonInfo 
        { 
            get => personInfo;
            set 
            {
                personInfo = value;
                OnPropertyChanged("PersonInfo");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Location")]
        public Location Location 
        { 
            get => location;
            set 
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Communication")]
        public Communication Communication 
        { 
            get => communication;
            set 
            {
                communication = value;
                OnPropertyChanged("Communication");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("DriverLicence")]
        public DriverLicence DriverLicence 
        { 
            get => driverLicence;
            set 
            {
                driverLicence = value;
                OnPropertyChanged("DriverLicence");
            }
        }

        /// <summary>
        /// National Identification Information
        /// </summary>
        [JsonProperty("NationalIds")]
        public List<NationalId> NationalIds 
        { 
            get => nationalIds;
            set 
            {
                nationalIds = value;
                OnPropertyChanged("NationalIds");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Passport")]
        public Passport Passport 
        { 
            get => passport;
            set 
            {
                passport = value;
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
            get => countrySpecific;
            set 
            {
                countrySpecific = value;
                OnPropertyChanged("CountrySpecific");
            }
        }
    }
} 