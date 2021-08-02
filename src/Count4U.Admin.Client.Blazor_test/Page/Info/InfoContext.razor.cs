using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
//using Blazored.LocalStorage;
//using Blazored.SessionStorage;
using Count4U.Model.Audit;
using Count4U.Model.Main;
using Count4U.Model.ProcessC4U;
using Count4U.Service.Shared;
using Count4U.Service.Shared.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;
using Monitor.Service.Urls;


namespace Count4U.Admin.Client.Page
{
	[Authorize]
	public class InfoContextBase : ComponentBase
	{
		protected string _userID { get; set; } = "";
		protected List<string> _urls { get; set; }
		protected List<string> _urls2 { get; set; }
		protected List<string> _urls3 { get; set; }
		protected List<string> _urls4 { get; set; }

		protected Processes _processes { get; set; }
		protected List<Customer> _customeres { get; set; }
		protected List<Branch> _branches { get; set; }
		protected List<Inventor> _inventors { get; set; }
		public string PingServer { get; set; }
		public string SessionStorageMode { get; set; }
		public string SessionAuthenticationServer { get; set; }
		public string StorageMonitorWebApiUrl { get; set; }
		public string StorageSignalRHubUrl { get; set; }


		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		protected IConfiguration Configuration { get; set; }

		[Inject]
		protected IProfileModel _profileModel { get; set; }

		[Inject]
		protected IProcessService _processService { get; set; }

		[Inject]
		protected ICustomerService _customerService { get; set; }

		[Inject]
		protected IBranchService _branchService { get; set; }

		[Inject]
		protected IInventorService _inventorService { get; set; }

		[Inject]
		protected IWebAPISettingsService _webAPISettingsService { get; set; }

		[Inject]
		protected IWebAPISettings _webAPISettings { get; set; }

		//[Inject]
		//protected ISessionStorageService _sessionStorage { get; set; }

		//[Inject]
		//protected ILocalStorageService _localStorage { get; set; }

		[Inject]
		protected IJwtService _jwtService { get; set; }

		[Inject]
		protected IJSRuntime JSRuntime  { get; set; }

		[Inject]
		protected IClaimService _claimService { get; set; }

