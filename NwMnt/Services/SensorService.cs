using Microsoft.EntityFrameworkCore;
using NwMnt.Models;
using NwMnt.Repositories;

namespace NwMnt.Services
{
    public class SensorService
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public async Task<List<Sensor>> GetAllSensors()
        {
            return await _sensorRepository.GetAllSensorsAsync(); // Gọi phương thức async
        }

        public async Task<Sensor> GetSensorById(int id)
        {
            return await _sensorRepository.GetSensorByIdAsync(id); // Gọi phương thức async
        }

        public async Task AddSensor(Sensor sensor)
        {
            await _sensorRepository.AddSensorAsync(sensor);
        }

        public async Task UpdateSensor(Sensor sensor)
        {
            await _sensorRepository.UpdateSensorAsync(sensor); // Gọi phương thức async và await kết quả
        }

        public async Task DeleteSensor(int id)
        {
            await _sensorRepository.DeleteSensorAsync(id); // Gọi phương thức async và await kết quả
        }

        public async Task<bool> SensorExists(int id)
        {
            return await _sensorRepository.SensorExistsAsync(id);
        }

        public async Task<List<Sensor>> GetSensorsByDeviceId(int deviceId)
        {
            var allSensors = await _sensorRepository.GetAllSensorsAsync(); // Gọi phương thức async và await kết quả
            return allSensors.Where(s => s.DeviceId == deviceId).ToList();
        }
    }
}
