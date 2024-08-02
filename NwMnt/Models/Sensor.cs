namespace NwMnt.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Oid { get; set; }
        public string DataType { get; set; }
        public string Unit { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public double? Threshold { get; set; }
        
    }
}
