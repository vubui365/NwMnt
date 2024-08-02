namespace NwMnt.ViewModels
{
    public class MeasurementViewModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string SensorName { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        // ... các thuộc tính khác nếu cần
    }
}

