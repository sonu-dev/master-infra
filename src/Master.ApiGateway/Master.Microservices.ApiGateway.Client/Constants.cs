namespace Master.Microservices.ApiGateway.Client
{
    public class Constants
    {
        public class IdentityConfig
        {
            public const string Authority = "https://localhost:5005";
        }

        public class ApiConfig
        {
            public class OrdersService
            {
                public const string ApiEndpoint = "https://localhost:5001/api";
                public const string ClientId = "ordersApiClient";
                public const string Secret = "secret1";
                public const string Scope = "api";
                public class Actions
                {
                    public const string Ping = "/ping-api/";
                }
            }

            public class PaymentsService
            {
                public const string ApiEndpoint = "https://localhost:5002/api";
                public const string ClientId = "paymentsApiClient";
                public const string Secret = "secret1";
                public const string Scope = "api";
            }
        }
    }
}
