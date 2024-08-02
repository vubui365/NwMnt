
using NwMnt.Models;
namespace NwMnt.ViewModels
{
    public class ReportDataViewModel
    {
        public string DeviceName { get; set; }
        public string SensorName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
