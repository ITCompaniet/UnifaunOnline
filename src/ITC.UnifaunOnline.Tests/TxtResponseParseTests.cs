using System;
using ITC.UnifaunOnline.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class TxtResponseParseTests
    {
        [TestMethod]
        public void TxtResponseParseTest()
        {
            // Arrange
            const string content = "ORDERNO;UNKNOWN;1234567890;2016-09-13 10:13:07;REFNO";

            // Act
            var response  = UnifaunResponseParser.Parse(content);

            // Assert
            Assert.AreEqual("ORDERNO", response.OrderNo);
            Assert.AreEqual(1234567890L, response.ShippmentNumber);
            Assert.AreEqual(new DateTime(2016,9,13,10, 13, 7), response.Date);
            Assert.AreEqual("REFNO", response.Reference);
        }
    }
}
