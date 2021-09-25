using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Count4U.Common.Constants;
using Count4U.Common.Helpers.Ftp;
using Monitor.Service.Model;

namespace Count4U.Model.Common
{
	public interface ISettingsFtpRepository
	{
		string HostRootFolder { get; set; }
		public string ProfileFolder { get; set; }
		string ToPdaFolder { get; set; }
		string FromPdaFolder { get; set; }
		string FromPhotoFolder { get; set; }
		string FromSignatureFolder { get; set; }
		string RelativeObjectPath { get; set; }
		string ProfilePath { get; set; }
		string ToPdaPath { get; set; }
		string FromPdaPath { get; set; }
		string FromPhotoPath { get; set; }
		string FromSignaturePath { get; set; }
		string FromPdaProcessPath { get; set; }
		string Host { get;  }
		string User { get;  }
		string Password { get;  }
		string CurrentDomainObject { get; set; }
		string TargetInDataFolder	 { get; set; }
		List<FileInfo> FilesInDataFolder	 { get; set; }
		string TargetInDataZipFolder	{ get; set; }
		void InitProperty(ProfileFile profileFileModel);
		ProfileFile ProfileFileSendToFtp(ProfileFile profileFileModel, bool createPathOnFtp = false, string fileName = "profile.xml");
		void CopyProfileFileFromFtpToMemoryStream(string fromFtpFonder, ref string profileText, ref string messageCreateFolder);

		List<string> GetCustomerCodeListFromFtp();
		List<string> GetBranchCodeListFromFtp(string customerCode);
		List<string> GetInventorSubFolderListFromFtp(string customerCode, string branchCode);

		List<string> GetSubFolder(string path, string folder);
	}
	public class SettingsFtpRepository : ISettingsFtpRepository
	{
		public string HostRootFolder { get; set; }
	  	public string ProfileFolder { get; set; }
		public string ToPdaFolder { get; set; }
		public string FromPdaFolder { get; set; }
 		public string FromPhotoFolder { get; set; }
		public string FromSignatureFolder { get; set; }
		public string RelativeObjectPath { get; set; }
		public string ProfilePath { get; set; }
		public string ToPdaPath { get; set; }
		public string FromPdaPath { get; set; }
		public string FromPhotoPath { get; set; }
		public string FromSignaturePath { get; set; }
		public string FromPdaProcessPath { get; set; }
		public string CurrentDomainObject { get; set; }
		public string TargetInDataFolder	 { get; set; }
		public List<FileInfo> FilesInDataFolder	 { get; set; }
		public string TargetInDataZipFolder	{ get; set; }

		//private Encoding ProviderEncoding = Encoding.GetEncoding("windows-1255");
		private Encoding ProviderEncoding = Encoding.UTF8;

		public SettingsFtpRepository( ) 
		{
		}

		public string Host
		{
			get
			{
				return PropertiesSettings.DefaultFtpHost;
			}
		}

		public string User
		{
			get
			{
				return PropertiesSettings.DefaultUser;
			}
		}

		public string Password
		{
			get
			{
				return PropertiesSettings.DefaultPassword;
			}
		}

