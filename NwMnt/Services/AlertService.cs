using Microsoft.EntityFrameworkCore;
using NwMnt.Models;
using NwMnt.Repositories;

namespace NwMnt.Services
{
    public class AlertService
    {
        private readonly IAlertRepository _alertRepository;

        public AlertService(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public async Task<List<Alert>> GetAllAlertsAsync()
        {
            return await _alertRepository.GetAllAlertsAsync();
        }


        public async Task<Alert> GetAlertByIdAsync(int id)
        {
            return await _alertRepository.GetAlertByIdAsync(id);
        }

        public async Task AddAlertAsync(Alert alert)
        {
            await _alertRepository.AddAlertAsync(alert);
        }

        public async Task DeleteAlertAsync(int id)
        {
            await _alertRepository.DeleteAlertAsync(id);
        }

        public async Task<bool> AlertExistsAsync(int id)
        {
            return await _alertRepository.AlertExistsByIdAsync(id); // Sử dụng AlertExistsByIdAsync
        }

        public async Task AcknowledgeAlert(int id)
        {
            var alert = await _alertRepository.GetAlertByIdAsync(id);
            if (alert != null)
            {
                alert.Acknowledged = true;
                await _alertRepository.UpdateAlertAsync(alert); // Sử dụng UpdateAlertAsync
            }
        }

        public async Task<List<Alert>> GetUnacknowledgedAlerts()
        {
            return await _alertRepository.GetAllAlertsAsync() // Gọi phương thức async
                .ContinueWith(task => task.Result.Where(a => !a.Acknowledged).ToList()); // Xử lý kết quả bất đồng bộ
        }

        public async Task<List<Alert>> GetAlertsByDeviceId(int deviceId)
        {
            return await _alertRepository.GetAllAlertsAsync()
                .ContinueWith(task => task.Result.Where(a => a.DeviceId == deviceId).ToList());
        }
    }
}
