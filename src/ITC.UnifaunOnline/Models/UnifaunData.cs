using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Models
{
    [XmlRoot("data")]
    public class UnifaunData
    {
        [XmlElement("sender")]
        public UnifaunSender Sender { get; set; }

        [XmlElement("receiver")]
        public UnifaunReceiver Receiver { get; set; }

        [XmlElement("party")]
        public UnifaunParty Party { get; set; }

        [XmlElement("shipment")]
        public UnifaunShipment Shipment { get; set; }
    }
}
