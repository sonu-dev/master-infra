using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Master.Microservices.Identity.Client
{
    public class IdentityClientManager
    {
        const string _authority = "https://localhost:5005";
        public static async Task<TokenResponse> GenerateTokenAsync(string clientId, string scope, string secret)
        {
            // discover identity endpoints from metadata
            var documentResponse = await GetDicoveryDocumentAsync(_authority);

            var tokenResponse = await RequestAccessToken(documentResponse.TokenEndpoint, clientId, secret, scope);
            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            return tokenResponse;
        }
        private static async Task<DiscoveryDocumentResponse> GetDicoveryDocumentAsync(string identityAuthority)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(identityAuthority);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return null;
            }
            return disco;
        }

        private static async Task<TokenResponse> RequestAccessToken(string tokenEndPoint, string clientId, string sceret, string scope)
        {
            var client = new HttpClient();
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = tokenEndPoint,
                ClientId = clientId,
                ClientSecret = sceret,
                Scope = scope
            });
            return tokenResponse;
        }
    }
}
