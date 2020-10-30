using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruliooSDK.Exceptions;
using TruliooSDK.Http.Client;
using TruliooSDK.Http.Request;
using TruliooSDK.Http.Response;
using TruliooSDK.Utilities;

namespace TruliooSDK.Controllers
{
    public class ConnectionController: BaseController, IConnectionController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static readonly object SyncObject = new object();
        private static ConnectionController _instance;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static ConnectionController Instance
        {
            get
            {
                lock (SyncObject)
                    if (null == _instance)
                    {
                        _instance = new ConnectionController();
                    }
                return _instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// This method enables you to check if your credentials are valid. You will need to use ApiKeyAuth authentication to ensure a successful response.
        /// </summary>
        /// <return>Returns the string response from the API call</return>
        public string GetTestAuthentication()
        {
            Task<string> t = GetTestAuthenticationAsync();
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method enables you to check if your credentials are valid. You will need to use ApiKeyAuth authentication to ensure a successful response.
        /// </summary>
        /// <return>Returns the string response from the API call</return>
        public async Task<string> GetTestAuthenticationAsync()
        {
            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/connection/v1/testauthentication");

            //process optional template parameters

            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() }
            });


            //validate and preprocess url
            var queryUrl = APIHelper.CleanUrl(queryBuilder);

            //append request with appropriate headers and parameters
            var headers = new Dictionary<string, string> {{"user-agent", "Trulioo C# SDK"}, {"x-trulioo-api-key", Configuration.XTruliooApiKey}};


            //prepare the API call request to fetch the response
            HttpRequest request = ClientInstance.Get(queryUrl,headers);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return response.Body;
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

    }
} 
