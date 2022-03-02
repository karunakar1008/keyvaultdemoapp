using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace AzureKeyvaultDemoApp
{
    public class Utils
    {
        static string appId = ConfigurationManager.AppSettings["ClientId"];
        static string appSecret = ConfigurationManager.AppSettings["ClientSecret"];


        public static async Task<string> GetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(appId, appSecret);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);
            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");
            return result.AccessToken;
        }

    }
}