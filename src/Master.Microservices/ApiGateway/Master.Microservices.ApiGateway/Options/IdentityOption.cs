namespace Master.Microservices.ApiGateway.Options
{
    public class IdentityOption
    {
        public string IdentityProviderKey { get; set; }
        public string Authority { get; set; }     
        public bool RequireHttpsMetadata { get; set; }
    }
}
