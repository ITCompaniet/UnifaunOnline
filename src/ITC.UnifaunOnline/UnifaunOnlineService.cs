using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using ITC.UnifaunOnline.Elements;
using ITC.UnifaunOnline.Responses;

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
                data.WriteXml(writer);
                return writer.ToString();
            }
        }

        private static void WriteXml<T>(this T objectToSerialize, TextWriter writer)
        {
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            new XmlSerializer(typeof(T)).Serialize(writer, objectToSerialize, xns);
        }

        /// <summary>
        /// Post XML to Unifaun Online
        /// </summary>
        /// <param name="data"></param>
        /// <param name="developerId"></param>
        /// <param name="userId"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public static bool XmlPost(UnifaunData data, string developerId, string userId, string pin)
        {
            var uri = $"https://www.unifaunonline.com/ufoweb/order?session=ufo_SE&user={userId}&pin={pin}&developerid={developerId}&type=xml";
            var webRequest = (HttpWebRequest) WebRequest.Create(uri);

            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml";

            var encoding = Encoding.GetEncoding("ISO-8859-1");

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                data.WriteXml(streamWriter);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (var webResponse = (HttpWebResponse) webRequest.GetResponse())
            using (var responseStream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(responseStream, encoding))
            {
                var serializer = new XmlSerializer(typeof(UnifaunXmlPostResponse));
                var response = (UnifaunXmlPostResponse) serializer.Deserialize(reader);
                if (response.Status == "201")
                    return true;
            }

            return false;
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
