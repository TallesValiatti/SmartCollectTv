namespace smartcollecttv.api.Models
{
    public class CollectionPoint
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Location? Location { get; set; }
        public string[]? IotSensors { get; set; }
        public string? TotalMeters { get; set; }
        public DateTime LastCollection { get; set; }
        public string? Observations { get; set; }
    }
}