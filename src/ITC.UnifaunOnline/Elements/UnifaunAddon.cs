using System;
using System.Xml.Serialization;
using ITC.UnifaunOnline.Helpers;

// ReSharper disable RedundantCaseLabel

namespace ITC.UnifaunOnline.Elements
{
    /// <summary>
    /// Add-on services, such as Cash On Delivery and Receiver payment, can be supplied in this element
    /// </summary>
    public class UnifaunAddon : UnifaunValues
    {
        public UnifaunAddon() { }

        public UnifaunAddon(string addonId = null, string misc = null, string miscType = null)
        {
            AddonId = addonId;
            Misc = misc;
            MiscType = miscType;
        }

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
        /// <summary>
        /// Email Notification
        /// </summary>
        /// <param name="serviceCode">Unifaun Service Code</param>
        /// <param name="emailAddress">Email address</param>
        /// <returns></returns>
        public static UnifaunAddon EmailNot(string serviceCode, string emailAddress)
        {
            if (!EmailValidator.IsValid(emailAddress))
                throw new Exception($"Invalid Email ({emailAddress})");

            switch (serviceCode)
            {
                case "ASPOC": // DHL Service Point, CoD
                    return null; // Sets in CoD

                // PostNord
                case "P19": // PostNord MyPack
                    return new UnifaunAddon("NOTEMAIL", emailAddress);

                case "P32": // PostNord Hempaket 
                    return new UnifaunAddon("DLVNOT") { Text4 = emailAddress };

                // DB Schenker
                case "BHP": // DB SCHENKERprivpak - Ombud Standard
                    return new UnifaunAddon("NOT") { Text4 = emailAddress };

                case "BPA": // DB SCHENKERparcel
                    return new UnifaunAddon("NOT") { Text4 = emailAddress };

                case "ASPO": // DHL Service Point
                default:
                    return new UnifaunAddon("NOT", emailAddress, "EMAIL");
            }
        }

        /// <summary>
        /// Letter notification
        /// </summary>
        /// <param name="serviceCode">Unifaun Service Code</param>
        /// <returns></returns>
        public static UnifaunAddon LetterNot(string serviceCode)
        {
            switch (serviceCode)
            {
                // PostNord
                case "P19": // PostNord MyPack
                    return new UnifaunAddon("NOTLTR");

                case "ASPO": // DHL Service Point
                    return new UnifaunAddon("NOT", miscType: "LETTER");

                case "ASPOC": // DHL Service Point, CoD (Sets in CoD)
                default:
                    return null; 
            }
        }

        /// <summary>
        /// SMS Notification
        /// </summary>
        /// <param name="serviceCode">Unifaun Service Code</param>
        /// <param name="smsNumber">SMS Number</param>
        /// <returns></returns>
        public static UnifaunAddon SmsNot(string serviceCode, string smsNumber)
        {
            switch (serviceCode)
            {
                case "ASPOC": // DHL Service Point, CoD
                    return null; // Sets in CoD

                // PostNord
                case "P19": // PostNord MyPack
                    return new UnifaunAddon("NOTSMS", smsNumber);

                case "P32": // PostNord Hempaket 
                    return new UnifaunAddon("DLVNOT") { Text3 = smsNumber };
                    
                // DB Schenker
                case "BHP": // DB SCHENKERprivpak - Ombud Standard
                    return new UnifaunAddon("NOT") { Text3 = smsNumber };

                case "BPA": // DB SCHENKERparcel - Ombud Standard
                    return new UnifaunAddon("NOT") { Text3 = smsNumber };

                case "AEX": // DHL Paket
                case "ASPO": // DHL Service Point
                case "ASP2": // DHL Pall
                case "ASWP2": // DHL Parti
                case "ASWS2": // DHL Stycke
                default:
                    return new UnifaunAddon("NOT", smsNumber, "SMS");

            }
        }

        /// <summary>
        /// Cash On Delivery
        /// </summary>
        /// <param name="serviceCode">Unifaun Service Code</param>
        /// <param name="amount">Amount</param>
        /// <param name="reference">Payment reference</param>
        /// <param name="smsNumber">Only for DHL Service Point</param>
        /// <param name="email">Only for DHL Service Point</param>
        /// <returns></returns>
        public static UnifaunAddon Cod(string serviceCode, decimal amount, string reference, string smsNumber = null, string email = null)
        {
            switch (serviceCode)
            {
                case "ASPOC": // DHL Service Point, CoD

                    return new UnifaunAddon
                    {
                        AddonId = "COD",
                        Amount = amount,
                        Reference = reference,
                        Misc = smsNumber ?? email,
                        MiscType = smsNumber != null ? "SMS" : (email != null ? "EMAIL" : "LETTER")
                    };

                default:
                    return new UnifaunAddon
                    {
                        AddonId = "COD",
                        Amount = amount,
                        Reference = reference
                    };
            }
        }
    }
}