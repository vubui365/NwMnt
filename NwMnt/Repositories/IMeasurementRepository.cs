using NwMnt.Models;

namespace NwMnt.Repositories
{
    public interface IMeasurementRepository
    {
        List<Measurement> GetAllMeasurements();
        Task<Measurement> GetMeasurementByIdAsync(int id);
        Task AddMeasurementAsync(Measurement measurement);
        Task UpdateMeasurementAsync(Measurement measurement);
        Task DeleteMeasurementAsync(int id);
        Task<bool> MeasurementExistsAsync(int id);
        Task<List<Measurement>> GetMeasurementsBySensorIdAndDateRange(int sensorId, DateTime fromDate, DateTime toDate);

        // Các phương thức khác (nếu cần)
        List<Measurement> GetLatestMeasurementsByDeviceId(int deviceId, int count);
        
    }
}
