using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class UnifaunTrackBackAndDiscardServiceTests
    {
        [TestMethod]
        public void AuthTest()
        {
            var unifaunTrackBackAndDiscardService = new UnifaunTrackBackAndDiscardService("", "", "");
            var sessionId = unifaunTrackBackAndDiscardService.SessionId;

            Assert.AreEqual(false, string.IsNullOrEmpty(sessionId));
        }

        [TestMethod]
        public void NewShipmentsTest()
        {
            var unifaunTrackBackAndDiscardService = new UnifaunTrackBackAndDiscardService("", "", "");
            var shipments = unifaunTrackBackAndDiscardService.FetchNewShipments();

        }

        [TestMethod]
        public void Discard()
        {
            var unifaunTrackBackAndDiscardService = new UnifaunTrackBackAndDiscardService("", "", "");
            unifaunTrackBackAndDiscardService.DiscardByShipmentNo("6165468593");
        }
    }
}
