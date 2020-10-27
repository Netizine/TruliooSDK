
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TruliooSDK.Models
{
    public class VerifyResult : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string transactionId;
        private DateTime? uploadedDt;
        private string countryCode;
        private string productName;
        private Record record;
        private string customerReferenceId;
        private List<ServiceError> errors;

        /// <summary>
        /// The id for the transaction it will be a GUID.
        /// </summary>
        [JsonProperty("TransactionID")]
        public string TransactionId 
        { 
            get => transactionId;
            set 
            {
                transactionId = value;
                OnPropertyChanged("TransactionID");
            }
        }

        /// <summary>
        /// Time in UTC.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("UploadedDt")]
        public DateTime? UploadedDt 
        { 
            get => uploadedDt;
            set 
            {
                uploadedDt = value;
                OnPropertyChanged("UploadedDt");
            }
        }

        /// <summary>
        /// Country Code
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
        /// Product Name
        /// </summary>
        [JsonProperty("ProductName")]
        public string ProductName 
        { 
            get => productName;
            set 
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Record")]
        public Record Record 
        { 
            get => record;
            set 
            {
                record = value;
                OnPropertyChanged("Record");
            }
        }

        /// <summary>
        /// Customer Reference ID
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
        /// See <a class="link-to-api" href="#section-service-errors">Errors</a> for explanation of any error encountered.
        /// </summary>
        [JsonProperty("Errors")]
        public List<ServiceError> Errors 
        { 
            get => errors;
            set 
            {
                errors = value;
                OnPropertyChanged("Errors");
            }
        }
    }
} 