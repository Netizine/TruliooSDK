
using TruliooSDK.Controllers;
using TruliooSDK.Http.Client;

namespace TruliooSDK
{
    public class TruliooSDKClient: ITruliooSDKClient
    {
        public Configuration.Environment HostingEnvironment { get; }

        /// <summary>
        /// Singleton access to Connection controller
        /// </summary>
        public IConnectionController Connection => ConnectionController.Instance;

        /// <summary>
        /// Singleton access to Configuration controller
        /// </summary>
        public IConfigurationController Configuration => ConfigurationController.Instance;

        /// <summary>
        /// Singleton access to Verifications controller
        /// </summary>
        public IVerificationsController Verifications => VerificationsController.Instance;

        /// <summary>
        /// The shared http client to use for all API calls
        /// </summary>
        public IHttpClient SharedHttpClient
        {
            get => BaseController.ClientInstance;
            set => BaseController.ClientInstance = value;
        }
        #region Constructors
        /// <summary>
        /// Default constructor 
        /// </summary>
        private TruliooSDKClient() { }

        /// <summary>
        /// Client initialization constructor
        /// </summary>
        public TruliooSDKClient(Configuration.Environment hostingEnvironment, string xTruliooApiKey)
        {
            HostingEnvironment = hostingEnvironment;
            TruliooSDK.Configuration.HostingEnvironment = hostingEnvironment;
            TruliooSDK.Configuration.XTruliooApiKey = xTruliooApiKey;
        }
        #endregion
    }
}