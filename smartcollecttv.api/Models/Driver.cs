using Newtonsoft.Json;

namespace smartcollecttv.api.Models
{
    public class Driver : BaseModel
    {
        public string? RFID { get; set; }  
        public string? Name { get; set; }        
        public string? Location { get; set; }               
        public string? LastLogin { get; set; }        
    }
}