
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class NationalId : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _number;
        private string _type;
        private string _districtOfIssue;
        private string _cityOfIssue;
        private string _provinceOfIssue;
        private string _countyOfIssue;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Number")]
        public string Number 
        { 
            get => _number;
            set 
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        /// <summary>
        /// Supported Types: NationalID, Health, SocialService, TaxIDNumber.
        /// </summary>
        [JsonProperty("Type")]
        public string Type 
        { 
            get => _type;
            set 
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        /// <summary>
        /// District that issued the ID.
        /// </summary>
        [JsonProperty("DistrictOfIssue")]
        public string DistrictOfIssue 
        { 
            get => _districtOfIssue;
            set 
            {
                _districtOfIssue = value;
                OnPropertyChanged("DistrictOfIssue");
            }
        }

        /// <summary>
        /// City that issued the ID.
        /// </summary>
        [JsonProperty("CityOfIssue")]
        public string CityOfIssue 
        { 
            get => _cityOfIssue;
            set 
            {
                _cityOfIssue = value;
                OnPropertyChanged("CityOfIssue");
            }
        }

        /// <summary>
        /// Province that issued the ID.
        /// </summary>
        [JsonProperty("ProvinceOfIssue")]
        public string ProvinceOfIssue 
        { 
            get => _provinceOfIssue;
            set 
            {
                _provinceOfIssue = value;
                OnPropertyChanged("ProvinceOfIssue");
            }
        }

        /// <summary>
        /// County that issued the ID.
        /// </summary>
        [JsonProperty("CountyOfIssue")]
        public string CountyOfIssue 
        { 
            get => _countyOfIssue;
            set 
            {
                _countyOfIssue = value;
                OnPropertyChanged("CountyOfIssue");
            }
        }
    }
} 