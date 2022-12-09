using smartcollecttv.api.Models;

namespace smartcollecttv.api.Data.Interfaces
{
    public interface IIotSensorRepository : IBaseRepository<IotSensor>
    {
        Task<IEnumerable<IotSensor>> GetAsync(int take, int skip);
    }
}