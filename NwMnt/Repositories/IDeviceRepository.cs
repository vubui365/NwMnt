using NwMnt.Models;

namespace NwMnt.Repositories
{
    public interface IDeviceRepository
    {
       
        Task<List<Device>> GetAllDevicesAsync();
        List<Device> GetActiveDevices();
        Task<Device> GetDeviceByIdAsync(int id);
        Task AddDeviceAsync(Device device);
        Task UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(int id);
        Task<bool> DeviceExistsAsync(int id);
    }
}