using Master.Web.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Master.Web.Api.Extensions
{
    public static class JwtAuthenticationExtension
    {
        public static IApplicationBuilder UseJwtAuthentication(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<JwtMiddleware>();
        }
    }
}
