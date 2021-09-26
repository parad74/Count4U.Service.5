using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Count4U.Model.SelectionParams;
using Monitor.Model.ServiceContract.Interface;
using System.Data.Common;
using System.IO;
using System.Data;
using Monitor.Service.Model;
using Monitor.Service.Urls;
using Count4U.Model.Common;
using WebAPI.Filter.Sqlite.CodeFirst;
using System.Xml.Serialization;
using System.Text;
using System.Security.Claims;
using Monitor.Profile.Sqlite.CodeFirst.ExportImport;
using CommonServiceLocator;

namespace WebAPI.Monitor.Sqlite.CodeFirst.Controllers
{
	[ApiController]
	//[Route("api/[controller]")]
//[ServiceFilter(typeof(ControllerFtpServiceFilter))]
	public class ProfileFileController : ControllerBase
	{
		private readonly ILogger<ProfileFileController> _logger;
		private readonly IProfileFileRepository _profileFileRepository;
		private readonly IJwtService _jwtService;
		//private readonly IUnityContainer _container;
		private readonly IServiceLocator _serviceLocator;
		private readonly ISettingsFtpRepository _settingsFtpRepository;


		public ProfileFileController(
			ILoggerFactory loggerFactory,
			ISettingsFtpRepository settingsFtpRepository,
			IProfileFileRepository profileFileRepository
			//, ICommandResultRepository commandResultRepository
			, IJwtService jwtService
			,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<ProfileFileController>();
			this._settingsFtpRepository = settingsFtpRepository ??
						   throw new ArgumentNullException(nameof(settingsFtpRepository));
			this._profileFileRepository = profileFileRepository ??
						   throw new ArgumentNullException(nameof(profileFileRepository));
			this._jwtService = jwtService ??
						   throw new ArgumentNullException(nameof(jwtService));
			this._serviceLocator = serviceLocator ??
						   throw new ArgumentNullException(nameof(serviceLocator));
			//_serviceLocator = serviceLocator;
			//_container = container;
		}


		[HttpPost(WebApiProfileFile.AddToQueueUpdateFtpAndDbRun)]
		public async Task<ProfileFile[]> AddToQueueUpdateFtpAndDbRun([FromBody] ProfileFile profileFile)  //command.AdapterName
		{
			try
			{
				ClaimsPrincipal authenticatedUser = this._jwtService.GetClaimsPrincipalFromToken(this.HttpContext.Request);
				if (authenticatedUser != null) profileFile.User = authenticatedUser.Identity.Name;
				IProfileHandler profileHandler = this._serviceLocator.GetInstance<IProfileHandler>();
				return await profileHandler.AddToQueueUpdateFtpAndDbRun(profileFile);
			}
			catch (Exception ex)
			{
				return new ProfileFile[] { new ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.Error, CommandErrorCodeEnum.CommandResultWithException) { Error = $"ERROR AddToQueueUpdateFtpAndDbRun : {ex.Message}" } };
			}
		}

