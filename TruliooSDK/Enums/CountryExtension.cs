using System;

namespace TruliooSDK.Enums
{
    public static class CountryExtension
    {
        public static string ToAlpha2CodeString(this Country code)
        {
            switch (code)
            {
                case Country.Australia:
                    return "AU";
                case Country.Austria:
                    return "AT";
                case Country.Denmark:
                    return "DK";
                case Country.Norway:
                    return "NO";
                case Country.Sweden:
                    return "SE";
                case Country.Turkey:
                    return "TR";
                case Country.Brazil:
                    return "BR";
                case Country.Belgium:
                    return "BE";
                case Country.Germany:
                    return "DE";
                case Country.Netherlands:
                    return "NL";
                case Country.GreatBritain:
                    return "GB";
                case Country.UnitedStates:
                    return "US";
                case Country.Malaysia:
                    return "MY";
                case Country.Russia:
                    return "RU";
                default:
                    throw new ArgumentOutOfRangeException(nameof(code), code, "Country code not mapped");
            }
        }
    }
}
