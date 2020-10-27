
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class VerifyRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private bool? acceptTruliooTermsAndConditions;
        private string callBackUrl;
        private int? timeout;
        private bool? cleansedAddress;
        private string configurationName;
        private List<string> consentForDataSources;
        private string countryCode;
        private string customerReferenceId;
        private DataFields dataFields;
        private bool? verboseMode;

        /// <summary>
        /// Indicate that Trulioo terms and conditions are accepted.\nThe Verification request will be executed only if the value of this header is passed as 'true'.
        /// </summary>
        [JsonProperty("AcceptTruliooTermsAndConditions")]
        public bool? AcceptTruliooTermsAndConditions 
        { 
            get => acceptTruliooTermsAndConditions;
            set 
            {
                acceptTruliooTermsAndConditions = value;
                OnPropertyChanged("AcceptTruliooTermsAndConditions");
            }
        }

        /// <summary>
        /// If set, the transaction will run asyncronously and trulioo will try to update the client with transaction state updates until completed.
        /// </summary>
        [JsonProperty("CallBackUrl")]
        public string CallBackUrl 
        { 
            get => callBackUrl;
            set 
            {
                callBackUrl = value;
                OnPropertyChanged("CallBackUrl");
            }
        }

        /// <summary>
        /// If set, trulioo will try to update the client syncronously within the timeout in seconds. If failed to accomplish, the transaction will be canceled.
        /// </summary>
        [JsonProperty("Timeout")]
        public int? Timeout 
        { 
            get => timeout;
            set 
            {
                timeout = value;
                OnPropertyChanged("Timeout");
            }
        }

        /// <summary>
        /// Set to true if you want to receive address cleanse information. This will only change the response if you have address cleansing enabled for the country you are querying for.
        /// </summary>
        [JsonProperty("CleansedAddress")]
        public bool? CleansedAddress 
        { 
            get => cleansedAddress;
            set 
            {
                cleansedAddress = value;
                OnPropertyChanged("CleansedAddress");
            }
        }

        /// <summary>
        /// Indicate the configuration used for the verification. Currently only 'Identity Verification' is supported.\nDefault value will be "Identity Verification"
        /// </summary>
        [JsonProperty("ConfigurationName")]
        public string ConfigurationName 
        { 
            get => configurationName;
            set 
            {
                configurationName = value;
                OnPropertyChanged("ConfigurationName");
            }
        }

        /// <summary>
        /// Some datasources require your customer provide consent to access them. For each datasource that requires consent, send the requred string if your customer has provided it. A list of these required strings for a country can be gotten by the <a class="link-to-api" href="#get-consents">Get Consents</a> call. If consent is not provided the datasource will not be queried.
        /// </summary>
        [JsonProperty("ConsentForDataSources")]
        public List<string> ConsentForDataSources 
        { 
            get => consentForDataSources;
            set 
            {
                consentForDataSources = value;
                OnPropertyChanged("ConsentForDataSources");
            }
        }

        /// <summary>
        /// Country alpha2 code
        /// </summary>
        [JsonProperty("CountryCode")]
        public string CountryCode 
        { 
            get => countryCode;
            set 
            {
                countryCode = value;
                OnPropertyChanged("CountryCode");
            }
        }

        /// <summary>
        /// Use this field to send any internal reference ID to GlobalGateway. It will be contained in the response so it is simple to link Trulioo's API to your system.
        /// </summary>
        [JsonProperty("CustomerReferenceID")]
        public string CustomerReferenceId 
        { 
            get => customerReferenceId;
            set 
            {
                customerReferenceId = value;
                OnPropertyChanged("CustomerReferenceID");
            }
        }

        /// <summary>
        /// The data field name-value pairs for the data elements on which the verification is to be performed
        /// </summary>
        [JsonProperty("DataFields")]
        public DataFields DataFields 
        { 
            get => dataFields;
            set 
            {
                dataFields = value;
                OnPropertyChanged("DataFields");
            }
        }

        /// <summary>
        /// Verbose Mode Output Flag.
        /// </summary>
        [JsonProperty("VerboseMode")]
        public bool? VerboseMode 
        { 
            get => verboseMode;
            set 
            {
                verboseMode = value;
                OnPropertyChanged("VerboseMode");
            }
        }
    }
} 