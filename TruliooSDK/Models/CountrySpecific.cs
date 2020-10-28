using System;
using System.Collections.Generic;
using System.Text;

namespace TruliooSDK.Models
{
    /// <summary>
    /// Fields specific for the country the verification is being done for.  
    /// Call configuration/v1/fields/Identity Verification/countryCode to get the list of fields that are valid for your configuration
    /// </summary>
    public class CountrySpecific : Dictionary<string, Dictionary<string, string>>
    {
    }
}
