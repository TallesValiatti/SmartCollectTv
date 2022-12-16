using System.Net;
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
       
        public async Task<T?> GetAsync(string id, string? partitionKey)
        {
            try
            {
                return await _container.ReadItemAsync<T>(id.ToString(), new PartitionKey(this.NormalizePartitionkey(partitionKey)));
            }
            catch (CosmosException ex)
            { 
                if(ex.StatusCode == HttpStatusCode.NotFound)
                    return default(T);
                else
                    throw ex;
            }
        }

        public async Task DeleteAsync(string id, string? partitionKey)
        {
            await _container.DeleteItemAsync<T>(id.ToString(), new PartitionKey(this.NormalizePartitionkey(partitionKey)));
        }

        public async Task CreateAsync(T item, string? partitionKey)
        {
            await _container.CreateItemAsync<T>(item, new PartitionKey(this.NormalizePartitionkey(partitionKey)));
        }

        public async Task UpdateAsync(T item, string? partitionKey)
        {
            await _container.UpsertItemAsync<T>(item, new PartitionKey(this.NormalizePartitionkey(partitionKey)));
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

        private string NormalizePartitionkey(string? partitionKey) => string.IsNullOrWhiteSpace(partitionKey) ? string.Empty : partitionKey.Trim();
    }
}