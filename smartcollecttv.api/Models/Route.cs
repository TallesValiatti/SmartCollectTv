namespace smartcollecttv.api.Models
{
    public class Route : BaseModel
    {
        public DateTime? DateTime { get; set; }
        public Guid? DriverId { get; set; }
        public Guid? VehicleId { get; set; }
        public Location? StartPoint { get; set; }
        public Location? EndPoint { get; set; }
        public IEnumerable<Guid>? CollectionPointsPreview { get; set; }
        public IEnumerable<Guid>? CollectionPointsReal { get; set; }
        public decimal? TotalDuration { get; set; }
        public int? TotalDistance { get; set; }
        public int? FuelConsumption { get; set; }
    }
}