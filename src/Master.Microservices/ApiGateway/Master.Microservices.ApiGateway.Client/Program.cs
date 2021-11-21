using System;
using System.Threading.Tasks;

namespace Master.Microservices.ApiGateway.Client
{
    class Program
    {
        static async void Main(string[] args)
        {
            var apiUrl = $"{Constants.ApiConfig.OrdersService.ApiEndpoint}{Constants.ApiConfig.OrdersService.Actions.Ping}";
            var client = new Client();
            await client.ExecuteAsync(apiUrl);

            Console.ReadKey();
        }
    }
}
