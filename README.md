# Getting started

Trulioo SDK

## How to Use

The following section explains how to use the Trulioo C# SDK library in a C# project.

## Initialization

### Authentication
In order to setup authentication and initialization of the API client, you need the following information.

| Parameter | Description |
|-----------|-------------|
| hostingEnvironment | Trulioo Hosting Environment |
| xTruliooApiKey | Trulioo Api Key |



API client can be initialized as following.

```csharp
// Configuration parameters and credentials
Configuration.Environment hostingEnvironment = TruliooSDK.Configuration.Environment.Trial;
string xTruliooApiKey = "xTruliooApiKey"; // Trulioo Api Key

TruliooSDKClient client = new TruliooSDKClient(hostingEnvironment, xTruliooApiKey);
```



# Class Reference

## <a name="list_of_controllers"></a>List of Controllers

* [ConnectionController](#connection_controller)
* [ConfigurationController](#configuration_controller)
* [VerificationsController](#verifications_controller)

## <a name="connection_controller"></a>![Class: ]("TruliooSDK.Standard.Controllers.ConnectionController") ConnectionController

### Get singleton instance

The singleton instance of the ``` ConnectionController ``` class can be accessed from the API Client.

```csharp
IConnectionController connection = client.Connection;
```

### <a name="get_test_authentication"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConnectionController.GetTestAuthentication") GetTestAuthentication

> This method enables you to check if your credentials are valid. You will need to use ApiKeyAuth authentication to ensure a successful response.


```csharp
Task<string> GetTestAuthentication(string mode)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |


#### Example Usage

```csharp
string mode = "trial";

string result = await connection.GetTestAuthentication(mode);

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

## <a name="configuration_controller"></a>![Class: ]("TruliooSDK.Standard.Controllers.ConfigurationController") ConfigurationController

### Get singleton instance

The singleton instance of the ``` ConfigurationController ``` class can be accessed from the API Client.

```csharp
IConfigurationController configuration = client.Configuration;
```

### <a name="get_country_codes"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetCountryCodes") GetCountryCodes

> This method retrieves all the countries that are available to perform a verification. It returns an array of Alpha2 Country Codes


```csharp
Task<List<string>> GetCountryCodes(string mode, string configurationName)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| configurationName |  ``` Required ```  ``` DefaultValue ```  | The product configuration. Currently "Identity Verification" for all products. |


#### Example Usage

```csharp
string mode = "trial";
string configurationName = "Identity Verification";

List<string> result = await configuration.GetCountryCodes(mode, configurationName);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_test_entities"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetTestEntities") GetTestEntities

> Gets the test entities configured for your product and country.


```csharp
Task<List<Models.DataFields>> GetTestEntities(string mode, string configurationName, string countryCode)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| configurationName |  ``` Required ```  ``` DefaultValue ```  | The product configuration. Currently "Identity Verification" for all products. |
| countryCode |  ``` Required ```  | Country alpha2 code |


#### Example Usage

```csharp
string mode = "trial";
string configurationName = "Identity Verification";
string countryCode = "countryCode";

List<Models.DataFields> result = await configuration.GetTestEntities(mode, configurationName, countryCode);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_fields"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetFields") GetFields

> Generates json schema for the API, the schema is dynamic based on the country and configuration you are using json-schema.org


```csharp
Task<object> GetFields(string mode, string countryCode, string configurationName)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| countryCode |  ``` Required ```  | Country alpha2 code |
| configurationName |  ``` Required ```  ``` DefaultValue ```  | The product configuration. Currently "Identity Verification" for all products. |


#### Example Usage

```csharp
string mode = "trial";
string countryCode = "countryCode";
string configurationName = "Identity Verification";

object result = await configuration.GetFields(mode, countryCode, configurationName);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_recommended_fields"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetRecommendedFields") GetRecommendedFields

> Generates json schema for the API, the schema is dynamic based on the recommendedFields country and account you are using.
> 
> http://json-schema.org/documentation.html


```csharp
Task<object> GetRecommendedFields(string mode, string countryCode, string configurationName)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| countryCode |  ``` Required ```  | Country alpha2 code |
| configurationName |  ``` Required ```  ``` DefaultValue ```  | The product configuration. Currently "Identity Verification" for all products. |


#### Example Usage

```csharp
string mode = "trial";
string countryCode = "countryCode";
string configurationName = "Identity Verification";

object result = await configuration.GetRecommendedFields(mode, countryCode, configurationName);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_consents"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetConsents") GetConsents

> This method retrieves the consents required for the data sources currently configured in your account configuration. 
> 
> The response for this method contains a collection of string that Verify method's ConsentForDataSources field expects to perform a verification using those data sources. 
> 
> Failure to provide an element from the string collection will lead to a 1005 service error


