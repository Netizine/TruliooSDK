
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TruliooSDK.Models
{
    public class TransactionRecordResult : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _transactionId;
        private DateTime? _uploadedDt;
        private string _countryCode;
        private string _productName;
        private Record _record;
        private string _customerReferenceId;
        private List<ServiceError> _errors;
        private List<DataField> _inputFields;

        /// <summary>
        /// The id for the transaction it will be a GUID.
        /// </summary>
        [JsonProperty("TransactionID")]
        public string TransactionId 
        { 
            get => _transactionId;
            set 
            {
                _transactionId = value;
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
            get => _uploadedDt;
            set 
            {
                _uploadedDt = value;
                OnPropertyChanged("UploadedDt");
            }
        }

        /// <summary>
        /// Country Code
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
        /// Product Name
        /// </summary>
        [JsonProperty("ProductName")]
        public string ProductName 
        { 
            get => _productName;
            set 
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Record")]
        public Record Record 
        { 
            get => _record;
            set 
            {
                _record = value;
                OnPropertyChanged("Record");
            }
        }

        /// <summary>
        /// Customer Reference ID
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
        /// See <a class="link-to-api" href="#section-service-errors">Errors</a> for explanation of any error encountered.
        /// </summary>
        [JsonProperty("Errors")]
        public List<ServiceError> Errors 
        { 
            get => _errors;
            set 
            {
                _errors = value;
                OnPropertyChanged("Errors");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("InputFields")]
        public List<DataField> InputFields 
        { 
            get => _inputFields;
            set 
            {
                _inputFields = value;
                OnPropertyChanged("InputFields");
            }
        }
    }
} 