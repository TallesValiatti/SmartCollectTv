namespace smartcollecttv.api.Models
{
    public class Driver : BaseModel
    {
        public string? Name { get; set; }        
        public string? Location { get; set; }        
        public string? Rfid { get; set; }        
        public string? LastLogin { get; set; }        
    }
}