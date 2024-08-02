namespace NwMnt.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
