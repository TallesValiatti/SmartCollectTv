using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;
using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Implementation
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext context) : base(context.Vehicles)
        {
        }
    }
}