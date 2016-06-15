using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Elements
{
    /// <summary>
    /// The element party contains a neutral party’s information and its occurrence in a file is optional.
    /// </summary>
    public class UnifaunParty : UnifaunBaseAddress
    {
        [XmlAttribute("ptyid")]
        public string PartyId { get; set; }

        [XmlIgnore]
        public string DoorCode;
    }
}
