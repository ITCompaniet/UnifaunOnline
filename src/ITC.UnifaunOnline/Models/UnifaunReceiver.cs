using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Models
{
    /// <summary>
    /// The element receiver contains receiver's information and its occurrence in a file is mandatory.
    /// </summary>
    public class UnifaunReceiver : UnifaunBaseAddress
    {
        [XmlAttribute("rcvid")]
        public string ReceiverId { get; set; }
        
        [XmlIgnore]
        public string DoorCode;
    }
}