		[Inject]
		protected HttpClient Http { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected IImportFromPdaService _importFromPdaService { get; set; }

		//[Inject]
		//protected IAdapterInitialazeService _adapterInitialazeService  { get; set; }

		public InfoContextBase()
		{
			this._urls = null;
			this._urls2 = null;
			this._urls3 = null;
			this._urls4 = null;
			this._processes = null;
			this._customeres = null;
			this._branches = null;
			this._inventors = null;
		}


		protected async Task SetAuthenticationServer()
		{
			try
			{
				//if (this._localStorage != null)
				//{
				//	string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				//	this.SessionAuthenticationServer = authenticationWebapiUrl;
				//	this._webAPISettings.authenticationWebapiUrl = authenticationWebapiUrl;   //??
				//}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.InfoContextBase.SetAuthenticationServer() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}

		protected async Task SetMonitorWebapiUrl()
		{
			try
			{
				//if (this._localStorage != null)
				//{
				//	string monitorWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
				//	this.StorageMonitorWebApiUrl = monitorWebapiUrl;
				//	this._webAPISettings.monitorWebapiUrl = monitorWebapiUrl;   //??
				//}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.InfoContextBase.SetMonitorServer() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}

		protected async Task SetSignalRHubUrl()
		{
			//try
			//{
			//	if (this._localStorage != null)
			//	{
			//		string signalRHubUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
			//		this.StorageSignalRHubUrl = signalRHubUrl;
			//		this._webAPISettings.signalRHubUrl = signalRHubUrl;   //??
			//	}
			//}
			//catch (Exception ecx)
			//{
			//	Console.WriteLine("Client.InfoContextBase.SetSignalRHubUrl() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//}
		}



		public async Task MonitorWebapiUrlSet()
		{
			try
			{
				this._webAPISettings.monitorWebapiUrl = this.StorageMonitorWebApiUrl;    //??

				//if (this._localStorage != null)
				//{
				//	await this._localStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrl, this.StorageMonitorWebApiUrl);
				//}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.InfoContextBase.MonitorWebapiUrlSet() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}

		public async Task SignalRHubUrlSet()
		{
			try
			{
				this._webAPISettings.monitorWebapiUrl = this.StorageSignalRHubUrl;    //??

				//if (this._localStorage != null)
				//{
				//	await this._localStorage.SetItemAsync(SessionStorageKey.signalRHubUrl, this.StorageSignalRHubUrl);
				//}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.InfoContextBase.SignalRHubUrlSet() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}

		public async Task AuthenticationServerClicked()
		{
			try
			{
				this._webAPISettings.authenticationWebapiUrl = this.SessionAuthenticationServer;    //??

				//if (this._localStorage != null)
				//{
				//	await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, this.SessionAuthenticationServer);
				//	this._navigationManager.NavigateTo("/Logout");
				//}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.InfoContextBase.AuthenticationServerClicked() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}

		protected async Task LogUsername()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.LogUsername() : start");
			if (this.AuthenticationStateProvider == null)
			{
				Console.WriteLine($"Client.InfoContextBase.LogUsername() : AuthenticationStateProvider is null");
			}
			else
			{
				try
				{
					var authState = await this.AuthenticationStateProvider.GetAuthenticationStateAsync();
					if (authState != null)
					{
						var user = authState.User;
						if (user != null)
						{
							if (user.Identity != null)
							{
								if (user.Identity.IsAuthenticated)
								{
									Console.WriteLine($"Client.InfoContextBase.LogUsername() : {user.Identity.Name} is authenticated.");
									Console.WriteLine($"Client.InfoContextBase.LogUsername() : end");
									//		_logger.LogInformation($"{user.Identity.Name} is authenticated.");
									return;
								}
							}
						}
					}
					Console.WriteLine("Client.InfoContextBase.LogUsername() : the user is NOT authenticated.");
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.InfoContextBase.LogUsername() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.InfoContextBase.LogUsername() : end");
			}
		}

		protected List<string> Items = new List<string>();
		protected string selectedItem = "";
		protected void InventorClicked(ChangeEventArgs e)
		{
			string selectedItem = e.Value.ToString();
		}
		protected async Task GetInventors()
		{

			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetInventors() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetInventors() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == true)
			{
				Console.WriteLine($"Client.InfoContextBase.GetInventors() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._inventorService == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetInventors() : _inventorService is null");
			}
			else
			{
				try
				{
					this._inventors = await this._inventorService.GetInventoresByCurrnetBranch(this._profileModel.DataServerAddress);
					this.Items = this._inventors.Select(x => x.Code).ToList();
					if (this._inventors != null)
					{
						Console.WriteLine($"Client.InfoContextBase.GetInventors() : count inventors {this._inventors.Count}");
					}
					else
					{
						Console.WriteLine("Client.InfoContextBase.GetInventors() : inventors is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.InfoContextBase.GetInventors() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.InfoContextBase.GetInventors() : end");
			}

		}


		protected async Task GetBranches()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetBranches() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetBranches() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == true)
			{
				Console.WriteLine($"Client.InfoContextBase.GetBranches() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._branchService == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetBranches() :_branchService is null");
			}
			else
			{
				try
				{
					this._branches = await this._branchService.GetBranchesByCurrnetCustomer(this._profileModel.DataServerAddress);
					if (this._branches != null)
					{
						Console.WriteLine($"Client.InfoContextBase.GetBranches() : count branches {this._branches.Count}");
					}
					else
					{
						Console.WriteLine("Client.InfoContextBase.GetBranches() : branches is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.InfoContextBase.GetBranches() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.InfoContextBase.GetBranches() : end");
			}
		}



		protected async Task GetCustomers()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetCustomers() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetCustomers() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == true)
			{
				Console.WriteLine($"Client.InfoContextBase.GetCustomers() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._customerService == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetCustomers() : _customerService is null");
			}
			else
			{
				try
				{
					this._customeres = await this._customerService.GetCustomers(this._profileModel.DataServerAddress);
					if (this._customeres != null)
					{
						Console.WriteLine($"Client.InfoContextBase.GetCustomers() : count customeres {this._customeres.Count}");
					}
					else
					{
						Console.WriteLine("Client.InfoContextBase.GetCustomers() : customeres is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.InfoContextBase.GetCustomers() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.InfoContextBase.GetCustomers() : end");
			}
		}


		protected async Task GetProcesses()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetProcesses() : start");
			if (this._profileModel == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetProcesses() : _profileModel is null");
			}
			else if (string.IsNullOrWhiteSpace(this._profileModel.DataServerAddress) == true)
			{
				Console.WriteLine($"Client.InfoContextBase.GetProcesses() : _profileModel.DataServerAddress is Empty");
			}
			else if (this._processService == null)
			{
				Console.WriteLine($"Client.InfoContextBase.GetProcesses() : _processService is null");
			}
			else
			{
				try
				{
					this._processes = await this._processService.GetProcesses(this._profileModel.DataServerAddress);
					if (this._processes != null)
					{
						Console.WriteLine($"Client.InfoContextBase.GetProcesses() : count processes {this._processes.Count}");
					}
					else
					{
						Console.WriteLine("Client.InfoContextBase.GetProcesses() : processes is null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.InfoContextBase.GetProcesses() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.InfoContextBase.GetProcesses() : end");
			}
		}

		protected void ChangePasswordClicked()
		{
			try
			{
				this._navigationManager.NavigateTo("/userchangepassword/" + _userID);
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.InfoContextBase.ChangePasswordClicked() Exception : ");
				Console.WriteLine(ecx.Message);
			}

		}

	

		//protected async Task GetUrls()
		//{
		//	Console.WriteLine();
		//	Console.WriteLine($"Client.InfoContextBase.GetUrls() : start");
		//	if (_webAPISettingsService == null)
		//	{
		//		Console.WriteLine($"Client.InfoContextBase.GetUrls() : _webAPISettingsService is null");
		//	}
		//	else
		//	{
		//		try
		//		{
		//			Console.WriteLine($"Client.InfoContextBase.GetUrls() : _webAPISettingsService have got");
		//			var url = await _webAPISettingsService.GetWebApiUrls("InfoContextBase");
		//			if (url == null)
		//			{
		//				Console.WriteLine($"Client.InfoContextBase.GetUrls() : url is null");
		//			}
		//			else
		//			{
		//				Console.WriteLine($"Client.InfoContextBase.GetUrls() : Url got : {url}");
		//				_urls = url.Split(';').ToList();
		//				if (_urls != null)
		//				{
		//					Console.WriteLine($"Client.InfoContextBase.GetUrls() : Count Urls {_urls.Count}");
		//				}
		//				else
		//				{
		//					Console.WriteLine("Client.InfoContextBase.GetUrls() : urls is null");
		//				}
		//			}
		//		}
		//		catch (Exception ecx)
		//		{
		//			Console.WriteLine("Client.InfoContextBase.GetUrls() Exception : ");
		//			Console.WriteLine(ecx.Message);
		//		}
		//		Console.WriteLine($"Client.InfoContextBase.GetUrls() : end");
		//	}
		//}

		//protected async Task GetCount4UModelUrls()
		//{
		//	Console.WriteLine();
		//	Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : start");
		//	if (_webAPISettings == null)
		//	{
		//		Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : _webAPISettings is null");
		//	}
		//	else
		//	{
		//		try
		//		{
		//			Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : _webAPISettings have got");
		//			var url = _webAPISettings.count4uWebapiUrls;
		//			if (url == null)
		//			{
		//				Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : url is null");
		//			}
		//			else
		//			{
		//				Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : Url got : {url}");
		//				_urls = url.Split(';').ToList();
		//				if (_urls != null)
		//				{
		//					Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : Count Urls {_urls.Count}");
		//				}
		//				else
		//				{
		//					Console.WriteLine("Client.InfoContextBase.GetCount4UModelUrls() : urls is null");
		//				}
		//			}
		//		}
		//		catch (Exception ecx)
		//		{
		//			Console.WriteLine("Client.InfoContextBase.GetCount4UModelUrls() Exception : ");
		//			Console.WriteLine(ecx.Message);
		//		}
		//		Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : end");
		//	}
		//}

		//await _sessionStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, _webAPISettings.authenticationWebapiUrl);

		//await _sessionStorage.SetItemAsync(SessionStorageKey.count4uWebapiUrls, _webAPISettings.count4uWebapiUrls);
		protected async Task GetCount4UModelUrls()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : start");

			//try
			//{
			//	string url = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.count4uWebapiUrls);
			//	if (url == null)
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : url is null");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : Url got : {url}");
			//		this._urls = url.Split(';').ToList();
			//		if (this._urls != null)
			//		{
			//			Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : Count Urls {this._urls.Count}");
			//		}
			//		else
			//		{
			//			Console.WriteLine("Client.InfoContextBase.GetCount4UModelUrls() : urls is null");
			//		}
			//	}
			//}
			//catch (Exception ecx)
			//{
			//	Console.WriteLine("Client.InfoContextBase.GetCount4UModelUrls() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//}
			//Console.WriteLine($"Client.InfoContextBase.GetCount4UModelUrls() : end");
		 //  await JSRuntime.InvokeVoidAsync("console.log", "GetCount4UModelUrls", _urls);
		}

		//await _sessionStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrls, _webAPISettings.authenticationWebapiUrls);
		protected async Task GetAuthenticationUrls()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : start");

			//try
			//{
			//	string url = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrls);
			//	if (url == null)
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : url is null");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : Url got : {url}");
			//		this._urls2 = url.Split(';').ToList();
			//		if (this._urls2 != null)
			//		{
			//			Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : Count Urls {this._urls2.Count}");
			//		}
			//		else
			//		{
			//			Console.WriteLine("Client.InfoContextBase.GetAuthenticationUrls() : urls is null");
			//		}
			//	}
			//}
			//catch (Exception ecx)
			//{
			//	Console.WriteLine("Client.InfoContextBase.GetAuthenticationUrls() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//}
			//Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : end");
			//await JSRuntime.InvokeVoidAsync("console.log", "GetAuthenticationUrls", _urls2);
		}

		protected async Task GetMonitorUrls()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetMonitorUrls() : start");

			//try
			//{
			//	string url = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrls);
			//	if (url == null)
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetMonitorUrls() : url is null");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetMonitorUrls() : Url got : {url}");
			//		this._urls3 = url.Split(';').ToList();
			//		if (this._urls3 != null)
			//		{
			//			Console.WriteLine($"Client.InfoContextBase.GetMonitorUrls() : Count Urls {this._urls3.Count}");
			//		}
			//		else
			//		{
			//			Console.WriteLine("Client.InfoContextBase.GetMonitorUrls() : urls is null");
			//		}
			//	}
			//}
			//catch (Exception ecx)
			//{
			//	Console.WriteLine("Client.InfoContextBase.GetMonitorUrls() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//}
			//Console.WriteLine($"Client.InfoContextBase.GetMonitorUrls() : end");
			//await JSRuntime.InvokeVoidAsync("console.log", "GetMonitorUrls", _urls3);
		}


		protected async Task GetSignalRHubUrls()
		{
			//Console.WriteLine();
			//Console.WriteLine($"Client.InfoContextBase.GetSignalRHubUrls() : start");

			//try
			//{
			//	string url = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrls);
			//	if (url == null)
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetSignalRHubUrls() : url is null");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.GetSignalRHubUrls() : Url got : {url}");
			//		this._urls4 = url.Split(';').ToList();
			//		if (this._urls4 != null)
			//		{
			//			Console.WriteLine($"Client.InfoContextBase.GetSignalRHubUrls() : Count Urls {this._urls4.Count}");
			//		}
			//		else
			//		{
			//			Console.WriteLine("Client.InfoContextBase.GetSignalRHubUrls() : urls is null");
			//		}
			//	}
			//}
			//catch (Exception ecx)
			//{
			//	Console.WriteLine("Client.InfoContextBase.GetMonitorUrls() Exception : ");
			//	Console.WriteLine(ecx.Message);
			//}
			//Console.WriteLine($"Client.InfoContextBase.GetMonitorUrls() : end");

		}

		//protected async Task GetAuthenticationUrls()
		//{
		//	Console.WriteLine();
		//	Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : start");
		//	if (_webAPISettings == null)
		//	{
		//		Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : _webAPISettings is null");
		//	}
		//	else
		//	{
		//		try
		//		{
		//			Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : _webAPISettings have got");
		//			var url = _webAPISettings.authenticationWebapiUrls;
		//			if (url == null)
		//			{
		//				Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : url is null");
		//			}
		//			else
		//			{
		//				Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : Url got : {url}");
		//				_urls2 = url.Split(';').ToList();
		//				if (_urls2 != null)
		//				{
		//					Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : Count Urls {_urls2.Count}");
		//				}
		//				else
		//				{
		//					Console.WriteLine("Client.InfoContextBase.GetAuthenticationUrls() : urls is null");
		//				}
		//			}
		//		}
		//		catch (Exception ecx)
		//		{
		//			Console.WriteLine("Client.InfoContextBase.GetAuthenticationUrls() Exception : ");
		//			Console.WriteLine(ecx.Message);
		//		}
		//		Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : end");
		//	}
		//}

		protected override async Task OnInitializedAsync()
		{
			//Console.WriteLine();
			//Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : start");
			//try
			//{
			//	if (this._sessionStorage == null)
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : _sessionStorage is null");
			//	}
			//	else if (this._jwtService == null)
			//	{
			//		Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : _jwtService is null");
			//	}
			//	else
			//	{
			//		string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
			//		Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : got Token");
			//		this._profileModel = this._jwtService.GetProfileModelFromStoragedToken(tokenFromStorage);
			//		this._userID = this._profileModel.ID;
			//		Console.WriteLine($"Client.ProfileBase.OnInitializedAsync() : _userID = {this._userID} ");
			//		if (this._profileModel != null)
			//		{
			//			Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : got _profileModel");

			//			//ProfileModel = await ClaimService.GetProfileModelFromServerAsync(); //это с сервера
			//			//C4UViewModel = await ClaimService.GetProfileModelAsync();
			//			string result = await this._claimService.PingServerAsync();
			//			this.PingServer = "CLIENT";
			//			if (result == PingOpetarion.Pong)
			//				this.PingServer = "SERVER";

			//			//this.SessionStorageMode = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.hostMode);
			//			//this.SessionAuthenticationServer = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
			//			//this.StorageMonitorWebApiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
			//			//this.StorageSignalRHubUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);


			//			await this.SetAuthenticationServer();
			//			Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : got AuthenticationServer Adress");
			//			await this.SetMonitorWebapiUrl();
			//			Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : got Monitor DB Webapi Url");
			//			await this.SetSignalRHubUrl();
			//			Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : got SignalR Hub Url");

			//			await this.GetAuthenticationUrls();
			//			Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : GetAuthenticationUrls");
			//			await this.GetMonitorUrls();
			//			Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : GetMonitorUrls");
			//			await this.GetSignalRHubUrls();
			//			Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : GetSignalRHubUrls");
						
			//		}
			//	}
			//}
			//catch (Exception exc)
			//{
			//	Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() Exception :");
			//	Console.WriteLine(exc.Message);
			//}
			//Console.WriteLine($"Client.InfoContextBase.OnInitializedAsync() : end");
		}
	}
}

