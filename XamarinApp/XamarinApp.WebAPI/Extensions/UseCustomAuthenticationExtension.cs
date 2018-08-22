using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using XamarinApp.WebAPI.Middlewares;

namespace XamarinApp.WebAPI.Extensions
{
    public static class UseCustomAuthenticationExtension
    {
        public static void UseCustomAuthentication(this IApplicationBuilder app, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseLoadTest"))
            {
                app.UseMiddleware<ByPassAuthMiddleware>();
            }

            app.UseAuthentication();            
        }
    }
}
