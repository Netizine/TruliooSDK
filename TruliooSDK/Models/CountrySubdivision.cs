using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class CountrySubdivision : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _name;
        private string _code;
        private string _parentCode;

        /// <summary>
        /// Name of the area, in english or one of the languages of the country
        /// </summary>
        [JsonProperty("Name")]
        public string Name 
        { 
            get => _name;
            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Code for the area
        /// </summary>
        [JsonProperty("Code")]
        public string Code 
        { 
            get => _code;
            set 
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        /// <summary>
        /// Code of the parent entity
        /// </summary>
        [JsonProperty("ParentCode")]
        public string ParentCode 
        { 
            get => _parentCode;
            set 
            {
                _parentCode = value;
                OnPropertyChanged("ParentCode");
            }
        }
    }
} 