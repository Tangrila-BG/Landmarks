using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.Infrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDbFactory dbFactory):base(dbFactory){}

        public Location GetLocationByCoordinates(double latitude, double longitude)
        {
            return this.DbContext.Locations.FirstOrDefault(x => x.Latitude == latitude && x.Longitude == longitude);
        }
    }
}
