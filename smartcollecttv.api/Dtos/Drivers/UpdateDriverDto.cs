using System.ComponentModel.DataAnnotations;

namespace smartcollecttv.api.Dtos.Drivers
{
    public class UpdateDriverDto
    {
        [Required]
        public string? Id { get; set; }  
        public string? Name { get; set; }        
        public string? Location { get; set; }        
        public string? RFID { get; set; }        
        public string? LastLogin { get; set; }      
    }
}