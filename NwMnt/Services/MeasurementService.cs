using NwMnt.Models;
using NwMnt.Repositories;

namespace NwMnt.Services
{
    public class MeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly ISensorRepository _sensorRepository;
        private readonly IAlertRepository _alertRepository;

        public MeasurementService(IMeasurementRepository measurementRepository,
                                 ISensorRepository sensorRepository,
                                 IAlertRepository alertRepository)
        {
            _measurementRepository = measurementRepository;
            _sensorRepository = sensorRepository;
            _alertRepository = alertRepository;
        }

        public async Task SaveMeasurementAsync(Measurement measurement)
        {
            try
            {
                await _measurementRepository.AddMeasurementAsync(measurement);

                var sensor = await _sensorRepository.GetSensorByIdAsync(measurement.SensorId);
                if (sensor != null && sensor.Threshold.HasValue && measurement.Value > sensor.Threshold.Value)
                {
                    if (measurement.Sensor != null && measurement.Sensor.Device != null) // Kiểm tra cả measurement.Sensor và measurement.Sensor.Device
                    {
                        var alert = new Alert
                        {
                            DeviceId = measurement.Sensor.DeviceId,
                            SensorId = measurement.SensorId,
                            Timestamp = DateTime.Now,
                            Message = $"Giá trị của sensor {sensor.Name} ({measurement.Value} {sensor.Unit}) trên thiết bị {measurement.Sensor.Device.Name} đã vượt quá ngưỡng cho phép ({sensor.Threshold.Value} {sensor.Unit}).",
                            Acknowledged = false
                        };
                        await _alertRepository.AddAlertAsync(alert);
                    }
                    else
                    {
                        // Xử lý trường hợp measurement.Sensor hoặc measurement.Sensor.Device là null (ví dụ: log lỗi)
                        // Bạn có thể ghi log lỗi vào file hoặc cơ sở dữ liệu để theo dõi
                        Console.WriteLine("Lỗi: Không thể tạo cảnh báo do thông tin sensor hoặc thiết bị không đầy đủ.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: log lỗi)
                Console.WriteLine($"Lỗi khi lưu measurement và tạo cảnh báo: {ex.Message}");
            }
        }

        // ... (Các phương thức khác của MeasurementService)
    }
}




