
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class VerifyRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private bool? _acceptTruliooTermsAndConditions;
        private string _callBackUrl;
        private int? _timeout;
        private bool? _cleansedAddress;
        private string _configurationName;
        private List<string> _consentForDataSources;
        private string _countryCode;
        private string _customerReferenceId;
        private DataFields _dataFields;
        private bool? _verboseMode;

        /// <summary>
        /// Indicate that Trulioo terms and conditions are accepted.
        /// The Verification request will be executed only if the value of this header is passed as 'true'.
        /// </summary>
        [JsonProperty("AcceptTruliooTermsAndConditions")]
        public bool? AcceptTruliooTermsAndConditions 
        { 
            get => _acceptTruliooTermsAndConditions;
            set 
            {
                _acceptTruliooTermsAndConditions = value;
                OnPropertyChanged("AcceptTruliooTermsAndConditions");
            }
        }

        /// <summary>
        /// If set, the transaction will run asyncronously and trulioo will try to update the client with transaction state updates until completed.
        /// </summary>
        [JsonProperty("CallBackUrl")]
        public string CallBackUrl 
        { 
            get => _callBackUrl;
            set 
            {
                _callBackUrl = value;
                OnPropertyChanged("CallBackUrl");
            }
        }

        /// <summary>
        /// If set, trulioo will try to update the client syncronously within the timeout in seconds. If failed to accomplish, the transaction will be canceled.
        /// </summary>
        [JsonProperty("Timeout")]
        public int? Timeout 
        { 
            get => _timeout;
            set 
            {
                _timeout = value;
                OnPropertyChanged("Timeout");
            }
        }

        /// <summary>
        /// Set to true if you want to receive address cleanse information. This will only change the response if you have address cleansing enabled for the country you are querying for.
        /// </summary>
        [JsonProperty("CleansedAddress")]
        public bool? CleansedAddress 
        { 
            get => _cleansedAddress;
            set 
            {
                _cleansedAddress = value;
                OnPropertyChanged("CleansedAddress");
            }
        }

        /// <summary>
        /// Indicate the configuration used for the verification. Currently only 'Identity Verification' is supported.
        /// Default value will be "Identity Verification"
        /// </summary>
        [JsonProperty("ConfigurationName")]
        public string ConfigurationName 
        { 
            get => _configurationName;
            set 
            {
                _configurationName = value;
                OnPropertyChanged("ConfigurationName");
            }
        }

        /// <summary>
        /// Some datasources require your customer provide consent to access them. For each datasource that requires consent, send the requred string if your customer has provided it. A list of these required strings for a country can be gotten by the <a class="link-to-api" href="#get-consents">Get Consents</a> call. If consent is not provided the datasource will not be queried.
        /// </summary>
        [JsonProperty("ConsentForDataSources")]
        public List<string> ConsentForDataSources 
        { 
            get => _consentForDataSources;
            set 
            {
                _consentForDataSources = value;
                OnPropertyChanged("ConsentForDataSources");
            }
        }

        /// <summary>
        /// Country alpha2 code
        /// </summary>
        [JsonProperty("CountryCode")]
        public string CountryCode 
        { 
            get => _countryCode;
            set 
            {
                _countryCode = value;
                OnPropertyChanged("CountryCode");
            }
        }

        /// <summary>
        /// Use this field to send any internal reference ID to GlobalGateway. It will be contained in the response so it is simple to link Trulioo's API to your system.
        /// </summary>
        [JsonProperty("CustomerReferenceID")]
        public string CustomerReferenceId 
        { 
            get => _customerReferenceId;
            set 
            {
                _customerReferenceId = value;
                OnPropertyChanged("CustomerReferenceID");
            }
        }

        /// <summary>
        /// The data field name-value pairs for the data elements on which the verification is to be performed
        /// </summary>
        [JsonProperty("DataFields")]
        public DataFields DataFields 
        { 
            get => _dataFields;
            set 
            {
                _dataFields = value;
                OnPropertyChanged("DataFields");
            }
        }

        /// <summary>
        /// Verbose Mode Output Flag.
        /// </summary>
        [JsonProperty("VerboseMode")]
        public bool? VerboseMode 
        { 
            get => _verboseMode;
            set 
            {
                _verboseMode = value;
                OnPropertyChanged("VerboseMode");
            }
        }
    }
} 
