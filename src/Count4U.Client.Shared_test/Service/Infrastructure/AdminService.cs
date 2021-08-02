using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
//using Blazored.LocalStorage;
//using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Monitor.Service.Model;
using Monitor.Service.Urls;
using System.Text.Json;
using System.Collections.Generic;

namespace Count4U.Service.Shared
{

	public interface IAdminService
	{
		Task<ChangePasswordResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel);
		Task<DeleteResult> Delete(DeleteModel deleteModel);
		Task<List<UserViewModel>> GetUsers();
		Task<List<RoleModel>> GetRoles();
		Task<RoleModel> RoleWithUsers(string roleId);
		Task<RoleResult> UpdateUsersInRole(RoleModel roleModel);
		
	}

	public class AdminService : IAdminService
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		//private readonly ISessionStorageService _sessionStorage;
		//private readonly ILocalStorageService _localStorage;

		public AdminService(HttpClient httpClient
						   , AuthenticationStateProvider authenticationStateProvider
						 //  , ISessionStorageService sessionStorage
							//, ILocalStorageService localStorage)
							)
		{
			this._httpClient = httpClient ??
						   throw new ArgumentNullException(nameof(httpClient));
			this._authenticationStateProvider = authenticationStateProvider ??
						   throw new ArgumentNullException(nameof(authenticationStateProvider));
			//this._sessionStorage = sessionStorage ??
			//			   throw new ArgumentNullException(nameof(sessionStorage));
			//this._localStorage = localStorage ??
			//			   throw new ArgumentNullException(nameof(localStorage));
		}


		  //[HttpPost(WebApiAuthenticationAdmin.PostChangePassword)]
        //public async Task<ChangePasswordResult> ChangePassword([FromBody] ChangePasswordModel changePasswordModel)

		public async Task<ChangePasswordResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
		{
			Console.WriteLine($"Client.AdminService.ChangePasswordAsync() : start");
			//if (changePasswordModel == null)
			//{
			//	Console.WriteLine($"Client.AdminService.ChangePasswordAsync() : in changePasswordModel is null");
			//	var error = new ChangePasswordResult { Successful = SuccessfulEnum.NotSuccessful, Error = "changePasswordModel is null" };
			//	return error;
			//}
			//try
			//{
				//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				//{
				//	Console.WriteLine($"Client.AdminService.changePasswordModel() : ERROR Authentication Server Url is Empty. Can't get user from Server");
				//	var error = new ChangePasswordResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Authentication Server Url is Empty. Can't get user from Server" };
				//	Console.WriteLine($"Client.AdminService.changePasswordModel() : end");
				//	return error;
				//}

			//	string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.PostChangePassword);
			//	Console.WriteLine($"Client.AdminService.changePasswordModel() : request {request}");
			////	var result = await this._httpClient.PostJsonAsync<ChangePasswordResult>(request, changePasswordModel);
			//	HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ChangePasswordModel>(request, changePasswordModel);
			//	ChangePasswordResult result = await response.Content.ReadFromJsonAsync<ChangePasswordResult>();

			//	if (result == null)
			//	{
			//		Console.WriteLine($"Client.AdminService.changePasswordModel() : Can't login to Server");
			//		var error = new ChangePasswordResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Can't login to Server" };
			//		return error;
			//	}
			//	if (result.Successful == SuccessfulEnum.Successful)
			//	{
			//		Console.WriteLine($"Client.AdminService.changePasswordModel() : ChangePassword Successfuly");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"Client.AdminService.changePasswordModel() : ChangePassword Not Successfuly");
			//	}
			//	return result;
			//}
			//catch (Exception ecx) when (LogError(ecx))
			//{
			//	Console.WriteLine("Client.AdminService.changePasswordModel() Exception : ");
			//	Console.WriteLine(ecx.Message);
				var error = new ChangePasswordResult { Successful = SuccessfulEnum.NotSuccessful };
				Console.WriteLine($"Client.AdminService.changePasswordModel() : end with Exception");
				return error;
			//}
		}

