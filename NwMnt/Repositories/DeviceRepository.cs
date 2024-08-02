using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using NwMnt.Data;
using NwMnt.Models;


namespace NwMnt.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Device>> GetAllDevicesAsync()
        {
            return await _context.Devices.Include(d => d.Sensors).ToListAsync();
        }


        public List<Device> GetActiveDevices()
        {
            return _context.Devices.Where(d => d.Status).ToList();
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task AddDeviceAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeviceAsync(Device device)
        {
            _context.Update(device);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteDeviceAsync(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> DeviceExistsAsync(int id)
        {
            return await _context.Devices.AnyAsync(e => e.Id == id);
        }
    }
}