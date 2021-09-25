//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace Sip2.TCPClient.Emulator
//{
//	public class ConfigCommunication
//	{
//		public ConfigCommunication()
//		{
//		}

	
//		public string GetProxyIsDefault(out string errorXDoc, string folderPath = "")
//		{
//			XDocument xdoc = UtilsSip2.XDocumentConfigCommunication(folderPath);
//			errorXDoc = "";
//			if (xdoc == null)
//			{
//				errorXDoc = errorXDoc + " : ??" + UtilsSip2.Error;			//TODO 
//				return "Test Data";
//			}

//			try
//			{
//				//var responseTestData = xdoc.Descendants("operation").Where(t => t.Attribute("code").Value == codeOperation).Descendants("response").FirstOrDefault().Value;
//				XElement proxyXElement = xdoc.Descendants("proxy").Where(t => t.Attribute("isdefault").Value == "1").FirstOrDefault();
//				if (proxyXElement == null) { return "Test Data"; }
//				string proxyTitle = (string)proxyXElement.Attribute("name") ?? "";
//				if (string.IsNullOrWhiteSpace(proxyTitle) == true) { return "Test Data"; }
//				return proxyTitle;
//			}
//			catch (Exception exp)
//			{
//				errorXDoc = errorXDoc + exp.Message + "--" + exp.StackTrace;
//				return "Test Data";
//			}
//		}


//		public List<string> GetDataNames(out string errorXDoc, string folderPath = "")
//		{
//			List<string> proxyElementNames = new List<string>();
//			XDocument xdoc = UtilsSip2.XDocumentConfigCommunication(folderPath);
//			errorXDoc = "";
//			if (xdoc == null)
//			{
//				errorXDoc = errorXDoc + " : ??" + UtilsSip2.Error;			//TODO 
//				proxyElementNames.Add("Test Data");
//				return proxyElementNames;
//			}

//			try
//			{
//				//var responseTestData = xdoc.Descendants("operation").Where(t => t.Attribute("code").Value == codeOperation).Descendants("response").FirstOrDefault().Value;
							
//				IEnumerable<XElement> proxyXElements = xdoc.Descendants("proxy");
//				if (proxyXElements == null)
//				{
//					proxyElementNames.Add("Test Data");
//					return proxyElementNames;
//				}

//				foreach (XElement xElementProxy in proxyXElements)
//				{
//					string name = (string)xElementProxy.Attribute("name") ?? "";
//					if (name != "") 	proxyElementNames.Add(name);
//				}
//				return proxyElementNames;
//			}
//			catch (Exception exp)
//			{
//				errorXDoc = errorXDoc + exp.Message + "--" + exp.StackTrace;
//				proxyElementNames.Add("Test Data");
//				return proxyElementNames;
//			}
//		}


//		public IEnumerable<XElement> GetDataRequest(string proxyName, out string errorXDoc, string folderPath = "")
//		{
//			XDocument xdoc = UtilsSip2.XDocumentConfigCommunication(folderPath);
//			errorXDoc = "";
//			if (xdoc == null)
//			{
//				errorXDoc = errorXDoc + " : 1 " + UtilsSip2.Error;			//TODO 
//				return null;
//			}

//			try
//			{
//				//var responseTestData = xdoc.Descendants("operation").Where(t => t.Attribute("code").Value == codeOperation).Descendants("response").FirstOrDefault().Value;

//				IEnumerable<XElement> proxyXElements = xdoc.Descendants("proxy").Where(t => t.Attribute("name").Value == proxyName).Descendants("testData");
				
//				if (proxyXElements == null)
//				{
//					errorXDoc = errorXDoc + " : 2 " + UtilsSip2.Error;			//TODO 
//					return null;
//				}

//				return proxyXElements;
//			}
//			catch (Exception exp)
//			{
//				errorXDoc = errorXDoc + exp.Message + "--" + exp.StackTrace;
//				return null;
//			}
//		}

//		//public string GetValue_FromString_ByFormat(string entity, XElement xElementFormat)
//		//{
//		//	string retData = "";
//		//	if (string.IsNullOrWhiteSpace(entity) == true) return retData;
//		//	if (xElementFormat == null) return retData;

