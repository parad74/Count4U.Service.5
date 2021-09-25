//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Xml.Linq;

//namespace Sip2.TCPClient.Emulator
//{
//	public class UtilsSip2
//	{
//		public static string _profilrFile = "Profile.xml";//IdSip2.Common.Properties.Settings1.Default.ConfigCommunicationFile;
//		private static XDocument _xDocumentConfigCommunication = null;
//		private static string _error = "";
//		//public static string AppDataFolder = IdSip2.Common.Properties.Settings1.Default.AppDataFolder;

//		private static string AssemblyFolderPath()
//		{

//			string appDataFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

//			DirectoryInfo di = new DirectoryInfo(appDataFolder);
//			return di.FullName;
//		}



//		public static string BuildAppDataFolderPath(string folderPath = "")
//		{
//			string appDataFolderPath = AssemblyFolderPath() + @"\";
//			if (folderPath != "")
//			{
//				appDataFolderPath = folderPath + @"\";
//			}
//			return appDataFolderPath;
//		}


	
//		public static XDocument XDocumentConfigCommunication(string folderPath = "")
//		{
//			UtilsSip2._error = "";

//			string configCommunicationPath = UtilsSip2.ConfigCommunicationFilePath(folderPath);

//			if (UtilsSip2._xDocumentConfigCommunication == null)
//			{
//				try
//				{
//					if (File.Exists(configCommunicationPath) == false) UtilsSip2._error = UtilsSip2._error + "File not Exists : " + configCommunicationPath;
//					UtilsSip2._xDocumentConfigCommunication = XDocument.Load(configCommunicationPath);
//				}
//				catch (Exception exp)
//				{
//					UtilsSip2._xDocumentConfigCommunication = null;
//					UtilsSip2._error = UtilsSip2._error + exp.Message;
//				}
//			}
//			return UtilsSip2._xDocumentConfigCommunication;
//		}

//		public static string ConfigCommunicationFilePath(string folderPath = "")
//		{
//			return BuildAppDataFolderPath(folderPath) + UtilsSip2._profilrFile;
//		}

//		public static string Error
//		{
//			get { return UtilsSip2._error; }
//			set { UtilsSip2._error = value; }
//		}


//	}


//}
