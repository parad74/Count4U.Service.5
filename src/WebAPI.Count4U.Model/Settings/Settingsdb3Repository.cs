using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Count4U.Common.Constants;
using Count4U.Model.Audit;
using Count4U.Model.Interface;
using Count4U.Model.Interface.Audit;
using Monitor.Service.Urls;
using Monitor.Service.Model;
using Monitor.Service;


namespace Count4U.Model.Common
{
	public interface ISettingsdb3Repository
	{
		string HostRootFolder { get; set; }
		string ToPdaFolder { get; set; }
		string FromPdaFolder { get; set; }
		string FromPhotoFolder { get; set; }
		string FromSignatureFolder { get; set; }

		string RelativeObjectPath { get; set; }
		string ToPdaPath { get; set; }
		string FromPdaPath { get; set; }
		string FromPhotoPath { get; set; }
		string FromSignaturePath { get; set; }
		string FromPdaProcessPath { get; set; }
		string Host { get; set; }
		string User { get; set; }
		string Password { get; set; }
	 	string TargetInDataFolder	 { get; set; }
		List<FileInfo> FilesInDataFolder	 { get; set; }
		string TargetInDataZipFolder	{ get; set; }
		void InitProperty(string inventorCode);
	 	string GetPathForProcessBackup(string rootFrom, string fileName);
		string GetPathForInDataBackup(string inventorCode, string fileName);
		string GetPathForInDataZip(string fileName);
		void UnZip(string fromZipFilePath);
		void DeleteFileFromProcess(string fileName);
 	}
	public class Settingsdb3Repository : ISettingsdb3Repository {
		public string HostRootFolder { get; set; }
		public string ToPdaFolder { get; set; }
		public string FromPdaFolder { get; set; }
		public string FromPhotoFolder { get; set; }
		public string FromSignatureFolder { get; set; }
		public string RelativeObjectPath { get; set; }
		public string ToPdaPath { get; set; }
		public string FromPdaPath { get; set; }
		public string FromPhotoPath { get; set; }
		public string FromSignaturePath { get; set; }
		public string FromPdaProcessPath { get; set; }
		public string Host { get; set; }
		public string User { get; set; }
		public string Password { get; set; }

		public string TargetInDataFolder	 { get; set; }
		public List<FileInfo> FilesInDataFolder	 { get; set; }
		public string TargetInDataZipFolder	{ get; set; }


		private readonly IContextCBIRepository _contextCBIRepository;
		private readonly IDBSettings _dbSettings ;
		private readonly 	IZip 	_zip;
		public Settingsdb3Repository(
			IContextCBIRepository contextCBIRepository
			, IConnectionDB connection
			, IDBSettings dbSettings
			, IZip zip
		) 
		{
			this._contextCBIRepository = contextCBIRepository;
			this._dbSettings = dbSettings;
			this._zip = zip ;
		}

