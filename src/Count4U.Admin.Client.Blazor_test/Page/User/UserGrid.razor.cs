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


namespace Count4U.Service.Client.Page
{
	public class UserGridBase : ComponentBase
	{
		protected List<Location> _locations { get; set; }
		protected string _userID { get; set; } = "";
		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }
		public string SessionAuthenticationServer { get; set; }

		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		protected IProfileModel _profileModel { get; set; }

		[Inject]
		protected ILocationService _locationService { get; set; }

		//[Inject]
		//protected ISessionStorageService _sessionStorage { get; set; }

		//[Inject]
		//protected ILocalStorageService _localStorage { get; set; }

		[Inject]
		protected IJwtService _jwtService { get; set; }

		[Inject]
		protected IClaimService _claimService { get; set; }

		[Inject]
		protected HttpClient Http { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		public UserGridBase()
		{
			this._locations = null;
		}

		protected List<string> Items = new List<string>();
		protected string selectedItem = "";
		protected void InventorClicked(ChangeEventArgs e)
		{
			string selectedItem = e.Value.ToString();
		}
		protected async Task GetLocations()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.UserGridBase.GetLocations() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.UserGridBase.GetLocations() : _profileModel is null");
				this._locations = new List<Location>();
			}
			else if (string.IsNullOrWhiteSpace(this._profileModel.DBPath) == true)
			{
				Console.WriteLine($"Client.UserGridBase.GetLocations() : _profileModel.DataServerAddress is Empty");
				this._locations = new List<Location>();
			}
			else if (this._locationService == null)
			{
				Console.WriteLine($"Client.UserGridBase.GetLocations() : _locationService is null");
				this._locations = new List<Location>();
			}
			else
			{
				try
				{
					this._locations = await this._locationService.GetLocations(this._profileModel.DataServerAddress);
					this.Items = this._locations.Select(x => x.Code).ToList();
					if (this._locations != null)
					{
						Console.WriteLine($"Client.UserGridBase.GetLocations() : count locations {this._locations.Count}");
					}
					else
					{
						Console.WriteLine("Client.UserGridBase.GetLocations() : locations is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.UserGridBase.GetLocations() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.UserGridBase.GetLocations() : end");
			}
		}


	
		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			//Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : start");
			//try
			//{
			//	string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
			//	Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : got Token");
			//	this._profileModel = this._jwtService.GetProfileModelFromStoragedToken(tokenFromStorage);
			//	this._userID = this._profileModel.ID;
			//	Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : _userID = {this._userID} ");
			//	Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : got _profileModel");

			//	//ProfileModel = await ClaimService.GetProfileModelFromServerAsync(); //это с сервера
			//	//C4UViewModel = await ClaimService.GetProfileModelAsync();
			//	string result = await this._claimService.PingServerAsync();
			//	this.PingServer = "CLIENT";
			//	if (result == PingOpetarion.Pong)
			//		this.PingServer = "SERVER";

			//	//this.SessionStorageMode = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.hostMode);
			//	//this.SessionAuthenticationServer = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);

			//	await this.SetAuthenticationServer();
			//	Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : got AuthenticationServer Adress");
			//	await this.GetLocations();
			//	//await GetIturs();
			//	Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : GetAuthenticationUrls");
			//}
			//catch (Exception exc)
			//{
			//	Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() Exception :");
			//	Console.WriteLine(exc.Message);
			//}
			//Console.WriteLine($"Client.UserGridBase.OnInitializedAsync() : end");
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


		public async Task AuthenticationServerClicked()
		{
			try
			{
				//if (this._localStorage != null)
				//{
				//	await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, this.SessionAuthenticationServer);
				//	this._navigationManager.NavigateTo("/Logout");
				//}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.UserGridBase.AuthenticationServerClicked() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}
	}
}

