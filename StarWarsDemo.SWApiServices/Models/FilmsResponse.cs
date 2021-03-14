using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarWarsDemo.SWApiServices.Models
{
    public class FilmsResponse
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
