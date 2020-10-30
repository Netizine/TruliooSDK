using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TruliooSDK.Http.Request;
using TruliooSDK.Http.Response;
using TruliooSDK.Utilities;

namespace TruliooSDK.Http.Client
{
    public class HTTPClient : IHttpClient
    {
        public static IHttpClient SharedClient { get; set; }
        private readonly HttpClient _client = new HttpClient();
		

        static HTTPClient()
        {
            SharedClient = new HTTPClient();
        }

        public void SetTimeout(TimeSpan timeout)
        {
            _client.Timeout = timeout;
        }


        #region Execute methods

        public HttpResponse ExecuteAsString(HttpRequest request)
        {
            Task<HttpResponse> t = ExecuteAsStringAsync(request);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        public async Task<HttpResponse> ExecuteAsStringAsync(HttpRequest request)
        {
            //raise the on before request event
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage = await HttpResponseMessageAsync(request).ConfigureAwait(false);

            HttpResponse response = new HttpStringResponse
            {
                Headers = GetCombinedResponseHeaders(responseMessage),
                RawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Body = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false),
                StatusCode = (int)responseMessage.StatusCode
            };

            //raise the on after response event
            RaiseOnAfterHttpResponseEvent(response);
            return response;
        }

        public HttpResponse ExecuteAsBinary(HttpRequest request)
        {
            Task<HttpResponse> t = ExecuteAsBinaryAsync(request);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        public async Task<HttpResponse> ExecuteAsBinaryAsync(HttpRequest request)
        {
            //raise the on before request event
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage = await HttpResponseMessageAsync(request).ConfigureAwait(false);

            var response = new HttpResponse
            {
                Headers = GetCombinedResponseHeaders(responseMessage),
                RawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false),
                StatusCode = (int)responseMessage.StatusCode
            };

            //raise the on after response event
            RaiseOnAfterHttpResponseEvent(response);
            return response;
        }

        #endregion


        #region Http request and response events

        public event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;
        public event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        private void RaiseOnBeforeHttpRequestEvent(HttpRequest request)
        {
            if ((null != OnBeforeHttpRequestEvent) && (null != request))
            {
                OnBeforeHttpRequestEvent(this, request);
            }
        }

        private void RaiseOnAfterHttpResponseEvent(HttpResponse response)
        {
            if ((null != OnAfterHttpResponseEvent) && (null != response))
            {
                OnAfterHttpResponseEvent(this, response);
            }
        }

        #endregion


        #region Http methods

        public HttpRequest Get(string queryUrl, Dictionary<string, string> headers)
        {
            return new HttpRequest(HttpMethod.Get, queryUrl, headers);
        }

        public HttpRequest Get(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Get, queryUrl);
        }

