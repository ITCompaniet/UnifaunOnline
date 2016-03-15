using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Models
{
    /// <summary>
    /// This element supplies the carrier's service code and its presence is mandatory.
    /// </summary>
    public class UnifaunService : UnifaunValues
    {
        public UnifaunService() { }

        public UnifaunService(string serviceCode, params UnifaunAddon[] addons)
        {
            ServiceCode = serviceCode;
            Addons = addons;
        }

        [XmlAttribute("srvid")]
        public string ServiceCode { get; set; }

        /// <summary>
        /// Defines if the shipment is a return shipment or not. Valid values: yes, no,both
        /// </summary>
        [XmlIgnore]
        public string ReturnLabel;

        /// <summary>
        /// Defines action when the package is undeliverable.
        /// RETURN = Return to sender, ABANDON = Treat as abandoned in receiver's country.
        /// </summary>
        [XmlIgnore]
        public string NonDelivery;

        /// <summary>
        /// Defines Shipper's Load and Count (SLAC) = total shipment pieces (e.g. 3 boxes and 3
        /// pallets of 100 pieces each = SLAC of 303).
        /// </summary>
        [XmlIgnore]
        public string Slac;

        /// <summary>
        /// Defines Booking ID / Booking number.
        /// </summary>
        [XmlIgnore]
        public string BookingId;

        /// <summary>
        /// Add-on services, such as Cash On Delivery and Receiver payment, can be supplied in this element.
        /// </summary>
        [XmlElement("addon")]
        public UnifaunAddon[] Addons { get; set; }
    }
}