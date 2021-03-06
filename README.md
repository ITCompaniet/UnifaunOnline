# UnifaunOnline
Unifaun Online Order XML Generator


## Usage

### Generate XML
```CSharp


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
                    Service = UnifaunServiceBuilder.Service("ASPO")
                            .SmsNot("0701234567")
                            .Cod(123.50m, "COD Ref 1")
                            .Build(),
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
```

### Embedded Partners
Get all Unifaun Partners
```CSharp
            var partners = EmbeddedPartners.GetEmbeddedPartners();
```

### XML Post
Post XML to Unifaun Online
```CSharp
            var unifaunData = new UnifaunData();
            // Fill unifaunData with data
            
            var success = UnifaunOnlineService.XmlPost(unifaunData, "{DEVID}", "{USERID}", "{PASS}");
```

### TXT Response
Parse TXT Reponse from Unifaun OnlineConnect
```CSharp
            var response = UnifaunResponseParser.Parse(content);
```

### TrackBack
This service is used to report back shipment history
```CSharp
            var unifaunTrackBackAndDiscardService = new UnifaunTrackBackAndDiscardService("{DEVID}", "{USERID}", "{PASS}");
            var shipments = unifaunTrackBackAndDiscardService.FetchNewShipments();
```
### Discard
Discarding printed shipments
```CSharp
            var unifaunTrackBackAndDiscardService = new UnifaunTrackBackAndDiscardService("{DEVID}", "{USERID}", "{PASS}");
            unifaunTrackBackAndDiscardService.DiscardByShipmentNo("1234567890");
```