        public HttpRequest Post(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl);
        }

        public HttpRequest Put(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl);
        }

        public HttpRequest Delete(string queryUrl)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl);
        }

        public HttpRequest Patch(string queryUrl)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl);
        }

        public HttpRequest Post(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl, headers, formParameters);
        }

        public HttpRequest PostBody(string queryUrl, Dictionary<string, string> headers, object body)
        {
            return new HttpRequest(HttpMethod.Post, queryUrl, headers, body);
        }

        public HttpRequest Put(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl, headers, formParameters);
        }

        public HttpRequest PutBody(string queryUrl, Dictionary<string, string> headers, object body)
        {
            return new HttpRequest(HttpMethod.Put, queryUrl, headers, body);
        }

        public HttpRequest Patch(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, formParameters);
        }

        public HttpRequest PatchBody(string queryUrl, Dictionary<string, string> headers, object body)
        {
            return new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, body);
        }

        public HttpRequest Delete(string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, object>> formParameters)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl, headers, formParameters);
        }

        public HttpRequest DeleteBody(string queryUrl, Dictionary<string, string> headers, object body)
        {
            return new HttpRequest(HttpMethod.Delete, queryUrl, headers, body);
        }

        #endregion

        #region Helper methods

        private async Task<HttpResponseMessage> HttpResponseMessageAsync(HttpRequest request)
        {
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(request.QueryUrl),
                Method = request.HttpMethod,
            };
            foreach (KeyValuePair<string, string> headers in request.Headers)
            {
                requestMessage.Headers.TryAddWithoutValidation(headers.Key, headers.Value);
            }

            if (request.HttpMethod.Equals(HttpMethod.Delete) || request.HttpMethod.Equals(HttpMethod.Post) || request.HttpMethod.Equals(HttpMethod.Put) || request.HttpMethod.Equals(new HttpMethod("PATCH")))
            {
                if (request.Body != null)
                {
                    if (request.Body is FileStreamInfo file)
                    {
                        requestMessage.Content = new StreamContent(file.FileStream);
                        requestMessage.Content.Headers.ContentType = !string.IsNullOrWhiteSpace(file.ContentType) ? new MediaTypeHeaderValue(file.ContentType) : new MediaTypeHeaderValue("application/octet-stream");
                    }
                    else if (request.Headers.Any(f => f.Key == "content-type" && f.Value == "application/json; charset=utf-8"))
                    {
                        requestMessage.Content = new StringContent((string)request.Body ?? string.Empty, Encoding.UTF8,
                            "application/json");
                    }
                    else if (request.Headers.ContainsKey("content-type"))
                    {
                        requestMessage.Content = new ByteArrayContent(
                            request.Body == null ? new byte[] { } : Encoding.UTF8.GetBytes((string)request.Body));

                        try
                        {
                            requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(request.Headers["content-type"]);
                        } catch(Exception)
                        {
                            requestMessage.Content.Headers.TryAddWithoutValidation("content-type", request.Headers["content-type"]);
                        }
                    }
                    else
                    {
                        requestMessage.Content = new StringContent(request.Body.ToString() ?? string.Empty, Encoding.UTF8,
                            "text/plain");
                    }
                }
                else if (request.FormParameters != null && request.FormParameters.Any(f => f.Value is FileStreamInfo))
                {
                    var formContent = new MultipartFormDataContent();
                    foreach (KeyValuePair<string, object> param in request.FormParameters)
                    {
                        if (param.Value is FileStreamInfo fileInfo)
                        {
                            var fileContent = new StreamContent(fileInfo.FileStream);
                            if (string.IsNullOrEmpty(fileInfo.FileName))
                            {
                                fileInfo.FileName = "file";
                                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                {
                                    Name = param.Key,
                                    FileName = fileInfo.FileName
                                };
                            }
                            fileContent.Headers.ContentType = !string.IsNullOrWhiteSpace(fileInfo.ContentType) ? new MediaTypeHeaderValue(fileInfo.ContentType) : new MediaTypeHeaderValue("application/octet-stream");
                            formContent.Add(fileContent, param.Key);
                        }
                        else
                        {
                            formContent.Add(new StringContent(param.Value.ToString()), param.Key);
                        }
                    }

                    requestMessage.Content = formContent;
                }
                else if (request.FormParameters != null)
                {
                    var parameters = new List<KeyValuePair<string, string>>();
                    foreach (KeyValuePair<string, object> param in request.FormParameters)
                    {
                        parameters.Add(new KeyValuePair<string, string>(param.Key, param.Value.ToString()));
                    }

                    requestMessage.Content = new FormUrlEncodedContent(parameters);
                }
            }
            return await _client.SendAsync(requestMessage).ConfigureAwait(false);
        }

        private static Dictionary<string, string> GetCombinedResponseHeaders(HttpResponseMessage responseMessage)
        {
            var headers = responseMessage.Headers.ToDictionary(l => l.Key, k => k.Value.First());
            if (responseMessage.Content == null)
            {
                return headers;
            }
            foreach (KeyValuePair<string, IEnumerable<string>> contentHeader in responseMessage.Content.Headers)
            {
                if (headers.ContainsKey(contentHeader.Key))
                {
                    continue;
                }
                headers.Add(contentHeader.Key, contentHeader.Value.First());
            }
            return headers;
        }

        #endregion
    }
}
