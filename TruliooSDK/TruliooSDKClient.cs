
using TruliooSDK.Controllers;
using TruliooSDK.Http.Client;

namespace TruliooSDK
{
    public class TruliooSDKClient: ITruliooSDKClient
    {

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
        public TruliooSDKClient(Mode mode, string xTruliooApiKey)
        {
            TruliooSDK.Configuration.Mode = mode;
            TruliooSDK.Configuration.XTruliooApiKey = xTruliooApiKey;
        }
        #endregion
    }
}
