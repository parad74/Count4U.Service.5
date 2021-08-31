namespace Monitor.Service.Urls
{
	public static class Opetarion
	{
		public static string UrlCombine(string dataServerAddress, string path)
		{
			string host = @"http://" + dataServerAddress.Replace(@"http://", "");
			host = host.TrimEnd('/');
			path = path.TrimStart('/');
			string request = host + @"/" + path;
			return request;
		}

		public static string UrlCombine(string dataServerAddress, string path, string param1)
		{
			string host = @"http://" + dataServerAddress.Replace(@"http://", "");
			host = host.TrimEnd('/');
			string request = host + @"/" + path;
			if (string.IsNullOrWhiteSpace(param1) == false)
			{
				request = request + @"/" + param1;
			}
			return request;
		}
	}

	public static class PingOpetarion
	{
		public const string Pong = @"Pong";
	}


	public static class SessionStorageKey
	{
		public const string hostMode = @"hostMode";
		public const string authenticationWebapiUrl = @"authenticationWebapiUrl";
		public const string authenticationWebapiUrls = @"authenticationWebapiUrls";

		public const string count4uWebapiUrl = @"count4uWebapiUrl";
		public const string count4uWebapiUrls = @"count4uWebapiUrls";

		public const string monitorWebapiUrl = @"monitorWebapiUrl";
		public const string monitorWebapiUrls = @"monitorWebapiUrls";

		public const string signalRHubUrl = @"signalRHubUrl";
		public const string signalRHubUrls = @"signalRHubUrls";
		public const string authToken = @"authToken";
		public const string isImporting = @"isImporting";

		public const string onPageCustomerNumber = @"onPageCustomerNumber";
		public const string onPageInventorNumber = @"onPageInventorNumber";
		public const string filterCustomer = @"filterCustomer";
		public const string filterInventor = @"filterInventor";

	}

	public static class WebApiAuthenticationClaim
	{
		public const string GetClaims = @"api/claim/GetClaims";
		public const string GetClaimConvertItems = @"api/claim/GetClaimConvertItems";
		public const string GetClaimConvertItemFirstAsync = @"api/claim/GetClaimConvertItemFirstAsync";
		public const string GetClaimEnumList = @"api/claim/GetClaimEnumList";
		public const string GetClaimValue = @"api/claim/GetClaimValue/{key}";
	}

	public static class WebApiAuthenticationAccounts
	{
		public const string PostProfile = @"api/accounts/profile";
		public const string GetCurrentUserProfile = @"api/accounts/getcurrentuserprofile";
		public const string PostRegister = @"api/accounts/register";
		public const string PostUpdateprofile = @"api/accounts/updateprofile";
		public const string GetUser = @"api/accounts/user";
		public const string DeleteUser = @"api/accounts/deleteuser";
		
	}

	public static class WebApiAuthenticationAdmin
	{
		public const string Delete = @"api/admin/delete";
		public const string PostChangePassword = @"api/admin/changepassword";
		public const string RoleWithUsers = @"api/admin/rolewithusers";
		public const string UpdateUsersInRole = @"api/admin/updateusersinrole";
		public const string GetRoles = @"api/admin/getroles";
		public const string GetUsers = @"api/admin/getusers";
		public const string GetUserWithPassword = @"api/admin/getuserwithpassword";
		public const string ForgotPassword = @"api/admin/fogotpassword";
		public const string GetUser = @"api/admin/getuser";


	}

	public static class WebApiAuthenticationLogin
	{
		public const string PostLogin = @"api/login";
		//public const string ForgotPassword = @"api/forgotpassword";
		public const string ResetPassword = @"api/resetpassword";
		
		
	}

	public static class WebApiAuthenticationPing
	{
		public const string GetPing = @"api/authentication/ping";
		public const string GetPingSecure = @"api/authentication/ping/secure";
	}

	public static class ServerPing
	{
		public const string GetPing = @"api/ping";
		public const string GetPingSecure = @"api/pingsecure";
	}


	public static class FileService
	{
		public const string PostUpload = @"upload";
	}

	public static class ServerAdminPing
	{
		public const string GetPing = @"api/ServerAdminPing/ping";
		public const string GetPingSecure = @"api/ServerAdminPing/pingsecure";
	}

	public static class ServerManagerPing
	{
		public const string GetPing = @"api/ServerManagerPing/ping";
		public const string GetPingSecure = @"api/ServerManagerPing/pingsecure";
	}
	public static class ServerMonitorPing
	{
		public const string GetPing = @"api/ServerMonitorPing/ping";
		public const string GetPingSecure = @"api/ServerMonitorPing/pingsecure";
	}


	public static class WebApiCount4UModelPing
	{
		public const string GetPing = @"api/pingwebapi/ping";
		public const string GetPingSecure = @"api/pingwebapi/secure";
	}

	public static class WebApiMonitorPing
	{
		public const string GetPing = @"api/monitorwebapi/ping";
		public const string GetPingSecure = @"api/monitorwebapi/pingsecure";
	}

	public static class WebApiProfilePing
	{
		public const string GetPing = @"api/profilewebapi/ping";
		public const string GetPingSecure = @"api/profilewebapi/pingsecure";
	}

	

	public static class SignalRHubPing
	{
		public const string GetPing = @"api/signalrhub/ping";
		public const string GetPingSecure = @"api/signalrhub/pingsecure";
	}
	public static class ServerSettings
	{
		public const string Count4uWebapiUrl = @"api/serverwebapi/getcount4uwebapiurls";
		public const string AuthenticationWebapiUrls = @"api/serverwebapi/getauthenticationwebapiurls";
		public const string AuthenticationWebapiUrl = @"api/serverwebapi/getauthenticationwebapiurl";
		public const string GetWebAPISettings = @"api/serverwebapi/getwebapisettings";

		public const string MonitorWebapiUrls = @"api/serverwebapi/getmonitorwebapiurls";
		public const string MonitorWebapiUrl = @"api/serverwebapi/getmonitorwebapiurl";

		public const string GetSignalRUrls = @"api/serverwebapi/getsignalrurls";
		public const string GetSignalRUrl = @"api/serverwebapi/getsignalrurl";

		
	}

	public static class WebApiCount4UModelInventor
	{
		public const string GetInventors = @"api/inventor/GetInventors";
		public const string GetCurrentInventor = @"api/inventor/GetCurrentInventor";
		public const string GetInventorByCode = @"api/inventor/GetInventorByCode/{сode}";
		public const string GetInventorsByCurrentBranch = @"api/inventor/GetInventorsByCurrentBranch";
		public const string GetInventorsByBranchCode = @"api/inventor/GetInventorsByBranchCode/{branchCode}";
		public const string GetInventorCodeListByCurrentCustomer = @"api/inventor/GetInventorCodeListByCurrentCustomer";
		public const string GetInventorCodeListByCustomerCode = @"api/inventor/GetInventorCodeListByCustomerCode/{customerCode}";
		public const string GetInventorCodeListByCurrentBranch = @"api/inventor/GetInventorCodeListByCurrentBranch";
		public const string GetInventorCodeListByBranchCode = @"api/inventor/GetInventorCodeListByBranchCode/{branchCode}";

		
	}

	public static class WebApiCount4UModelContextCBI
	{
		public const string GetProcessCBIConfig = @"api/GetProcessCBIConfig";
	}

		public static class WebApiCount4UModelClaim
	{
		public const string GetClaimWebApiConvertItems = @"api/ClaimWebApi/GetClaimWebApiConvertItems";
	}

	public static class WebApiMonitorModelClaim
	{
		public const string GetClaimsFromWebApi = @"api/ClaimWebApi/GetClaimsFromWebApi";
	}

	public static class WebApiProfileModelClaim
	{
		public const string GetClaimsProfileFromWebApi = @"api/ClaimProfileWebApi/GetClaimsFromWebApi";
	}
	public static class WebApiCount4UModelItur
	{
		public const string GetIturs = @"api/itur/GetIturs";
		public const string GetTopIturs = @"api/itur/GetTopIturs";
		public const string GetSelectParamsIturs = @"api/itur/GetSelectParamsIturs";
		public const string GetIturTotalCount = @"api/itur/GetIturTotalCount";
		public const string ClearStatusBit = @"api/itur/ClearStatusBit";
		public const string GetIturByCode = @"api/itur/GetItur";
		public const string GetIturCodesForLocationCode = @"api/itur/GetIturCodesForLocationCode/{locationCode}";
		public const string TestUpdateFileItemsInData = @"api/itur/TestUpdateFileItemsInData";

		//TODO move
		public const string GetRefillApproveStatusBitByIturCode = @"api/itur/GetRefillApproveStatusBitByIturCode";
		public const string RefillApproveStatusBitByIturCode = @"api/itur/RefillApproveStatusBitByIturCode";
		public const string RefillApproveStatusBitByIturCodeList = @"api/itur/RefillApproveStatusBitByIturCodeList";

		public const string RefillParallelApproveStatusBit = @"api/itur/RefillParallelApproveStatusBit";
		public const string RefillParallelApproveStatusBitSelectParams = @"api/itur/RefillParallelApproveStatusBitSelectParams";



		//public const string RefillApproveStatusBitByIturCode = @"api/Itur/RefillApproveStatusBitByIturCode";

	}

	public static class FileIO
	{
		public const string Download1ToProcessBackup = @"Download1ToProcessBackup";
		public const string Download2ToInDataBackup = @"Download2ToInDataBackup ";
		public const string Download3ToInDataZip = @"Download3ToInDataZip ";
	}


	public static class WebApiCount4UModelAdapterInitialaze
	{
		//public const string InitImportFolder = @"api/AdapterInitialaze/InitImportFolder";
		//public const string AdapterInit = @"api/AdapterInitialaze/AdapterInit";

		public const string Clear = @"api/ImportFromPdaNativPlusSqlite/Clear";
		public const string PingAdapterInitCommand = @"api/ImportFromPdaNativPlusSqlite/PingAdapterInitCommand";
		public const string ImportFull = @"api/ImportFromPdaNativPlusSqlite/ImportFull";

		public const string SetQueue = @"api/ImportFromPdaNativPlusSqlite/SetQueue";
		public const string Init = @"api/ImportFromPdaNativPlusSqlite/Init";
		public const string Import = @"api/ImportFromPdaNativPlusSqlite/Import";
		public const string CopyFileAfter = @"api/ImportFromPdaNativPlusSqlite/CopyFileAfter";
		public const string RefreshIturStatus = @"api/ImportFromPdaNativPlusSqlite/RefreshIturStatus";
	}

	public static class WebApiCount4UImportFromPdaAdapter
	{
		public const string AdapterInit = @"api/ImportFromPdaAdapter/AdapterInit";
		public const string GetClearCommandResultArray = @"api/ImportFromPdaAdapter/GetClearCommandResultArray";
		public const string GetImportCommandResultArray = @"api/ImportFromPdaAdapter/GetImportCommandResultArray";
		public const string GetAdapterTitle = @"api/ImportFromPdaAdapter/GetAdapterTitle";
		public const string AddToQueueClearRun = @"api/ImportFromPdaAdapter/AddToQueueClearRun";
		public const string AddToQueueImportRun = @"api/ImportFromPdaAdapter/AddToQueueImportRun";

	}



	public static class WebApiCount4UModelLocation
	{
		public const string GetLocations = @"api/location/GetLocations";
	}


	public static class WebApiCount4UPathSetting
	{
		public const string FromPdaProcessPath = @"api/PathSetting/FromPdaProcessPath";
		public const string GetFilesInfoInDataFolder = @"api/PathSetting/GetFilesInfoInDataFolder";
		public const string GetFilesItemInDataFolder = @"api/PathSetting/GetFilesItemInDataFolder";

	}

	public static class WebApiCount4UModelConnectionDB
	{
		public const string GetPing = @"api/ConnectionDB/Ping";
	}


	public static class WebApiCount4UModelBranch
	{
		public const string GetBranches = @"api/branch/GetBranches";
		public const string GetCurrentBranch = @"api/branch/GetCurrentBranch";
		public const string GetBranchByCode = @"api/branch/GetBranchByCode/{branchCode}";
		public const string GetBranchesByCurrnetCustomer = @"api/branch/GetBranchesByCurrnetCustomer";
		public const string GetBranchesByCustomerCode = @"api/branch/GetBranchesByCustomerCode/{customerCode}";
		public const string GetBranchCodeListByCustomerCode = @"api/branch/GetBranchCodeListByCustomerCode/{customerCode}";
	}

	public static class WebApiCount4UModelCustomer
	{
		public const string GetCustomers = @"api/customer/GetCustomers";
		public const string GetCustomerCodeList = @"api/customer/GetCustomerCodeList";
		public const string GetCurrentCustomer = @"api/customer/GetCurrentCustomer";
		public const string GetCustomerByCode = @"api/customer/GetCustomerByCode/{customerCode}";
		public const string GetCodeList = @"api/customer/GetCodeList";
	}

	public static class WebApiCount4UModelProcess
	{
		public const string GetProcesses = @"api/process/GetProcesses";
		public const string GetProcessByProcessCode = @"api/process/GetProcessByProcessCode/{processCode}";
	}

	public static class WebApiMonitorCommandResult
	{
		public const string GetCommandResults = @"api/commandresult/GetCommandResults";
		public const string GetTestDataCommandResults = @"api/commandresult/GetTestDataCommandResults";
		public const string GetCommandResultsWithSelectParam = @"api/commandresult/GetCommandResultsWithSelectParam";
		public const string GetCommandResultsWithSelectParamTest = @"api/commandresult/GetCommandResultsWithSelectParamTest";
		public const string GetCommandResultById = @"api/commandresult/GetCommandResultById";
		public const string GetCommandResultByCommandResultCode = @"api/commandresult/GetCommandResultByCommandResultCode";
		public const string GetCommandResultsByParentCode = @"api/commandresult/GetCommandResultsByParentCode";
		public const string DeleteById = @"api/commandresult/DeleteById";
		public const string DeleteByCommandResultCode = @"api/commandresult/DeleteByCommandResultCode";
		public const string Insert = @"api/commandresult/Insert";
		public const string Insert1 = @"api/commandresult/Insert1";
		public const string InsertArray = @"api/commandresult/InsertArray";
		public const string Update = @"api/commandresult/Update";
		public const string DeleteAll = @"api/commandresult/DeleteAll";

		public const string GetCommandResultByGuid = @"api/commandresult/GetCommandResultByGuid";



	}

	public static class WebApiProfileFile
	{
		public const string SaveOrUpdateProfileFileOnFtp = @"api/webapiprofile/insertorupdatefromftp";
		public const string GetProfileFileFromFtp = @"api/webapiprofile/getprofilefilefromftp";
		public const string GetProfileFiles = @"api/webapiprofile/getprofiles";
		public const string GetProfileFilesWithSelectParam = @"api/webapiprofile/getprofileswithselectparam";
		public const string GetTestDataProfileFiles = @"api/webapiprofile/gettestdataprofiles";
		public const string GetProfileFileById = @"api/webapiprofile/getprofilefilebyid";
		public const string GetCustomersProfileFiles = @"api/webapiprofile/getcustomersprofiles";
		public const string GetBranchesProfileFiles = @"api/webapiprofile/getbranchesprofiles";
		public const string GetBranchesByCustomerCode = @"api/webapiprofile/getbranchesbycustomercode";
		public const string GetInventoriesProfileFiles = @"api/webapiprofile/getinventoriesprofiles";
		public const string GetInventoriesByCustomerCode = @"api/webapiprofile/getinventoriesbycustomercode";
		public const string GetInventoriesByBranchCode = @"api/webapiprofile/getinventoriesbybranchcode";
		public const string GetProfileFilesByParentCode = @"api/webapiprofile/getprofilesbyparentcode";
		public const string GetProfileFileByObjectCode = @"api/webapiprofile/getprofilebyobjectcode";
public const string GetProfileFileByInventorCode = @"api/webapiprofile/getprofilebyinventorcode";
		
		public const string DeleteById = @"api/webapiprofile/deletebyid";
		public const string DeleteAll = @"api/webapiprofile/deleteall";
		public const string DeleteByCode = @"api/webapiprofile/deletebycode";
		public const string Insert = @"api/webapiprofile/insert";
		public const string InsertArray = @"api/webapiprofile/insertarray";
		public const string InsertList = @"api/webapiprofile/insertlist";
		public const string Update = @"api/webapiprofile/update";
		public const string TestGetProfileFileFromFtp = @"api/webapiprofile/TestGetProfileFileFromFtp";
		public const string SaveProfileFileCustomersFromFtpToDb = @"api/webapiprofile/SaveProfileFileCustomersFromFtpToDb";
		public const string SaveProfileFileBranchesFromFtpToDb = @"api/webapiprofile/SaveProfileFileBranchesFromFtpToDb";
		public const string SaveProfileFileInventorsFromFtpToDb = @"api/webapiprofile/SaveProfileFileInventorsFromFtpToDb";
		public const string UpdateOrInsertProfileFileInventorFromFtpToDb = @"api/webapiprofile/UpdateOrInsertProfileFileInventorFromFtpToDb";
		public const string GetCustomerListFromDb = @"api/webapiprofile/GetCustomerListFromDb";
		public const string GetBranchCodeListFromDb = @"api/webapiprofile/GetBranchCodeListFromDb";
		public const string GetInventorCodeListFromDb = @"api/webapiprofile/GetInventorCodeListFromDb";

		public const string AddToQueueUpdateFtpAndDbRun = @"api/webapiprofile/AddToQueueUpdateFtpAndDbRun";

		public const string TestGetCustomerListFromFtp = @"api/webapiprofile/TestGetCustomerListFromFtp";
		public const string TestGetBranchCodeListFromFtp = @"api/webapiprofile/TestGetBranchCodeListFromFtp";
		public const string TestGetInventorCodeListFromFtp = @"api/webapiprofile/TestGetInventorCodeListFromFtp";
		

		


	}





	public static class BlogPosts
	{
		public const string GetBlogPosts = @"api/BlogPosts";
	}

	public enum C4UFeatureFlags
	{
		FeatureA,
		FeatureB,
		FeatureC
	}
}
