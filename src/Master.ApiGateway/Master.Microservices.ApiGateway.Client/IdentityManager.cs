using IdentityModel.Client;
using System.Net.Http;
using System.Threading.Tasks;

namespace Master.Microservices.ApiGateway.Client
{
    public class IdentityManager
    {
        public static async Task<DiscoveryDocumentResponse> GetIdentityDiscoveryDocumentAsync()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(Constants.IdentityConfig.Authority);
            return disco;
        }

        public static async Task<TokenResponse> RequestAccessTokenAsync(ClientCredentialsTokenRequest clientCredentialsTokenRequest)
        {
            var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            return tokenResponse;
        }
    }
}
