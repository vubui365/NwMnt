namespace NwMnt.Models
{
    
    public class Alert
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public bool Acknowledged { get; set; } // Đánh dấu đã được xác nhận
        public string Name { get; set; }
    }

    
}
