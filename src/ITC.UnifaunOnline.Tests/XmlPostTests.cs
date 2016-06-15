using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class XmlPostTests
    {
        [TestMethod]
        public void XmlPost_Test()
        {
            UnifaunOnlineService.XmlPost(UnifaunOnlineServiceTest.ASPO_full_data, "", "", "");
        }
    }
}