		public void InitProperty(ProfileFile profileFileModel) 
		{
		
			this.ClearProperty();
			string relativeDb = BuildLongFtpPath(profileFileModel).Trim('\\');
			this.ProfileFolder = Path.Combine(relativeDb, FtpFolderName.Profile);           //Inventor\2018\1\1\<InventorCode>\Profile
			this.ToPdaFolder = Path.Combine(relativeDb, FtpFolderName.ToPda);      //Inventor\2018\1\1\<InventorCode>\ToPda
			this.FromPdaFolder = Path.Combine(relativeDb, FtpFolderName.FromPda);      //Inventor\2018\1\1\<InventorCode>\FromPda
																							//this.FromPhotoFolder = Path.Combine(relativeDb, FtpFolderName.Photo);      //Inventor\2018\1\1\<InventorCode>\Photo
																							//this.FromSignatureFolder = Path.Combine(relativeDb, FtpFolderName.Signature);      //Inventor\2018\1\1\<InventorCode>\Signature
			//FTP
			this.HostRootFolder = this.RootFolderFtp(); //mINV 
			this.ProfilePath = this.RootFolderFtp(this.ProfileFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\Profile
			this.ToPdaPath = this.RootFolderFtp(this.ToPdaFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\ToPda
			this.FromPdaPath = this.RootFolderFtp(this.FromPdaFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\FromPda
			this.RelativeObjectPath = this.RootFolderFtp(relativeDb);  //	 \mINV\Inventor\2018\1\1\<InventorCode>
			//this.FromPhotoPath = this.RootFolderFtp(this.FromPhotoFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\Photo
			//this.FromSignaturePath = this.RootFolderFtp(this.FromSignatureFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\Signature
			this.FromPdaProcessPath = Path.Combine(this.FromPdaPath, FtpFolderName.Process);     //  \mINV\Inventor\2018\1\1\<InventorCode>\FromPda\Process
		}

		private string RootFolderFtp(string subFolder = "")
		{
			string rootFolderFtp = PropertiesSettings.RootFolderFtp;
			if (string.IsNullOrWhiteSpace(subFolder) == true)
			{
				return rootFolderFtp;
			}
			else
			{
				rootFolderFtp = Path.Combine(rootFolderFtp, subFolder);
				return rootFolderFtp;
			}
		}

		public void ClearProperty()
		{
			this.HostRootFolder = "";
			this.ToPdaFolder = "";
			this.FromPdaFolder = "";
			this.FromPhotoFolder = "";
			this.FromSignatureFolder = "";
			this.RelativeObjectPath = "";
			this.ToPdaPath = "";
			this.ProfilePath = "";
			this.FromPdaPath = "";
			this.FromPhotoPath = "";
			this.FromSignaturePath = "";
			this.FromPdaProcessPath = "";
			//this.Host = "";
			//this.User = "";
			//this.Password = "";
			this.TargetInDataFolder = "";
			this.TargetInDataZipFolder = "";
			this.CurrentDomainObject = "";
		}

		


		public void DeleteFile(string folderPath, string fileName)
		{
			if (string.IsNullOrWhiteSpace(folderPath) == true)
				return;
			if (string.IsNullOrWhiteSpace(fileName) == true)
				return;
			string filePath = Path.Combine(folderPath, fileName)	;
			if (File.Exists(filePath) == false)
				return;
			try
			{
				File.Delete(filePath);
			}
			catch { }

		}

		private string BuildLongFtpPath(ProfileFile profileFileModel) 
		{
			return BuildLongCodesPath(profileFileModel.DomainObject, profileFileModel.CustomerCode, profileFileModel.BranchCode,
				profileFileModel.InventorDBPath);
		}

	

		private string BuildLongCodesPath(string domainObject, string customerCode = "", string branchCode = "", string inventorDBPath = "")
		{
			if (string.IsNullOrWhiteSpace(domainObject) == true) return String.Empty;

			if (domainObject == PropertiesSettings.FolderCustomer)
			{
				string customerPrat = PropertiesSettings.FolderCustomer.Trim('\\') + @"\" + customerCode;
				return customerPrat;
			}

			if (domainObject == PropertiesSettings.FolderBranch)
			{
				string customerPart = PropertiesSettings.FolderCustomer.Trim('\\') + @"\" + customerCode;
				string branchPart = PropertiesSettings.FolderBranch.Trim('\\') + @"\" + branchCode;
				return customerPart + @"\" + branchPart;
			}


			if (domainObject == PropertiesSettings.FolderInventor)
			{
				string customerPart = PropertiesSettings.FolderCustomer.Trim('\\') + @"\" + customerCode;
				string branchPart = PropertiesSettings.FolderBranch.Trim('\\') + @"\" + branchCode;
				string inventorPart = PropertiesSettings.FolderInventor.Trim('\\') + @"\" + inventorDBPath;
				return customerPart + @"\" + branchPart + @"\" + inventorPart;
			}

			return String.Empty;
		}


		private string BuildLongFtpPathWithoutObjectCode(ProfileFile profileFileModel)
		{
			return BuildLongCodesPathWithoutObjectCode(profileFileModel.DomainObject, profileFileModel.CustomerCode, profileFileModel.BranchCode,
				profileFileModel.InventorDBPath);
		}
		private string BuildLongCodesPathWithoutObjectCode(string domainObject, string customerCode = "", string branchCode = "", string inventorDBPath = "")
		{
			if (string.IsNullOrWhiteSpace(domainObject) == true) return String.Empty;

			if (domainObject == PropertiesSettings.FolderCustomer)
			{
				string customerPrat = PropertiesSettings.FolderCustomer.Trim('\\');
				return customerPrat;
			}

			if (domainObject == PropertiesSettings.FolderBranch)
			{
				string customerPart = PropertiesSettings.FolderCustomer.Trim('\\') + @"\" + customerCode;
				string branchPart = PropertiesSettings.FolderBranch.Trim('\\');
				return customerPart + @"\" + branchPart;
			}


			if (domainObject == PropertiesSettings.FolderInventor)
			{
				string customerPart = PropertiesSettings.FolderCustomer.Trim('\\') + @"\" + customerCode;
				string branchPart = PropertiesSettings.FolderBranch.Trim('\\') + @"\" + branchCode;
				string inventorPart = PropertiesSettings.FolderInventor.Trim('\\') ;
				return customerPart + @"\" + branchPart + @"\" + inventorPart;
			}

			return String.Empty;
		}


		//rootFonderOnFtp = "mINV" 
		//string rootFonderOnFtp = this._customerRepository.Connection.RootFolderFtp(); //mINV
		public void ProfileFileSendFromLocalPathToFtp(ProfileFile profileFileModel, 
			string fromLocalPath, string fileName = "profile.xml")      //mINV
		{
			if (profileFileModel == null)
			{
				//_logger.Error("InventorProfileCreate ERROR : Inventor is Null  ");
				return;
			}

			string messageCreateFolder = "";
			try
			{
				string folderForInventorObject = this.BuildLongFtpPath(profileFileModel).Trim(@"\".ToCharArray()) + @"\Profile";
				//rootFonderOnFtp = "mINV" 

				string ftpFolder = this.CreatePathOnFtp(this.HostRootFolder, folderForInventorObject, ref messageCreateFolder);

				this.CopyFileToFtp(fromLocalPath, ftpFolder, fileName);
			}
			catch (Exception exc)
			{
				//_logger.ErrorException("In process create Folder on FTP, happens ERROR : ", exc);
				return;
			}


		}


		//rootFonderOnFtp = "mINV" 
		//string rootFonderOnFtp = this._customerRepository.Connection.RootFolderFtp(); //mINV
		public ProfileFile ProfileFileSendToFtp(ProfileFile profileFileModel, bool createPathOnFtp = false, string fileName = "profile.xml")      //mINV
		{
			if (profileFileModel == null)
			{
				return new ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.ProfileFileIsNull) { Error = $"ERROR SaveOrUpdatOnFtpPrivate : ProfileFile is null" };
			}

			string messageCreateFolder = "";
			try
			{
				//string folderForInventorObject = this.BuildLongFtpPath(profileFileModel).Trim(@"\".ToCharArray()) + @"\Profile";
				//rootFonderOnFtp = "mINV" 
				//string ftpFolder = this.CreatePathOnFtp(this.HostRootFolder, folderForInventorObject, ref messageCreateFolder);
				string longFtpPath = this.BuildLongFtpPathWithoutObjectCode(profileFileModel);
				string fonderOnFtp = this.HostRootFolder + @"\" + longFtpPath.Trim(@"\".ToCharArray());
				if (createPathOnFtp == true)
				{
					//string ftpFolder = this.CreatePathOnFtp(objectFonderOnFtp, "Profile", ref messageCreateFolder);
					string ftpFolder = this.CreatePathOnFtp(fonderOnFtp, $"{profileFileModel.CustomerCode}" + @"\Profile", ref messageCreateFolder);
				}

				string longFtpPath1 = this.BuildLongFtpPath(profileFileModel);
				string objectFonderOnFtp = this.HostRootFolder + @"\" + longFtpPath1.Trim(@"\".ToCharArray());
				this.CopyTextToFtpAsFile(profileFileModel.ProfileXml, objectFonderOnFtp + @"\Profile", fileName);
				return profileFileModel;
			}
			catch (Exception exc)
			{
				//_logger.ErrorException("In process create Folder on FTP, happens ERROR : ", exc);
				profileFileModel.Successful = SuccessfulEnum.NotSuccessful;
				profileFileModel.ErrorCode = CommandErrorCodeEnum.CommandResultWithException;
				profileFileModel.ResultCode = CommandResultCodeEnum.Error;
				profileFileModel.Error = exc.Message;
				return null;
			}


		}


		//  Create folder on ftp
		//mINV\Customer\<CustomerCode>\Branch\BranchCode>\Inventor\<InventorCode>\Profile\<profile>
		//rootFonderOnFtp = "mINV" 
		public string CreatePathOnFtp(string rootFonderOnFtp, string objectFolder, ref string messageCreateFolder)
		{
			//string host = _userSettingsManager.HostGet().Trim('\\');
			bool enableSsl = false;
			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			FtpClient client = new FtpClient(host, user, password, enableSsl);
			string folderResult = client.CreatePathOnFtp(host, rootFonderOnFtp, objectFolder, ref messageCreateFolder);
			return folderResult;

		}

		public void CopyProfileFileFromFtpToMemoryStream(string fromFtpFonder, ref string profileText, ref string messageCreateFolder)
		{
			profileText = "";
			string fileName = "profile.xml";
   			bool enableSsl = false;

			string host = this.Host;
			string user = this.User;
			string password = this.Password;
			
			FtpClient client = new FtpClient(host, user, password, enableSsl);
			client.uri = host;

			try
			{
				string path = @"mINV\" + fromFtpFonder.Trim('\\') + @"\profile";
				FtpStatusCode statusCode = client.ChangeWorkingDirectoryReturnStatusCode(path);
				if (statusCode == FtpStatusCode.PathnameCreated)
				{
					List<FileDirectoryInfo> listInfoDirectory = client.GetDirectoryInformation(path, host, user, password);
					if (listInfoDirectory.Count < 1)   		return;	  

					string fromFtpPathProfile = path;
					try
					{  
	  					fromFtpPathProfile = path.TrimEnd(@"\".ToCharArray()) + @"\" + fileName;         //  на ftp	  (from)

						using (MemoryStream ms = new MemoryStream())
						{
							StreamWriter sw = new StreamWriter(ms, ProviderEncoding);
							FtpStatusCode result = client.SaveFileFromFtpToStreamWriter(fileName, sw, ProviderEncoding);
							sw.Flush();
							profileText = this.ProviderEncoding.GetString(ms.ToArray());
							//_logger.Info("Copy profile.xml from ftpServer[" + fromFtpPathProfile + "]");
							//_logger.Info("with Result [" + result.ToString() + "]");
							messageCreateFolder = messageCreateFolder + "Copy profile.xml from ftpServer[" + fromFtpPathProfile + "]"
								+ " with Result [" + result.ToString() + "]";

						}
					}
					catch (Exception exc)
					{
						string message = String.Format("GetFromFtpCommandExecuted (File.Move to unsurePath) {0} => {1}", fromFtpPathProfile);
						messageCreateFolder = messageCreateFolder + message;
						//_logger.ErrorException(message, exc);
					}
				}
			}
			catch (Exception exc)
			{
				//_logger.ErrorException("GetFromFtpCommandExecuted", exc);
				messageCreateFolder = messageCreateFolder + exc.Message;
			}
		}


		 //1
		public List<string> GetInventorSubFolderListFromFtp(string customerCode, string branchCode)
		{
			string path = $"mINV/Customer/{customerCode}/Branch/{branchCode}/Inventor";
			List<string> sortFolderY = new List<string>();
			List<FromFtpItem> listItem = new List<FromFtpItem>();

			try { 
			bool enableSsl = false;

			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			FtpClient client = new FtpClient(host, user, password, enableSsl);

			FtpStatusCode statusCode = client.ChangeWorkingDirectoryReturnStatusCode(path);
			if (statusCode == FtpStatusCode.PathnameCreated)
			{
				List<FileDirectoryInfo> listInfoDirectory = client.GetDirectoryInformation(path, host, user, password);
				if (listInfoDirectory.Count > 0)
				{
					foreach (FileDirectoryInfo fi in listInfoDirectory)
					{
						if (fi == null) continue;
						if (string.IsNullOrWhiteSpace(fi.Name) == true) continue;
						if (fi.IsDirectory == true)
						{
							string folderName = fi.Name;
							sortFolderY.Add(folderName);
						}
					}
				}
			}

			List<string> returnSubFolderM = new List<string>();
			foreach (string folder in sortFolderY.OrderByDescending(x => x))
			{
				List<string> list = GetSubFolder(path, folder);
				foreach (string li in list)
				{
					returnSubFolderM.Add(li);
				}
			}

			List<string> returnSubFolderD = new List<string>();
			foreach (string folder in returnSubFolderM.OrderByDescending(x => x))
			{
				List<string> list = GetSubFolder(path, folder);
				foreach (string li in list)
				{
					returnSubFolderD.Add(li);
				}
			}

			List<string> returnSubFolderCode = new List<string>();
			foreach (string folder in returnSubFolderD.OrderByDescending(x => x))
			{
				List<string> list = GetSubFolder(path, folder);
				foreach (string li in list)
				{
					returnSubFolderCode.Add(li);
				}
			}

			return returnSubFolderCode;
			}
			catch (Exception exc)
			{
				//_logger.ErrorException("GetFromFtpCommandExecuted", exc);
				//messageCreateFolder = messageCreateFolder + exc.Message;
				return new List<string>();
			}
		}

		//2 
		public List<string> GetSubFolder(string path, string folder)
		{
			List<string> returnSubFolders = new List<string>();
			List<string> subFolders = new List<string>();

			//List<FromFtpItem> listItem = new List<FromFtpItem>();
			path = path + @"\" + folder;

			//string fileName = "profile.xml";
			bool enableSsl = false;

			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			FtpClient client = new FtpClient(host, user, password, enableSsl);
			FtpStatusCode statusCode = client.ChangeWorkingDirectoryReturnStatusCode(path);

			if (statusCode == FtpStatusCode.PathnameCreated)
			{
				List<FileDirectoryInfo> listInfoDirectory = client.GetDirectoryInformation(path, host, user, password);
				if (listInfoDirectory.Count > 0)
				{
					foreach (FileDirectoryInfo fi in listInfoDirectory)
					{
						if (fi == null) continue;
						if (string.IsNullOrWhiteSpace(fi.Name) == true) continue;
						if (fi.IsDirectory == true)
						{
							string folderName = fi.Name;
							subFolders.Add(folderName);
						}
					}
				}
			}


			foreach (string sub in subFolders)
			{
				returnSubFolders.Add(folder + @"\" + sub);
			}
			return returnSubFolders;
		}


		public List<string> GetCustomerCodeListFromFtp()
		{
			string path = @"mINV/Customer";
			//string folder = "Customer";

			List<string> returnSubFolders = new List<string>();
			List<string> subFolders = new List<string>();

			//List<FromFtpItem> listItem = new List<FromFtpItem>();
			//path = path + @"\" + folder;

			//string fileName = "profile.xml";
			bool enableSsl = false;

			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			FtpClient client = new FtpClient(host, user, password, enableSsl);
			FtpStatusCode statusCode = client.ChangeWorkingDirectoryReturnStatusCode(path);

			if (statusCode == FtpStatusCode.PathnameCreated)
			{
				List<FileDirectoryInfo> listInfoDirectory = client.GetDirectoryInformation(path, host, user, password);
				if (listInfoDirectory.Count > 0)
				{
					foreach (FileDirectoryInfo fi in listInfoDirectory)
					{
						if (fi == null) continue;
						if (string.IsNullOrWhiteSpace(fi.Name) == true) continue;
						if (fi.IsDirectory == true)
						{
							string folderName = fi.Name;
							subFolders.Add(folderName);
						}
					}
				}
			}


			foreach (string sub in subFolders)
			{
				returnSubFolders.Add(sub);
			}
			return returnSubFolders;
		}


		public List<string> GetBranchCodeListFromFtp(string customerCode)
		{
			string path = $"mINV/Customer/{customerCode}/Branch";
			//string folder = "Customer";

			//mINV / Customer / dn6x / Branch

			List<string> returnSubFolders = new List<string>();
			List<string> subFolders = new List<string>();

			//List<FromFtpItem> listItem = new List<FromFtpItem>();
			//path = path + @"\" + folder;

			//string fileName = "profile.xml";
			bool enableSsl = false;

			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			FtpClient client = new FtpClient(host, user, password, enableSsl);
			FtpStatusCode statusCode = client.ChangeWorkingDirectoryReturnStatusCode(path);

			if (statusCode == FtpStatusCode.PathnameCreated)
			{
				List<FileDirectoryInfo> listInfoDirectory = client.GetDirectoryInformation(path, host, user, password);
				if (listInfoDirectory.Count > 0)
				{
					foreach (FileDirectoryInfo fi in listInfoDirectory)
					{
						if (fi == null) continue;
						if (string.IsNullOrWhiteSpace(fi.Name) == true) continue;
						if (fi.IsDirectory == true)
						{
							string folderName = fi.Name;
							subFolders.Add(folderName);
						}
					}
				}
			}


			foreach (string sub in subFolders)
			{
				returnSubFolders.Add(sub);
			}
			return returnSubFolders;
		}


	

		public void CopyFileToFtp(string fromLocalFolder, string toFtpFolder, string fileName)
		{
			//string host = _userSettingsManager.HostGet().Trim('\\');
			bool enableSsl = false;
			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			try
			{

				FtpClient client = new FtpClient(host, user, password, enableSsl);
				client.uri = host;
				string result3 = client.ChangeWorkingDirectory(toFtpFolder);

				string toFTPFilePath = fileName;
				string fromLocalFilePath = fromLocalFolder + @"\" + fileName;

				string result = client.SaveFileToFtp(fromLocalFilePath, toFTPFilePath);
				//_logger.Info("Save file [" + fromLocalFilePath + "]" + " to ftp [" + toFTPFilePath + "]");
				//_logger.Info("with Result [" + result + "]");

			}
			catch (Exception exc)
			{
				string message = String.Format("CopyFileFromFtp ");
				//_logger.ErrorException(message, exc);
			}

		}


		public void CopyMemoryStreamToFtp(MemoryStream ms, string toFtpFolder, string fileName)
		{
			//string host = _userSettingsManager.HostGet().Trim('\\');
			bool enableSsl = false;
			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			try
			{

				FtpClient client = new FtpClient(host, user, password, enableSsl);
				client.uri = host;
				string result3 = client.ChangeWorkingDirectory(toFtpFolder);

				string toFTPFilePath = fileName;
				//string fromLocalFilePath = fromLocalFolder + @"\" + fileName;

				string result = client.SaveMemoryStreamToFtp(ms, toFTPFilePath);
				//_logger.Info("Save file [" + fromLocalFilePath + "]" + " to ftp [" + toFTPFilePath + "]");
				//_logger.Info("with Result [" + result + "]");

			}
			catch (Exception exc)
			{
				string message = String.Format("CopyFileFromFtp ");
				//_logger.ErrorException(message, exc);
			}

		}


		public void CopyTextToFtpAsFile(string text, string toFtpFolder, string fileName)
		{
			//string host = _userSettingsManager.HostGet().Trim('\\');
			bool enableSsl = false;
			string host = this.Host;
			string user = this.User;
			string password = this.Password;

			try
			{

				FtpClient client = new FtpClient(host, user, password, enableSsl);
				client.uri = host;
				string result3 = client.ChangeWorkingDirectory(toFtpFolder);

				string toFTPFilePath = fileName;
				//string fromLocalFilePath = fromLocalFolder + @"\" + fileName;

				string result = client.SaveTextToFtpAsFile(text, toFTPFilePath);
				//_logger.Info("Save file [" + fromLocalFilePath + "]" + " to ftp [" + toFTPFilePath + "]");
				//_logger.Info("with Result [" + result + "]");

			}
			catch (Exception exc)
			{
				string message = String.Format("CopyFileFromFtp ");
				//_logger.ErrorException(message, exc);
			}

		}
	}
}
