using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using XamarinApp.Domain.Configurations;

namespace XamarinApp.WebAPI.Extensions
{
    public static class AddcustomRedisExtension
    {
        public static IServiceCollection AddCustomRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BasketSettings>(configuration);

            //By connecting here we are making sure that our service
            //cannot start until redis is ready. This might slow down startup,
            //but given that there is a delay on resolving the ip address
            //and then creating the connection it seems reasonable to move
            //that cost to startup instead of having the first request pay the
            //penalty.
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<BasketSettings>>().Value;
                var config = ConfigurationOptions.Parse(settings.ConnectionString, true);

                config.ResolveDns = true;

                return ConnectionMultiplexer.Connect(config);
            });

            return services;

        }
    }
}
