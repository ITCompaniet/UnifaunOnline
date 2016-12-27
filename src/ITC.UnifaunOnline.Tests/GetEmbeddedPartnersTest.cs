using ITC.UnifaunOnline.Partners;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ITC.UnifaunOnline.Tests
{

    [TestClass]
    public class GetEmbeddedPartnersTest
    {
        [TestMethod]
        public void EmbeddedPartners_Test()
        {
            var partners = EmbeddedPartners.GetEmbeddedPartners();

            Assert.AreEqual(false, partners.First().Services.First().ToCountries.Last().Contains("\r"));
        }
    }
}
