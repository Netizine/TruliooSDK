
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TruliooSDK.Models
{
    public class Record : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string _transactionRecordId;
        private string _recordStatus;
        private List<DatasourceResult> _datasourceResults;
        private List<ServiceError> _errors;
        private RecordRule _rule;

        /// <summary>
        /// The TransactionRecordID, this is the ID you will use to fetch the transaction again.
        /// </summary>
        [JsonProperty("TransactionRecordID")]
        public string TransactionRecordId 
        { 
            get => _transactionRecordId;
            set 
            {
                _transactionRecordId = value;
                OnPropertyChanged("TransactionRecordID");
            }
        }

        /// <summary>
        /// 'match' or 'nomatch' if the verification passed the rules configured on your account this will be 'match'.
        /// </summary>
        [JsonProperty("RecordStatus")]
        public string RecordStatus 
        { 
            get => _recordStatus;
            set 
            {
                _recordStatus = value;
                OnPropertyChanged("RecordStatus");
            }
        }

        /// <summary>
        /// Results for each datasource that was queried.
        /// </summary>
        [JsonProperty("DatasourceResults")]
        public List<DatasourceResult> DatasourceResults 
        { 
            get => _datasourceResults;
            set 
            {
                _datasourceResults = value;
                OnPropertyChanged("DatasourceResults");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
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
        /// RecordRule used for the transaction.
        /// </summary>
        [JsonProperty("Rule")]
        public RecordRule Rule 
        { 
            get => _rule;
            set 
            {
                _rule = value;
                OnPropertyChanged("Rule");
            }
        }
    }
} 