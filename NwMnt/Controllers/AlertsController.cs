using Microsoft.AspNetCore.Mvc;
using NwMnt.Services;
using NwMnt.ViewModels;

namespace NwMnt.Controllers
{
    public class AlertsController : Controller
    {
        private readonly AlertService _alertService;

        public AlertsController(AlertService alertService)
        {
            _alertService = alertService;
        }

        // GET: Alerts
        public async Task<IActionResult> Index()
        {
            var alerts = await _alertService.GetAllAlertsAsync(); // Sử dụng GetAllAlertsAsync và await
            var alertViewModels = alerts.Select(a => new AlertViewModel
            {
                Id = a.Id,
                DeviceName = a.Device.Name,
                SensorName = a.Sensor.Name,
                Timestamp = a.Timestamp,
                Message = a.Message,
                Acknowledged = a.Acknowledged
            });
            return View(alertViewModels);
        }

        // GET: Alerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int alertId = id.Value;
            var alert = await _alertService.GetAlertByIdAsync(alertId); // Sử dụng GetAlertByIdAsync và await
            if (alert == null)
            {
                return NotFound();
            }

            var alertViewModel = new AlertViewModel
            {
                Id = alert.Id,
                DeviceName = alert.Device.Name,
                SensorName = alert.Sensor.Name,
                Timestamp = alert.Timestamp,
                Message = alert.Message,
                Acknowledged = alert.Acknowledged
            };

            return View(alertViewModel);
        }

        // POST: Alerts/Acknowledge/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Acknowledge(int id)
        {
            await _alertService.AcknowledgeAlert(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
