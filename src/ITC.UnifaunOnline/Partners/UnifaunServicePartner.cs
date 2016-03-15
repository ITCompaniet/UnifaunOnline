using System.Collections.Generic;
using System.Diagnostics;

namespace ITC.UnifaunOnline.Partners
{
    [DebuggerDisplay("{Code}: {Name}")]
    public class UnifaunServicePartner
    {
        public UnifaunServicePartner()
        {
            Services = new List<PartnerService>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<PartnerService> Services { get; set; }
    }

    [DebuggerDisplay("{Code}: {Name}")]
    public class PartnerService
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string[] FromCountries { get; set; }
        public string[] ToCountries { get; set; }
    }
}
