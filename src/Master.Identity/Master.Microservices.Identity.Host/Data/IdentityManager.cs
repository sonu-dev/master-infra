using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityClient = IdentityServer4.Models.Client;

namespace Master.Microservices.Identity.Data
{
    public class IdentityManager
    {
        public static IEnumerable<IdentityClient> GetClients()
        {
            return new List<IdentityClient>
            {
               new IdentityClient
               {
                   ClientId = "ordersApiClient",
                   // no interactive user, use the clientid/secret for authentication
                   AllowedGrantTypes = new List<string> { OidcConstants.GrantTypes.ClientCredentials },
                   ClientSecrets = new List<Secret> { new Secret("secret1".ToSha256()) },
                   AllowedScopes = new List<string> { "api" }
               },
               new IdentityClient
               {
                   ClientId = "paymentsApiClient",
                   // no interactive user, use the clientid/secret for authentication
                   AllowedGrantTypes = new List<string> { OidcConstants.GrantTypes.ClientCredentials },
                   ClientSecrets = new List<Secret> { new Secret("secret2".ToSha256()) },
                   AllowedScopes = new List<string> { "api" }
               }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
             {
              new ApiScope("api", "Master Microservices API")
             };
        }
    }
}
