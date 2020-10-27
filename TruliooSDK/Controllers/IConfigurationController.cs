using System.Collections.Generic;
using System.Threading.Tasks;

namespace TruliooSDK.Controllers
{
    public interface IConfigurationController
    {
        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        List<string> GetCountryCodes(string configurationName);

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        Task<List<string>> GetCountryCodesAsync(string configurationName);

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        List<Models.DataFields> GetTestEntities(string configurationName, string countryCode);

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        Task<List<Models.DataFields>> GetTestEntitiesAsync(string configurationName, string countryCode);

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        object GetFields(string countryCode, string configurationName);

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        Task<object> GetFieldsAsync(string countryCode, string configurationName);

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        object GetRecommendedFields(string countryCode, string configurationName);

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        Task<object> GetRecommendedFieldsAsync(string countryCode, string configurationName);

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        List<string> GetConsents(string countryCode, string configurationName);

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        Task<List<string>> GetConsentsAsync(string countryCode, string configurationName);

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="countryCode">Required parameter: Call CountryCodes to get the countries available to you.</param>
        /// <param name="configurationName">Required parameter: Identity Verification</param>
        /// <return> Returns the List{Models.Consent} response from the API call</return>
        List<Models.Consent> GetDetailedConsents(string countryCode, string configurationName);

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="countryCode">Required parameter: Call CountryCodes to get the countries available to you.</param>
        /// <param name="configurationName">Required parameter: Identity Verification</param>
        /// <return> Returns the List{Models.Consent} response from the API call</return>
        Task<List<Models.Consent>> GetDetailedConsentsAsync(string countryCode, string configurationName);

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List{Models.CountrySubdivision} response from the API call</return>
        List<Models.CountrySubdivision> GetCountrySubdivisions(string countryCode);

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List{Models.CountrySubdivision} response from the API call</return>
        Task<List<Models.CountrySubdivision>> GetCountrySubdivisionsAsync(string countryCode);

        /// <summary>
        /// Gets datasource groups configured for your product and country.
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List{Models.NormalizedDatasourceGroupCountry} response from the API call</return>
        List<Models.NormalizedDataSourceGroupCountry> GetDataSources(string configurationName, string countryCode);

        /// <summary>
        /// Gets datasource groups configured for your product and country.
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently "Identity Verification" for all products.</param>
        /// <param name="countryCode">Required parameter: Country alpha2 code</param>
        /// <return>Returns the List{Models.NormalizedDatasourceGroupCountry} response from the API call</return>
        Task<List<Models.NormalizedDataSourceGroupCountry>> GetDataSourcesAsync(string configurationName, string countryCode);

    }
} 
