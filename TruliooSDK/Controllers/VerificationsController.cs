using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruliooSDK.Exceptions;
using TruliooSDK.Http.Client;
using TruliooSDK.Http.Response;
using TruliooSDK.Utilities;

namespace TruliooSDK.Controllers
{
    public class VerificationsController: BaseController, IVerificationsController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static readonly object SyncObject = new object();
        private static VerificationsController _instance;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static VerificationsController Instance
        {
            get
            {
                lock (SyncObject)
                {
                    if (null == _instance) _instance = new VerificationsController();
                }
                return _instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Calling this method will perform a verification. If your account includes address cleansing set the CleansedAddress flag to get
        /// additional address information in the result.  You can query configuration to get what fields are available to you in each country.
        /// It is also possible to get sample requests from the customer portal. If you are configured for a sandbox account make sure to call Get Test Entities to get test data for a country you want to try. Sandbox accounts only use these test entities and so trying to verify with any other data will result in no matches being found.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.VerifyResult response from the API call</return>
        public Models.VerifyResult CreateVerify(string mode, Models.VerifyRequest body)
        {
            var t = CreateVerifyAsync(mode, body);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Calling this method will perform a verification. If your account includes address cleansing set the CleansedAddress flag to get
        /// additional address information in the result.  You can query configuration to get what fields are available to you in each country.
        /// It is also possible to get sample requests from the customer portal. If you are configured for a sandbox account make sure to call Get Test Entities to get test data for a country you want to try. Sandbox accounts only use these test entities and so trying to verify with any other data will result in no matches being found.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the Models.VerifyResult response from the API call</return>
        public async Task<Models.VerifyResult> CreateVerifyAsync(string mode, Models.VerifyRequest body)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == body)
                throw new ArgumentNullException(nameof(body), "The parameter \"body\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/verifications/v1/verify");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode }
            });


            //validate and preprocess url
            var queryUrl = APIHelper.CleanUrl(queryBuilder);

            //append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>
            {
                {"user-agent", "Trulioo C# SDK"},
                {"accept", "application/json"},
                {"content-type", "application/json; charset=utf-8"},
                {"x-trulioo-api-key", Configuration.XTruliooApiKey}
            };

            //append body params
            var json = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            var request = ClientInstance.PostBody(queryUrl, headers, json);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return APIHelper.JsonDeserialize<Models.VerifyResult>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// This method is used to retrieve the request and results of a verification performed using the verify method. 
        /// The response for this method includes the same information as verify method's response, along with data present in the input fields of the verify request.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="id">Required parameter: The TransactionRecordID from the Verify response, this will be a GUID</param>
        /// <return>Returns the Models.TransactionRecordResult response from the API call</return>
        public Models.TransactionRecordResult GetTransactionRecord(string mode, string id)
        {
            var t = GetTransactionRecordAsync(mode, id);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method is used to retrieve the request and results of a verification performed using the verify method. 
        /// The response for this method includes the same information as verify method's response, along with data present in the input fields of the verify request.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="id">Required parameter: The TransactionRecordID from the Verify response, this will be a GUID</param>
        /// <return>Returns the Models.TransactionRecordResult response from the API call</return>
        public async Task<Models.TransactionRecordResult> GetTransactionRecordAsync(string mode, string id)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == id)
                throw new ArgumentNullException(nameof(id), "The parameter \"id\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/verifications/v1/transactionrecord/{id}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "id", id }
            });


            //validate and preprocess url
            var queryUrl = APIHelper.CleanUrl(queryBuilder);

            //append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>
            {
                {"user-agent", "Trulioo C# SDK"}, 
                {"accept", "application/json"}, 
                {"x-trulioo-api-key", Configuration.XTruliooApiKey}
            };

            //prepare the API call request to fetch the response
            var request = ClientInstance.Get(queryUrl,headers);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return APIHelper.JsonDeserialize<Models.TransactionRecordResult>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

    }
} 