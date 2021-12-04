using Master.Microservices.Common.Constants;
using Microsoft.AspNetCore.Builder;

namespace Master.Microservices.Common.Host.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ConfigureSwagger(this IApplicationBuilder app, string url, string name)
        {
            app.UseSwagger(); //you can spin up your application and view the generated Swagger JSON at "/swagger/v1/swagger.json."
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url, name);
            });
        }
    }
}