		public void InitProperty(string inventorCode/*, bool isChecked, string adapterName*/) {
			//if (base.State == null)
			//	base.State = state;
			//if (adapterName == ImportAdapterName.ImportPdaNativSqliteAdapter
			//	|| adapterName == ImportAdapterName.ImportPdaNativPlusSqliteAdapter
			//	|| adapterName == ImportAdapterName.ImportPdaNativPlusMISSqliteAdapter) {
			//	this._copyPhoto = true;
			//	this._copySignature = true;
			//}
			//else {
			//	this._copyPhoto = false;
			//	this._copySignature = false;
			//}
			//string inventorCode
			this.ClearProperty();
			Inventor currentInventor = this._contextCBIRepository.GetInventorByCode(inventorCode);
			if (currentInventor == null) return;
			string relativeDb = this._contextCBIRepository.BuildLongCodesPath(currentInventor).Trim('\\');
			this.ToPdaFolder = Path.Combine(relativeDb, FtpFolderName.ToPda);      //Inventor\2018\1\1\<InventorCode>\ToPda
			this.FromPdaFolder = Path.Combine(relativeDb, FtpFolderName.FromPda);      //Inventor\2018\1\1\<InventorCode>\FromPda
			this.FromPhotoFolder = Path.Combine(relativeDb, FtpFolderName.Photo);      //Inventor\2018\1\1\<InventorCode>\Photo
			this.FromSignatureFolder = Path.Combine(relativeDb, FtpFolderName.Signature);      //Inventor\2018\1\1\<InventorCode>\Signature

			//FTP
			this.HostRootFolder = this.RootFolderFtp(); //mINV 
			this.ToPdaPath = this.RootFolderFtp(this.ToPdaFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\ToPda
			this.FromPdaPath = this.RootFolderFtp(this.FromPdaFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\FromPda
			this.RelativeObjectPath = this.RootFolderFtp(relativeDb);  //	 \mINV\Inventor\2018\1\1\<InventorCode>
			this.FromPhotoPath = this.RootFolderFtp(this.FromPhotoFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\Photo
			this.FromSignaturePath = this.RootFolderFtp(this.FromSignatureFolder); //	 \mINV\Inventor\2018\1\1\<InventorCode>\Signature
			this.FromPdaProcessPath = Path.Combine(this.FromPdaPath, FtpFolderName.Process);     //  \mINV\Inventor\2018\1\1\<InventorCode>\FromPda\Process

			//InData
			string importPDAFolder = this._dbSettings.ImportFolderPath();//inData в папке каждого инвентора
			this.TargetInDataFolder =  Path.Combine(importPDAFolder,"Inventor", inventorCode, "inData");
			if (Directory.Exists(this.TargetInDataFolder) == false)
				Directory.CreateDirectory(this.TargetInDataFolder);
			if (Directory.Exists(this.TargetInDataFolder) == true)
			{
				var dir = new DirectoryInfo(this.TargetInDataFolder);
				this.FilesInDataFolder = dir.GetFiles().ToList();
			}

			this.TargetInDataZipFolder = Path.Combine(importPDAFolder, "Inventor", inventorCode, @"inData\zip");
			if (Directory.Exists(this.TargetInDataZipFolder) == false)
				Directory.CreateDirectory(this.TargetInDataZipFolder);

			//this._folderItems.Add(new ItemFindViewModel() { Value = FtpFolderName.Process, Text = FtpFolderName.Process });
			//this._folderItemSelected = this._folderItems.FirstOrDefault();
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
			this.FromPdaPath = "";
			this.FromPhotoPath = "";
			this.FromSignaturePath = "";
			this.FromPdaProcessPath = "";
			this.Host = "";
			this.User = "";
			this.Password = "";
			this.TargetInDataFolder = "";
			this.TargetInDataZipFolder = "";
		}

//For PDA spatial folders for work “Process”.
//Format FileName from Count4U to PDA – <BackupCode>^ <YYYY_MM_DD_hh_mm_ss>.zip
//Data files form PDA to Count4U – save in FromPDA \Process. File name  start from <DeviceCode>^<BackupCode>^ <YYYY_MM_DD_hh_mm_ss>^ , where <BackupCode> the same <BackupCode> that incoming in FileName  from Count4U,  <YYYY_MM_DD_hh_mm_ss> time save on  ftp
//Where <BackupCode> - is code like '2018-157~f'
 //Where YYYY_MM_DD_hh_mm_ss is datetime like 2018_02_08_23_12_15
 //separation sign between part  of FileName is ^

			//1 step Copy file from ftp/Process to ftp/backup
		public string GetPathForProcessBackup(string rootFrom, string fileName)
		{
			try
			{
				string backupFolder = GetBackupFolder(fileName);	//из зашифрованного имени

				//==================   create backup folder on  ftp
				string fromPdaThreadCodeCopyFolder = CreateBackupFolderOnFrom(rootFrom, this.FromPdaPath, backupFolder);
				string fromPdaThreadCodeCopyPath = Path.Combine(fromPdaThreadCodeCopyFolder, fileName);
				return 	fromPdaThreadCodeCopyPath;
				//=================== 	copy   FROM Process (on ftp) TO backup folder	(on ftp)
				// Copy file on ftp
				//string fromFtpPathFile = this.FromPdaProcessPath + @"\" + fileName;          //  на ftp	  (process)	  from
				//File.Copy(fromFtpPathFile, fromPdaThreadCodeCopyFolder, true);
 			}
			catch (Exception exc)
			{
				//string message = String.Format("GetFromFtpCommandExecuted {0} ", fileName);
				//this.LogImport.Add(MessageTypeEnum.Error, message);
				//_logger.ErrorException(message, exc);
				return "";
			}
		}
		
		//2 step Copy file from ftp/Process to inData/<backup>
		public string GetPathForInDataBackup(string inventorCode, string fileName)
		{
			try
			{
				string backupFolder = GetBackupFolder(fileName);	//из зашифрованного имени

				//=================  create backup folder on count4U
				string targetInDataBackupFolder = CreateBackupFolderOnCount4U(this._dbSettings.ImportFolderPath(), inventorCode, backupFolder);
				string targetInDataBackupPath = Path.Combine(targetInDataBackupFolder, fileName);
				return 	targetInDataBackupPath;
				//=================== 	copy   FROM Process (on ftp) TO backup folder	(on ftp)
				// Copy file on ftp
				//string fromFtpPathFile = this.FromPdaProcessPath + @"\" + fileName;          //  на ftp	  (process)	  from
				//File.Copy(fromFtpPathFile, fromPdaThreadCodeCopyFolder, true);
 			}
			catch (Exception exc)
			{
				//string message = String.Format("GetFromFtpCommandExecuted {0} ", fileName);
				//this.LogImport.Add(MessageTypeEnum.Error, message);
				//_logger.ErrorException(message, exc);
				return "";
			}
		}

		//Step3 get Path to inData/zip 
		public string GetPathForInDataZip(string fileName)
		{
			try
			{
				string inDataZipPathFile = Path.Combine(this.TargetInDataZipFolder, fileName); 
				return inDataZipPathFile;
				//======================      TO inData\zip (Count4U)
				//string fromFtpPathFile = Path.Combine(this.FromPdaProcessPath, fileName);          //  на ftp	  (process)	  from
				//string targetInDataZipFilePath = Path.Combine(this.TargetInDataZipFolder,fileName);		 //to indata/zip
				//return targetInDataZipFilePath;
				//File.Copy(fromFtpPathFile, targetInDataZipFilePath, true);
			}
			catch (Exception exc)
			{
				//string message = String.Format("GetFromFtpCommandExecuted {0} ", fileName);
				//this.LogImport.Add(MessageTypeEnum.Error, message);
				//_logger.ErrorException(message, exc);
				return "";
			}
		}

		public void UnZip(string fromZipFilePath)
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			try
			{
				 //====================== unzip  FROM inData\zip (Count4U)  TO   inData (Count4U)
				this._zip.ReadDb3FromZipFile(fromZipFilePath, this.TargetInDataFolder);
			}
			catch (Exception exc)
			{
				//string message = String.Format("GetFromFtpCommandExecuted {0} ", fileName);
				//this.LogImport.Add(MessageTypeEnum.Error, message);
				//_logger.ErrorException(message, exc);
			}
		}

		public void DeleteFileFromProcess(string fileName)
		{
		#if DEBUG
				//this.ClearFolderOnFtp(FromPdaProcessPath);		//TEST
				if (this.FromPdaProcessPath.Contains(FtpFolderName.Process) == true)
				{
					this.DeleteFile(this.FromPdaProcessPath, fileName);    //TEST
				}
#else
											//очистить ftp folder  FromPda\Process 
											if (FromPdaProcessPath.Contains(FtpFolderName.Process) == true)
											{
			  									this.DeleteFile(this.FromPdaProcessPath, fileName);
											}
#endif
		}

	

//		public void GetFromFtp(string rootFrom, string inventorCode, string fileName)
//		{
//			try
//			{
//				string backupFolder = GetBackupFolder(fileName);	//из зашифрованного имени см Assembla

//				//==================   create backup folder on  ftp
//				string fromPdaThreadCodeCopyFolder = CreateBackupFolderOnFrom(rootFrom, this.FromPdaPath, backupFolder);

//				//=================== 	copy   FROM Process (on ftp) TO backup folder	(on ftp)
//				// Copy file on ftp
//				string fromFtpPathFile = this.FromPdaProcessPath + @"\" + fileName;          //  на ftp	  (process)	  from
//				File.Copy(fromFtpPathFile, fromPdaThreadCodeCopyFolder, true);

//				//=================  create backup folder on count4U
//				string targetInDataBackupFolder = CreateBackupFolderOnCount4U(this._dbSettings.ImportFolderPath(), inventorCode, backupFolder);

//				//====================== copy FROM Process (ftp)                TO inData\zip (Count4U)
//				string targetInDataZipFilePath = this.TargetInDataZipFolder + @"\" + fileName;
//				string fromFtpPathFile1 = this.FromPdaProcessPath + @"\" + fileName;          //  на ftp	  (process)	  from
//				File.Copy(fromFtpPathFile1, targetInDataZipFilePath, true);

//				//====================== unzip  FROM inData\zip (Count4U)  TO   inData (Count4U)
//				this._zip.ReadDb3FromZipFile(targetInDataZipFilePath, this.TargetInDataFolder);

//				//====================== copy FROM inData (Count4U) TO  Count4U BackupFolder (Count4U)
//				File.Copy(targetInDataZipFilePath, targetInDataBackupFolder + @"\" + fileName, true);

//				//очистить ftp folder  FromPda\Process 
//#if DEBUG
//				//this.ClearFolderOnFtp(FromPdaProcessPath);		//TEST
//				if (this.FromPdaProcessPath.Contains(FtpFolderName.Process) == true)
//				{
//					this.DeleteFile(this.FromPdaProcessPath, fileName);    //TEST

//				}
//#else
//											//очистить ftp folder  FromPda\Process 
//											if (FromPdaProcessPath.Contains(this.FtpFolderName.Process) == true)
//											{
//			  									this.DeleteFile(this.FromPdaProcessPath, fileName);
//											}
//#endif

//			}
//			catch (Exception exc)
//			{
//				//string message = String.Format("GetFromFtpCommandExecuted {0} ", fileName);
//				//this.LogImport.Add(MessageTypeEnum.Error, message);
//				//_logger.ErrorException(message, exc);
//			}
//		}

		//==================   create backup folder on  ftp
		private static string CreateBackupFolderOnFrom(string root,  string fromPdaPath, string backupFolder)
		{
			if (string.IsNullOrWhiteSpace(root) == true)
				return "";
			if (string.IsNullOrWhiteSpace(fromPdaPath) == true)
				return"";
			if (string.IsNullOrWhiteSpace(backupFolder) == true)
				return"";

			string fromPdaThreadCodeCopyFolder = Path.Combine(root, fromPdaPath, backupFolder);
			if (Directory.Exists(fromPdaThreadCodeCopyFolder) == false)
				Directory.CreateDirectory(fromPdaThreadCodeCopyFolder);
			return fromPdaThreadCodeCopyFolder;
		}

		//=================  create backup folder on count4U
		private static string CreateBackupFolderOnCount4U(string importPDAFolder, string inventorCode, string backupFolder)
		{
			string targetInDataBackupFolder = Path.Combine(importPDAFolder, "Inventor", inventorCode, "inData", backupFolder);
			if (Directory.Exists(targetInDataBackupFolder) == false)
				Directory.CreateDirectory(targetInDataBackupFolder);
			return targetInDataBackupFolder;
		}
		private static string GetBackupFolder(string fileName)
		{
			string backupFolder = @"backupUnsure";
			string[] fileNamePart = fileName.Split('^');
			if (fileNamePart.Length >= 2) {
				if (string.IsNullOrWhiteSpace(fileNamePart[1]) == false) {
					backupFolder = fileNamePart[1].Trim();
					if (fileNamePart.Length >= 3) {
						if (string.IsNullOrWhiteSpace(fileNamePart[2]) == false) {
							if (fileNamePart[2].Trim() != ".zip") {
								string folderName = fileNamePart[2].Trim();
								if (folderName.Length > 10) {
									folderName = folderName.Substring(0, 10);
								}
								backupFolder = Path.Combine(fileNamePart[1].Trim(), folderName.Trim());
							}
							else {
								string folderName = fileNamePart[1].Trim();
								if (folderName.Length > 10) {
									folderName = folderName.Substring(0, 10);
								}
								backupFolder = Path.Combine(fileNamePart[0].Trim() ,folderName.Trim());
							}
						}
					}
				}
			}
			return backupFolder;
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

	}
}
