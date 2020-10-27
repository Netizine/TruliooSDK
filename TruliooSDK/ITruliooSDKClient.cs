using TruliooSDK.Controllers;

namespace TruliooSDK
{
    public interface ITruliooSDKClient
    {

        /// <summary>
        /// Singleton access to Connection controller
        /// </summary>
        IConnectionController Connection { get;}

        /// <summary>
        /// Singleton access to Configuration controller
        /// </summary>
        IConfigurationController Configuration { get;}

        /// <summary>
        /// Singleton access to Verifications controller
        /// </summary>
        IVerificationsController Verifications { get;}

    }
}