namespace Master.Web.Api.Options
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int TokenExpiryInDays { get; set; }
    }
}
