using System.Collections.Generic;

namespace Master.Web.Api.Providers.TokenProvider
{
    public interface ITokenProvider
    {
        string GetJwtToken(List<UserClaim> claims);        
    }
}
