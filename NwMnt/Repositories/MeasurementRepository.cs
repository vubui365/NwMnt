using Microsoft.EntityFrameworkCore;
using NwMnt.Data;
using NwMnt.Models;

namespace NwMnt.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly ApplicationDbContext _context;

        public MeasurementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddMeasurementAsync(Measurement measurement)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMeasurementAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Measurement> GetAllMeasurements()
        {
            throw new NotImplementedException();
        }

        public List<Measurement> GetLatestMeasurementsByDeviceId(int deviceId, int count)
        {
            throw new NotImplementedException();
        }

        public Task<Measurement> GetMeasurementByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Measurement>> GetMeasurementsBySensorIdAndDateRange(int sensorId, DateTime fromDate, DateTime toDate)
        {
            return await _context.Measurements
                .Where(m => m.SensorId == sensorId && m.Timestamp >= fromDate && m.Timestamp <= toDate)
                .ToListAsync(); // Sử dụng ToListAsync để thực hiện truy vấn bất đồng bộ
        }

        public Task<bool> MeasurementExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMeasurementAsync(Measurement measurement)
        {
            throw new NotImplementedException();
        }
    }
}
