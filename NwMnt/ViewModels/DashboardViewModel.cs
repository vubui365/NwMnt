

namespace NwMnt.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalDevices { get; set; }
        public int OnlineDevices { get; set; }
        public int OfflineDevices { get; set; }
        public int TotalAlerts { get; set; }
        public int UnacknowledgedAlerts { get; set; }

        
        public List<MeasurementViewModel> LatestMeasurements { get; set; } // Dữ liệu đo đạc mới nhất
        public List<AlertViewModel> RecentAlerts { get; set; } // Danh sách các cảnh báo gần đây
        public Dictionary<string, int> DeviceTypeCounts { get; set; } // Số lượng thiết bị theo loại
    }
}