//[HttpPost(WebApiAuthenticationAdmin.Delete)]
  //      public async Task<DeleteResult> Delete([FromBody] DeleteModel deleteModel)
      
		public async Task<DeleteResult> Delete( DeleteModel deleteModel)
		{
			Console.WriteLine($"Client.AdminService.Delete() : start");
			//if (deleteModel == null)
			//{
			//	Console.WriteLine($"Client.AdminService.Delete() : in deleteModel is null");
			//	var error = new DeleteResult { Successful = SuccessfulEnum.NotSuccessful, Error = "deleteModel is null" };
			//	return error;
			//}
			//try
			//{
				//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				//{
				//	Console.WriteLine($"Client.AdminService.Delete() : ERROR Authentication Server Url is Empty. Can't get user from Server");
				//	var error = new DeleteResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Authentication Server Url is Empty. Can't get user from Server" };
				//	Console.WriteLine($"Client.AdminService.Delete() : end");
				//	return error;
				//}

			//	string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.Delete);
			//	Console.WriteLine($"Client.AdminService.Delete() : request {request}");
			////	var result = await this._httpClient.PostJsonAsync<ChangePasswordResult>(request, changePasswordModel);
			//	HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<DeleteModel>(request, deleteModel);
			//	DeleteResult result = await response.Content.ReadFromJsonAsync<DeleteResult>();

			//	if (result == null)
			//	{
			//		Console.WriteLine($"Client.AdminService.Delete() : Can't login to Server");
			//		//var error = new LoginResult { Successful = false, Error = "Can't login to Server" };
			//		var error = new DeleteResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Can't login to Server" };
			//		return error;
			//	}
			//	//	if (result.Successful)
			//	if (result.Successful == SuccessfulEnum.Successful)
			//	{
			//		Console.WriteLine($"Client.AdminService.Delete() : Delete Successfuly");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"Client.AdminService.Delete() : Delete Not Successfuly");
			//	}
			//	return result;
			//}
			//catch (Exception ecx) when (LogError(ecx))
			//{
			//	Console.WriteLine("Client.AdminService.Delete() Exception : ");
			//	Console.WriteLine(ecx.Message);
				var error = new DeleteResult { Successful = SuccessfulEnum.NotSuccessful };
			//	Console.WriteLine($"Client.AdminService.Delete() : end with Exception");
				return error;
			//}
		}
       

        // ===================== User ========================
        //[HttpGet(WebApiAuthenticationAdmin.GetUsers)]
        //public async Task<List<UserViewModel>> GetUsers()
		public async Task<List<UserViewModel>> GetUsers()
		{
			Console.WriteLine($"Client.AdminService.GetUsers() : start");
			List<UserViewModel> resultEmpty = new List<UserViewModel>();
			//try
			//{
			//	//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
			//	//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
			//	//{
			//	//	Console.WriteLine($"Client.AdminService.GetUsers() : ERROR Authentication Server Url is Empty. Can't get user from Server");
			//	//	return resultEmpty;
			//	//}

			//	string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.GetUsers);
			//	Console.WriteLine($"Client.AdminService.GetUsers() : request {request}");			  //"api/admin/getusers"
			//	List<UserViewModel> result = await this._httpClient.GetFromJsonAsync<List<UserViewModel>>(request); 

			//	if (result == null)
			//	{
			//		Console.WriteLine($"Client.AdminService.GetUsers() : Can't login to Server");
			//		 return resultEmpty;
			//	}
			//	return result;
			//}
			//catch (Exception ecx) when (LogError(ecx))
			//{
			//	Console.WriteLine("Client.AdminService.GetUsers() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//	Console.WriteLine($"Client.AdminService.GetUsers() : end with Exception");
				return resultEmpty;
			//}
		}
     
        // ==================  Role   ========================
        //[HttpGet(WebApiAuthenticationAdmin.GetRoles)]
        //public async Task<List<RoleModel>> GetRoles()
		public async Task<List<RoleModel>> GetRoles()
		{
			Console.WriteLine($"Client.AdminService.GetRoles() : start");
			List<RoleModel> resultEmpty = new List<RoleModel>();
			//try
			//{
			//	//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
			//	//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
			//	//{
			//	//	Console.WriteLine($"Client.AdminService.GetRoles() : ERROR Authentication Server Url is Empty. Can't get user from Server");
			//	//	return resultEmpty;
			//	//}

			//	string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.GetRoles);
			//	Console.WriteLine($"Client.AdminService.GetRoles() : request {request}");			  //"api/admin/getusers"
			//	List<RoleModel> result = await this._httpClient.GetFromJsonAsync<List<RoleModel>>(request); 

			//	if (result == null)
			//	{
			//		Console.WriteLine($"Client.AdminService.GetRoles() : Can't login to Server");
			//		 return resultEmpty;
			//	}
			//	return result;
			//}
			//catch (Exception ecx) when (LogError(ecx))
			//{
			//	Console.WriteLine("Client.AdminService.GetRoles() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//	Console.WriteLine($"Client.AdminService.GetRoles() : end with Exception");
				return resultEmpty;
			//}
		}
    
		//TO DO !!!
		//[HttpPost(WebApiAuthenticationAdmin.UpdateUsersInRole)]
  //      public async Task<RoleResult> UpdateUsersInRole([FromBody] RoleModel roleModel)
		public async Task<RoleResult> UpdateUsersInRole(RoleModel roleModel)
		{
			Console.WriteLine($"Client.AdminService.GetUsersInRole() : start");
			RoleResult resultEmpty = new RoleResult();
			//try
			//{
			//	//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
			//	//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
			//	//{
			//	//	Console.WriteLine($"Client.AdminService.GetUsersInRole() : ERROR Authentication Server Url is Empty. Can't get user from Server");
			//	//	return resultEmpty;
			//	//}

			//	string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.UpdateUsersInRole);
			//	Console.WriteLine($"Client.AdminService.GetUsersInRole() : request {request}");			  //"api/admin/getusers"

			//	HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<RoleModel>(request, roleModel);
			//	RoleResult result = await response.Content.ReadFromJsonAsync<RoleResult>();

			//	if (result == null)
			//	{
			//		Console.WriteLine($"Client.AdminService.GetUsersInRole() : Can't login to Server");
			//		 return resultEmpty;
			//	}
			//	return result;
			//}
			//catch (Exception ecx) when (LogError(ecx))
			//{
			//	Console.WriteLine("Client.AdminService.GetUsersInRole() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//	Console.WriteLine($"Client.AdminService.GetUsersInRole() : end with Exception");
				return resultEmpty;
			//}
		}


        //Заполняем форму редактирования 
        //[HttpPost(WebApiAuthenticationAdmin.RoleWithUsers)]
        //public async Task<RoleModel> RoleWithUsers([FromBody] string roleId)
		public async Task<RoleModel> RoleWithUsers(string roleId)
		{
			Console.WriteLine($"Client.AdminService.RoleWithUsers() : start");
			RoleModel resultEmpty = new RoleModel();
			//if (string.IsNullOrWhiteSpace(roleId))
			//{
			//	Console.WriteLine($"Client.AdminService.RoleWithUsers() :  roleId is empty");
			//	return resultEmpty;
			//}
			//try
			//{
			//	//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
			//	//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
			//	//{
			//	//	Console.WriteLine($"Client.AdminService.RoleWithUsers() : ERROR Authentication Server Url is Empty. Can't get user from Server");
			//	//	Console.WriteLine($"Client.AdminService.RoleWithUsers() : end");
			//	//	return resultEmpty;
			//	//}

			//	string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.RoleWithUsers);
			//	Console.WriteLine($"Client.AdminService.RoleWithUsers() : request {request}");
			//	HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, roleId);
			//	RoleModel result = await response.Content.ReadFromJsonAsync<RoleModel>();

			//	if (result == null)
			//	{
			//		Console.WriteLine($"Client.AdminService.RoleWithUsers() : Can't login to Server");
			//		return resultEmpty;
			//	}
			//	return result;
			//}
			//catch (Exception ecx) when (LogError(ecx))
			//{
			//	Console.WriteLine("Client.AdminService.RoleWithUsers() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//	Console.WriteLine($"Client.AdminService.RoleWithUsers() : end with Exception");
				return resultEmpty;
			//}
		}
   

        //[HttpPost(WebApiAuthenticationAdmin.UpdateUsersInRole)]
        //public async Task<List<RoleModificationResult>> UpdateUsersInRole([FromBody] RoleModificationModel model)
		public async Task<List<RoleModificationResult>> UpdateUsersInRole( RoleModificationModel model)
		{
			List<RoleModificationResult> resultEmpty = new List<RoleModificationResult>();
			//Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : start");
			//if (model == null)
			//{
			//	Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : in deleteModel is null");
			//	Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : end");
			//	return resultEmpty;
			//}
			//try
			//{
			//	//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
			//	//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
			//	//{
			//	//	Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : ERROR Authentication Server Url is Empty. Can't get user from Server");
			//	//	Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : end");
			//	//	return resultEmpty;
			//	//}

			//	string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.UpdateUsersInRole);
			//	Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : request {request}");
			//	HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<RoleModificationModel>(request, model);
			//	List<RoleModificationResult> result = await response.Content.ReadFromJsonAsync<List<RoleModificationResult>>();

			//	if (result == null)
			//	{
			//		Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : Can't login to Server");
			//		Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : end");
			//		return resultEmpty;
			//	}
			//	return result;
			//}
			//catch (Exception ecx) when (LogError(ecx))
			//{
			//	Console.WriteLine("Client.AdminService.UpdateUsersInRole() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//	Console.WriteLine($"Client.AdminService.UpdateUsersInRole() : end with Exception");
				return resultEmpty;
			//}
		}
     


		static bool LogError(Exception ex)
		{
			return true;
		}
	}
}