namespace NwMnt.ViewModels
{
    public class SensorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Oid { get; set; }
        public string DataType { get; set; }
        public string Unit { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; } 
        public double? Threshold { get; set; } 
    }
}
