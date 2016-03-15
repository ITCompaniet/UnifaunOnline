using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Models
{
    public class UnifaunUfOnline
    {
        public UnifaunUfOnline() { }

        public UnifaunUfOnline(params UnifaunOption[] options)
        {
            Options = options;
        }

        [XmlElement("addon")]
        public UnifaunOption[] Options { get; set; }

        public class UnifaunOption : UnifaunValues
        {
            [XmlAttribute("optid")]
            public string OptionId { get; set; }

            [XmlIgnore] public string Message;
            [XmlIgnore] public string Cc;
            [XmlIgnore] public string Bcc;
            [XmlIgnore] public string SendMail;
            [XmlIgnore] public string From;
            [XmlIgnore] public string To;
        }
    }

    public static class Options
    {
        public static UnifaunUfOnline.UnifaunOption ENot(string to, string message)
        {
            return new UnifaunUfOnline.UnifaunOption
            {
                OptionId = "ENOT",
                To = to,
                Message = message
            };
        }
    }
}