Unofficial Trulioo C# SDK. 

This is the link to the [Official SDK](https://github.com/Trulioo/sdk-csharp-v1 "Official SDK")

## How to Use

The following section explains how to use the Trulioo C# SDK library in a C# project.

## Initialization

### Authentication
In order to setup authentication and initialization of the API client, you need the following information.

| Parameter | Description |
|-----------|-------------|
| mode | Trulioo Mode |
| xTruliooApiKey | Trulioo Api Key |

API client can be initialized as following.

```csharp
// Configuration parameters and credentials
Mode mode = Mode.Trial; // free trial or live
string xTruliooApiKey = "xTruliooApiKey"; // Trulioo Api Key

var client = new TruliooSDK.TruliooSDKClient(mode, xTruliooApiKey);
```

# Class Reference

## <a name="list_of_controllers"></a>List of Controllers
*[Connection Controller](#connection_controller)
*[Configuration Controller](#configuration_controller)
*[Verifications Controller](#verifications_controller)

## <a name="connection_controller"></a>![Class: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/class.png "TruliooSDK.Standard.Controllers.ConnectionController") ConnectionController

### Get singleton instance of the Connection Controller

The singleton instance of the ``` ConnectionController ``` class can be accessed from the API Client.

```csharp
IConnectionController connection = client.Connection;
```

### <a name="get_test_authentication"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConnectionController.GetTestAuthentication") GetTestAuthentication

> This method enables you to check if your credentials are valid. You will need to use ApiKeyAuth authentication to ensure a successful response.

```csharp
string GetTestAuthentication();
//Async
Task<string> GetTestAuthenticationAsync();
```

#### Example Usage for GetTestAuthenticationAsync

```csharp
string result = await connection.GetTestAuthenticationAsync();
```

[Back to List of Controllers](#list_of_controllers)

## <a name="configuration_controller"></a>![Class: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/class.png "TruliooSDK.Standard.Controllers.ConfigurationController") ConfigurationController

### Get singleton instance of the Configuration Controller

The singleton instance of the ``` ConfigurationController ``` class can be accessed from the API Client.

```csharp
var configuration = client.Configuration;
```

### <a name="get_country_codes"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConfigurationController.GetCountryCodes") GetCountryCodes

> This method retrieves all the countries that are available to perform a verification. It returns a collection of the supported countries

```csharp
List<Country> GetCountryCodes();
//Async
Task<List<Country>> GetCountryCodesAsync();
```

#### Parameters for GetCountryCodesAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| configurationName |  ``` Optional ```  ``` DefaultValue ```  | The product configuration. Currently defaults to "Identity Verification" for all products. |

#### Example Usage for GetCountryCodesAsync

```csharp
var result = await configuration.GetCountryCodesAsync();

```

### <a name="get_test_entities"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConfigurationController.GetTestEntities") GetTestEntities

> Gets the test entities configured for your product and country.

```csharp
List<Models.DataFields> GetTestEntities(Country.GreatBritain);
//Async
Task<List<Models.DataFields>> GetTestEntitiesAsync(Country.GreatBritain);
```

#### Parameters for GetTestEntitiesAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| configurationName |  ``` Optional ```  ``` DefaultValue ```  | The product configuration. Currently defaults to "Identity Verification" for all products. |
| country|  ``` Required ```  | Country enum |

#### Example Usage for GetTestEntitiesAsync

```csharp
var result = await configuration.GetTestEntitiesAsync(Country.GreatBritain);
```

### <a name="get_fields"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConfigurationController.GetFields") GetFields

> Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org

```csharp
object GetFields(Country.GreatBritain);
//Async
Task<object> GetFieldsAsync(Country.GreatBritain);
```

#### Parameters for GetFieldsAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| country|  ``` Required ```  | Country enum |
| configurationName |  ``` Optional ```  ``` DefaultValue ```  | The product configuration. Currently defaults to "Identity Verification" for all products. |

#### Example Usage for GetFieldsAsync

```csharp
object result = await configuration.GetFieldsAsync(Country.GreatBritain);
```

### <a name="get_recommended_fields"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConfigurationController.GetRecommendedFields") GetRecommendedFields

> Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
> 
> http://json-schema.org/documentation.html

```csharp
object GetRecommendedFields(Country.GreatBritain);
Task<object> GetRecommendedFieldsAsync(Country.GreatBritain);
```

#### Parameters for GetRecommendedFieldsAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| country |  ``` Required ```  | Country enum |
| configurationName |  ``` Optional ```  ``` DefaultValue ```  | The product configuration. Currently defaults to "Identity Verification" for all products. |

#### Example Usage for GetRecommendedFieldsAsync

```csharp
var result = await configuration.GetRecommendedFieldsAsync(Country.GreatBritain);
```

### <a name="get_consents"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png  "TruliooSDK.Standard.Controllers.ConfigurationController.GetConsents") GetConsents

> This method retrieves the consents required for the data sources currently configured in your account configuration. 
> 
> The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
> 
> Failure to provide an element from the string collection will lead to a 1005 service error

```csharp
List<string> GetConsents(Country.GreatBritain);
//Async
Task<List<string>> GetConsentsAsync(Country.GreatBritain);
```
#### Parameters for GetConsentsAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| country|  ``` Required ```  | Country enum |
| configurationName |  ``` Optional ```  ``` DefaultValue ```  | The product configuration. Currently defaults to "Identity Verification" for all products. |

#### Example Usage for GetConsentsAsync

```csharp
var result = await configuration.GetConsentsAsync(Country.GreatBritain);
```
### <a name="get_detailed_consents"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConfigurationController.GetDetailedConsents") GetDetailedConsents

> This method retrieves details about consents required for data sources currently configured in your account configuration. 
> 
> The response for this method contains a collection of objects.
> 
> Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
> 
> Failure to provide a Name from the object collection will lead to a 1005 service error.

```csharp
List<Models.Consent> GetDetailedConsents(Country.GreatBritain);
//Async
Task<List<Models.Consent>> GetDetailedConsentsAsync(Country.GreatBritain);
```
#### Parameters for GetDetailedConsentsAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| country |  ``` Required ```  | Call CountryCodes to get the countries available to you. |
| configurationName |  ``` Optional ```  ``` DefaultValue ```  | Currentlt defailts to Identity Verification |

#### Example Usage for GetDetailedConsentsAsync

```csharp
var result = await configuration.GetDetailedConsentsAsync(Country.GreatBritain);
```

### <a name="get_country_subdivisions"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConfigurationController.GetCountrySubdivisions") GetCountrySubdivisions

> Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2

```csharp
List<Models.CountrySubdivision> GetCountrySubdivisions(Country.GreatBritain);
//Async
Task<List<Models.CountrySubdivision>> GetCountrySubdivisionsAsync(Country.GreatBritain);
```

#### Parameters for GetCountrySubdivisionsAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| country |  ``` Required ```  | Country enum |

#### Example Usage for GetCountrySubdivisionsAsync

```csharp
var result = await configuration.GetCountrySubdivisionsAsync(Country.GreatBritain);
```

### <a name="get_datasources"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.ConfigurationController.GetDatasources") GetDatasources

> Gets datasource groups configured for your product and country.

```csharp
List<Models.NormalizedDatasourceGroupCountry> GetDataSources(Country.GreatBritain);
//Async
Task<List<Models.NormalizedDatasourceGroupCountry>> GetDataSourcesAsync(Country.GreatBritain);
```

#### Parameters for GetDataSourcesAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| configurationName |  ``` Optional ```  ``` DefaultValue ```  | The product configuration. Currently defaults to "Identity Verification" for all products. |
| country |  ``` Required ```  | Country enum |

#### Example Usage for GetDataSourcesAsync

```csharp
var result = await configuration.GetDataSourcesAsync(Country.GreatBritain);
```

[Back to List of Controllers](#list_of_controllers)

## <a name="verifications_controller"></a>![Class: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/class.png "TruliooSDK.Standard.Controllers.VerificationsController") VerificationsController

### Get singleton instance of the Verifications Controller

The singleton instance of the ``` VerificationsController ``` class can be accessed from the API Client.

```csharp
IVerificationsController verifications = client.Verifications;
```

### <a name="create_verify"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.VerificationsController.CreateVerify") CreateVerify

> Calling this method will perform a verification. If your account includes address cleansing set the CleansedAddress flag to get
> 
> additional address information in the result.  You can query configuration to get what fields are available to you in each country.
> 
> It is also possible to get sample requests from the customer portal. If you are configured for a sandbox account make sure to call Get Test Entities to get test data for a country you want to try. Sandbox accounts only use these test entities and so trying to verify with any other data will result in no matches being found.

```csharp
Models.VerifyResult CreateVerify(VerifyRequest body);
//Async
Task<Models.VerifyResult> CreateVerifyAsync(VerifyRequest body);
```
#### Parameters for CreateVerifyAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| verifyRequest |  ``` Required ```  | The verify request body |

#### Example Usage for CreateVerifyAsync

```csharp
var verifyRequest = new VerifyRequest
{
    AcceptTruliooTermsAndConditions = true,
    Country = Country.GreatBritain,
    CustomerReferenceId = "Test",
    DataFields = new DataFields
    {
        PersonInfo = new PersonInfo(),
        Location = new Location()
    }
};
verifyRequest.DataFields.PersonInfo.FirstGivenName = "Julia";
verifyRequest.DataFields.PersonInfo.FirstSurName = "Audi";
verifyRequest.DataFields.PersonInfo.MiddleName = "Ronald";
verifyRequest.DataFields.PersonInfo.DayOfBirth =26;
verifyRequest.DataFields.PersonInfo.MonthOfBirth = 1;
verifyRequest.DataFields.PersonInfo.YearOfBirth = 1979;

verifyRequest.DataFields.Location.BuildingNumber = "12";
verifyRequest.DataFields.Location.BuildingName = "Beck";
verifyRequest.DataFields.Location.UnitNumber = 1;
verifyRequest.DataFields.Location.StreetName = "Moorfoot";
verifyRequest.DataFields.Location.StreetType = "Way";
verifyRequest.DataFields.Location.PostalCode = "L33 1WZ";

var result = await truliooClient.Verifications.CreateVerifyAsync(verifyRequest);
```

### <a name="get_transaction_record"></a>![Method: ](https://raw.githubusercontent.com/Jayman1305/TruliooSDK/master/TruliooSDK/method.png "TruliooSDK.Standard.Controllers.VerificationsController.GetTransactionRecord") GetTransactionRecord

> This method is used to retrieve the request and results of a verification performed using the verify method. 
> 
> The response for this method includes the same information as verify method's response, along with data present in the input fields of the verify request.

```csharp
Models.TransactionRecordResult GetTransactionRecord(string id);
//Async
Task<Models.TransactionRecordResult> GetTransactionRecordAsync(string id);
```

#### Parameters for GetTransactionRecordAsync

| Parameter | Tags | Description |
|-----------|------|-------------|
| id |  ``` Required ```  | The TransactionRecordID from the Verify response, this will be a GUID |

#### Example Usage for GetTransactionRecordAsync

```csharp
string id = "id";

var result = await verifications.GetTransactionRecordAsync(id);

```
#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |

[Back to List of Controllers](#list_of_controllers)
