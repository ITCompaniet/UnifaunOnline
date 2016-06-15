using System.Collections.Generic;
using ITC.UnifaunOnline.Elements;

namespace ITC.UnifaunOnline.Builders
{
    /// <summary>
    /// Fluid API Service Builder
    /// </summary>
    public class UnifaunServiceBuilder
    {
        #region Fields

        private readonly List<UnifaunAddon> _addons = new List<UnifaunAddon>();
        private string _serviceCode;
        private string _smsNumber;
        private decimal? _amount;
        private string _reference;
        private string _emailAddress;

        #endregion

        private UnifaunServiceBuilder(string serviceCode)
        {
            _serviceCode = serviceCode;
        }

        public static UnifaunServiceBuilder Service(string serviceCode)
        {
            return new UnifaunServiceBuilder(serviceCode);
        }

        public UnifaunServiceBuilder SmsNot(string smsNumber)
        {
            _smsNumber = smsNumber;
            return this;
        }

        public UnifaunServiceBuilder EmailNot(string emailAddress)
        {
            _emailAddress = emailAddress;
            return this;
        }

        public UnifaunServiceBuilder Cod(decimal amount, string reference)
        {
            // DHL Service Point CoD
            if (_serviceCode == "ASPO")
                _serviceCode = "ASPOC";

            _amount = amount;
            _reference = reference;
            return this;
        }

        public UnifaunServiceBuilder Add(UnifaunAddon addon)
        {
            _addons.Add(addon);
            return this;
        }

        public UnifaunService Build()
        {
            if (_smsNumber != null)
                _addons.Add(Addons.SmsNot(_serviceCode, _smsNumber));

            else if (_emailAddress != null)
                _addons.Add(Addons.EmailNot(_serviceCode, _emailAddress));

            if (_amount.HasValue)
                _addons.Add(Addons.Cod(_serviceCode, _amount.Value, _reference, _smsNumber, _emailAddress));

            return new UnifaunService(_serviceCode, _addons.ToArray());
        }
    }
}
