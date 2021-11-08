namespace Master.Microservices.Common.Identity
{
    public class IdentityClaim
    {
        public IdentityClaim(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }
    }
}
