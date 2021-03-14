using Newtonsoft.Json;

namespace StarWarsDemo.SWApiServices.Models
{
    public class FilmDetailItemResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
