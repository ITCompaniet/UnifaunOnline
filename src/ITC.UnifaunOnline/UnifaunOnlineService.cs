using ITC.UnifaunOnline.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ITC.UnifaunOnline
{
    public static class UnifaunOnlineService
    {
        /// <summary>
        /// Generate Unifaun Order XML
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Unifaun Order XML Content</returns>
        public static string GenerateXmlContent(UnifaunData data)
        {
            using (var writer = new Utf8StringWriter())
            {
                data.ToXml(writer);
                return writer.ToString();
            }
        }

        private static void ToXml<T>(this T objectToSerialize, StringWriter writer)
        {
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            new XmlSerializer(typeof (T)).Serialize(writer, objectToSerialize, xns);
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