//		//	string formatType = (string)xElementFormat.Attribute("type") ?? "";
//		//	if (formatType == "fixed")
//		//	{
//		//		int length = (int?)xElementFormat.Attribute("length") ?? 0;
//		//		int startindex = (int?)xElementFormat.Attribute("startindex") ?? 0;
//		//		string required = (string)xElementFormat.Attribute("required") ?? "";
//		//		if (length > 0 && startindex > 0)
//		//		{
//		//			if ((startindex + length) > entity.Length) length = entity.Length - startindex;
//		//			startindex  = startindex - 1;
//		//			retData = entity.Substring(startindex, length);
//		//		}
//		//	}
//		//	else if (formatType == "variablelength")
//		//	{
//		//		string start = (string)xElementFormat.Attribute("start") ?? "";
//		//		if (start.Length != 2) return retData;
//		//		string required = (string)xElementFormat.Attribute("required") ?? "";
//		//		int startindex = (int?)xElementFormat.Attribute("startindex") ?? 1;
//		//		string[] in_data = entity.Split(new Char[] { '|' });
//		//		foreach (var element in in_data)
//		//		{
//		//			//  Name
//		//			string ind = "";
//		//			if ((startindex - 1 + 2) < element.Length) {
//		//				ind = element.Substring(startindex - 1, 2).ToUpper();
//		//			}
//		//			if (ind == start) retData = element.Substring(startindex - 1 + 2);
//		//		}
//		//	}
//		//	else if (formatType == "variablelength_startindex")
//		//	{
//		//		int startindex = (int?)xElementFormat.Attribute("startindex") ?? 0;
//		//		string required = (string)xElementFormat.Attribute("required") ?? "";
//		//		int length = entity.Length - startindex;
//		//		startindex = startindex - 1;
//		//		retData = entity.Substring(startindex, length);
//		//	}
//		//	return retData;
//		//}

//		//	//<format type="fixed" length="1" startindex="1"  required="0|1|2">
//		////<format type="variablelength_startindex" startindex="9"  required="">
//		//// <format type="variablelength" start="AM" required=""> 
//		////Response -> ToString
//		//public string GetString_FromPropertyValue_ByFormat(string propertyValue, XElement xElementFormat)
//		//{
//		//	string retData = "";
//		//	if (string.IsNullOrWhiteSpace(propertyValue) == true) propertyValue = "";

//		//	if (xElementFormat == null) return retData;

//		//	string formatType = (string)xElementFormat.Attribute("type") ?? "";
//		//	if (formatType == "fixed")
//		//	{
//		//		int length = (int?)xElementFormat.Attribute("length") ?? 0;
//		//		int startindex = (int?)xElementFormat.Attribute("startindex") ?? 0;
//		//		string required = (string)xElementFormat.Attribute("required") ?? "";
//		//		if (required == "YYYYMMDDZZZZHHMMSS") retData = ConvertData.GetDateString();
//		//		else if (required == "DD.MM.YYYY") retData = ConvertData.GetDateShotString();
//		//		else if (propertyValue.Length > length) retData = propertyValue.Substring(0, length);
//		//		else if (propertyValue.Length < length) retData = propertyValue.PadRight(length, ' ');
//		//		else retData = propertyValue;
//		//	}
//		//	else if (formatType == "variablelength")
//		//	{
//		//		string required = (string)xElementFormat.Attribute("required") ?? "";
//		//		string start = (string)xElementFormat.Attribute("start") ?? "";
//		//		if (start.Length > 2) start = start.Substring(2); 
//		//		retData = start + propertyValue + "|";
//		//		if (required == "YYYYMMDDZZZZHHMMSS") retData = start + ConvertData.GetDateString() + "|";
//		//		else if (required == "DD.MM.YYYY") retData = start + ConvertData.GetDateShotString() + "|";
//		//		else if (required == "excludeIfEmpty")
//		//		{
//		//			if (string.IsNullOrWhiteSpace(propertyValue) == true)
//		//			{
//		//				retData = "";
//		//			}
//		//		}
//		//	}
//		//	else if (formatType == "variablelength_startindex")
//		//	{
//		//		int startindex = (int?)xElementFormat.Attribute("startindex") ?? 0;
//		//		string required = (string)xElementFormat.Attribute("required") ?? "";
//		//		retData = propertyValue;
//		//	}

//		//	return retData;
//		//}



//		//private static string LeadingEmpty(string inString, int n, string code)
//		//{
//		//	int lenCode = inString.Length;

//		//	if (lenCode > n) code = inString.Substring(0, n);

//		//	if (lenCode < n)
//		//	{
//		//		int rest = n - lenCode;
//		//		string temp = "";
//		//		for (int i = 0; i < rest; i++)
//		//		{
//		//			temp = temp + " ";
//		//		}
//		//		code = temp + inString;
//		//	}
//		//	return code;
//		//}

//	}



//}
