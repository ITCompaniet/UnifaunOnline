using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Elements
{
    /// <summary>
    /// The shipment element defines the shipment itself and its presence in the file is mandatory. Sender, receiver, delivery terms,
    /// service type and add-ons are defined in this element.
    /// </summary>
    public class UnifaunShipment : UnifaunValues
    {
        public UnifaunShipment() { }

        public UnifaunShipment(
            string from, string to, string orderNo, string reference, 
            string serviceCode, params UnifaunContainer[] containers)
        {
            From = from;
            To = to;
            OrderNo = orderNo;
            Reference = reference;
            Service = new UnifaunService(serviceCode);
            Containers = containers;
        }
        /// <summary>
        /// Unique order number. Any contents. Mandatory.
        /// Order number is searchable in the systems but not printed on shipping documents.
        /// </summary>
        [XmlAttribute("ordernr")]
        public string OrderNo { get; set; }

        /// <summary> 
        /// Merge ID is supplied only when consolidation is used.
        /// </summary>
        [XmlAttribute("mergeid")]
        public string MergeId { get; set; }

        /// <summary>
        /// Defines the sender. Refers to the sndid value for sender.
        /// </summary>
        [XmlIgnore]
        public string From;

        /// <summary>
        /// Defines the legal sender (not printed on shipping documents, could be set to be print).
        /// </summary>
        [XmlIgnore]
        public string LegalFrom;

        /// <summary>
        /// Defines the receiver. Refers to rcvid value for receiver
        /// </summary>
        [XmlIgnore]
        public string To;

        /// <summary>
        /// Defines the return address. 
        /// </summary>
        [XmlIgnore]
        public string ReturnTo;

        /// <summary>
        /// Defines the legal receiver (not printed on shipping documents).
        /// </summary>
        [XmlIgnore]
        public string LegalTo;

        /// <summary>
        /// Defines the agent’s ID for recipient in shipment.
        /// </summary>
        [XmlIgnore]
        public string AgentTo;

        /// <summary>
        /// Exporter
        /// </summary>
        [XmlIgnore]
        public string CustomsFrom;

        /// <summary>
        /// Importer
        /// </summary>
        [XmlIgnore]
        public string CustomsTo;

        /// <summary>
        /// Shipment ID.
        /// </summary>
        [XmlIgnore]
        public string ShpId;

        /// <summary>
        /// Shipment reference. Any contents. Max. 17 characters. 
        /// </summary>
        [XmlIgnore]
        public string Reference;

        /// <summary>
        /// Shipment reference as barcode. Max. 17 numeric characters.
        /// </summary>
        [XmlIgnore]
        public string ReferenceBarCode;

        /// <summary>
        /// Receiver's reference. Any contents. Max. 17 characters.
        /// </summary>
        [XmlIgnore]
        public string RcvReference;

        /// <summary>
        /// Number of EUR pallets in the shipment. Requires palletregno for sender and receiver
        /// </summary>
        [XmlIgnore]
        public int? EurPallets;

        /// <summary>
        /// Number of exchange half pallets in the shipment.
        /// </summary>
        [XmlIgnore]
        public int? HalfPallets;

        /// <summary>
        /// Number of exchange quarter pallets in the shipment.
        /// </summary>
        [XmlIgnore]
        public int? QuarterPallets;

        /// <summary>
        /// Free text field with any contents. Can be used for delivery instructions, for example. It
        /// is printed on shipping documents. 4 lines available, freetext1-4. Max. 30 characters/line.
        /// </summary>
        [XmlIgnore]
        public string Freetext1;

        /// <summary>
        /// Free text field with any contents. Can be used for delivery instructions, for example. It
        /// is printed on shipping documents. 5 lines available, sisfreetext1-5. Max. 30 characters/line.
        /// </summary>
        [XmlIgnore]
        public string SisFreetext1;

        /// <summary>
        /// Free text field with any contents. Can be used for delivery instructions, for example.
        /// Only printed on CMR waybill. 5 lines available, cmrfreetext1-5. Max. 30 characters/line
        /// </summary>
        [XmlIgnore]
        public string CmrFreetext1;

        /// <summary>
        /// Fields for additional documents. 2 lines available, cmrdocuments1-2.
        /// Max. 30 characters/line
        /// </summary>
        [XmlIgnore]
        public string CmrDocuments1;

        /// <summary>
        /// Specifies any special agreement. Max. 30 characters.
        /// </summary>
        [XmlIgnore]
        public string CmrSpecialAgreement;

        /// <summary>
        /// Delivery terms or freight payer information.
        /// </summary>
        [XmlIgnore]
        public string TermCode;

        /// <summary>
        /// Defines the location where takeover for the specified delivery term is done.
        /// </summary>
        [XmlIgnore]
        public string TermLocation;

        [XmlElement("service")]
        public UnifaunService Service { get; set; }
        
        [XmlElement("ufonline")]
        public UnifaunUfOnline UfOnline { get; set; }

        [XmlElement("container")]
        public UnifaunContainer[] Containers { get; set; }
    }
}
