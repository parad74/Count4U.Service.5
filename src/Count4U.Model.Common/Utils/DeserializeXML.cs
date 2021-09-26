using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Count4U.Model.Common
{
	public static class DeserializeXML
	{

        public static T DeserializeXMLFileToObject<T>(string XmlFilename)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmlFilename)) return default(T);

            try
            {
                StreamReader xmlStream = new StreamReader(XmlFilename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                string txt = ex.Message;
            }
            return returnObject;
        }


        public static T DeserializeXMLTextToObject<T>(string XmTtext)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmTtext)) return default(T);

            try
            {
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(XmTtext));
                StreamReader xmlStream = new StreamReader(ms);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                string txt = ex.Message;
            }
            return returnObject;
        }

        public static Exception TryDeserializeXMLTextToObject<T>(string XmTtext/*, out string error*/)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmTtext)) return new Exception();

            try
            {
                StringReader xmlStream = new StringReader(XmTtext);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return new Exception();
        }

        public static string SerializeToXml<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
				// removes version
				XmlWriterSettings settings = new XmlWriterSettings();
				settings.OmitXmlDeclaration = true;

				var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new Utf8StringWriter();
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    // removes namespace
                    var xmlns = new XmlSerializerNamespaces();
                    xmlns.Add(string.Empty, string.Empty);

                    xmlserializer.Serialize(writer, value, xmlns);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                string txt = ex.Message;
                return "";
            }
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
