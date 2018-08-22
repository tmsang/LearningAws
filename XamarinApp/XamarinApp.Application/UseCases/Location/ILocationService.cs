using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Domain.Models.Location;

namespace XamarinApp.Application.UseCases.Location
{
    public interface ILocationService
    {
        Task<Locations> GetLocation(int locationId);

        Task<UserLocation> GetUserLocation(string id);

        Task<List<Locations>> GetAllLocation();

        Task<bool> AddOrUpdateUserLocation(string userId, LocationRequest locRequest);
    }
}
