using System.Xml.Serialization;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public abstract class ChildOf<P>
        where P : class
    {
        [XmlIgnore]
        public P Parent;
    }
}
