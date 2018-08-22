using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

using XamarinApp.Application.Persistence;
using XamarinApp.Domain.Configurations;

namespace XamarinApp.WebAPI.Extensions
{
    public static class SeedLocationAsyncExtension
    {
        public static void SeedLocationAsync(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var locationRepository = SharedItems.ApplicationContainer.Resolve<ILocationRepository>();
            locationRepository.SeedAsync(app, loggerFactory);
        }
    }
}
