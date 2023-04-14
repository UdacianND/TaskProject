using System.Xml.Serialization;

namespace CollectionsProject.Models
{

    [XmlInclude(typeof(Car), Type = typeof(Car))]
    [XmlInclude(typeof(Bus), Type = typeof(Bus))]
    [XmlInclude(typeof(Scooter), Type = typeof(Scooter))]
    [XmlInclude(typeof(Truck), Type = typeof(Truck))]
    [Serializable]
    public abstract class Vehicle
    {
        public long Id { get; set; }
        [XmlElement]
        public Engine Engine { get; set; }
        [XmlElement]
        public Chassis Chassis { get; set; }
        [XmlElement]
        public Transmission Transmission { get; set; }
        public abstract string GetInfo();
    }
}
