using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    /// Fluid API Service Builder
    /// </summary>
    public class UnifaunServiceBuilder
    {
        #region Fields

        private readonly List<UnifaunAddon> _addons = new List<UnifaunAddon>();
        private string _serviceCode;
        private string _smsNumber;
        private decimal? _amount;
        private string _reference;
        private string _emailAddress;
        
        #endregion

        private UnifaunServiceBuilder(string serviceCode)
        {
            _serviceCode = serviceCode;
        }

        public static UnifaunServiceBuilder Service(string serviceCode)
        {
            return new UnifaunServiceBuilder(serviceCode);
        }

        public UnifaunServiceBuilder SmsNot(string smsNumber)
        {
            _smsNumber = smsNumber;
            return this;
        }

        public UnifaunServiceBuilder EmailNot(string emailAddress)
        {
            _emailAddress = emailAddress;
            return this;
        }

        public UnifaunServiceBuilder Cod(decimal amount, string reference)
        {
            // DHL Service Point CoD
            if (_serviceCode == "ASPO")
                _serviceCode = "ASPOC";

            _amount = amount;
            _reference = reference;
            return this;
        }

        public UnifaunServiceBuilder Add(UnifaunAddon addon)
        {
            _addons.Add(addon);
            return this;
        }

        public UnifaunService Build()
        {
            if (_smsNumber != null)
                _addons.Add(Addons.SmsNot(_serviceCode, _smsNumber));

            else if (_emailAddress != null)
                _addons.Add(Addons.EmailNot(_serviceCode, _emailAddress));

            if (_amount.HasValue)
                _addons.Add(Addons.Cod(_serviceCode, _amount.Value, _reference, _smsNumber, _emailAddress));

            return new UnifaunService(_serviceCode, _addons.ToArray());
        }
    }
}