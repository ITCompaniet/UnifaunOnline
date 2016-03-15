using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Models
{
    /// <summary>
    /// The container element defines contents of the shipment, e.g. number of parcels, weight and volume.
    /// </summary>
    public class UnifaunContainer : UnifaunValues
    {
        public UnifaunContainer()
        {
            Type = ContainerType.Parcel;
            Copies = 1;
        }

        public UnifaunContainer(decimal weight, string contents)
            : this()
        {
            Weight = weight;
            Contents = contents;
        }
        /// <summary>
        /// parcel/totals
        /// </summary>
        [XmlAttribute("type")]
        public ContainerType Type { get; set; }

        /// <summary>
        /// If "totals" the shipment contains two parcels and the total weight is 10 kg. The individual parcel weight is
        /// only assumed to be 5 kg each. Please note that the assumed individual parcel weight will not be printed on shipping documents.
        /// </summary>
        [XmlAttribute("measure")]
        public string Measure { get; set; }
        
        [XmlIgnore]
        public int Copies;

        [XmlIgnore]
        public decimal? Weight;

        [XmlIgnore]
        public decimal? Volume;

        [XmlIgnore]
        public string Contents;

        /// <summary>
        /// Package code.
        /// </summary>
        [XmlIgnore]
        public string PackageCode;
    }

    public enum ContainerType
    {
        [XmlEnum(Name = "parcel")]
        Parcel,

        [XmlEnum(Name = "totals")]
        Totals
    }
}