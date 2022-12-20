using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartcollecttv.api.Dtos.IotSensors
{
    public class CreateIotSensorDto
    {
        public string? DeviceId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? Battery { get; set; }
        public int? Distance { get; set; }
        public decimal? Temperature { get; set; }
        public int? Humidity { get; set; }
    }
}