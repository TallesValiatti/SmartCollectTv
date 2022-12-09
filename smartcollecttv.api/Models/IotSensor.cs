namespace smartcollecttv.api.Models
{
    public class IotSensor : BaseModel
    {
        public string? DeviceId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Battery { get; set; }
        public int? Distance { get; set; }
        public decimal? Temperature { get; set; }
        public int? Humidity { get; set; }
    }
}