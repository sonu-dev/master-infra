using Master.Core.Logging;
using Master.Web.Api.Extensions;
using Master.Web.Api.Middlewares;
using Master.Web.Api.Options;
using Master.Web.Api.Providers.TokenProvider;
using Master.Web.Api.Repositories;
using Master.Web.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Master.Web.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddSingleton(typeof(ILog<>), typeof(Log<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenProvider, TokenProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Jwt Authentication
            app.UseJwtAuthentication(); 
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware           
            app.UseMiddleware<JwtMiddleware>();           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();               
            });
        }
    }
}
