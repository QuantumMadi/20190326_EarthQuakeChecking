using Earthquake.Model;
using EarthquakeTest.Services;
using EarthquakeTest.Services.Abstract;
using Newtonsoft.Json;

namespace Earthquake.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);
            IRepository<FeatureCollection> repository = new XmlGenericRepository<FeatureCollection>(logger);

            string json = downloader.DownloadRawJsonData("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=50");
            var data = JsonConvert.DeserializeObject<FeatureCollection>(json);
            repository.Add(data);
        }
    }
}
