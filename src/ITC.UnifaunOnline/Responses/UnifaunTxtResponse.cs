using System;

namespace ITC.UnifaunOnline.Responses
{
    public class UnifaunTxtResponse
    {
        public string OrderNo { get; set; }
        public string Unknown { get; set; }
        public long ShippmentNumber { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
    }
}
