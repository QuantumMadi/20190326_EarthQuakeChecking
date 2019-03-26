using EarthquakeTest.Services.Abstract;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EarthquakeTest.Services
{
    public class XmlGenericRepository<T> : IRepository<T>
    {
        private readonly ILogger logger;

        public XmlGenericRepository(ILogger logger)
        {
            this.logger = logger;
        }
        public void Add(T entity)
        {
            logger.LogMessage($"Insert into {entity.ToString()} in file");

            var data = GetAll();
            data.Add(entity);

            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.Open("earthquale.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream,data);  //object to List
            }
        }

        public void Delete(T entity)
        {
            logger.LogMessage($"Delete {entity.ToString()} in file");

            var data = GetAll();
            data.Remove(entity);

            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.Open("earthquale.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, data);  //object to List
            }
        }

        public List<T> GetAll()
        {
            var type = typeof(List<T>);
            logger.LogMessage($"Getting list {type.Name} from file");

            var serializer = new XmlSerializer(type);
            using (var stream = File.Open("earthquale.xml", FileMode.OpenOrCreate))
            {
                if (stream.Length == 0) return new List<T>();
                return serializer.Deserialize(stream) as List<T>;  //object to List
            }
        }
    }
}
