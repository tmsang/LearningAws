using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApp.Application.Persistence;
using XamarinApp.Domain.Exceptions;
using XamarinApp.Domain.Models.Location;

namespace XamarinApp.Application.UseCases.Location
{
    public class LocationService: ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        //private readonly IEventBus _eventBus;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
            //_eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<Locations> GetLocation(int locationId)
        {
            return await _locationRepository.GetAsync(locationId);
        }

        public async Task<UserLocation> GetUserLocation(string userId)
        {
            return await _locationRepository.GetUserLocationAsync(userId);
        }

        public async Task<List<Locations>> GetAllLocation()
        {
            return await _locationRepository.GetLocationListAsync();
        }

        public async Task<bool> AddOrUpdateUserLocation(string userId, LocationRequest currentPosition)
        {
            // Get the list of ordered regions the user currently is within
            var currentUserAreaLocationList = await _locationRepository.GetCurrentUserRegionsListAsync(currentPosition);

            if (currentUserAreaLocationList is null)
            {
                throw new LocationDomainException("User current area not found");
            }

            // If current area found, then update user location
            var locationAncestors = new List<string>();
            var userLocation = await _locationRepository.GetUserLocationAsync(userId);
            userLocation = userLocation ?? new UserLocation();
            userLocation.UserId = userId;
            userLocation.LocationId = currentUserAreaLocationList[0].LocationId;
            userLocation.UpdateDate = DateTime.UtcNow;
            await _locationRepository.UpdateUserLocationAsync(userLocation);

            // Publish integration event to update marketing read data model
            // with the new locations updated
            //PublishNewUserLocationPositionIntegrationEvent(userId, currentUserAreaLocationList);

            return true;
        }

        //private void PublishNewUserLocationPositionIntegrationEvent(string userId, List<Locations> newLocations)
        //{
        //    var newUserLocations = MapUserLocationDetails(newLocations);
        //    var @event = new UserLocationUpdatedIntegrationEvent(userId, newUserLocations);
        //    _eventBus.Publish(@event);
        //}

        //private List<UserLocationDetails> MapUserLocationDetails(List<Locations> newLocations)
        //{
        //    var result = new List<UserLocationDetails>();
        //    newLocations.ForEach(location => {
        //        result.Add(new UserLocationDetails()
        //        {
        //            LocationId = location.LocationId,
        //            Code = location.Code,
        //            Description = location.Description
        //        });
        //    });

        //    return result;
        //}
    }
}
