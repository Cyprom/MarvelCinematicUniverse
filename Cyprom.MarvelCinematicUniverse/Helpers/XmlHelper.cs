using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Cyprom.MarvelCinematicUniverse.Models;

namespace Cyprom.MarvelCinematicUniverse.Helpers
{
    public static class XmlHelper
    {
        public static Collection ReadXml()
        {
            var serializer = new XmlSerializer(typeof(Collection));
            using (var reader = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "collection.xml")))
            {
                return (Collection)(serializer.Deserialize(reader));
            }
        }
    }
}
