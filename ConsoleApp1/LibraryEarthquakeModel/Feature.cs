using Newtonsoft.Json;

namespace Earthquake.Model
{
    public class Feature
    {        
        [JsonProperty("properties")]
        public Properties Properties { get; set; }                 
    }
}
