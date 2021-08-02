using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Model.SelectionParams;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Monitor.Service.Shared
{
	public interface IProfileFileService
	{

		ProfileFile[] RunUpdateFtpAndDbProfiles { get; set; }
		ProfileFile[] RunUpdateDbProfiles { get; set; }
		Task<ProfileFiles> GetProfileFiles(string dataServerAddressUrl);
		Task<ProfileFiles> GetProfileFilesWithSelectParam(SelectParams selectParams, string dataServerAddressUrl);
		Task<ProfileFile> GetProfileFileById(long id, string dataServerAddressUrl);
		Task<ProfileFile> GetProfileFileByCode(string code, string dataServerAddressUrl);
		
		Task<ProfileFiles> GetProfilesFilesByParentCode(string parentCode, string dataServerAddressUrl);
		Task<ProfileFiles> GetCustomerProfileFiles(string dataServerAddressUrl);
		Task<ProfileFiles> GetBranchProfileFiles(string dataServerAddressUrl);
		Task<ProfileFiles> GetBranchProfileFilesByCustomerCode(string customerCode, string dataServerAddressUrl);
		Task<ProfileFiles> GetInventorProfileFiles(string dataServerAddressUrl);
		Task<ProfileFiles> GetInventorProfileFilesByCustomerCode(string customerCode, string dataServerAddressUrl);
		Task<ProfileFiles> GetInventorProfileFilesByBranchCode(string branchCode, string dataServerAddressUrl);
		Task<ProfileFile> GetProfileFileFromFtp(ProfileFile profileFile, string dataServerAddressUrl);
		Task<List<string>> SaveCustomersFromFtpToDb(string dataServerAddressUrl);
		Task<List<string>> SaveBranchesFromFtpToDb(ProfileFile profileFile, string dataServerAddressUrl);
		Task<List<string>> SaveInventorsFromFtpToDb(ProfileFile profileFile, string dataServerAddressUrl);
		Task<List<string>> GetCustomerCodeListFromDb(string dataServerAddressUrl);
		Task<List<string>> GetBranchCodeListFromDb(ProfileFile profileFile, string dataServerAddressUrl);
		Task<List<string>> GetInventorCodeListFromDb(ProfileFile profileFile, string dataServerAddressUrl);
		Task<long> DeleteById(long id, string dataServerAddressUrl);
		Task<string> DeleteByCode(string code, string dataServerAddressUrl);
		Task<string> DeleteAll(string dataServerAddressUrl);
		Task<long> Insert(ProfileFile profileFile, string dataServerAddressUrl);
		Task<ProfileFile> Update(ProfileFile profileFile, string dataServerAddressUrl);

		Task<ProfileFile> SaveOrUpdateProfileFileOnFtp(ProfileFile profileFile, string dataServerAddressUrl);
		Task<ProfileFile> UpdateOrInsertProfileFileInventorFromFtpToDb(ProfileFile profileFile, string dataServerAddressUrl);
		Task<ProfileFile> GetProfileFileByInventorCode(string inventorCode, string dataServerAddressUrl);

		Task<ProfileFile[]> AddToQueueUpdateFtpAndDbRun(ProfileFile profileFile, string dataServerAddressUrl);
	}


	public class ProfileFileService : IProfileFileService
	{
		private readonly HttpClient _httpClient;
		public ProfileFile[] RunUpdateFtpAndDbProfiles { get; set; }
		public ProfileFile[] RunUpdateDbProfiles { get; set; }

		public ProfileFileService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
		}


		public async Task<ProfileFiles> GetProfileFiles(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetProfileFiles);
			Console.WriteLine($"ProfileFileService.GetProfileFiles : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<ProfileFiles>(request);
			return result;
		}

		public async Task<ProfileFiles> GetCustomerProfileFiles(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetCustomersProfileFiles);
			Console.WriteLine($"ProfileFileService.GetCustomersProfileFiles : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<ProfileFiles>(request);
			return result;
		}

		public async Task<ProfileFiles> GetBranchProfileFiles(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetBranchesProfileFiles);
			Console.WriteLine($"ProfileFileService.GetBranchesProfileFiles : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<ProfileFiles>(request);
			return result;
		}

		public async Task<ProfileFiles> GetBranchProfileFilesByCustomerCode(string customerCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetBranchesByCustomerCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, customerCode);
			ProfileFiles result = await response.Content.ReadFromJsonAsync<ProfileFiles>();
			return result;
		}

		public async Task<ProfileFiles> GetInventorProfileFiles(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetInventoriesProfileFiles);
			Console.WriteLine($"ProfileFileService.GetInventoriesProfileFiles : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<ProfileFiles>(request);
			return result;
		}

		public async Task<ProfileFiles> GetInventorProfileFilesByCustomerCode(string customerCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetInventoriesByCustomerCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, customerCode);
			ProfileFiles result = await response.Content.ReadFromJsonAsync<ProfileFiles>();
			return result;
		}

		public async Task<ProfileFiles> GetInventorProfileFilesByBranchCode(string branchCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetInventoriesByBranchCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, branchCode);
			ProfileFiles result = await response.Content.ReadFromJsonAsync<ProfileFiles>();
			return result;
		}

		public async Task<List<string>> SaveCustomersFromFtpToDb(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.SaveProfileFileCustomersFromFtpToDb);
			Console.WriteLine($"ProfileFileService.GetCustomerListFromFtp : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<string>>(request);
			return result;
		}

		public async Task<List<string>> SaveBranchesFromFtpToDb(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
	 		string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.SaveProfileFileBranchesFromFtpToDb);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			List<string> result = await response.Content.ReadFromJsonAsync<List<string>>();
			return result;
		}

		public async Task<List<string>> SaveInventorsFromFtpToDb(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.SaveProfileFileInventorsFromFtpToDb);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			List<string> result = await response.Content.ReadFromJsonAsync<List<string>>();
			return result;
		}

		
		public async Task<ProfileFile> UpdateOrInsertProfileFileInventorFromFtpToDb(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.UpdateOrInsertProfileFileInventorFromFtpToDb);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			ProfileFile result = await response.Content.ReadFromJsonAsync<ProfileFile>();
			return result;
		}

		public async Task<List<string>> GetCustomerCodeListFromDb(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetCustomerListFromDb);
			Console.WriteLine($"ProfileFileService.GetCustomerListFromFtp : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<string>>(request);
			return result;
		}

		public async Task<List<string>> GetBranchCodeListFromDb(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetBranchCodeListFromDb);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			List<string> result = await response.Content.ReadFromJsonAsync<List<string>>();
			return result;
		}

		public async Task<List<string>> GetInventorCodeListFromDb(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetInventorCodeListFromDb);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			List<string> result = await response.Content.ReadFromJsonAsync<List<string>>();
			return result;
		}

		public async Task<ProfileFiles> GetProfileFilesWithSelectParam(SelectParams selectParams, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetProfileFilesWithSelectParam);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<SelectParams>(request, selectParams);
			ProfileFiles result = await response.Content.ReadFromJsonAsync<ProfileFiles>();
			return result;
		}

		public async Task<ProfileFile> GetProfileFileById(long id, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetProfileFileById);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<long>(request, id);
			ProfileFile result = await response.Content.ReadFromJsonAsync<ProfileFile>();
			return result;
		}

		public async Task<ProfileFile> GetProfileFileByCode(string code, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetProfileFileByObjectCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, code);
			ProfileFile result = await response.Content.ReadFromJsonAsync<ProfileFile>();
			return result;
		}


		public async Task<ProfileFile> GetProfileFileByInventorCode(string inventorCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetProfileFileByInventorCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, inventorCode);
			ProfileFile result = await response.Content.ReadFromJsonAsync<ProfileFile>();
			return result;
		}
		


		public async Task<ProfileFiles> GetProfilesFilesByParentCode(string parentCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetProfileFilesByParentCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, parentCode);
			ProfileFiles result = await response.Content.ReadFromJsonAsync<ProfileFiles>();
			return result;
		}

		public async Task<long> DeleteById(long id, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return -1;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, Urls.WebApiProfileFile.DeleteById);
			//	long result = await this._httpClient.PostJsonAsync<long>(request, id);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<long>(request, id);
			long result = await response.Content.ReadFromJsonAsync<long>();
			return result;
		}

		public async Task<string> DeleteByCode(string code, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return "0";
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.DeleteByCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, code);
			string result = await response.Content.ReadFromJsonAsync<string>();
			return result;
		}

		public async Task<string> DeleteAll( string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return "0";
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.DeleteAll);
			var result = await this._httpClient.GetFromJsonAsync<string>(request);
			return result;
		}

		public async Task<long> Insert(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return -1;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.Insert);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			long result = await response.Content.ReadFromJsonAsync<long>();
			return result;
		}

		public async Task<ProfileFile> Update(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.Update);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			ProfileFile result = await response.Content.ReadFromJsonAsync<ProfileFile>();
			return result;
		}

	

		public async Task<ProfileFile> SaveOrUpdateProfileFileOnFtp(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.SaveOrUpdateProfileFileOnFtp);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			ProfileFile result = await response.Content.ReadFromJsonAsync<ProfileFile>();
			return result;
		}


		

		public async Task<ProfileFile[]> AddToQueueUpdateFtpAndDbRun(ProfileFile profileFile, string dataServerAddressUrl)   
		{
			#region validate
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
			{
				return new ProfileFile[] { new ProfileFile(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.dataServerAddressUrlIsNull) { Error = "dataServerAddressUrl is empty" } };
			}
			#endregion

			//command.User = user;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.AddToQueueUpdateFtpAndDbRun);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			ProfileFile[] result = await response.Content.ReadFromJsonAsync<ProfileFile[]>();
			return result;
		}
		public async Task<ProfileFile> GetProfileFileFromFtp(ProfileFile profileFile, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiProfileFile.GetProfileFileFromFtp);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileFile>(request, profileFile);
			ProfileFile result = await response.Content.ReadFromJsonAsync<ProfileFile>();
			return result;
		}

		
	}
}