		[HttpGet(WebApiProfileFile.GetProfileFiles)]
		public ActionResult<ProfileFiles> GetProfileFiles()
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetProfileFiles();
			return profileFiles;
		}

		[HttpPost(WebApiProfileFile.GetProfileFilesWithSelectParam)]
		public ActionResult<ProfileFiles> GetProfileFilesWithSelectParam([FromBody]SelectParams selectParams)
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetProfileFiles(selectParams);
			return profileFiles;
		}

		[HttpGet(WebApiProfileFile.GetCustomersProfileFiles)]
		public ActionResult<ProfileFiles> GetCustomersProfileFiles()
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetCustomersProfileFiles();
			return profileFiles;
		}

		[HttpGet(WebApiProfileFile.GetBranchesProfileFiles)]
		public ActionResult<ProfileFiles> GetBranchesProfileFiles()
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetBranchesProfileFiles();
			return profileFiles;
		}

		[HttpPost(WebApiProfileFile.GetBranchesByCustomerCode)]
		public ActionResult<ProfileFiles> GetBranchesProfileFilesByCustomerCode([FromBody] string customerCode)
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetBranchesProfileFiles(customerCode);
			return profileFiles;
		}

		[HttpGet(WebApiProfileFile.GetInventoriesProfileFiles)]
		public ActionResult<ProfileFiles> GetInventoriesProfileFiles()
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetInventoriesProfileFiles();
			return profileFiles;
		}

		[HttpPost(WebApiProfileFile.GetInventoriesByCustomerCode)]
		public ActionResult<ProfileFiles> GetInventoriesProfileFilesByCustomerCode([FromBody] string customerCode)
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetInventoriesProfileFilesByCustomerCode(customerCode);
			return profileFiles;
		}

		[HttpPost(WebApiProfileFile.GetInventoriesByBranchCode)]
		public ActionResult<ProfileFiles> GetInventoriesProfileFilesByBranchCode([FromBody] string branchCode)
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetInventoriesProfileFilesByBranchCode(branchCode);
			return profileFiles;
		}


	
		[HttpPost(WebApiProfileFile.GetProfileFileByUID)]
		public ActionResult<ProfileFile> GetProfileFileById([FromBody]string profileFileUID)
		{
			ProfileFile profileFile = this._profileFileRepository.GetProfileFile(profileFileUID);
			return profileFile;
		}


		[HttpPost(WebApiProfileFile.GetProfileFilesByParentCode)]
		public ActionResult<ProfileFiles> GetProfileFilesByParentCode([FromBody] string parentCode)
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetProfileFilesByParentCode(parentCode);
			return profileFiles;
		}

		[HttpPost(WebApiProfileFile.GetProfileFileByObjectCode)]
		public ActionResult<ProfileFile> GetProfileFileByObjectCode([FromBody] string objectCode)
		{
			ProfileFile profileFile = this._profileFileRepository.GetProfileFileByObjectCode(objectCode);
			return profileFile;
		}


		[HttpPost(WebApiProfileFile.GetProfileFileObjectByCode)]
		public ActionResult<Count4U.Service.Format.Profile> GetProfileFileObjectByCode([FromBody] string objectCode)
		{
			ProfileFile profileFile = this._profileFileRepository.GetProfileFileByObjectCode(objectCode);
			if (profileFile != null) 
			{
				Count4U.Service.Format.Profile profileFileObject1 =
			  DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(profileFile.ProfileXml);
				profileFile.FixProfileXml();
				Count4U.Service.Format.Profile profileFileObject = 
					DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(profileFile.ProfileXml);
				return profileFileObject;
			}
			return new Count4U.Service.Format.Profile();
		}

		[HttpPost(WebApiProfileFile.GetProfileFileByInventorCode)]
		public ActionResult<ProfileFile> GetProfileFileByInventorCode([FromBody] string inventorCode)
		{
			ProfileFile profileFile = this._profileFileRepository.GetProfileFileByInventorCode(inventorCode);
			return profileFile;
		}



		[HttpPost(WebApiProfileFile.DeleteByUid)]
		public ActionResult<string> DeleteByUid([FromBody]string uid)
		{
			this._profileFileRepository.DeleteByProfileFileUID(uid);
			return uid;
		}

		[HttpGet(WebApiProfileFile.DeleteAll)]
		public string DeleteAll()
		{
			this._profileFileRepository.DeleteAll();
			return "";
		}

		[HttpPost(WebApiProfileFile.DeleteByCode)]
		public ActionResult<string> DeleteByCode([FromBody] string objectCode)
		{
			this._profileFileRepository.DeleteByCode(objectCode);
			return objectCode;
		}

		[HttpPost(WebApiProfileFile.Insert)]
		public ActionResult<string> Insert([FromBody] ProfileFile profileFile)
		{
			string uid = this._profileFileRepository.Insert(profileFile);
			return uid;
		}

		[HttpPost(WebApiProfileFile.InsertArray)]
		public ActionResult<ProfileFile> InsertArray([FromBody] ProfileFile[] profileFileArray)
		{
			this._profileFileRepository.InsertArray(profileFileArray);
			return new ProfileFile();
		}

		[HttpPost(WebApiProfileFile.InsertList)]
		public ActionResult<ProfileFile> InsertList([FromBody] ProfileFiles profileFileList)
		{
			this._profileFileRepository.InsertList(profileFileList);
			return new ProfileFile();
		}

		[HttpPost(WebApiProfileFile.Update)]
		public ActionResult<ProfileFile> Update([FromBody] ProfileFile profileFile)
		{
			this._profileFileRepository.Update(profileFile);
			return profileFile;
		}

		[HttpPost(WebApiProfileFile.SaveOrUpdateProfileFileOnFtp)]
		public ActionResult<ProfileFile> SaveOrUpdateProfileFileOnFtp([FromBody] ProfileFile profileFile)
		{
			try 
			{ 
				this._settingsFtpRepository.InitProperty(profileFile);
				this._settingsFtpRepository.ProfileFileSendToFtp(profileFile, false);
				profileFile.Successful = SuccessfulEnum.Successful;
				return profileFile;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				profileFile.Successful = SuccessfulEnum.NotSuccessful;
				profileFile.Error = message;
				return profileFile;
			}
		}

		[HttpPost(WebApiProfileFile.GetProfileFileFromFtp)]
		public ActionResult<ProfileFile> GetProfileFileFromFtp([FromBody] ProfileFile profileFile)
		{
			try
			{
				this._settingsFtpRepository.InitProperty(profileFile);
				string profileTest = "";
				string messageCreateFolder = "";
				this._settingsFtpRepository.CopyProfileFileFromFtpToMemoryStream(profileFile.CurrentPath, ref profileTest, ref messageCreateFolder);
				profileFile.ProfileXml = profileTest;
				profileFile.Successful = SuccessfulEnum.Successful;
				return profileFile;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				profileFile.Successful = SuccessfulEnum.NotSuccessful;
				profileFile.Error = message;
				return profileFile;
			}
		}


		[HttpPost(WebApiProfileFile.SaveOrUpdateProfileFileOnFtpAndDB)]
		public ActionResult<ProfileFile> SaveOrUpdateProfileFileOnFtpAndDB([FromBody] ProfileFile profileFile)
		{
			try
			{
				//SaveOrUpdateProfileFileOnFtp
				this._settingsFtpRepository.InitProperty(profileFile);
				this._settingsFtpRepository.ProfileFileSendToFtp(profileFile, true);

				 //get profile from ftp
				this._settingsFtpRepository.InitProperty(profileFile);										 
				string profileTest = "";
				string messageCreateFolder = "";
				this._settingsFtpRepository.CopyProfileFileFromFtpToMemoryStream(profileFile.CurrentPath, ref profileTest, ref messageCreateFolder);
				profileFile.ProfileXml = profileTest;

				//insert   profile in db
				string uid = this._profileFileRepository.Insert(profileFile);
				
				profileFile.ProfileFileUID = uid;
				profileFile.Successful = SuccessfulEnum.Successful;
				return profileFile;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				profileFile.Successful = SuccessfulEnum.NotSuccessful;
				profileFile.Error = message;
				return profileFile;
			}
		}

		

		[HttpGet(WebApiProfileFile.SaveProfileFileCustomersFromFtpToDb)]
		public ActionResult<List<string>> SaveProfileFileCustomersFromFtpToDb()
		{
			try
			{
				//List<string> list = this._settingsFtpRepository.GetSubFolder("mINV", "Customer" );
				List<string> list = this._settingsFtpRepository.GetCustomerCodeListFromFtp();
				this._profileFileRepository.InsertCustomersBySubFolderList(list);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}


		[HttpPost(WebApiProfileFile.AddProfileFileCustomersToDb)]
		public ActionResult<ProfileFile> AddProfileFileCustomersToDb([FromBody] ProfileFile profileFileModel)
		{
			try
			{
				//List<string> list = this._settingsFtpRepository.GetSubFolder("mINV", "Customer" );
				List<string> list = this._settingsFtpRepository.GetCustomerCodeListFromFtp();
				this._profileFileRepository.InsertCustomersBySubFolderList(list);
				return profileFileModel;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				ProfileFile pf = new ProfileFile();
				pf.Message = message;
				return pf;
			}

		}


		[HttpPost(WebApiProfileFile.SaveProfileFileBranchesFromFtpToDb)]
		public ActionResult<List<string>> SaveProfileFileBranchesFromFtpToDb([FromBody] ProfileFile profileFileModel)
		{
			if (profileFileModel == null) return new List<string>();
			string customerCode = profileFileModel.CustomerCode;
			if(string.IsNullOrWhiteSpace(customerCode) == true) return new List<string>();

			try
			{
				List<string> list = this._settingsFtpRepository.GetBranchCodeListFromFtp(customerCode);
				this._profileFileRepository.InsertBranchsBySubFolderList(customerCode, list);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}

		[HttpPost(WebApiProfileFile.SaveProfileFileInventorsFromFtpToDb)]
		public ActionResult<List<string>> SaveProfileFileInventorsFromFtpToDb([FromBody] ProfileFile profileFileModel)
		{
			if (profileFileModel == null) return new List<string>();
			string customerCode = profileFileModel.CustomerCode;
			if (string.IsNullOrWhiteSpace(customerCode) == true) return new List<string>();
			string branchCode = profileFileModel.BranchCode;
			if (string.IsNullOrWhiteSpace(branchCode) == true) return new List<string>();
			try
			{
				//List<string> list = this._settingsFtpRepository.GetSubFolder("mINV", "Customer" );
				List<string> list = this._settingsFtpRepository.GetInventorSubFolderListFromFtp(customerCode, branchCode);
				this._profileFileRepository.InsertInventoriesBySubFolderList(customerCode, branchCode, list);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}


		[HttpPost(WebApiProfileFile.UpdateOrInsertProfileFileInventorFromFtpToDb)]
		public ActionResult<ProfileFile> UpdateOrInsertProfileFileInventorFromFtpToDb([FromBody] ProfileFile profileFileModel)
		{
			 if (profileFileModel == null)
			{
				return new ProfileFile();
			}
			try
			{
				ProfileFile ret = this._profileFileRepository.InsertInventoriesByCBI(profileFileModel);
				if (ret == null) return new ProfileFile();
				return ret;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return profileFileModel;
			}

		}


		[HttpGet(WebApiProfileFile.GetCustomerListFromDb)]
		public ActionResult<List<ProfileFileLite>> GetCustomerListFromDb()
		{
			try
			{
				List<ProfileFileLite> list= this._profileFileRepository.GetCustomerProfileFileLiteList();
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<ProfileFileLite>();
			}

		}

		[HttpPost(WebApiProfileFile.GetBranchCodeListFromDb)]
		public ActionResult<List<string>> GetBranchCodeListFromDb([FromBody] ProfileFile profileFileModel)
		{
			if (profileFileModel == null) return new List<string>();
			string customerCode = profileFileModel.CustomerCode;
			if (string.IsNullOrWhiteSpace(customerCode) == true) return new List<string>();

			try
			{
				List<string> list = this._profileFileRepository.GetBranchCodeListForCustomer(customerCode);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}

		[HttpPost(WebApiProfileFile.GetInventorCodeListFromDb)]
		public ActionResult<List<string>> GetInventorCodeListFromDb([FromBody] ProfileFile profileFileModel)
		{
			if (profileFileModel == null) return new List<string>();
			string customerCode = profileFileModel.CustomerCode;
			if (string.IsNullOrWhiteSpace(customerCode) == true) return new List<string>();
			string branchCode = profileFileModel.BranchCode;
			if (string.IsNullOrWhiteSpace(branchCode) == true) return new List<string>();
			try
			{
				List<string> list = this._profileFileRepository.GetInventorCodeListForBranch(branchCode);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}

		[HttpPost(WebApiProfileFile.GetTestDataProfileFiles)]
		public ActionResult<ProfileFiles> GetTestDataProfileFiles()
		{
			ProfileFiles profileFiles = this._profileFileRepository.GetTestDataProfileFiles();
			return profileFiles;
		}

		[HttpPost(WebApiProfileFile.TestGetProfileFileFromFtp)]
		public ActionResult<string> TestGetProfileFileFromFtp()
		{
			try
			{
				ProfileFile profileFileModel = new ProfileFile();
				this._settingsFtpRepository.InitProperty(profileFileModel);
				string profileTest = "";
				string messageCreateFolder = "";
				this._settingsFtpRepository.CopyProfileFileFromFtpToMemoryStream(@"mINV/Customer/dn6x/Branch/dn6x-nry3/Inventor/2019/6/6/75c98290-7c77-4f08-8ddd-c90bbe106b45/Profile", ref profileTest, ref messageCreateFolder);
				profileFileModel.ProfileXml = profileTest;
				return profileTest;

			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return message;
			}

		}

		[HttpPost(WebApiProfileFile.TestGetCustomerListFromFtp)]
		public ActionResult<List<string>> TestGetCustomerListFromFtp()
		{
			try
			{
				//List<string> list = this._settingsFtpRepository.GetSubFolder("mINV", "Customer" );
				List<string> list = this._settingsFtpRepository.GetCustomerCodeListFromFtp();
				this._profileFileRepository.InsertCustomersBySubFolderList(list);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}

		[HttpPost(WebApiProfileFile.TestGetBranchCodeListFromFtp)]
		public ActionResult<List<string>> TestGetBranchCodeListFromFtp()
		{
			string customerCode = "900";
			try
			{
				//List<string> list = this._settingsFtpRepository.GetSubFolder("mINV", "Customer" );
				List<string> list = this._settingsFtpRepository.GetBranchCodeListFromFtp(customerCode);
				this._profileFileRepository.InsertBranchsBySubFolderList(customerCode, list);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}

		[HttpPost(WebApiProfileFile.TestGetInventorCodeListFromFtp)]
		public ActionResult<List<string>> TestGetInventorCodeListFromFtp()
		{
			string customerCode = "900";
			string branchCode = "900-002";
			try
			{
				//List<string> list = this._settingsFtpRepository.GetSubFolder("mINV", "Customer" );
				List<string> list = this._settingsFtpRepository.GetInventorSubFolderListFromFtp(customerCode, branchCode);
				this._profileFileRepository.InsertInventoriesBySubFolderList(customerCode, branchCode, list);
				return list;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return new List<string>();
			}

		}


	}
}
