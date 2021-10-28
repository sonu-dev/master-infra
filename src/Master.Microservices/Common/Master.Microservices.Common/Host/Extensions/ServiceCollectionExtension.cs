using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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
    }
}
