using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Elements
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

            /// <summary>
            /// Text string with any contents. Line breaks can be entered with pipe character, |. 
            /// </summary>
            [XmlIgnore] public string Message;
            [XmlIgnore] public string Cc;
            [XmlIgnore] public string Bcc;
            [XmlIgnore] public string SendMail;
            [XmlIgnore] public string From;
            [XmlIgnore] public string To;

            /// <summary>
            /// Mailtemplate. Used for ”Anpassad föravisering”
            /// </summary>
            [XmlIgnore] public string MailTemplate;

            /// <summary>
            /// yes if you want to send e-mail (PrintLink only)
            /// </summary>
            [XmlIgnore] public string SendEmail;
        }
    }

    public static class Options
    {
        public static UnifaunUfOnline.UnifaunOption ENot(string to, string message, string from, string mailTemplate = null, string cc = null, string bcc = null)
        {
            return new UnifaunUfOnline.UnifaunOption
            {
                OptionId = "ENOT",
                To = to,
                Message = message,
                From = from,
                Cc = cc,
                Bcc = bcc,
                MailTemplate = mailTemplate
            };
        }

        public static UnifaunUfOnline.UnifaunOption SendPrintLink(string to, string message, string from, string cc = null, string bcc = null)
        {
            return new UnifaunUfOnline.UnifaunOption
            {
                OptionId = "LNKPRTN",
                To = to,
                Message = message,
                From = from,
                Cc = cc,
                Bcc = bcc,
                SendEmail = "yes"
            };
        }
    }
}