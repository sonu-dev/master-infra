using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Master.Microservices.Identity.ConsoleClient
{
    class Program
    {
        private static async Task Main()
        {
            // discover identity endpoints from metadata
            var tokenResponse = await RequestAccessTokenAsync(IdentityConfig.Authority);

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var response = await CallApiAsync(ApiConfig.OrdersApiEndpoint, "order", "ping", tokenResponse.AccessToken);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JArray.Parse(content));
        }

        private static async Task<TokenResponse> RequestAccessTokenAsync(string identityAuthority)
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(identityAuthority);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return null;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "apiClient",
                ClientSecret = "secret",
                Scope = "api"
            });
            return tokenResponse;
        }

        private static async Task<HttpResponseMessage> CallApiAsync(string apiEndpoint, string controller, string action, string accessToken)
        {
            var apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.SetBearerToken(accessToken);
            var response = await apiClient.GetAsync($"{ApiConfig.OrdersApiEndpoint}/{controller}/{action}");
            return response;
        }
    }   
}
