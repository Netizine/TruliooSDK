using System.Collections.Generic;
using System.Threading.Tasks;
using TruliooSDK.Enums;

namespace TruliooSDK.Controllers
{
    public interface IConfigurationController
    {
        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        List<Country> GetCountryCodes(string configurationName = "Identity Verification");

        /// <summary>
        /// This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes
        /// </summary>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        Task<List<Country>> GetCountryCodesAsync(string configurationName = "Identity Verification");

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        List<Models.DataFields> GetTestEntities(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// Gets the test entities configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.DataFields} response from the API call</return>
        Task<List<Models.DataFields>> GetTestEntitiesAsync(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        object GetFields(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        Task<object> GetFieldsAsync(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        object GetRecommendedFields(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
        /// http://json-schema.org/documentation.html
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the object response from the API call</return>
        Task<object> GetRecommendedFieldsAsync(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        List<string> GetConsents(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// This method retrieves the consents required for the data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
        /// Failure to provide an element from the string collection will lead to a 1005 service error
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return> Returns the List{string} response from the API call</return>
        Task<List<string>> GetConsentsAsync(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: Currently defaults to Identity Verification</param>
        /// <return> Returns the List{Models.Consent} response from the API call</return>
        List<Models.Consent> GetDetailedConsents(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// This method retrieves details about consents required for data sources currently configured in your account configuration. 
        /// The response for this method contains a collection of objects.
        /// Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
        /// Failure to provide a Name from the object collection will lead to a 1005 service error.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: Currently defaults to Identity Verification</param>
        /// <return> Returns the List{Models.Consent} response from the API call</return>
        Task<List<Models.Consent>> GetDetailedConsentsAsync(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.CountrySubdivision} response from the API call</return>
        List<Models.CountrySubdivision> GetCountrySubdivisions(Country country);

        /// <summary>
        /// Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <return>Returns the List{Models.CountrySubdivision} response from the API call</return>
        Task<List<Models.CountrySubdivision>> GetCountrySubdivisionsAsync(Country country);

        /// <summary>
        /// Gets data source groups configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.NormalizedDataSourceGroupCountry} response from the API call</return>
        List<Models.NormalizedDataSourceGroupCountry> GetDataSources(Country country, string configurationName = "Identity Verification");

        /// <summary>
        /// Gets data source groups configured for your product and country.
        /// </summary>
        /// <param name="country">The country which serializes to the country alpha2 code</param>
        /// <param name="configurationName">Required parameter: The product configuration. Currently defaults to "Identity Verification" for all products.</param>
        /// <return>Returns the List{Models.NormalizedDataSourceGroupCountry} response from the API call</return>
        Task<List<Models.NormalizedDataSourceGroupCountry>> GetDataSourcesAsync(Country country, string configurationName = "Identity Verification");

    }
} 
