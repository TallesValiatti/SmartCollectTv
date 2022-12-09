using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;

namespace smartcollecttv.api.Data.Implementation
{
    public class RouteRepository : BaseRepository<Models.Route>, IRouteRepository
    {
        public RouteRepository(DbContext context) : base(context.Routes)
        {
        }
    }
}