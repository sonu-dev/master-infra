using IdentityServer4.Models;
using System.Collections.Generic;

namespace Master.Microservices.Identity.Data
{
    public class IdentityManager
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               new Client
               {
                   ClientId = "apiClient",
                   // no interactive user, use the clientid/secret for authentication
                   AllowedGrantTypes = GrantTypes.ClientCredentials,
                   ClientSecrets = new List<Secret> { new Secret("secret".Sha256()) },
                   AllowedScopes = new List<string> { "api" }
               }               
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
             {
              new ApiScope("api", "Master Microservices API")             
             };
        }

        //public static IList<ApiResource> GetApiResources()
        //{
        //    return new List<ApiResource>();
        //}

        //public static IList<IdentityResource> GetIdentityResources()
        //{
        //    return new List<IdentityResource>
        //    {
        //      new IdentityResources.OpenId(),
        //      new IdentityResources.Profile(),
        //      new IdentityResources.Address(),
        //      new IdentityResources.Email(),
        //      new IdentityResource(
        //            "roles",
        //            "your role(s)",
        //            new List<string>() { "admin", "user" })
        //     };
        //}

        //public static IList<TestUser> GetIdentityUsers()
        //{
        //    return new List<TestUser>
        //    {
        //        new TestUser
        //        {
        //            SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
        //            Username = "sonu",
        //            Password = "Welcome1",
        //            Claims = new List<Claim>
        //            {
        //                new Claim(JwtClaimTypes.GivenName, "sonu kumar"),
        //                new Claim(JwtClaimTypes.Email, "sonu.econnect@gmail.com")
        //            }
        //        }
        //    };
        //}
    }
}
