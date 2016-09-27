using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using ITC.UnifaunOnline.UnifaunAuth;
using ITC.UnifaunOnline.UnifaunTrackBackDiscard;

namespace ITC.UnifaunOnline
{
    public class UnifaunTrackBackAndDiscardService
    {
        #region Fields

        private readonly string _developerId;
        private readonly string _userId;
        private readonly string _pin;
        private bool _authed;
        private string _sessionId;

        #endregion

        #region Ctor

        public UnifaunTrackBackAndDiscardService(string developerId, string userId, string pin)
        {
            _developerId = developerId;
            _userId = userId;
            _pin = pin;
        }

        #endregion

        public ICollection<fetchNewShipmentsResultShipment> FetchNewShipments()
        {
            try
            {
                var historyClient = new History3Client(BasicHttpBindingWithTransportSecurity, HistoryEndpoint);
                var shipments = new List<fetchNewShipmentsResultShipment>();
                var done = false;
                var fetchId = 0L;
                while (!done)
                {
                    var newShipmentsResponse = historyClient.FetchNewShipments1(SessionId, fetchId);
                    done = newShipmentsResponse.done;
                    fetchId = newShipmentsResponse.fetchId;

                    if (newShipmentsResponse.shipments != null)
                        shipments.AddRange(newShipmentsResponse.shipments);

                    if (!done)
                        Thread.Sleep((int)newShipmentsResponse.minDelay);
                }

                return shipments;
            }
            catch (FaultException<UnifaunTrackBackDiscard.wsFaultInfo> fe)
            {
                // Invalid Session
                if (fe.Detail.errorCode == 3)
                    _authed = false;

                throw;
            }
        }

        public void DiscardByShipmentNo(string shipmentNo) => Discard(shipmentNo, "SHIPMENT_NO");
        public void DiscardByOrderNo(string orderNo) => Discard(orderNo, "ORDER_NO");
        public void DiscardByReference(string reference) => Discard(reference, "REFERENCE");
        public void DiscardByParcelNo(string parcelNo) => Discard(parcelNo, "PARCEL_NO");

        private void Discard(string ident, string type)
        {
            try
            {
                var historyClient = new History3Client(BasicHttpBindingWithTransportSecurity, HistoryEndpoint);
                historyClient.DiscardShipments1(SessionId, new [] {ident}, type);
            }
            catch (FaultException<UnifaunTrackBackDiscard.wsFaultInfo> fe)
            {
                // Invalid Session
                if (fe.Detail.errorCode == 3)
                    _authed = false;

                throw;
            }
        }

        #region Properties

        public string SessionId
        {
            get
            {
                if (_authed && !string.IsNullOrEmpty(_sessionId))
                    return _sessionId;
                
                try
                {
                    var authClient = new Authentication2Client(BasicHttpBindingWithTransportSecurity, AuthEndpoint);
                    _sessionId = authClient.Login1(_userId, _pin, _developerId);
                    _authed = true;
                    return _sessionId;
                }
                catch
                {
                    _authed = false;
                    throw;
                }
            }
        }

        private static EndpointAddress AuthEndpoint => new EndpointAddress("https://www.unifaunonline.com/ws-extapi2/Authentication2");
        private static EndpointAddress HistoryEndpoint => new EndpointAddress("https://www.unifaunonline.com/ws-extapi2/History3");
        private static Binding BasicHttpBindingWithTransportSecurity => new BasicHttpBinding(BasicHttpSecurityMode.Transport);

        #endregion
    }
}