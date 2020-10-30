using System.Collections.Generic;
using System.Text;
using TruliooSDK.Utilities;

namespace TruliooSDK
{
    public class Configuration
    {
        protected Configuration()
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
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <return>Returns the base url</return>
        internal static string GetBaseURI()
        {
            return "https://gateway.trulioo.com";        
        }
    }
}
