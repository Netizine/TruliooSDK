using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Address : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string unitNumber;
        private string buildingNumber;
        private string buildingName;
        private string streetName;
        private string streetType;
        private string city;
        private string suburb;
        private string stateProvinceCode;
        private string postalCode;
        private string address1;
        private string addressType;
        private string stateProvince;

        /// <summary>
        /// Flat/Unit/Apartment number of address
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
        /// House / Civic / Building number of address
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
        /// Name of building
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
        /// Street name
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
        /// Street type of address (Typically St, Rd etc)
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
        /// City
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
        /// Suburb / Subdivision / Municipality
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
        /// State or province of address. US sources expect 2 characters. Australian sources expect 2 or 3 characters.
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
        /// ZIP Code or Postal Code
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
        /// It can be used to pass a compiled address field instead of sending individual address attributes (such as UnitNumber, BuildingNumber, BuildingName, StreetName and StreetType)
        /// </summary>
        [JsonProperty("Address1")]
        public string Address1 
        { 
            get => address1;
            set 
            {
                address1 = value;
                OnPropertyChanged("Address1");
            }
        }

        /// <summary>
        /// Type of address
        /// </summary>
        [JsonProperty("AddressType")]
        public string AddressType 
        { 
            get => addressType;
            set 
            {
                addressType = value;
                OnPropertyChanged("AddressType");
            }
        }

        /// <summary>
        /// State or province of address
        /// </summary>
        [JsonProperty("StateProvince")]
        public string StateProvince 
        { 
            get => stateProvince;
            set 
            {
                stateProvince = value;
                OnPropertyChanged("StateProvince");
            }
        }
    }
} 