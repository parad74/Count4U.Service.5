using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Count4U.Model.Common
{
	public static class DeserializeXML
	{

        //public static T DeserializeXMLFileToObject<T>(string XmlFilename)
        //{
        //    T returnObject = default(T);
        //    if (string.IsNullOrEmpty(XmlFilename)) return default(T);

        //    try
        //    {
        //        StreamReader xmlStream = new StreamReader(XmlFilename);
        //        XmlSerializer serializer = new XmlSerializer(typeof(T));
        //        returnObject = (T)serializer.Deserialize(xmlStream);
        //    }
        //    catch (Exception ex)
        //    {
        //        string txt = ex.Message;
        //    }
        //    return returnObject;
        //}
        public static T DeserializeXMLFileToObject<T>(string XmlFilename)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmlFilename)) return default(T);

            try
            {
                StreamReader xmlStream = new StreamReader(XmlFilename, Encoding.UTF8);
                string XmTtext = xmlStream.ReadToEnd();
                XmTtext = XmTtext.Trim();
                if (string.IsNullOrEmpty(XmTtext)) return default(T);
                XmTtext = XmTtext.FixProfileXml();

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(XmTtext));
                StreamReader xmlStream1 = new StreamReader(ms);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream1);
            }
            catch (Exception ex)
            {
                string txt = ex.Message;
            }
            return returnObject;
        }


        //return null if    XmTtext    IsNullOrEmpty
        public static T DeserializeXMLTextToObject<T>(string XmTtext)
        {
            T returnObject = default(T);
            XmTtext = XmTtext.Trim();
            if (string.IsNullOrEmpty(XmTtext)) return default(T);

            try
            {
                XmTtext = XmTtext.FixProfileXml();
          
                 
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(XmTtext));
                StreamReader xmlStream = new StreamReader(ms);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                string txt = ex.Message;
                if (ex != null && ex.InnerException != null)
                {
                    string txt1 = ex.InnerException.Message;
                }
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                {
                    string txt2 = ex.InnerException.InnerException.Message;
                }

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
                    string xml = stringWriter.ToString();

                    //System.Text.Encoding outputEnc = new System.Text.UTF8Encoding(false);
                    var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
					StreamReader xmlStream = new StreamReader(ms);
					XDocument xdoc = XDocument.Load(xmlStream);
					xml = xdoc.ToString();
                    int index = xml.IndexOf('<');
                    if (index > 0)
                    {
                        xml = xml.Substring(index, xml.Length - index);
                    }
                    string xml1 = xml.Replace(@" />", @"/>");
                    return xml1;
                   
				}
            }
            catch (Exception ex)
            {
                string txt = ex.Message;
                return "";
            }
        }


        public static string FixProfileXml(this string entity)
        {
            int index = entity.IndexOf('<');
            if (index > 0)
            {
                entity = entity.Substring(index, entity.Length - index);
            }
           //
            //int index = XmTtext.IndexOf('<');
            //if (index > 0)
            //{
            //    XmTtext = XmTtext.Substring(index, XmTtext.Length - index);
            //}
            //if (index < 0)
            //{
            //    return returnObject;
            //}

            //XmTtext = XmTtext.Replace("True", "true");
            //XmTtext = XmTtext.Replace("False", "false");
             //
            entity = entity.Replace("False", "false");
            entity = entity.Replace("True", "true");
            entity = entity.Replace(@" />", @"/>");
            return entity;
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
