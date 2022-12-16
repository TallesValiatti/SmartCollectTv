#nullable disable
using Newtonsoft.Json;

namespace smartcollecttv.api.Models
{
    public class BaseModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}