using System.Collections.Generic;
using System.Text;
using TruliooSDK.Utilities;

namespace TruliooSDK
{
    public class Configuration
    {

        public Configuration()
        {
            HostingEnvironment = Environment.Trial;
        }
        public enum Environment
        {
            //Production environment
            Production,
            //Trial environment
            Trial,
        }

        //The current environment being used
        public static Environment HostingEnvironment { get; set; }

        //Trulioo Api Key
        public static string XTruliooApiKey { get; set; }

        ////A map of environments and their corresponding servers/baseurls
        //public static Dictionary<Environment, Dictionary<Servers, string>> EnvironmentsMap =
        //    new Dictionary<Environment, Dictionary<Servers, string>>
        //    {
        //        { 
        //            Environment.Production,new Dictionary<Servers, string>
        //            {
        //                { Servers.EnumDefault,"https://gateway.trulioo.com" },
        //            }
        //        },
        //        { 
        //            Environment.Trial,new Dictionary<Servers, string>
        //            {
        //                { Servers.EnumDefault,"https://gateway.trulioo.com/trial" },
        //            }
        //        },
        //    };

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
            var url = HostingEnvironment == Environment.Trial ? new StringBuilder("https://gateway.trulioo.com/trial") : new StringBuilder("https://gateway.trulioo.com");
            APIHelper.AppendUrlWithTemplateParameters(url, GetBaseURIParameters());
            return url.ToString();        
        }
    }
}