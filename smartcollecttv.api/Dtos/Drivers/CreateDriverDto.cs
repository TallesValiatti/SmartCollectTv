using System.ComponentModel.DataAnnotations;

namespace smartcollecttv.api.Dtos.Drivers
{
    public class CreateDriverDto
    {
        public string? Name { get; set; }        
        public string? Location { get; set; }        
        public string? RFID { get; set; }        
        public string? LastLogin { get; set; }      
    }
}