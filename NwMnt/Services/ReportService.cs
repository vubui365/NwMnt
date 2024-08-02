using NwMnt.Models;
using NwMnt.Repositories;
using NwMnt.ViewModels;

namespace NwMnt.Services
{
    public class ReportService
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly ISensorRepository _sensorRepository;

        public ReportService(IMeasurementRepository measurementRepository,
                             IDeviceRepository deviceRepository,
                             ISensorRepository sensorRepository)
        {
            _measurementRepository = measurementRepository;
            _deviceRepository = deviceRepository;
            _sensorRepository = sensorRepository;
        }

        public async Task<ReportDataViewModel> GenerateReportData(ReportParametersViewModel parameters)
        {
            var measurements = await _measurementRepository.GetMeasurementsBySensorIdAndDateRange(
                parameters.SensorId, parameters.FromDate, parameters.ToDate
            );

            var device = await _deviceRepository.GetDeviceByIdAsync(parameters.DeviceId); // Sử dụng GetDeviceByIdAsync
            var sensor = await _sensorRepository.GetSensorByIdAsync(parameters.SensorId); // Sử dụng GetSensorByIdAsync

            return new ReportDataViewModel
            {
                DeviceName = device?.Name,
                SensorName = sensor?.Name,
                FromDate = parameters.FromDate,
                ToDate = parameters.ToDate,
                Measurements = measurements
            };
        }

       
    }
}
