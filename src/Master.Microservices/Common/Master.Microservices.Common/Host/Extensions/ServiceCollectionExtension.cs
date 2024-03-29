﻿using Master.Microservices.Common.Constants;
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

        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration, List<IdentityClaim> claims)
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
                options.AddPolicy(IdentityConstants.AuthoirizePolicy, policy =>
                {
                    //policy.RequireAuthenticatedUser();
                    claims.ForEach(c => policy.RequireClaim(c.ClaimType, c.ClaimValue));                    
                });
            });
        }

        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                // Specify the default API Version as 1.0
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                o.AssumeDefaultVersionWhenUnspecified = false;
                // Advertise the API versions supported for the particular endpoint
                o.ReportApiVersions = true;
            });
        }
    }
}
