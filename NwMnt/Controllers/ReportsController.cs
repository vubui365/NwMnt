using Microsoft.AspNetCore.Mvc;
using NwMnt.Services;
using NwMnt.ViewModels;

namespace NwMnt.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportService _reportService; // Đảm bảo bạn đã inject ReportService

        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateReport(ReportParametersViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reportData = _reportService.GenerateReportData(model);

                // Sử dụng thư viện tạo báo cáo để tạo báo cáo từ reportData (ví dụ: Rotativa, jsReport, ...)

                return View("ReportView", reportData);
            }

            return View("Index", model);
        }
    }
}
