
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Location : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _buildingNumber;
        private string _buildingName;
        private string _unitNumber;
        private string _streetName;
        private string _streetType;
        private string _city;
        private string _suburb;
        private string _county;
        private string _stateProvinceCode;
        private string _country;
        private string _postalCode;
        private string _pOBox;
        private LocationAdditionalFields _additionalFields;

        /// <summary>
        /// House / Civic / Building number of home address.
        /// </summary>
        [JsonProperty("BuildingNumber")]
        public string BuildingNumber 
        { 
            get => _buildingNumber;
            set 
            {
                _buildingNumber = value;
                OnPropertyChanged("BuildingNumber");
            }
        }

        /// <summary>
        /// Name of building of home address.
        /// </summary>
        [JsonProperty("BuildingName")]
        public string BuildingName 
        { 
            get => _buildingName;
            set 
            {
                _buildingName = value;
                OnPropertyChanged("BuildingName");
            }
        }

        /// <summary>
        /// Flat/Unit/Apartment number of home address.
        /// </summary>
        [JsonProperty("UnitNumber")]
        public string UnitNumber 
        { 
            get => _unitNumber;
            set 
            {
                _unitNumber = value;
                OnPropertyChanged("UnitNumber");
            }
        }

        /// <summary>
        /// Street name of home address.
        /// </summary>
        [JsonProperty("StreetName")]
        public string StreetName 
        { 
            get => _streetName;
            set 
            {
                _streetName = value;
                OnPropertyChanged("StreetName");
            }
        }

        /// <summary>
        /// Street type of home address (Typically St, Rd etc).
        /// </summary>
        [JsonProperty("StreetType")]
        public string StreetType 
        { 
            get => _streetType;
            set 
            {
                _streetType = value;
                OnPropertyChanged("StreetType");
            }
        }

        /// <summary>
        /// City of home address.
        /// </summary>
        [JsonProperty("City")]
        public string City 
        { 
            get => _city;
            set 
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Suburb / Subdivision / Municipality of home address.
        /// </summary>
        [JsonProperty("Suburb")]
        public string Suburb 
        { 
            get => _suburb;
            set 
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }

        /// <summary>
        /// County / District of home address.
        /// </summary>
        [JsonProperty("County")]
        public string County 
        { 
            get => _county;
            set 
            {
                _county = value;
                OnPropertyChanged("County");
            }
        }

        /// <summary>
        /// State of home address. US sources expect 2 characters. Australian sources expect 2 or 3 characters. Can be gotten using the <a class="link-to-api" href="#get-country-subdivisions">Get Country Subdivisions</a> call.
        /// </summary>
        [JsonProperty("StateProvinceCode")]
        public string StateProvinceCode 
        { 
            get => _stateProvinceCode;
            set 
            {
                _stateProvinceCode = value;
                OnPropertyChanged("StateProvinceCode");
            }
        }

        /// <summary>
        /// Country of home address (ISO 3166-1 alpha-2 code).
        /// </summary>
        [JsonProperty("Country")]
        public string Country 
        { 
            get => _country;
            set 
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }

        /// <summary>
        /// ZIP Code or Postal Code of home address.
        /// </summary>
        [JsonProperty("PostalCode")]
        public string PostalCode 
        { 
            get => _postalCode;
            set 
            {
                _postalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        /// <summary>
        /// Post Office Box.
        /// </summary>
        [JsonProperty("POBox")]
        public string PoBox 
        { 
            get => _pOBox;
            set 
            {
                _pOBox = value;
                OnPropertyChanged("POBox");
            }
        }

        /// <summary>
        /// Additional Fields for Location
        /// </summary>
        [JsonProperty("AdditionalFields")]
        public LocationAdditionalFields AdditionalFields 
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