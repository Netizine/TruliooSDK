using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruliooSDK.Enums;
using TruliooSDK.Exceptions;
using TruliooSDK.Http.Client;
using TruliooSDK.Http.Request;
using TruliooSDK.Http.Response;
using TruliooSDK.Models;
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
                    if (null == _instance)
                    {
                        _instance = new ConfigurationController();
                    }
                return _instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <return>Returns the List{string} response from the API call</return>
        public List<Country> GetCountryCodes()
        {
            return GetCountryCodes("Identity Verification");
        }

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{string} response from the API call</return>
        public List<Country> GetCountryCodes(string configurationName)
        {
            Task<List<Country>> t = GetCountryCodesAsync(configurationName);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <return>Returns the List{string} response from the API call</return>
        public Task<List<Country>> GetCountryCodesAsync()
        {
            return GetCountryCodesAsync("Identity Verification");
        }

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{string} response from the API call</return>
        public async Task<List<Country>> GetCountryCodesAsync(string configurationName)
        {

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/countrycodes/{configurationName}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
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
            HttpRequest request = ClientInstance.Get(queryUrl,headers);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return APIHelper.JsonDeserialize<List<Country>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        public List<DataFields> GetTestEntities(Country country)
        {
            return GetTestEntities(country, "Identity Verification");
        }

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        public List<DataFields> GetTestEntities(Country country, string configurationName)
        {
            Task<List<DataFields>> t = GetTestEntitiesAsync(country, configurationName);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        public Task<List<DataFields>> GetTestEntitiesAsync(Country country)
        {
            return GetTestEntitiesAsync(country, "Identity Verification");
        }

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        public async Task<List<DataFields>> GetTestEntitiesAsync(Country country, string configurationName)
        {
            //validating country parameter
            if (country == Country.NotSet)
            {
                throw new ArgumentException("The parameter \"country\" is required and cannot have the value NotSet.");
            }

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/testentities/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
                { "configurationName", configurationName },
                { "countryCode", country.ToAlpha2CodeString() }
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
            HttpRequest request = ClientInstance.Get(queryUrl,headers);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return APIHelper.JsonDeserialize<List<DataFields>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the object response from the API call</return>
        public object GetFields(Country country)
        {
            return GetFields(country, "Identity Verification");
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public object GetFields(Country country, string configurationName)
        {
            Task<object> t = GetFieldsAsync(country, configurationName);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the object response from the API call</return>
        public Task<object> GetFieldsAsync(Country country)
        {
            return GetFieldsAsync(country, "Identity Verification");
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public async Task<object> GetFieldsAsync(Country country, string configurationName)
        {
            //validating country parameter
            if (country == Country.NotSet)
            {
                throw new ArgumentException("The parameter \"country\" is required and cannot have the value NotSet.");
            }

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/fields/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
                { "countryCode", country.ToAlpha2CodeString() },
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

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the object response from the API call</return>
        public object GetRecommendedFields(Country country)
        {
            return GetRecommendedFields(country, "Identity Verification");
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public object GetRecommendedFields(Country country, string configurationName)
        {
            Task<object> t = GetRecommendedFieldsAsync(country, configurationName);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the object response from the API call</return>
        public Task<object> GetRecommendedFieldsAsync(Country country)
        {
            return GetRecommendedFieldsAsync(country, "Identity Verification");
        }

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        public async Task<object> GetRecommendedFieldsAsync(Country country, string configurationName)
        {
            //validating country parameter
            if (country == Country.NotSet)
            {
                throw new ArgumentException("The parameter \"country\" is required and cannot have the value NotSet.");
            }

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/recommendedfields/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
                { "countryCode", country.ToAlpha2CodeString() },
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

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return> Returns the List{string} response from the API call</return>
        public List<string> GetConsents(Country country)
        {
            return GetConsents(country, "Identity Verification");
        }

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        public List<string> GetConsents(Country country, string configurationName)
        {
            Task<List<string>> t = GetConsentsAsync( country, configurationName);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return> Returns the List{string} response from the API call</return>
        public Task<List<string>> GetConsentsAsync(Country country)
        {
            return GetConsentsAsync(country, "Identity Verification");
        }

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        public async Task<List<string>> GetConsentsAsync(Country country, string configurationName)
        {
            //validating country parameter
            if (country == Country.NotSet)
            {
                throw new ArgumentException("The parameter \"country\" is required and cannot have the value NotSet.");
            }

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/consents/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
                { "countryCode", country.ToAlpha2CodeString() },
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
            HttpRequest request = ClientInstance.Get(queryUrl,headers);

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
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.Consent} response from the API call</return>
        public List<Consent> GetDetailedConsents(Country country)
        {
            return GetDetailedConsents(country, "Identity Verification");
        }

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: Currently defaults to Identity Verification</param>
        /// <return>Returns the List{Models.Consent} response from the API call</return>
        public List<Consent> GetDetailedConsents(Country country, string configurationName)
        {
            Task<List<Consent>> t = GetDetailedConsentsAsync(country, configurationName);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return> Returns the List{Models.Consent} response from the API call</return>
        public Task<List<Consent>> GetDetailedConsentsAsync(Country country)
        {
            return GetDetailedConsentsAsync(country, "Identity Verification");
        }

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: Currently defaults to Identity Verification</param>
        /// <return> Returns the List{Models.Consent} response from the API call</return>
        public async Task<List<Consent>> GetDetailedConsentsAsync(Country country, string configurationName)
        {
            //validating country parameter
            if (country == Country.NotSet)
            {
                throw new ArgumentException("The parameter \"country\" is required and cannot have the value NotSet.");
            }

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/detailedConsents/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
                { "countryCode", country.ToAlpha2CodeString() },
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
            HttpRequest request = ClientInstance.Get(queryUrl,headers);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return APIHelper.JsonDeserialize<List<Consent>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.CountrySubdivision} response from the API call</return>
        public List<CountrySubdivision> GetCountrySubdivisions(Country country)
        {
            Task<List<CountrySubdivision>> t = GetCountrySubdivisionsAsync(country);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.CountrySubdivision} response from the API call</return>
        public async Task<List<CountrySubdivision>> GetCountrySubdivisionsAsync(Country country)
        {
            //validating country parameter
            if (country == Country.NotSet)
            {
                throw new ArgumentException("The parameter \"country\" is required and cannot have the value NotSet.");
            }

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/countrysubdivisions/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
                { "countryCode", country.ToAlpha2CodeString() }
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
            HttpRequest request = ClientInstance.Get(queryUrl,headers);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return APIHelper.JsonDeserialize<List<CountrySubdivision>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

        /// <summary>
        /// Gets data source groups configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.NormalizedDataSourceGroupCountry} response from the API call</return>
        public List<NormalizedDataSourceGroupCountry> GetDataSources(Country country)
        {
            return GetDataSources(country, null);
        }

        /// <summary>
        /// Gets data source groups configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.NormalizedDataSourceGroupCountry} response from the API call</return>
        public List<NormalizedDataSourceGroupCountry> GetDataSources(Country country, string configurationName)
        {
            Task<List<NormalizedDataSourceGroupCountry>> t = GetDataSourcesAsync(country, configurationName);
            TaskHelper.RunTaskSynchronously(t);
            return t.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets data source groups configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.NormalizedDataSourceGroupCountry} response from the API call</return>
        public Task<List<NormalizedDataSourceGroupCountry>> GetDataSourcesAsync(Country country)
        {
            return GetDataSourcesAsync(country, "Identity Verification");
        }

        /// <summary>
        /// Gets data source groups configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.NormalizedDataSourceGroupCountry} response from the API call</return>
        public async Task<List<NormalizedDataSourceGroupCountry>> GetDataSourcesAsync(Country country, string configurationName)
        {
            //validating country parameter
            if (country == Country.NotSet)
            {
                throw new ArgumentException("The parameter \"country\" is required and cannot have the value NotSet.");
            }

            //the base uri for api requests
            var baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{mode}/configuration/v1/datasources/{configurationName}/{countryCode}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "mode", Configuration.Mode.ToFriendlyString() },
                { "configurationName", configurationName },
                { "countryCode", country.ToAlpha2CodeString() }
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
            HttpRequest request = ClientInstance.Get(queryUrl,headers);

            //invoke request and get response
            var response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(request).ConfigureAwait(false);
            var context = new HttpContext(request,response);

            //handle errors defined at the API level
            ValidateResponse(response, context);

            try
            {
                return APIHelper.JsonDeserialize<List<NormalizedDataSourceGroupCountry>>(response.Body);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to parse the response: " + ex.Message, context);
            }
        }

    }
} 
