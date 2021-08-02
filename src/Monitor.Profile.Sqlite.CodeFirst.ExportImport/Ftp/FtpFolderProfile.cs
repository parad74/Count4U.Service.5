//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using Count4U.Common.Helpers.Ftp;
//using Count4U.Model;
//using Count4U.Model.Audit;
//using Count4U.Model.Main;
////using Ionic.Zip;

//namespace Count4U.Model.Common
//{
//	public class FtpFolderProFile
//	{
//		private ISettingsFtpRepository _settingsFtpRepository;
//		public FtpFolderProFile(ISettingsFtpRepository settingsFtpRepository)
//		{
//			this._settingsFtpRepository = settingsFtpRepository ??
//				  throw new ArgumentNullException(nameof(settingsFtpRepository));
//		}


//		//rootFonderOnFtp = "mINV" 
//		//string rootFonderOnFtp = this._customerRepository.Connection.RootFolderFtp(); //mINV
//		public void InventorProfileSendFromLocalPathToFtp(Inventor inventor, string rootFonderOnFtp, string fromLocalPath, string fileName = "profile.xml")      //mINV
//		{
//			if (inventor == null)
//			{
//				//_logger.Error("InventorProfileCreate ERROR : Inventor is Null  ");
//				return;
//			}

//			string messageCreateFolder = "";
//			try
//			{
//				string folderForInventorObject = this._contextCBIRepository.BuildLongCodesPath(inventor).Trim(@"\".ToCharArray()) + @"\Profile";
//				//rootFonderOnFtp = "mINV" 

//				string ftpFolder = this.CreatePathOnFtp(rootFonderOnFtp, folderForInventorObject, ref messageCreateFolder);

//				this.CopyFileToFtp(fromLocalPath, ftpFolder, fileName);
//			}
//			catch (Exception exc)
//			{
//				//_logger.ErrorException("In process create Folder on FTP, happens ERROR : ", exc);
//				return;
//			}


//		}

	

//		//  Create folder on ftp
//		//mINV\Customer\<CustomerCode>\Branch\BranchCode>\Inventor\<InventorCode>\Profile\<profile>
//		//rootFonderOnFtp = "mINV" 
//		public string CreatePathOnFtp(string rootFonderOnFtp, string objectFolder, ref string messageCreateFolder)
//		{
//			//string host = _userSettingsManager.HostGet().Trim('\\');
//			bool enableSsl = false;
//			string host = this._settingsFtpRepository.Host;
//			string user = this._settingsFtpRepository.User;
//			string password = this._settingsFtpRepository.Password;

//			FtpClient client = new FtpClient(host, user, password, enableSsl);
//			string folderResult = client.CreatePathOnFtp(host, rootFonderOnFtp, objectFolder, ref messageCreateFolder);
//			return folderResult;
	
//		}

//		public void CopyFileFromFtp(string fromFtpFonder, string toLocalFolder, string fileName, ref string messageCreateFolder)
//		{
//			if (Directory.Exists(toLocalFolder) == false) return;
//			bool enableSsl = false;
		
//			string host = this._settingsFtpRepository.Host;
//			string user = this._settingsFtpRepository.User;
//			string password = this._settingsFtpRepository.Password;

//			FtpClient client = new FtpClient(host, user, password, enableSsl);
//			client.uri = host;
	
//			try
//			{

//					FtpStatusCode statusCode = client.ChangeWorkingDirectoryReturnStatusCode(fromFtpFonder);
//					if (statusCode == FtpStatusCode.PathnameCreated)
//					{
//						List<FileDirectoryInfo> listInfoDirectory = client.GetDirectoryInformation(fromFtpFonder, host, user, password);
//						if (listInfoDirectory.Count < 1) return;
//						string targetPath = "none";

//						targetPath = toLocalFolder + @"\" + fileName; //Inventor
//						DateTime dt = DateTime.Now;
//						string backupTargetPath = toLocalFolder + @"\backup";
//						if (Directory.Exists(backupTargetPath) == false) Directory.CreateDirectory(backupTargetPath);
//						string extension = Path.GetExtension(targetPath);
//						backupTargetPath = backupTargetPath + @"\" + Path.GetFileNameWithoutExtension(targetPath)
//							+ dt.Year + dt.Month + dt.Day + dt.Hour + dt.Minute + extension;
//						string fromFtpPathProfile = fromFtpFonder;
//							try
//							{   //Inventor
//								if (File.Exists(targetPath) == true) File.Move(targetPath, backupTargetPath);				 //Count4U

//								fromFtpPathProfile = fromFtpFonder + @"\" + fileName;		  //  на ftp	  (from)
//								FtpStatusCode result = client.GetFileFromFtp(fileName, targetPath);
//								//_logger.Info("Copy profile.xml from ftpServer[" + fromFtpPathProfile + "]");
//								//_logger.Info("with Result [" + result.ToString() + "]");
//								messageCreateFolder = messageCreateFolder + "Copy profile.xml from ftpServer[" + fromFtpPathProfile + "]"
//									+ " with Result [" + result.ToString() + "]";


//							}
//							catch (Exception exc)
//							{
//								string message = String.Format("GetFromFtpCommandExecuted (File.Move to unsurePath) {0} => {1}", fromFtpPathProfile, targetPath);
//								messageCreateFolder = messageCreateFolder + message;
//								//_logger.ErrorException(message, exc);
//							}
//					}
//			}
//			catch (Exception exc)
//			{
//				//_logger.ErrorException("GetFromFtpCommandExecuted", exc);
//				messageCreateFolder = messageCreateFolder + exc.Message;
//			}

//		}

//		public void CopyFileToFtp(string fromLocalFolder, string toFtpFolder, string fileName)
//		{												 
//			//string host = _userSettingsManager.HostGet().Trim('\\');
//			bool enableSsl = false;
//			string host = this._settingsFtpRepository.Host;
//			string user = this._settingsFtpRepository.User;
//			string password = this._settingsFtpRepository.Password;

//			try
//			{

//				FtpClient client = new FtpClient(host, user, password, enableSsl);
//				client.uri = host;
//				string result3 = client.ChangeWorkingDirectory(toFtpFolder);

//				string toFTPFilePath = fileName;
//				string fromLocalFilePath = fromLocalFolder + @"\" + fileName;

//				string result = client.SaveFileToFtp(fromLocalFilePath, toFTPFilePath);
//				//_logger.Info("Save file [" + fromLocalFilePath + "]" + " to ftp [" + toFTPFilePath + "]");
//				//_logger.Info("with Result [" + result + "]");

//			}
//			catch (Exception exc)
//			{
//				string message = String.Format("CopyFileFromFtp ");
//				//_logger.ErrorException(message, exc);
//			}

//		}

//	}
//}

 