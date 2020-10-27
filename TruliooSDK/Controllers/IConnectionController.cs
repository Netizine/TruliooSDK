using System.Threading.Tasks;

namespace TruliooSDK.Controllers
{
    public interface IConnectionController
    {
        /// <summary>
        /// This method enables you to check if your credentials are valid. You will need to use ApiKeyAuth authentication to ensure a successful response.
        /// </summary>
        /// <return>Returns the string response from the API call</return>
        string GetTestAuthentication();

        /// <summary>
        /// This method enables you to check if your credentials are valid. You will need to use ApiKeyAuth authentication to ensure a successful response.
        /// </summary>
        /// <return>Returns the string response from the API call</return>
        Task<string> GetTestAuthenticationAsync();

    }
} 
