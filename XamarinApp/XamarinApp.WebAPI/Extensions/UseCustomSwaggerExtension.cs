using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace XamarinApp.WebAPI.Extensions
{
    public static class UseCustomSwaggerExtension
    {
        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            var pathBase = configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                loggerFactory.CreateLogger("init").LogDebug($"Using PATH BASE '{pathBase}'");
                app.UsePathBase(pathBase);
            }

            app
                .UseSwagger()
                .UseSwaggerUI(c => {
                    c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Catalog.API V1");
                });
        }
    }
}
