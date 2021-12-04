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
            public const string BaseUrl = "http://localhost:5000/gw";
            public class OrdersService
            {               
                public const string ClientId = "ordersApiClient";
                public const string Secret = "secret1";
                public const string Scope = "api";
                public class Actions
                {
                    public const string Ping = "ping-order";
                }
            }

            public class PaymentsService
            {               
                public const string ClientId = "paymentsApiClient";
                public const string Secret = "secret1";
                public const string Scope = "api";
            }
        }
    }
}
