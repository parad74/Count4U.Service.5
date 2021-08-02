using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
//using Blazored.LocalStorage;
//using Blazored.SessionStorage;
using Count4U.Model.Count4U;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Monitor.Service.Model;
using Monitor.Service.Urls;


namespace Count4U.Admin.Client.Page
{
	public class UserGridBase : ComponentBase
	{
		protected List<UserViewModel> _users { get; set; }
		protected string _userID { get; set; } = "";
		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }
		public string SessionAuthenticationServer { get; set; }


		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		protected IProfileModel _profileModel { get; set; }

		//[Inject]
		//protected ISessionStorageService _sessionStorage { get; set; }

		//[Inject]
		//protected ILocalStorageService _localStorage { get; set; }

		[Inject]
		protected IJwtService _jwtService { get; set; }

		[Inject]
		protected IAdminService _adminService { get; set; }

		//[Inject]
		//protected HttpClient Http { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		public UserGridBase()
		{
			this._users = null;
		}

		protected async Task GetUsers()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserGridBase.GetRoles() : start");

			if (this._adminService == null)
			{
				Console.WriteLine($"Client.UserGridBase.GetRoles() : _adminService is null");
				this._users = new List<UserViewModel>();
			}
			else
			{
				try
				{
					this._users = await this._adminService.GetUsers();
			
					if (this._users != null)
					{
						Console.WriteLine($"Client.UserGridBase.GetRoles() : count roles {this._users.Count}");
					}
					else
					{
						Console.WriteLine("Client.UserGridBase.GetRoles() : roles is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.UserGridBase.GetRoles() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.UserGridBase.GetRoles() : end");
			}
		}

	   //https://blazor-university.com/javascript-interop/calling-javascript-from-dotnet/ - dialog
	   //https://chrissainty.com/using-javascript-interop-in-razor-components-and-blazor/ JS
		public async Task UserDelete(string userId)
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserGridBase.UserDelete() : start");

			if (this._adminService == null)
			{
				Console.WriteLine($"Client.UserGridBase.UserDelete() : _adminService is null");
			}
			else
			{
				try
				{
					var result = await this._adminService.Delete(new DeleteModel() { ApplicationUserID = userId });
					this._users = await this._adminService.GetUsers();
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.UserGridBase.GetRoles() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.UserGridBase.GetRoles() : end");
				//this.StateHasChanged();
			}
		}

		public async Task UserChangePassword(string roleId)
		{
            this._navigationManager.NavigateTo("/userchangepassword/" + roleId);
		}

		public async Task UserAdd()
		{
			this._navigationManager.NavigateTo("/useradd");
		}


		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : start");
			try
			{
				//string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
				//Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : got Token");
				//this._profileModel = this._jwtService.GetProfileModelFromStoragedToken(tokenFromStorage);
				//this._userID = this._profileModel.ID;
				//Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : _userID = {this._userID} ");
				//Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : got _profileModel");
		
				//this.SessionStorageMode = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.hostMode);
				//this.SessionAuthenticationServer = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);

				await this.SetAuthenticationServer();
				Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : got AuthenticationServer Adress");
				await this.GetUsers();
				Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : GetAuthenticationUrls");
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : end");
		}

		protected async Task SetAuthenticationServer()
		{
			try
			{
				//if (this._localStorage != null)
				//{
				//	string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				//	this.SessionAuthenticationServer = authenticationWebapiUrl;
				//}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.UserGridBase.SetAuthenticationServer() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}


		//public async Task AuthenticationServerClicked()
		//{
		//	try
		//	{
		//		if (this._localStorage != null)
		//		{
		//			await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, this.SessionAuthenticationServer);
		//			this._navigationManager.NavigateTo("/Logout");
		//		}
		//	}
		//	catch (Exception ecx)
		//	{
		//		Console.WriteLine("Client.RoleGridBase.AuthenticationServerClicked() Exception : ");
		//		Console.WriteLine(ecx.Message);
		//	}

	//}
	}
}

