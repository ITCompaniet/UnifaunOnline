using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Elements
{
    /// <summary>
    /// The sender element contains sender's information and its occurrence is not always mandatory in a file.
    /// Sender's information can be defined both in the online systems and UFPS. If this is the case, only a referral is needed in
    /// order file, pointing to a sender's so called quick ID value. This referral is done in the shipment element.
    /// </summary>
    public class UnifaunSender : UnifaunBaseAddress
    {
        [XmlAttribute("sndid")]
        public string SenderId { get; set; }

        /// <summary>
        /// Partner (carrier) information must be supplied in those cases senders are not predefined in the online systems or UFPS.
        /// </summary>
        [XmlElement("partner")]
        public UnifaunPartner Partner { get; set; }
    }
}
