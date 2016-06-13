using System.IO;
using ITC.UnifaunOnline.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class UnifaunOnlineServiceTest
    {
        #region Test data

        private UnifaunData testData = new UnifaunData
        {
            Sender = new UnifaunSender
            {
                SenderId = "123",
                Name = "Kalle Svensson",
                Address1 = "Skickargatan 1",
                ZipCode = "132 45",
                City = "Skickarstaden",
                Country = "SE"
            },
            Receiver = new UnifaunReceiver()
            {
                ReceiverId = "321",
                Name = "Kalle Ökvist",
                Address1 = "Storgatan 123",
                ZipCode = "132 45",
                City = "Mottagarstaten",
                Country = "SE"
            },
            Party = new UnifaunParty()
            {
                PartyId = "321",
                Name = "Party Olsson",
                Address1 = "Storgatan 456",
                ZipCode = "3245",
                City = "Partystaden",
                Country = "NO"
            },
            Shipment = new UnifaunShipment
            {
                From = "123",
                To = "321",
                Reference = "Order 123",
                Freetext1 = "Freee",
                OrderNo = "123",
                UfOnline = new UnifaunUfOnline(Options.ENot("kalle@company.se", "Testing!")),
                Service = new UnifaunService("ASPO",
                    Addons.Sms("0703305551"),
                    Addons.Cod(123.50m, "COD Ref1")),
                Containers = new[] { new UnifaunContainer
                        {
                            Type = ContainerType.Parcel,
                            Copies = 2,
                            Weight = 20.1m,
                            Contents = "Stuff",
                            Volume = 0.67m
                        },
                        new UnifaunContainer
                        {
                            Weight = 10.2m,
                            Contents = "Stuff 2",
                            Volume = 0.2m
                        },
                        new UnifaunContainer(25.5m, "Cool stuffs")
                    }
            }
        };

        #endregion

        [TestMethod]
        public void GenerateXmlContentTest()
        {
            var content = UnifaunOnlineService.GenerateXmlContent(testData);
        }

        [TestMethod]
        public void SaveXmlContentTest()
        {
            var content = UnifaunOnlineService.GenerateXmlContent(testData);
            File.WriteAllText(@"c:\temp\unifaun\_test.xml", content);
        }
    }
}
