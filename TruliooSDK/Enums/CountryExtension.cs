using System;
using System.Collections.Generic;
using System.Text;

namespace TruliooSDK.Enums
{
    public static class CountryExtension
    {
        public static string ToFriendlyString(this CountryCode mode)
        {
            switch (mode)
            {
                case CountryCode.Australia:
                    return "AU";
                case CountryCode.Austria:
                    return "AT";
                case CountryCode.Denmark:
                    return "DK";
                case CountryCode.Norway:
                    return "NO";
                case CountryCode.Sweden:
                    return "SE";
                case CountryCode.Turkey:
                    return "TR";
                case CountryCode.Brazil:
                    return "BR";
                case CountryCode.Belgium:
                    return "BE";
                case CountryCode.Germany:
                    return "DE";
                case CountryCode.Netherlands:
                    return "NL";
                case CountryCode.GreatBritain:
                    return "GB";
                case CountryCode.UnitedStates:
                    return "US";
                case CountryCode.Malaysia:
                    return "MY";
                case CountryCode.Russia:
                    return "RU";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
