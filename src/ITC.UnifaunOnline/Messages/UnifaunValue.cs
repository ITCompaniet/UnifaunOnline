using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Messages
{
    public class UnifaunValue
    {
        public UnifaunValue() { }

        public UnifaunValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [XmlAttribute("n")]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
