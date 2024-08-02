using Microsoft.EntityFrameworkCore;
using NwMnt.Models;
using NwMnt.Repositories;
using NwMnt.ViewModels;

namespace NwMnt.Services
{
    public class DeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<List<Device>> GetAllDevices()
        {
            return await _deviceRepository.GetAllDevicesAsync();
        }

        public async Task<Device> GetDeviceById(int? id)
        {
            return await _deviceRepository.GetDeviceByIdAsync(id ?? 0);
        }

        public async Task AddDevice(Device device)
        {
            await _deviceRepository.AddDeviceAsync(device);
        }

        public async Task UpdateDevice(Device device)
        {
            await _deviceRepository.UpdateDeviceAsync(device);
        }

        public async Task DeleteDevice(int id)
        {
            await _deviceRepository.DeleteDeviceAsync(id);
        }

        public async Task<bool> DeviceExists(int id)
        {
            return await _deviceRepository.DeviceExistsAsync(id);
        }
    }
}
