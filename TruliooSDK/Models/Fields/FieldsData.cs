using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TruliooSDK.Enums;

namespace TruliooSDK.Models.Fields
{
    public class FieldsData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        //[JsonProperty("type")]
        //public TypeEnum Type { get; set; }

        [JsonProperty("properties")]
        public FieldsDataProperties Properties { get; set; }
    }

    public class FieldsDataProperties
    {
        [JsonProperty("PersonInfo")]
        public PersonInfoData PersonInfo { get; set; }

        [JsonProperty("Location")]
        public LocationData Location { get; set; }

        [JsonProperty("Communication")]
        public CommunicationData Communication { get; set; }

        [JsonProperty("DriverLicence")]
        public DriverLicenceData DriverLicence { get; set; }

        [JsonProperty("NationalIds")]
        public NationalIdsData NationalIds { get; set; }

        [JsonProperty("CountrySpecific")]
        public CountrySpecificData CountrySpecific { get; set; }
    }

    public class CommunicationData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public CommunicationProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<object> RequiredFields { get; set; }
    }

    public class CommunicationProperties
    {
        [JsonProperty("MobileNumber")]
        public Field MobileNumber { get; set; }

        [JsonProperty("Telephone")]
        public Field Telephone { get; set; }

        [JsonProperty("EmailAddress")]
        public Field EmailAddress { get; set; }

        [JsonProperty("Telephone2")]
        public Field Telephone2 { get; set; }
    }

    //public class PropertiesProperties
    //{
    //    [JsonProperty("Address1")]
    //    public Field Address1 { get; set; }
    //}

    public class FieldProperties
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        //[JsonProperty("properties")]
        //public PropertiesProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<object> RequiredFields { get; set; }
    }

    public class Field
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public FieldProperties Properties { get; set; }
    }

    public class CountrySpecificData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public CountrySpecificProperties Properties { get; set; }
    }

    public class CountrySpecificProperties
    {
        [JsonProperty("US")]
        public UnitedStates UnitedStates { get; set; }

        [JsonProperty("BE")]
        public Belgium Belgium { get; set; }

        [JsonProperty("NL")]
        public Netherlands Netherlands { get; set; }

        [JsonProperty("RU")]
        public Russia Russia { get; set; }
    }

    public class UnitedStates
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("properties")]
        public UnitedStatesProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<object> RequiredFields { get; set; }
    }

    public class UnitedStatesProperties
    {
        [JsonProperty("DriverLicenceNumber")]
        public Field DriverLicenceNumber { get; set; }

        [JsonProperty("IPAddress")]
        public Field IpAddress { get; set; }
    }

    public partial class Belgium
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public BelgiumProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<object> BeRequired { get; set; }
    }

    public partial class BelgiumProperties
    {
        [JsonProperty("HouseExtension")]
        public Field HouseExtension { get; set; }
    }

    public partial class Netherlands
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public NetherlandsProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<object> NetherlandsRequired { get; set; }
    }

    public partial class NetherlandsProperties
    {
        [JsonProperty("HouseExtension")]
        public Field HouseExtension { get; set; }
    }

    public partial class Russia
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public RussiaProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<string> RussiaRequired { get; set; }
    }

    public partial class RussiaProperties
    {
        [JsonProperty("DayOfIssue")]
        public Field DayOfIssue { get; set; }

        [JsonProperty("InternalPassportNumber")]
        public Field InternalPassportNumber { get; set; }

        [JsonProperty("MonthOfIssue")]
        public Field MonthOfIssue { get; set; }

        [JsonProperty("PassportSerie")]
        public Field PassportSerie { get; set; }

        [JsonProperty("YearOfIssue")]
        public Field YearOfIssue { get; set; }
    }

    public class DriverLicenceData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public DriverLicenceProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<object> RequiredFields { get; set; }
    }

    public class DriverLicenceProperties
    {
        [JsonProperty("Number")]
        public Field Number { get; set; }
    }

    public class LocationData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public LocationProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<string> RequiredFields { get; set; }
    }

    public class LocationProperties
    {
        [JsonProperty("BuildingNumber")]
        public Field BuildingNumber { get; set; }

        [JsonProperty("UnitNumber")]
        public Field UnitNumber { get; set; }

        [JsonProperty("StreetName")]
        public Field StreetName { get; set; }

        [JsonProperty("StreetType")]
        public Field StreetType { get; set; }

        [JsonProperty("City")]
        public Field City { get; set; }

        [JsonProperty("StateProvinceCode")]
        public Field StateProvinceCode { get; set; }

        [JsonProperty("PostalCode")]
        public Field PostalCode { get; set; }

        [JsonProperty("AdditionalFields")]
        public Field AdditionalFields { get; set; }

        [JsonProperty("Suburb")]
        public Field Suburb { get; set; }

    }

    public class NationalIdsData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public NationalIdsProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<object> RequiredFields { get; set; }
    }

    public class NationalIdsProperties
    {
        [JsonProperty("Number")]
        public Number Number { get; set; }

        [JsonProperty("Type")]
        public TypeClass Type { get; set; }
    }

    public class Number
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class TypeClass
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class PersonInfoData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public PersonInfoProperties Properties { get; set; }

        [JsonProperty("required")]
        public List<string> RequiredFields { get; set; }
    }

    public class PersonInfoProperties
    {
        [JsonProperty("FirstGivenName")]
        public Field FirstGivenName { get; set; }

        [JsonProperty("MiddleName")]
        public Field MiddleName { get; set; }

        [JsonProperty("FirstSurName")]
        public Field FirstSurName { get; set; }

        [JsonProperty("DayOfBirth")]
        public Field DayOfBirth { get; set; }

        [JsonProperty("MonthOfBirth")]
        public Field MonthOfBirth { get; set; }

        [JsonProperty("YearOfBirth")]
        public Field YearOfBirth { get; set; }

        [JsonProperty("Gender")]
        public Field Gender { get; set; }

    }
}
