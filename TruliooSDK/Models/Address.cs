using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Address : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _unitNumber;
        private string _buildingNumber;
        private string _buildingName;
        private string _streetName;
        private string _streetType;
        private string _city;
        private string _suburb;
        private string _stateProvinceCode;
        private string _postalCode;
        private string _address1;
        private string _addressType;
        private string _stateProvince;

        /// <summary>
        /// Flat/Unit/Apartment number of address
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
        /// House / Civic / Building number of address
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
        /// Name of building
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
        /// Street name
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
        /// Street type of address (Typically St, Rd etc)
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
        /// City
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
        /// Suburb / Subdivision / Municipality
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
        /// State or province of address. US sources expect 2 characters. Australian sources expect 2 or 3 characters.
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
        /// ZIP Code or Postal Code
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
        /// It can be used to pass a compiled address field instead of sending individual address attributes (such as UnitNumber, BuildingNumber, BuildingName, StreetName and StreetType)
        /// </summary>
        [JsonProperty("Address1")]
        public string Address1 
        { 
            get => _address1;
            set 
            {
                _address1 = value;
                OnPropertyChanged("Address1");
            }
        }

        /// <summary>
        /// Type of address
        /// </summary>
        [JsonProperty("AddressType")]
        public string AddressType 
        { 
            get => _addressType;
            set 
            {
                _addressType = value;
                OnPropertyChanged("AddressType");
            }
        }

        /// <summary>
        /// State or province of address
        /// </summary>
        [JsonProperty("StateProvince")]
        public string StateProvince 
        { 
            get => _stateProvince;
            set 
            {
                _stateProvince = value;
                OnPropertyChanged("StateProvince");
            }
        }
    }
} 