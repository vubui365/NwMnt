namespace NwMnt.ViewModels
{
    public class AlertViewModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string SensorName { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public bool Acknowledged { get; set; }
    }
}
