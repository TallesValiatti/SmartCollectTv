using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;
using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Implementation
{
    public class IotSensorRepository : BaseRepository<IotSensor>, IIotSensorRepository
    {
        public IotSensorRepository(DbContext context) : base(context.IotSensors)
        {
        }

        public async Task<IEnumerable<IotSensor>> GetAsync(int take, int skip)
        {
            var queryable = this.GetItemLinqQueryable();

            using FeedIterator<IotSensor> feed = queryable
                .Skip(skip)
                .Take(take)
                .ToFeedIterator();
            
            return await this.CreateData(feed);
        }
    }
}