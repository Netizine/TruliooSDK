using System.Collections.Generic;
using System.Text;
using TruliooSDK.Utilities;

namespace TruliooSDK
{
    public class Configuration
    {

        public Configuration()
        {
            Mode = Mode.Trial;
        }

        //The current environment being used
        public static Mode Mode { get; set; }

        /// <summary>
        /// Trulioo Api Key
        /// </summary>
        public static string XTruliooApiKey { get; set; }


        /// <summary>
        /// Makes a list of the BaseURL parameters 
        /// </summary>
        /// <return>Returns the parameters list</return>
        internal static List<KeyValuePair<string, object>> GetBaseURIParameters()
        {
            var kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList; 
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <return>Returns the baseurl</return>
        internal static string GetBaseURI()
        {
            var url = new StringBuilder("https://gateway.trulioo.com");
            APIHelper.AppendUrlWithTemplateParameters(url, GetBaseURIParameters());
            return url.ToString();        
        }
    }
}
