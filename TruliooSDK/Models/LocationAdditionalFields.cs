
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class LocationAdditionalFields : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string address1;

        /// <summary>
        /// Address1 is available in certain countries. It can be used to pass a compiled address field instead of sending individual address attributes (such as UnitNumber, BuidlingNumber, BuildingName, StreetName and StreetType). 
        /// GlobalGateway will provide a pass through of Address1 directly to connected datasources for the selected country. 
        /// Please note: each datasource requires the address fields to be configured in a certain manner, implementing and sending Address1 instead of individual address fields may affect your ability to verify this address.
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
    }
} 