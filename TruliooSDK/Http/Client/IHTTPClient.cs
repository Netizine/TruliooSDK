using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruliooSDK.Http.Request;
using TruliooSDK.Http.Response;

namespace TruliooSDK.Http.Client
{
	public interface IHttpClient
    {
        /// <summary>
        /// Sets the time to wait before the request times out.
        ///<param name="timeout"> A timespan object specifying the time to wait</param>
        /// </summary>
        void SetTimeout(TimeSpan timeout);
        /// <summary>
        /// Event raised before an Http request is sent over the network
        /// This event can be used for logging, request modification, appending
        /// additional headers etc.
        /// </summary>
        event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;

        /// <summary>
        /// Event raised after an Http response is received from the network.
        /// This event can be used for logging, response modification, extracting
        /// additional information etc.
        /// </summary>
        event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        /// <summary>
        /// Execute a given HttpRequest to get string response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        HttpResponse ExecuteAsString(HttpRequest request);

        /// <summary>
        /// Execute a given HttpRequest to get binary response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        HttpResponse ExecuteAsBinary(HttpRequest request);

        /// <summary>
        /// Execute a given HttpRequest to get async string response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        Task<HttpResponse> ExecuteAsStringAsync(HttpRequest request);

        /// <summary>
        /// Execute a given HttpRequest to get async binary response back
        /// </summary>
        /// <param name="request">The given HttpRequest to execute</param>
        /// <returns> HttpResponse containing raw information</returns>
        Task<HttpResponse> ExecuteAsBinaryAsync(HttpRequest request);

        /// <summary>
        /// Create a simple HTTP GET request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns>HttpRequest initialised with the url specified</returns>
        HttpRequest Get(string queryUrl);

        /// <summary>
        /// Create a simple HTTP POST request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Post(string queryUrl);

        /// <summary>
        /// Create a simple HTTP PUT request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Put(string queryUrl);

        /// <summary>
        /// Create a simple HTTP DELETE request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Delete(string queryUrl);

        /// <summary>
        /// Create a simple HTTP PATCH request given the URL
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <returns> HttpRequest initialised with the url specified</returns>
        HttpRequest Patch(string queryUrl);

        /// <summary>
        /// Create a simple HTTP GET request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Get(string queryUrl, Dictionary<string, string> headers);

        /// <summary>
        ///  Create a simple HTTP POST request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Post(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters);

        /// <summary>
        /// Create a simple HTTP POST with a body request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest PostBody(string queryUrl, Dictionary<string, string> headers, object body);

        /// <summary>
        ///  Create a simple HTTP PUT request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Put(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters);

        /// <summary>
        /// Create a simple HTTP PUT with a body request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest PutBody(string queryUrl, Dictionary<string, string> headers, object body);

        /// <summary>
        ///  Create a simple HTTP PATCH request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Patch(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters);

        /// <summary>
        /// Create a simple HTTP Patch with a body request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest PatchBody(string queryUrl, Dictionary<string, string> headers, object body);

        /// <summary>
        ///  Create a simple HTTP DELETE request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="formParameters">Form parameters to be included</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest Delete(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters);

        /// <summary>
        /// Create a simple HTTP Delete with a body request given relevant parameters
        /// </summary>
        /// <param name="queryUrl">Url the request should be sent to</param>
        /// <param name="headers">HTTP headers that should be included</param>
        /// <param name="body">The body/payload of the response</param>
        /// <returns> HttpRequest initialised with the http parameters specified</returns>
        HttpRequest DeleteBody(string queryUrl, Dictionary<string, string> headers, object body);
    }
}

