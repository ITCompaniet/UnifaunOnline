using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Models
{
    /// <summary>
    /// Add-on services, such as Cash On Delivery and Receiver payment, can be supplied in this element
    /// </summary>
    public class UnifaunAddon : UnifaunValues
    {
        [XmlAttribute("adnid")]
        public string AddonId { get; set; }

        /// <summary>
        /// Amount. Used only with add-on COD (Cash On Delivery).
        /// </summary>
        [XmlIgnore]
        public decimal? Amount;

        /// <summary>
        /// Customer number for carrier.
        /// Used primarily with RPAY(receiver pays) and OPAY(other payer).
        /// </summary>
        [XmlIgnore]
        public string CustNo;

        /// <summary>
        /// Payment reference. Used with add-on COD.
        /// </summary>
        [XmlIgnore]
        public string Reference;

        /// <summary>
        /// Type of reference. Valid values: TXT = Text, OCR = OCR number.
        /// Used only with addon COD(Cash On Delivery).
        /// </summary>
        [XmlIgnore]
        public string ReferenceType;

        /// <summary>
        /// Defines value for misctype.
        /// </summary>
        [XmlIgnore]
        public string Misc;

        /// <summary>
        /// Used to define notification mode for add-on NOT
        /// </summary>
        [XmlIgnore]
        public string MiscType;

        /// <summary>
        /// Account number. Used only with addon COD (Cash On Delivery).
        /// </summary>
        [XmlIgnore]
        public string Account;

        /// <summary>
        /// Account type. Valid values: BG = BankGiro, PG = PlusGiro, Konto = Offshore account.
        /// Used only with addon COD(Cash On Delivery). To specify if OCR or not, see the "referencetype" tag.
        /// </summary>
        [XmlIgnore]
        public string AccountType;

        [XmlIgnore]
        public string Text1;

        [XmlIgnore]
        public string Text2;

        [XmlIgnore]
        public string Text3;

        [XmlIgnore]
        public string Text4;

        [XmlIgnore]
        public string Bank;

        [XmlIgnore]
        public int? TempMax;

        [XmlIgnore]
        public int? TempMin;
    }

    public static class Addons
    {
        public static UnifaunAddon Sms(string smsNumber)
        {
            return new UnifaunAddon
            {
                AddonId = "NOTSMS",
                Misc = smsNumber
            };
        }

        public static UnifaunAddon PreNot(string smsNumber)
        {
            return new UnifaunAddon
            {
                AddonId = "PRENOT",
                Text3 = smsNumber
            };
        }

        public static UnifaunAddon Cod(decimal amount, string reference)
        {
            return new UnifaunAddon
            {
                AddonId = "COD",
                Amount = amount,
                Reference = reference
            };
        }
    }
}