using System;
using System.Threading.Tasks;

namespace Master.Microservices.ApiGateway.Client
{
    class Program
    {
       public static async Task Main(string[] args)
        {
            Console.Title = "ApiGateway Client";
            var apiUrl = $"{Constants.ApiConfig.BaseUrl}/{Constants.ApiConfig.OrdersService.Actions.Ping}";
            var client = new Client();
            await client.ExecuteAsync(apiUrl);

            Console.ReadKey();
        }
    }
}
