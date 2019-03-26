using Newtonsoft.Json;
using LibraryEarthquakeModel.utilites;
using System;

namespace Earthquake.Model
{
    public class Properties
    {
        [JsonProperty("mag")]
        public double Mag { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime TimeAsLong { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

}
