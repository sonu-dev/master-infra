namespace Master.Microservices.Identity.ViewModels
{
    public class TokenRequestViewModel
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Scope { get; set; }
    }
}
