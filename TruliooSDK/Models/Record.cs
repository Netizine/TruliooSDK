
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Record : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string transactionRecordId;
        private string recordStatus;
        private List<DatasourceResult> datasourceResults;
        private List<ServiceError> errors;
        private RecordRule rule;

        /// <summary>
        /// The TransactionRecordID, this is the ID you will use to fetch the transaction again.
        /// </summary>
        [JsonProperty("TransactionRecordID")]
        public string TransactionRecordId 
        { 
            get => transactionRecordId;
            set 
            {
                transactionRecordId = value;
                OnPropertyChanged("TransactionRecordID");
            }
        }

        /// <summary>
        /// 'match' or 'nomatch' if the verification passed the rules configured on your account this will be 'match'.
        /// </summary>
        [JsonProperty("RecordStatus")]
        public string RecordStatus 
        { 
            get => recordStatus;
            set 
            {
                recordStatus = value;
                OnPropertyChanged("RecordStatus");
            }
        }

        /// <summary>
        /// Results for each datasource that was queried.
        /// </summary>
        [JsonProperty("DatasourceResults")]
        public List<DatasourceResult> DatasourceResults 
        { 
            get => datasourceResults;
            set 
            {
                datasourceResults = value;
                OnPropertyChanged("DatasourceResults");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
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

        /// <summary>
        /// RecordRule used for the transaction.
        /// </summary>
        [JsonProperty("Rule")]
        public RecordRule Rule 
        { 
            get => rule;
            set 
            {
                rule = value;
                OnPropertyChanged("Rule");
            }
        }
    }
} 