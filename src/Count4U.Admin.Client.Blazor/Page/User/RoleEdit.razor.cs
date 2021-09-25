using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Count4U.Admin.Client.Blazor.I18nText;
using Count4U.Model.Count4U;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Monitor.Service.Model;
using Monitor.Service.Urls;


namespace Count4U.Admin.Client.Page
{
	public class RoleEditBase : ComponentBase
	{
		 [Parameter]
        public string roleID { get; set; }

		public RoleModel _role { get; set; } = new RoleModel();
		
		public RoleResult _roleResult  { get; set; }

		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }
		public string SessionAuthenticationServer { get; set; }

		public GetResources LocalizationResources { get; set; }

		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		protected IProfileModel _profileModel { get; set; }

		[Inject]
		protected ILocationService _locationService { get; set; }

		[Inject]
		protected ISessionStorageService _sessionStorage { get; set; }

		[Inject]
		protected ILocalStorageService _localStorage { get; set; }

		[Inject]
		protected IJwtService _jwtService { get; set; }

		[Inject]
		protected IAdminService _adminService { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		public RoleEditBase()
		{

		}

		protected async Task UpdateRoleAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.RoleEdit.UpdateRoleAsync() : start");
			_roleResult = null;
			
			//foreach (UserViewModel user in _role.NonMembers)
   //         {
   //         	if (user.ToAdd == true)
			//	{
			//		 Console.WriteLine($"{user.Email}");
			//	}
                    
   //         }
			// foreach (UserViewModel user in _role.Members)
   //         {
   //         	if (user.ToDelete == true)
			//	{
			//		 Console.WriteLine($"{user.Email}");
			//	}
   //         }

			if (this._adminService == null)
			{
				Console.WriteLine($"Client.RoleEditBase.UpdateRoleAsync() : _adminService is null");
			}
			else
			{
				try
				{
					this._roleResult = await _adminService.UpdateUsersInRole(_role);

					if (this._roleResult != null)
					{
						if (this._roleResult.Successful == SuccessfulEnum.Successful)
						{
							Console.WriteLine($"Client.RoleEditBase.UpdateRoleAsync() : Successful");
						}
						else
						{
							Console.WriteLine($"Client.RoleEditBase.UpdateRoleAsync() : Errors");
							Console.WriteLine($"{this._roleResult.Error}");
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.RoleEditBase.UpdateRoleAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.RoleEditBase.UpdateRoleAsync() : end");
			}

			this._navigationManager.NavigateTo("/rolegrid");
		}

		 public void Cancel()
        {
            this._navigationManager.NavigateTo("/rolegrid");
        }

		protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(roleID))
            {
				this._role = await _adminService.RoleWithUsers(roleID);
            }
        }
		
		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
				string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
				Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : got Token");
				this._profileModel = this._jwtService.GetProfileModelFromStoragedToken(tokenFromStorage);
				//Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : _userID = {this._userID} ");
				//Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : got _profileModel");
		
				this.SessionStorageMode = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.hostMode);
				this.SessionAuthenticationServer = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);

				await this.SetAuthenticationServer();
				Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : got AuthenticationServer Adress");
				Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : GetAuthenticationUrls");
			}
			catch (Exception exc)
			{
				Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() Exception :");
				Console.WriteLine(exc.Message);
			}
			Console.WriteLine($"Client.RoleGridBase.OnInitializedAsync() : end");
		}

		protected async Task SetAuthenticationServer()
		{
			try
			{
				if (this._localStorage != null)
				{
					string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
					this.SessionAuthenticationServer = authenticationWebapiUrl;
				}
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

