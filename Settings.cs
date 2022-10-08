using System.Xml.Serialization;

namespace FIFA_Helper {
    public class Settings {
        [XmlAttribute("OriginPath")]
        public string OriginPath { get; set; }

    }
}