```csharp
Task<List<string>> GetConsents(string mode, string countryCode, string configurationName)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| countryCode |  ``` Required ```  | Country alpha2 code |
| configurationName |  ``` Required ```  ``` DefaultValue ```  | The product configuration. Currently "Identity Verification" for all products. |


#### Example Usage

```csharp
string mode = "trial";
string countryCode = "countryCode";
string configurationName = "Identity Verification";

List<string> result = await configuration.GetConsents(mode, countryCode, configurationName);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_detailed_consents"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetDetailedConsents") GetDetailedConsents

> This method retrieves details about consents required for data sources currently configured in your account configuration. 
> 
> The response for this method contains a collection of objects.
> 
> Each object contains the Name of the data source, Text outlining what the user is consenting to, and optionally a Url where the user can find more information about how their data will be used.  
> 
> Failure to provide a Name from the object collection will lead to a 1005 service error.


```csharp
Task<List<Models.Consent>> GetDetailedConsents(string mode, string countryCode, string configurationName)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| countryCode |  ``` Required ```  | Call CountryCodes to get the countries available to you. |
| configurationName |  ``` Required ```  ``` DefaultValue ```  | Identity Verification |


#### Example Usage

```csharp
string mode = "trial";
string countryCode = "countryCode";
string configurationName = "Identity Verification";

List<Models.Consent> result = await configuration.GetDetailedConsents(mode, countryCode, configurationName);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_country_subdivisions"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetCountrySubdivisions") GetCountrySubdivisions

> Gets the provinces states or other subdivisions for a country, mostly matches ISO 3166-2


```csharp
Task<List<Models.CountrySubdivision>> GetCountrySubdivisions(string mode, string countryCode)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| countryCode |  ``` Required ```  | Country alpha2 code |


#### Example Usage

```csharp
string mode = "trial";
string countryCode = "countryCode";

List<Models.CountrySubdivision> result = await configuration.GetCountrySubdivisions(mode, countryCode);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_datasources"></a>![Method: ]("TruliooSDK.Standard.Controllers.ConfigurationController.GetDatasources") GetDatasources

> Gets datasource groups configured for your product and country.


```csharp
Task<List<Models.NormalizedDatasourceGroupCountry>> GetDatasources(string mode, string configurationName, string countryCode)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| configurationName |  ``` Required ```  ``` DefaultValue ```  | The product configuration. Currently "Identity Verification" for all products. |
| countryCode |  ``` Required ```  | Country alpha2 code |


#### Example Usage

```csharp
string mode = "trial";
string configurationName = "Identity Verification";
string countryCode = "countryCode";

List<Models.NormalizedDatasourceGroupCountry> result = await configuration.GetDatasources(mode, configurationName, countryCode);

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

## <a name="verifications_controller"></a>![Class: ]("TruliooSDK.Standard.Controllers.VerificationsController") VerificationsController

### Get singleton instance

The singleton instance of the ``` VerificationsController ``` class can be accessed from the API Client.

```csharp
IVerificationsController verifications = client.Verifications;
```

### <a name="create_verify"></a>![Method: ]("TruliooSDK.Standard.Controllers.VerificationsController.CreateVerify") CreateVerify

> Calling this method will perform a verification. If your account includes address cleansing set the CleansedAddress flag to get
> 
> additional address information in the result.  You can query configuration to get what fields are available to you in each country.
> 
> It is also possible to get sample requests from the customer portal. If you are configured for a sandbox account make sure to call Get Test Entities to get test data for a country you want to try. Sandbox accounts only use these test entities and so trying to verify with any other data will result in no matches being found.


```csharp
Task<Models.VerifyResult> CreateVerify(string mode, Models.VerifyRequest body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| body |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
string mode = "trial";
var body = new Models.VerifyRequest();

Models.VerifyResult result = await verifications.CreateVerify(mode, body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Your request could not be processed, there should be more details in the response. |
| 401 | The user name and password you provided is not valid or you are using an account not configured to be an API user. |
| 408 | The request took longer to process than we waited. |
| 415 | You asked for a media type that we do not support. You should request application/json in the Content-Type header. |
| 500 | An error happened on the server without a specific message. |


### <a name="get_transaction_record"></a>![Method: ]("TruliooSDK.Standard.Controllers.VerificationsController.GetTransactionRecord") GetTransactionRecord

> This method is used to retrieve the request and results of a verification performed using the verify method. 
> 
> The response for this method includes the same information as verify method's response, along with data present in the input fields of the verify request.


```csharp
Task<Models.TransactionRecordResult> GetTransactionRecord(string mode, string id)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| mode |  ``` Required ```  ``` DefaultValue ```  | free trial or live |
| id |  ``` Required ```  | The TransactionRecordID from the Verify response, this will be a GUID |


#### Example Usage

```csharp
string mode = "trial";
string id = "id";

Models.TransactionRecordResult result = await verifications.GetTransactionRecord(mode, id);

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


