using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace ITC.UnifaunOnline.Elements
{
    public abstract class UnifaunValues
    {
        [XmlElement("val")]
        public UnifaunValue[] Values
        {
            get
            {
                return (from field in GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)
                    let value = field.GetValue(this)
                    where value != null
                    select new UnifaunValue(field.Name.ToLower(), ToInvariantString(value))).ToArray();
            }
            set { }
        }

        private static string ToInvariantString(object obj)
        {
            return (obj as IConvertible)?.ToString(CultureInfo.InvariantCulture) ?? 
                ((obj as IFormattable)?.ToString(null, CultureInfo.InvariantCulture) ?? obj.ToString());
        }
    }
}