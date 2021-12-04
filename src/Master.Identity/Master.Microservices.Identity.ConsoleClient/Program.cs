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
            var documentResponse = await GetIdsDicoveryDocumentAsync(IdentityConfig.Authority);

            var tokenResponse = await RequestAccessToken(documentResponse.TokenEndpoint, Api.Orders.ClientId, Api.Orders.Secret, Api.Orders.Scope);
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);               
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var response = await CallApiAsync(Api.Orders.ApiEndpoint, "ping", tokenResponse.AccessToken);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);               
            }
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                Console.WriteLine(JArray.Parse(content));
            }
           
            Console.ReadKey();
        }

        private static async Task<DiscoveryDocumentResponse> GetIdsDicoveryDocumentAsync(string identityAuthority)
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

        private static async Task<HttpResponseMessage> CallApiAsync(string apiEndpoint, string controller, string accessToken)
        {
            var apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.SetBearerToken(accessToken);
            var response = await apiClient.GetAsync($"{apiEndpoint}/{controller}");
            return response;
        }
    }   
}
