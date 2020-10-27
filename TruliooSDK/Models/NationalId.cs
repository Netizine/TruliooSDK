
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class NationalId : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string number;
        private string type;
        private string districtOfIssue;
        private string cityOfIssue;
        private string provinceOfIssue;
        private string countyOfIssue;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Number")]
        public string Number 
        { 
            get => number;
            set 
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        /// <summary>
        /// Supported Types: NationalID, Health, SocialService, TaxIDNumber.
        /// </summary>
        [JsonProperty("Type")]
        public string Type 
        { 
            get => type;
            set 
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        /// <summary>
        /// District that issued the ID.
        /// </summary>
        [JsonProperty("DistrictOfIssue")]
        public string DistrictOfIssue 
        { 
            get => districtOfIssue;
            set 
            {
                districtOfIssue = value;
                OnPropertyChanged("DistrictOfIssue");
            }
        }

        /// <summary>
        /// City that issued the ID.
        /// </summary>
        [JsonProperty("CityOfIssue")]
        public string CityOfIssue 
        { 
            get => cityOfIssue;
            set 
            {
                cityOfIssue = value;
                OnPropertyChanged("CityOfIssue");
            }
        }

        /// <summary>
        /// Province that issued the ID.
        /// </summary>
        [JsonProperty("ProvinceOfIssue")]
        public string ProvinceOfIssue 
        { 
            get => provinceOfIssue;
            set 
            {
                provinceOfIssue = value;
                OnPropertyChanged("ProvinceOfIssue");
            }
        }

        /// <summary>
        /// County that issued the ID.
        /// </summary>
        [JsonProperty("CountyOfIssue")]
        public string CountyOfIssue 
        { 
            get => countyOfIssue;
            set 
            {
                countyOfIssue = value;
                OnPropertyChanged("CountyOfIssue");
            }
        }
    }
} 