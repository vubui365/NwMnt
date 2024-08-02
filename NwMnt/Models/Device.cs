namespace NwMnt.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
