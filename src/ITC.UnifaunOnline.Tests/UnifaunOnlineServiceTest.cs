using ITC.UnifaunOnline.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class UnifaunOnlineServiceTest
    {
        [TestMethod]
        public void GenerateXmlContentTest()
        {
            var data = new UnifaunData
            {
                Sender = new UnifaunSender
                {
                    SenderId = "123",
                    Name = "Kalle Svensson",
                    Address1 = "Storgatan 1"
                },
                Receiver = new UnifaunReceiver()
                {
                    ReceiverId = "321",
                    Name = "Kalle Olsson",
                    Address1 = "Storgatan 123",
                    ZipCode = "132 45",
                    Country = "SE"
                },
                Party = new UnifaunParty()
                {
                    PartyId = "321",
                    Name = "Party Olsson",
                    Address1 = "Storgatan 456",
                    ZipCode = "3245",
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
                    Containers = new [] { new UnifaunContainer
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

            var content = UnifaunOnlineService.GenerateXmlContent(data);
        }
    }
}
