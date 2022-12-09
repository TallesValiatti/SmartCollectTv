using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}