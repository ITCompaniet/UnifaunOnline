using System.IO;
using ITC.UnifaunOnline.Builders;
using ITC.UnifaunOnline.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlUnit.Xunit;
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class UnifaunOnlineServiceTest
    {
        #region Test data

        public static UnifaunData ASPO_full_data = new UnifaunData
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
                UfOnline = new UnifaunUfOnline(Options.ENot("kalle@company.se", "Testing!", "from@company.se")),
                Service = UnifaunServiceBuilder
                .Service("ASPO")
                .SmsNot("0701234567")
                .Build(),
                Containers = new[] 
                {
                    new UnifaunContainer
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

        private UnifaunData ASPOC_data = new UnifaunData
        {
            Sender = new UnifaunSender
            {
                SenderId = "123"
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
            Shipment = new UnifaunShipment
            {
                From = "123",
                To = "321",
                UfOnline = new UnifaunUfOnline(Options.ENot("kalle@company.se", "Testing!", "from@company.se")),
                Service = UnifaunServiceBuilder
                .Service("ASPO")
                .SmsNot("0701234567")
                .Cod(123.50m, "COD Ref 1")
                .Build(),
                Containers = new[] 
                {
                    new UnifaunContainer(25.5m, "Cool stuffs")
                }
            }
        };

        private UnifaunData P19_data = new UnifaunData
        {
            Sender = new UnifaunSender
            {
                SenderId = "123"
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
            Shipment = new UnifaunShipment
            {
                From = "123",
                To = "321",
                UfOnline = new UnifaunUfOnline(Options.ENot("kalle@company.se", "Testing!", "from@company.se")),
                Service = UnifaunServiceBuilder
                .Service("P19")
                .SmsNot("0701234567")
                .Build(),
                Containers = new[]
                {
                    new UnifaunContainer(25.5m, "Cool stuffs")
                }
            }
        };

        #endregion

        #region Assert Data

        private const string ASPO_full_xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<data>
  <sender sndid=""123"">
    <val n=""name"">Kalle Svensson</val>
    <val n=""address1"">Skickargatan 1</val>
    <val n=""zipcode"">132 45</val>
    <val n=""city"">Skickarstaden</val>
    <val n=""country"">SE</val>
  </sender>
  <receiver rcvid=""321"">
    <val n=""name"">Kalle Ökvist</val>
    <val n=""address1"">Storgatan 123</val>
    <val n=""zipcode"">132 45</val>
    <val n=""city"">Mottagarstaten</val>
    <val n=""country"">SE</val>
  </receiver>
  <party ptyid=""321"">
    <val n=""name"">Party Olsson</val>
    <val n=""address1"">Storgatan 456</val>
    <val n=""zipcode"">3245</val>
    <val n=""city"">Partystaden</val>
    <val n=""country"">NO</val>
  </party>
  <shipment ordernr=""123"">
    <val n=""from"">123</val>
    <val n=""to"">321</val>
    <val n=""reference"">Order 123</val>
    <val n=""freetext1"">Freee</val>
    <service srvid=""ASPO"">
      <addon adnid=""NOT"">
        <val n=""misc"">0701234567</val>
        <val n=""misctype"">SMS</val>
      </addon>
    </service>
    <ufonline>
      <addon optid=""ENOT"">
        <val n=""message"">Testing!</val>
        <val n=""from"">from@company.se</val>
        <val n=""to"">kalle@company.se</val>
      </addon>
    </ufonline>
    <container type=""parcel"">
      <val n=""copies"">2</val>
      <val n=""weight"">20.1</val>
      <val n=""volume"">0.67</val>
      <val n=""contents"">Stuff</val>
    </container>
    <container type=""parcel"">
      <val n=""copies"">1</val>
      <val n=""weight"">10.2</val>
      <val n=""volume"">0.2</val>
      <val n=""contents"">Stuff 2</val>
    </container>
    <container type=""parcel"">
      <val n=""copies"">1</val>
      <val n=""weight"">25.5</val>
      <val n=""contents"">Cool stuffs</val>
    </container>
  </shipment>
</data>";

        private const string ASPOC_xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<data>
  <sender sndid=""123"" />
  <receiver rcvid=""321"">
    <val n=""name"">Kalle Ökvist</val>
    <val n=""address1"">Storgatan 123</val>
    <val n=""zipcode"">132 45</val>
    <val n=""city"">Mottagarstaten</val>
    <val n=""country"">SE</val>
  </receiver>
  <shipment>
    <val n=""from"">123</val>
    <val n=""to"">321</val>
    <service srvid=""ASPOC"">
      <addon adnid=""COD"">
        <val n=""amount"">123.50</val>
        <val n=""reference"">COD Ref 1</val>
        <val n=""misc"">0701234567</val>
        <val n=""misctype"">SMS</val>
      </addon>
    </service>
    <ufonline>
      <addon optid=""ENOT"">
        <val n=""message"">Testing!</val>
        <val n=""from"">from@company.se</val>
        <val n=""to"">kalle@company.se</val>
      </addon>
    </ufonline>
    <container type=""parcel"">
      <val n=""copies"">1</val>
      <val n=""weight"">25.5</val>
      <val n=""contents"">Cool stuffs</val>
    </container>
  </shipment>
</data>";
        
        private const string P19_xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<data>
  <sender sndid=""123"" />
  <receiver rcvid=""321"">
    <val n=""name"">Kalle Ökvist</val>
    <val n=""address1"">Storgatan 123</val>
    <val n=""zipcode"">132 45</val>
    <val n=""city"">Mottagarstaten</val>
    <val n=""country"">SE</val>
  </receiver>
  <shipment>
    <val n=""from"">123</val>
    <val n=""to"">321</val>
    <service srvid=""P19"">
      <addon adnid=""NOTSMS"">
        <val n=""misc"">0701234567</val>
      </addon>
    </service>
    <ufonline>
      <addon optid=""ENOT"">
        <val n=""message"">Testing!</val>
        <val n=""from"">from@company.se</val>
        <val n=""to"">kalle@company.se</val>
      </addon>
    </ufonline>
    <container type=""parcel"">
      <val n=""copies"">1</val>
      <val n=""weight"">25.5</val>
      <val n=""contents"">Cool stuffs</val>
    </container>
  </shipment>
</data>";

        #endregion

        [TestMethod]
        public void ASPO_full_Test()
        {
            var content = UnifaunOnlineService.GenerateXmlContent(ASPO_full_data);

            XmlAssertion.AssertXmlEquals(ASPO_full_xml, content);
        }

        [TestMethod]
        public void ASPOC_Test()
        {
            var content = UnifaunOnlineService.GenerateXmlContent(ASPOC_data);

            XmlAssertion.AssertXmlEquals(ASPOC_xml, content);
        }

        [TestMethod]
        public void P19_Test()
        {
            var content = UnifaunOnlineService.GenerateXmlContent(P19_data);

            XmlAssertion.AssertXmlEquals(P19_xml, content);
        }

       [TestMethod]
        public void SaveXmlContentTest()
        {
            var content = UnifaunOnlineService.GenerateXmlContent(ASPOC_data);
            File.WriteAllText(@"c:\temp\unifaun\_test.xml", content);
        }
    }
}
