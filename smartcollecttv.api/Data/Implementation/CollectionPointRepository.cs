using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;
using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Implementation
{
    public class CollectionPointRepository : ICollectionPointRepository
    {
        private readonly Container _container;
        public CollectionPointRepository(DbContext context)
        {
            _container = context.CollectionPoints;
        }
        public async Task<IEnumerable<CollectionPoint>> GetAllAsync()
        {
            using FeedIterator<CollectionPoint> feed = this.GetItemLinqQueryable().ToFeedIterator();
            
            return await this.CreateData(feed);
        }
        
        private IOrderedQueryable<CollectionPoint> GetItemLinqQueryable()
        {
            return _container.GetItemLinqQueryable<CollectionPoint>();
        }

        private async Task<IEnumerable<CollectionPoint>> CreateData(FeedIterator<CollectionPoint> feed)
        {
            List<CollectionPoint> results = new();

            while (feed.HasMoreResults)
            {
                FeedResponse<CollectionPoint> response = await feed.ReadNextAsync();
                foreach (CollectionPoint item in response)
                    results.Add(item);
            }

            return results;
        }
    }
}