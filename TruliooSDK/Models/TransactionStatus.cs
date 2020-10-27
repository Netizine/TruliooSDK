
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TruliooSDK.Models
{
    public class TransactionStatus : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string transactionId;
        private string transactionRecordId;
        private string status;
        private DateTime? uploadedDt;
        private bool? isTimedOut;

        /// <summary>
        /// Transaction ID of the transaction.
        /// </summary>
        [JsonProperty("TransactionId")]
        public string TransactionId 
        { 
            get => transactionId;
            set 
            {
                transactionId = value;
                OnPropertyChanged("TransactionId");
            }
        }

        /// <summary>
        /// Transaction Record ID of the transaction available once the transaction has finished processing.
        /// </summary>
        [JsonProperty("TransactionRecordId")]
        public string TransactionRecordId 
        { 
            get => transactionRecordId;
            set 
            {
                transactionRecordId = value;
                OnPropertyChanged("TransactionRecordId");
            }
        }

        /// <summary>
        /// Status of the transaction. Possible Values: Uploading, Processing, Completed, InProgress, Failed, WaitAsync, ToBeResumed, Canceled, TimeoutCanceled. Call GetTransactionRecord when status changes to Completed, Failed, Canceled or TimeoutCanceled to get the verification results.
        /// </summary>
        [JsonProperty("Status")]
        public string Status 
        { 
            get => status;
            set 
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        /// <summary>
        /// Uploaded date for transaction.
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
        /// Set to true when transaction has timed out.
        /// </summary>
        [JsonProperty("IsTimedOut")]
        public bool? IsTimedOut 
        { 
            get => isTimedOut;
            set 
            {
                isTimedOut = value;
                OnPropertyChanged("IsTimedOut");
            }
        }
    }
} 