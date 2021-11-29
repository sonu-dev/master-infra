using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.ApiGateway.Client
{
    public class Client
    {
        public async Task ExecuteAsync(string apiUrl)
        {
            // STEP #1: Get identity metadata
            var identityDisco = await IdentityManager.GetIdentityDiscoveryDocumentAsync();
            if (identityDisco == null)
            {
                return;
            }

            if (identityDisco.IsError)
            {
                Console.WriteLine(identityDisco.Error);
                return;
            }

            // STEP #2: Authenticate Api and get request token
            var accessTokenResponse = await IdentityManager.RequestAccessTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = identityDisco.TokenEndpoint,
                ClientId = Constants.ApiConfig.OrdersService.ClientId,
                ClientSecret = Constants.ApiConfig.OrdersService.Secret,
                Scope = Constants.ApiConfig.OrdersService.Scope
            });
            if (accessTokenResponse.IsError)
            {
                Console.WriteLine(accessTokenResponse.Error);
                return;
            }

            Console.WriteLine(accessTokenResponse.Json);
            Console.WriteLine("\n\n");

            // STEP #3: Call Api using HttpClient
            var response = await ApiManager.ExecuteAsync(apiUrl, accessTokenResponse.AccessToken);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JArray.Parse(content));

            Console.ReadKey();
        }
    }
}
