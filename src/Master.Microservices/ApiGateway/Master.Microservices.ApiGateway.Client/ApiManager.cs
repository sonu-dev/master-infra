using IdentityModel.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Master.Microservices.ApiGateway.Client
{
    public class ApiManager
    {
        public static async Task<HttpResponseMessage> ExecuteAsync(string url, string accessToken)
        {
            var apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.SetBearerToken(accessToken);
            var response = await apiClient.GetAsync(url);
            return response;
        }
    }
}
