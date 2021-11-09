namespace Master.Microservices.Identity.ConsoleClient
{
    public static class Api
    {
        public static class Orders
        {
            public const string ApiEndpoint = "https://localhost:5001/api";
            public const string ClientId = "ordersApiClient";
            public const string Secret = "secret1";
            public const string Scope = "api";
        }

        public static class Payments
        {
            public const string ApiEndpoint = "https://localhost:5002/api";
            public const string ClientId = "paymentsApiClient";
            public const string Secret = "secret1";
            public const string Scope = "api";
        }
    }
}
