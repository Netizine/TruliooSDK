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
    public class ConfigurationController: BaseController, IConfigurationController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static readonly object SyncObject = new object();
        private static ConfigurationController _instance;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static ConfigurationController Instance
        {
            get
            {
                lock (SyncObject)
                {
                    if (null == _instance) _instance = new ConfigurationController();
                }
                return _instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the List<string> response from the API call</return>
        public List<string> GetCountryCodes(string mode, string configurationName)
        {
            var t = GetCountryCodesAsync(mode, configurationName);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the List<string> response from the API call</return>
        public async Task<List<string>> GetCountryCodesAsync(string mode, string configurationName)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == configurationName)
                throw new ArgumentNullException(nameof(configurationName), "The parameter \"configurationName\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/countrycodes/{configurationName}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "configurationName", configurationName }
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
                return APIHelper.JsonDeserialize<List<string>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List<Models.DataFields> response from the API call</return>
        public List<Models.DataFields> GetTestEntities(string mode, string configurationName, string countryCode)
        {
            var t = GetTestEntitiesAsync(mode, configurationName, countryCode);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List<Models.DataFields> response from the API call</return>
        public async Task<List<Models.DataFields>> GetTestEntitiesAsync(string mode, string configurationName, string countryCode)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == configurationName)
                throw new ArgumentNullException(nameof(configurationName), "The parameter \"configurationName\" is a required parameter and cannot be null.");

            if (null == countryCode)
                throw new ArgumentNullException(nameof(countryCode), "The parameter \"countryCode\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/testentities/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "configurationName", configurationName },
                { "countryCode", countryCode }
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
                return APIHelper.JsonDeserialize<List<Models.DataFields>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public object GetFields(string mode, string countryCode, string configurationName)
        {
            var t = GetFieldsAsync(mode, countryCode, configurationName);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public async Task<object> GetFieldsAsync(string mode, string countryCode, string configurationName)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == countryCode)
                throw new ArgumentNullException(nameof(countryCode), "The parameter \"countryCode\" is a required parameter and cannot be null.");

            if (null == configurationName)
                throw new ArgumentNullException(nameof(configurationName), "The parameter \"configurationName\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/fields/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "countryCode", countryCode },
                { "configurationName", configurationName }
            });


            //validate and preprocess url
            var queryUrl = APIHelper.CleanUrl(queryBuilder);

            //append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>
            {
                {"user-agent", "Trulioo C# SDK"}, 
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
                return response.Body;
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public object GetRecommendedFields(string mode, string countryCode, string configurationName)
        {
            var t = GetRecommendedFieldsAsync(mode, countryCode, configurationName);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public async Task<object> GetRecommendedFieldsAsync(string mode, string countryCode, string configurationName)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == countryCode)
                throw new ArgumentNullException(nameof(countryCode), "The parameter \"countryCode\" is a required parameter and cannot be null.");

            if (null == configurationName)
                throw new ArgumentNullException(nameof(configurationName), "The parameter \"configurationName\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/recommendedfields/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "countryCode", countryCode },
                { "configurationName", configurationName }
            });


            //validate and preprocess url
            var queryUrl = APIHelper.CleanUrl(queryBuilder);

            //append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>
            {
                {"user-agent", "Trulioo C# SDK"}, 
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
                return response.Body;
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the List<string> response from the API call</return>
        public List<string> GetConsents(string mode, string countryCode, string configurationName)
        {
            var t = GetConsentsAsync(mode, countryCode, configurationName);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the List<string> response from the API call</return>
        public async Task<List<string>> GetConsentsAsync(string mode, string countryCode, string configurationName)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == countryCode)
                throw new ArgumentNullException(nameof(countryCode), "The parameter \"countryCode\" is a required parameter and cannot be null.");

            if (null == configurationName)
                throw new ArgumentNullException(nameof(configurationName), "The parameter \"configurationName\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/consents/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "countryCode", countryCode },
                { "configurationName", configurationName }
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
                return APIHelper.JsonDeserialize<List<string>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Call CountryCodes to get the countries available to you.</param>
        /// <param name="configurationName">Required parameter: Identity Verification</param>
        /// <return>Returns the List<Models.Consent> response from the API call</return>
        public List<Models.Consent> GetDetailedConsents(string mode, string countryCode, string configurationName)
        {
            var t = GetDetailedConsentsAsync(mode, countryCode, configurationName);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Call CountryCodes to get the countries available to you.</param>
        /// <param name="configurationName">Required parameter: Identity Verification</param>
        /// <return>Returns the List<Models.Consent> response from the API call</return>
        public async Task<List<Models.Consent>> GetDetailedConsentsAsync(string mode, string countryCode, string configurationName)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == countryCode)
                throw new ArgumentNullException(nameof(countryCode), "The parameter \"countryCode\" is a required parameter and cannot be null.");

            if (null == configurationName)
                throw new ArgumentNullException(nameof(configurationName), "The parameter \"configurationName\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/detailedConsents/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "countryCode", countryCode },
                { "configurationName", configurationName }
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
                return APIHelper.JsonDeserialize<List<Models.Consent>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List<Models.CountrySubdivision> response from the API call</return>
        public List<Models.CountrySubdivision> GetCountrySubdivisions(string mode, string countryCode)
        {
            var t = GetCountrySubdivisionsAsync(mode, countryCode);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List<Models.CountrySubdivision> response from the API call</return>
        public async Task<List<Models.CountrySubdivision>> GetCountrySubdivisionsAsync(string mode, string countryCode)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == countryCode)
                throw new ArgumentNullException(nameof(countryCode), "The parameter \"countryCode\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/countrysubdivisions/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "countryCode", countryCode }
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
                return APIHelper.JsonDeserialize<List<Models.CountrySubdivision>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Gets datasource groups configured for your product and country.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List<Models.NormalizedDatasourceGroupCountry> response from the API call</return>
        public List<Models.NormalizedDatasourceGroupCountry> GetDataSources(string mode, string configurationName, string countryCode)
        {
            var t = GetDataSourcesAsync(mode, configurationName, countryCode);
            APIHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets datasource groups configured for your product and country.
        /// </summary>
        /// <param name="mode">Required parameter: free trial or live</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List<Models.NormalizedDatasourceGroupCountry> response from the API call</return>
        public async Task<List<Models.NormalizedDatasourceGroupCountry>> GetDataSourcesAsync(string mode, string configurationName, string countryCode)
        {
            //validating required parameters
            if (null == mode)
                throw new ArgumentNullException(nameof(mode), "The parameter \"mode\" is a required parameter and cannot be null.");

            if (null == configurationName)
                throw new ArgumentNullException(nameof(configurationName), "The parameter \"configurationName\" is a required parameter and cannot be null.");

            if (null == countryCode)
                throw new ArgumentNullException(nameof(countryCode), "The parameter \"countryCode\" is a required parameter and cannot be null.");

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/datasources/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", mode },
                { "configurationName", configurationName },
                { "countryCode", countryCode }
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
                return APIHelper.JsonDeserialize<List<Models.NormalizedDatasourceGroupCountry>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

    }
} 