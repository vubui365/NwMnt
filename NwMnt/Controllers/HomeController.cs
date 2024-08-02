using Microsoft.AspNetCore.Mvc;
using NwMnt.Models;
using NwMnt.Services;
using System.Diagnostics;
using NwMnt.ViewModels;

namespace NwMnt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DeviceService _deviceService;

        private readonly AlertService _alertService;
        // ... (Các service khác nếu cần)

        public HomeController(ILogger<HomeController> logger,
                              DeviceService deviceService,
                              AlertService alertService
                              /* ... (Các service khác nếu cần) */)
        {
            _logger = logger;
            _deviceService = deviceService;
            _alertService = alertService;
            // ... (Khởi tạo các service khác nếu cần)
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Dashboard()
        {
            try
            {
                var allDevices = await _deviceService.GetAllDevices(); // Sử dụng await

                var dashboardViewModel = new DashboardViewModel
                {
                    TotalDevices = allDevices.Count,
                    OnlineDevices = allDevices.Count(d => d.Status),
                    OfflineDevices = allDevices.Count(d => !d.Status),
                    TotalAlerts = (await _alertService.GetAllAlertsAsync()).Count, // Sử dụng await
                    UnacknowledgedAlerts = (await _alertService.GetUnacknowledgedAlerts()).Count // Sử dụng await
                                                                                                 // ... (Các thông tin khác cho Dashboard)
                };

                return View(dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy dữ liệu cho Dashboard");
                return View("Error");
            }
        }
    }
}
