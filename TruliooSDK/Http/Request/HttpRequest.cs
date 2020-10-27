using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TruliooSDK.Http.Request
{
  public class HttpRequest
    {
        /// <summary>
        /// The HTTP verb to use for this request
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// The query url for the http request
        /// </summary>
        public string QueryUrl { get; set; }

        /// <summary>
        /// Headers collection for the current http request
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Form parameters for the current http request
        /// </summary>
        public List<KeyValuePair<string, object>> FormParameters { get; set; }

        /// <summary>
        /// Optional raw string to send as request body
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Optional username for Basic Auth
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional password for Basic Auth
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Constructor to initialize the http request object
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        public HttpRequest(HttpMethod method, string queryUrl)
        {
            HttpMethod = method;
            QueryUrl = queryUrl;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password)
            : this(method, queryUrl)
        {
            Headers = headers;
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, body and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="body">The string to use as raw body of the http request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            Body = body;
        }

        /// <summary>
        /// Constructor to initialize the http request with headers, form parameters and optional Basic auth params
        /// </summary>
        /// <param name="method">Http verb to use for the http request</param>
        /// <param name="queryUrl">The query url for the http request</param>
        /// <param name="headers">Headers to send with the request</param>
        /// <param name="formParameters">Form parameters collection for the request</param>
        /// <param name="username">Basic auth username</param>
        /// <param name="password">Basic auth password</param>
        public HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password)
            : this(method, queryUrl, headers, username, password)
        {
            FormParameters = formParameters;
        }
    }
}
