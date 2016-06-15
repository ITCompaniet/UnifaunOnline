using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Messages
{
    public class UnifaunPartner : UnifaunBaseAddress
    {
        [XmlAttribute("parid")]
        public string PartnerId { get; set; }

        [XmlIgnore]
        public string CustNo;

        /// <summary>
        /// Pallet reg. number for EUR-pallets
        /// </summary>
        [XmlIgnore]
        public string PalletRegNo;

        /// <summary>
        /// Terminal, used with delivery terms for international freights.
        /// </summary>
        [XmlIgnore]
        public string Terminal;

        /// <summary>
        /// Number for PlusGiro. Used mostly by Cash On Delivery add-on.
        /// </summary>
        [XmlIgnore]
        public string PostGiro;

        /// <summary>
        /// Number for BankGiro. Used mostly by Cash On Delivery add-on.
        /// </summary>
        [XmlIgnore]
        public string BankGiro;

        /// <summary>
        /// Specifies an offshore account
        /// </summary>
        [XmlIgnore]
        public string Konto;

        /// <summary>
        /// Agent ID. Normally set by application
        /// </summary>
        [XmlIgnore]
        public string AgentNo;

        /// <summary>
        /// Customer number issuer.
        /// </summary>
        [XmlIgnore]
        public string CustNoIssuerCode;
    }
}
