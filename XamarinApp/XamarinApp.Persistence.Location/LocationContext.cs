using Microsoft.Extensions.Options;
using MongoDB.Driver;
using XamarinApp.Domain.Configurations;
using XamarinApp.Domain.Models.Location;

namespace XamarinApp.Persistence.Location
{
    public class LocationContext
    {
        private readonly IMongoDatabase _database = null;

        public LocationContext(IOptions<LocationSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<UserLocation> UserLocation
        {
            get
            {
                return _database.GetCollection<UserLocation>("UserLocation");
            }
        }

        public IMongoCollection<Locations> Locations
        {
            get
            {
                return _database.GetCollection<Locations>("Locations");
            }
        }
    }
}
