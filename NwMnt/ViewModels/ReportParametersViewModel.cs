namespace NwMnt.ViewModels
{
    public class ReportParametersViewModel
    {
        public int DeviceId { get; set; } // ID của thiết bị được chọn
        public int SensorId { get; set; } // ID của sensor được chọn
        public DateTime FromDate { get; set; } // Ngày bắt đầu
        public DateTime ToDate { get; set; } // Ngày kết thúc
        public string ReportType { get; set; } // Loại báo cáo (ví dụ: PDF, Excel, HTML)
    }
}
