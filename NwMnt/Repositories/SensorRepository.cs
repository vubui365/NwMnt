using Microsoft.EntityFrameworkCore;
using NwMnt.Data;
using NwMnt.Models;

namespace NwMnt.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _context;

        public SensorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sensor> GetAllSensors() // Có thể cần đổi thành async nếu cần
        {
            return _context.Sensors.ToList();
        }

        public Sensor GetSensorById(int id) // Có thể cần đổi thành async nếu cần
        {
            return _context.Sensors.Find(id);
        }

        public async Task AddSensorAsync(Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSensorAsync(Sensor sensor)
        {
            _context.Entry(sensor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<List<Sensor>> GetAllSensorsAsync()
        {
            return await _context.Sensors.ToListAsync();
        }

        public async Task<Sensor> GetSensorByIdAsync(int id)
        {
            return await _context.Sensors.FindAsync(id);
        }

        public async Task DeleteSensorAsync(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensors.Remove(sensor);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> SensorExistsAsync(int id)
        {
            return await _context.Sensors.AnyAsync(e => e.Id == id);
        }
    }
}