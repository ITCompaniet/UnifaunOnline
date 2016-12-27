using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ITC.UnifaunOnline.Partners
{
    public class EmbeddedPartners
    {
        public static ICollection<UnifaunServicePartner> GetEmbeddedPartners()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ITC.UnifaunOnline.unifaun_codes.txt"))
            using (var reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                var lines = result.Split(new [] { "\r\n", "\n" }, StringSplitOptions.None);

                var servicePartners = new List<UnifaunServicePartner>();

                foreach (var line in lines)
                {
                    var lineContent = line.Split(new[] { "\t" }, StringSplitOptions.None);

                    var partnerCode = lineContent[0];
                    var partnerName = lineContent[1];
                    var serviceCode = lineContent[2];
                    var serviceName = lineContent[3];
                    var fromCountries = lineContent[4].Replace(" ", "").Split(',');
                    var toCountries = lineContent[5].Replace(" ", "").Split(',');

                    var partner = servicePartners.FirstOrDefault(p => p.Code == partnerCode);
                    if (partner == null)
                    {
                        partner = new UnifaunServicePartner
                        {
                            Code = partnerCode,
                            Name = partnerName
                        };
                        servicePartners.Add(partner);
                    }

                    partner.Services.Add(new PartnerService
                    {
                        Code = serviceCode,
                        Name = serviceName,
                        FromCountries = fromCountries,
                        ToCountries = toCountries
                    });
                }
                return servicePartners.ToArray();
            }
        }
    }
}
