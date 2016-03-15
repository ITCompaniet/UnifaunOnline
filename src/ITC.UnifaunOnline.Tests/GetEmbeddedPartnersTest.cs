using ITC.UnifaunOnline.Partners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class GetEmbeddedPartnersTest
    {
        [TestMethod]
        public void EmbeddedPartners_Test()
        {
            var partners = EmbeddedPartners.GetEmbeddedPartners();
        }
    }
}
