using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinApp.Application.UseCases.Identity;
using XamarinApp.Application.UseCases.Location;

namespace XamarinApp.WebAPI.Controllers
{
    [Route("api/location")]
    [Authorize]
    public class LocationController: ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IIdentityService _identityService;

        public LocationController(ILocationService locationService, IIdentityService identityService)
        {
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        //GET api/location/user/1
        [Route("user/{userId:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetUserLocation(Guid userId)
        {
            var userLocation = await _locationService.GetUserLocation(userId.ToString());
            return Ok(userLocation);
        }

        //GET api/location/
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocation();
            return Ok(locations);
        }

        //GET api/location/1
        [Route("{locationId}")]
        [HttpGet]
        public async Task<IActionResult> GetLocation(int locationId)
        {
            var location = await _locationService.GetLocation(locationId);
            return Ok(location);
        }

        //POST api/location/
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateUserLocation([FromBody]LocationRequest newLocReq)
        {
            var userId = _identityService.GetUserIdentity();
            var result = await _locationService.AddOrUpdateUserLocation(userId, newLocReq);

            return result ?
                (IActionResult)Ok() :
                (IActionResult)BadRequest();
        }
    }
}
