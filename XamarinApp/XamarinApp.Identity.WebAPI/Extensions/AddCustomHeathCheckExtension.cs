using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XamarinApp.Identity.WebAPI.Extensions
{
    public static class AddCustomHeathCheckExtension
    {
        public static IServiceCollection AddCustomHeathCheck(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHealthChecks(checks =>
            //{
            //    var minutes = 1;
            //    if (int.TryParse(Configuration["HealthCheck:Timeout"], out var minutesParsed))
            //    {
            //        minutes = minutesParsed;
            //    }
            //    checks.AddSqlCheck("Identity_Db", Configuration["ConnectionString"], TimeSpan.FromMinutes(minutes));
            //});

            return services;
        }
    }
}
