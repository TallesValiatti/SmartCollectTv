namespace smartcollecttv.api.Models
{
    public class Vehicle : BaseModel
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? LicensePlate { get; set; }
        public int? MedianFuelConsumption { get; set; } 
    }
}