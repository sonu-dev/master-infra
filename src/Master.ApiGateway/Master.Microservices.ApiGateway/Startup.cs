using IdentityServer4.AccessTokenValidation;
using Master.Microservices.ApiGateway.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Master.Microservices.ApiGateway
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddApiExplorer();

            // Add IdentityServer client
            AddIdentity(services);

            // Add Ocelot with cache support
            services.AddOcelot(_configuration)
            .AddCacheManager(x =>
            {
                x.WithDictionaryHandle();
            });

            // Add Swagger
            services.AddSwaggerForOcelot(_configuration);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ocelot
            await app.UseOcelot();

            //Swagger
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        private void AddIdentity(IServiceCollection services)
        {
            var identityOptions = new IdentityOption();
            _configuration.GetSection(typeof(IdentityOption).Name).Bind(identityOptions);

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
           .AddIdentityServerAuthentication(identityOptions.IdentityProviderKey, options =>
           {
               options.Authority = identityOptions.Authority;
               options.RequireHttpsMetadata = false;
               options.SupportedTokens = SupportedTokens.Both;
           });
        }
    }
}
