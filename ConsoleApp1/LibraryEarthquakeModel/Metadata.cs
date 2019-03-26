using Newtonsoft.Json;

namespace Earthquake.Model
{
    public class Metadata
    {         
        [JsonProperty("title")]
        public string Title { get; set; }
           
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
