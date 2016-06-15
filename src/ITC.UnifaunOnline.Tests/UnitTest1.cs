using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using ITC.UnifaunOnline.Responses;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void XmlPost_Test()
        {
            UnifaunOnlineService.XmlPost(UnifaunOnlineServiceTest.ASPO_full_data, "", "", "");
        }
    }
}
