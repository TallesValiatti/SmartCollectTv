using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(string id, string? partitionKey);
        Task DeleteAsync(string id, string? partitionKey);
        Task CreateAsync(T item, string? partitionKey);
        Task UpdateAsync(T item, string? partitionKey);
    }
}