using System;
using TruliooSDK.Exceptions;
using TruliooSDK.Http.Client;
using TruliooSDK.Http.Response;
using TruliooSDK.Utilities;

namespace TruliooSDK.Controllers
{
    public class BaseController
    {
        #region shared http client instance
        private static readonly object SyncObject = new object();
        private static IHttpClient _clientInstance;

        public static IHttpClient ClientInstance
        {
            get
            {
                lock(SyncObject)
                {
                    if (null != _clientInstance) return _clientInstance;
                    _clientInstance = new HTTPClient();
                    _clientInstance.SetTimeout(TimeSpan.FromMilliseconds(30000));
                    return _clientInstance;
                }
            }
            set
            {
                lock (SyncObject)
                    if (value is IHttpClient client) _clientInstance = client;
            }
        }
        #endregion shared http client instance

        internal ArrayDeserialization ArrayDeserializationFormat = ArrayDeserialization.Indexed;
        internal static char ParameterSeparator = '&';

        /// <summary>
        /// Validates the response against HTTP errors defined at the API level
        /// </summary>
        /// <param name="response">The response received</param>
        /// <param name="context">Context of the request and the received response</param>
        internal void ValidateResponse(HttpResponse response, HttpContext context)
        {
            switch (response.StatusCode)
            {
                case 400:
                    throw new APIException(@"Your request could not be processed, there should be more details in the response.", context);
                case 401:
                    throw new APIException(@"The user name and password you provided is not valid or you are using an account not configured to be an API user.", context);
                case 403:
                    throw new APIException(@"The requested resource is forbidden.", context);
                case 408:
                    throw new APIException(@"The request took longer to process than we waited.", context);
                case 415:
                    throw new APIException(@"You asked for a media type that we do not support. You should request application/json in the Content-Type header.", context);
                case 500:
                    throw new APIException(@"An error happened on the server without a specific message.", context);
            }

            if ((response.StatusCode < 200) || (response.StatusCode > 208)) //[200,208] = HTTP OK
                throw new APIException(@"HTTP Response Not OK", context);
        }
    }
} 
