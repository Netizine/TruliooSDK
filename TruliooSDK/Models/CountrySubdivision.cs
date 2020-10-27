using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class CountrySubdivision : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string name;
        private string code;
        private string parentCode;

        /// <summary>
        /// Name of the area, in english or one of the languages of the country
        /// </summary>
        [JsonProperty("Name")]
        public string Name 
        { 
            get => name;
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Code for the area
        /// </summary>
        [JsonProperty("Code")]
        public string Code 
        { 
            get => code;
            set 
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        /// <summary>
        /// Code of the parent entity
        /// </summary>
        [JsonProperty("ParentCode")]
        public string ParentCode 
        { 
            get => parentCode;
            set 
            {
                parentCode = value;
                OnPropertyChanged("ParentCode");
            }
        }
    }
} 