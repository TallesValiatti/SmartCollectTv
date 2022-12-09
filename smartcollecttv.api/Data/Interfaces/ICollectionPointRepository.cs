using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Interfaces
{
    public interface ICollectionPointRepository
    {
        Task<IEnumerable<CollectionPoint>> GetAllAsync();
    }
}