using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

using XamarinApp.Application.UseCases.Location;
using XamarinApp.Domain.Models.Location;

namespace XamarinApp.Application.Persistence
{
    public interface ILocationRepository
    {
        Task<Locations> GetAsync(int locationId);

        Task<List<Locations>> GetLocationListAsync();

        Task<UserLocation> GetUserLocationAsync(string userId);

        Task<List<Locations>> GetCurrentUserRegionsListAsync(LocationRequest currentPosition);

        Task AddUserLocationAsync(UserLocation location);

        Task UpdateUserLocationAsync(UserLocation userLocation);

        Task SeedAsync(IApplicationBuilder app, ILoggerFactory loggerFactory);
    }
}
