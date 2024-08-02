using NwMnt.Models;

namespace NwMnt.Repositories
{
    public interface ISensorRepository
    {
        Task<List<Sensor>> GetAllSensorsAsync();
        Task<Sensor> GetSensorByIdAsync(int id);
        Task AddSensorAsync(Sensor sensor);
        Task UpdateSensorAsync(Sensor sensor);
        Task DeleteSensorAsync(int id);
        Task<bool> SensorExistsAsync(int id);
    }
}
