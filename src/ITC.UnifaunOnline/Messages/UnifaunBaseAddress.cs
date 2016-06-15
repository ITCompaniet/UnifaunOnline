using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Messages
{
    public abstract class UnifaunBaseAddress : UnifaunValues
    {
        [XmlIgnore]
        public string Name;

        [XmlIgnore]
        public string Address1;

        [XmlIgnore]
        public string Address2;

        [XmlIgnore]
        public string ZipCode;

        [XmlIgnore]
        public string City;

        /// <summary>
        /// Country code according to ISO standard
        /// </summary>
        [XmlIgnore]
        public string Country;

        [XmlIgnore]
        public string Phone;

        [XmlIgnore]
        public string Fax;

        [XmlIgnore]
        public string Email;

        /// <summary>
        /// Mobile phone number.
        /// For Sweden, the number must begin with 07 and contain 10 characters.
        /// </summary>
        [XmlIgnore]
        public string Sms;

        /// <summary>
        /// Organisation number (for Sweden only)
        /// </summary>
        [XmlIgnore]
        public string Orgno;

        /// <summary>
        /// VAT number
        /// </summary>
        [XmlIgnore]
        public string VatNo;
    }
}
