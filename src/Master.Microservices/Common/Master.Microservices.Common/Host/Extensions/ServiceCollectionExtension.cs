using Master.Microservices.Common.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Master.Microservices.Common.Host.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddSwagger(this IServiceCollection services, string apiTitle, string version)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = apiTitle, Version = version });
            });
        }

        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration, string policy, List<IdentityClaim> claims)
        {
            services.AddHttpContextAccessor();

            var identityOptions = new IdentityOptions();
            configuration.GetSection(typeof(IdentityOptions).Name).Bind(identityOptions);

            if(string.IsNullOrEmpty(identityOptions.Authority))
            {
                throw new ArgumentNullException(nameof(identityOptions.Authority));
            }

            services.AddAuthentication("Bearer")
                   .AddJwtBearer("Bearer", options =>
                   {                     
                       options.Authority = identityOptions.Authority;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateAudience = false
                       };
                   });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(policy, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    claims.ForEach(c => policy.RequireClaim(c.ClaimType, c.ClaimValue));                    
                });
            });
        }
    }
}
