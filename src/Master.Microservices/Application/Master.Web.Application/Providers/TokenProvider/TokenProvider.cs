using Master.Web.Api.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Master.Web.Api.Providers.TokenProvider
{
    public class TokenProvider : ITokenProvider
    {
        private AppSettings _appSettings;
        public TokenProvider(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string GetJwtToken(List<UserClaim> claims)
        {
            // generate token that is valid for TokenExpiryInDays 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Add claims
                Subject = new ClaimsIdentity(GetClaims(claims).ToArray()),
                // Set token expiry
                Expires = DateTime.UtcNow.AddDays(_appSettings.TokenExpiryInDays),
                // Sign token with secret key
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private List<Claim> GetClaims(List<UserClaim> userClaims)
        {
            var claims = new List<Claim>();
            userClaims.ForEach(uc => claims.Add(new Claim(uc.Name, uc.Value)));
            return claims;
        }
    }
}
