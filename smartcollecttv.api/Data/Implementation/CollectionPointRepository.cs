using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;
using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Implementation
{
    public class CollectionPointRepository : BaseRepository<CollectionPoint>, ICollectionPointRepository
    {
        public CollectionPointRepository(DbContext context) : base(context.CollectionPoints)
        {
        }
    }
}