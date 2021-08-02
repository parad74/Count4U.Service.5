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
	public class RoleGridBase : ComponentBase
	{
		protected List<RoleModel> _roles { get; set; }
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

		public RoleGridBase()
		{
			this._roles = null;
		}

		protected async Task GetRoles()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.RoleGridBase.GetRoles() : start");

			if (this._adminService == null)
			{
				Console.WriteLine($"Client.RoleGridBase.GetRoles() : _adminService is null");
				this._roles = new List<RoleModel>();
			}
			else
			{
				try
				{
					this._roles = await this._adminService.GetRoles();
			
					if (this._roles != null)
					{
						Console.WriteLine($"Client.RoleGridBase.GetRoles() : count roles {this._roles.Count}");
					}
					else
					{
						Console.WriteLine("Client.RoleGridBase.GetRoles() : roles is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.RoleGridBase.GetRoles() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.RoleGridBase.GetRoles() : end");
			}
		}


		public async Task RoleEdit(string roleId)
		{
            this._navigationManager.NavigateTo("/roleedit/" + roleId);
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			//Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : start");
			//try
			//{
			//	string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
			//	Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : got Token");
			//	this._profileModel = this._jwtService.GetProfileModelFromStoragedToken(tokenFromStorage);
			//	this._userID = this._profileModel.ID;
			//	Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : _userID = {this._userID} ");
			//	Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : got _profileModel");
		
			//	this.SessionStorageMode = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.hostMode);
			//	this.SessionAuthenticationServer = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);

			//	await this.SetAuthenticationServer();
			//	Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : got AuthenticationServer Adress");
			//	await this.GetRoles();
			//	Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : GetAuthenticationUrls");
			//}
			//catch (Exception exc)
			//{
			//	Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() Exception :");
			//	Console.WriteLine(exc.Message);
			//}
			//Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : end");
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
				Console.WriteLine("Client.RoleGridBase.SetAuthenticationServer() Exception : ");
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

