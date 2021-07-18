namespace Master.Web.Api.Providers.TokenProvider
{
    public class UserClaim
    {
        public UserClaim(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
