using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using smartcollecttv.api.Data.Interfaces;

namespace smartcollecttv.api.Data.Implementation
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly Container _container;

        public BaseRepository(Container container)
        {
            _container = container;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using FeedIterator<T> feed = this.GetItemLinqQueryable().ToFeedIterator();
            
            return await this.CreateData(feed);
        }
        
        protected IOrderedQueryable<T> GetItemLinqQueryable()
        {
            return _container.GetItemLinqQueryable<T>();
        }

        protected async Task<IEnumerable<T>> CreateData(FeedIterator<T> feed)
        {
            List<T> results = new();

            while (feed.HasMoreResults)
            {
                FeedResponse<T> response = await feed.ReadNextAsync();
                foreach (T item in response)
                    results.Add(item);
            }

            return results;
        }
    }
}