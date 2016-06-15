using System.Linq;
using System.Xml.Serialization;
using ITC.UnifaunOnline.Elements;

namespace ITC.UnifaunOnline.Responses
{
    [XmlRoot("response")]
    public class UnifaunXmlPostResponse
    {
        [XmlElement("val")]
        public UnifaunValue[] Values { get; set; }

        [XmlIgnore]
        public string Session => Values.FirstOrDefault(v => v.Name == "session")?.Value;

        [XmlIgnore]
        public string Status => Values.FirstOrDefault(v => v.Name == "status")?.Value;

        [XmlIgnore]
        public string Message => Values.FirstOrDefault(v => v.Name == "message")?.Value;
    }
}
