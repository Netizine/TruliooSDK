
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Location : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string buildingNumber;
        private string buildingName;
        private string unitNumber;
        private string streetName;
        private string streetType;
        private string city;
        private string suburb;
        private string county;
        private string stateProvinceCode;
        private string country;
        private string postalCode;
        private string pOBox;
        private LocationAdditionalFields additionalFields;

        /// <summary>
        /// House / Civic / Building number of home address.
        /// </summary>
        [JsonProperty("BuildingNumber")]
        public string BuildingNumber 
        { 
            get => buildingNumber;
            set 
            {
                buildingNumber = value;
                OnPropertyChanged("BuildingNumber");
            }
        }

        /// <summary>
        /// Name of building of home address.
        /// </summary>
        [JsonProperty("BuildingName")]
        public string BuildingName 
        { 
            get => buildingName;
            set 
            {
                buildingName = value;
                OnPropertyChanged("BuildingName");
            }
        }

        /// <summary>
        /// Flat/Unit/Apartment number of home address.
        /// </summary>
        [JsonProperty("UnitNumber")]
        public string UnitNumber 
        { 
            get => unitNumber;
            set 
            {
                unitNumber = value;
                OnPropertyChanged("UnitNumber");
            }
        }

        /// <summary>
        /// Street name of home address.
        /// </summary>
        [JsonProperty("StreetName")]
        public string StreetName 
        { 
            get => streetName;
            set 
            {
                streetName = value;
                OnPropertyChanged("StreetName");
            }
        }

        /// <summary>
        /// Street type of home address (Typically St, Rd etc).
        /// </summary>
        [JsonProperty("StreetType")]
        public string StreetType 
        { 
            get => streetType;
            set 
            {
                streetType = value;
                OnPropertyChanged("StreetType");
            }
        }

        /// <summary>
        /// City of home address.
        /// </summary>
        [JsonProperty("City")]
        public string City 
        { 
            get => city;
            set 
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Suburb / Subdivision / Municipality of home address.
        /// </summary>
        [JsonProperty("Suburb")]
        public string Suburb 
        { 
            get => suburb;
            set 
            {
                suburb = value;
                OnPropertyChanged("Suburb");
            }
        }

        /// <summary>
        /// County / District of home address.
        /// </summary>
        [JsonProperty("County")]
        public string County 
        { 
            get => county;
            set 
            {
                county = value;
                OnPropertyChanged("County");
            }
        }

        /// <summary>
        /// State of home address. US sources expect 2 characters. Australian sources expect 2 or 3 characters. Can be gotten using the <a class="link-to-api" href="#get-country-subdivisions">Get Country Subdivisions</a> call.
        /// </summary>
        [JsonProperty("StateProvinceCode")]
        public string StateProvinceCode 
        { 
            get => stateProvinceCode;
            set 
            {
                stateProvinceCode = value;
                OnPropertyChanged("StateProvinceCode");
            }
        }

        /// <summary>
        /// Country of home address (ISO 3166-1 alpha-2 code).
        /// </summary>
        [JsonProperty("Country")]
        public string Country 
        { 
            get => country;
            set 
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        /// <summary>
        /// ZIP Code or Postal Code of home address.
        /// </summary>
        [JsonProperty("PostalCode")]
        public string PostalCode 
        { 
            get => postalCode;
            set 
            {
                postalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        /// <summary>
        /// Post Office Box.
        /// </summary>
        [JsonProperty("POBox")]
        public string PoBox 
        { 
            get => pOBox;
            set 
            {
                pOBox = value;
                OnPropertyChanged("POBox");
            }
        }

        /// <summary>
        /// Additional Fields for Location
        /// </summary>
        [JsonProperty("AdditionalFields")]
        public LocationAdditionalFields AdditionalFields 
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