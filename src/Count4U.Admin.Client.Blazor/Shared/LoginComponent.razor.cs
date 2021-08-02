using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Count4U.Admin.Client.Blazor.I18nText;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Count4U.Admin.Client.Page
{
	// [Route("/LoginComponent")]
	public class LoginComponentBase : ComponentBase
	{
		protected LoginModel _loginModel = new LoginModel();
		//protected bool? _showErrors;
		//protected bool? _showSuccessful;
		//protected string _error = "";
		protected LoginResult _loginResult;
		protected List<string> _urls2 { get; set; }
		protected List<string> _urls3 { get; set; }
		protected List<string> _urls4 { get; set; }


		protected ForgotPasswordModel _forgotPasswordModel { get; set; }
		protected ForgotPasswordResult _forgotPasswordResult { get; set; }

		[Inject]
		protected NavigationManager _navigationManager { get; set; }

		[Inject]
		protected IAuthService _authService { get; set; }

		[Inject]
		protected IClaimService _claimService { get; set; }

		[Inject]
		protected HttpClient Http { get; set; }

		[Inject]
		protected ISessionStorageService _sessionStorage { get; set; }

		[Inject]
		protected ILocalStorageService _localStorage { get; set; }

		public string SessionStorageMode { get; set; }
		public string StorageAuthenticationServer { get; set; }
		public string StorageMonitorWebApiUrl { get; set; }
		public string StorageSignalRHubUrl { get; set; }
		public bool Ping { get; set; }
		public bool PingMonitor { get; set; }
		public bool PingSignalRHub { get; set; }

		[Parameter]
		public GetResources LocalizationResources { get; set; }

		public LoginComponentBase()
		{
		}

		protected async Task NavigateToRegister()
		{
			this._navigationManager.NavigateTo("/register");
		}

		protected async Task LoginAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.IndexBase.LoginAsync() : start");

			//this._showErrors = null;
			//this._showSuccessful = null;
			//this._error = "";
			this._loginResult = null;

			if (this._authService == null)
			{
				Console.WriteLine($"Client.LoginComponentBase.LoginAsync() : _authService is null");
			}
			else
			{
				try
				{
					this._loginModel.Email = @"manager@profile.ftp";
					this._loginModel.Password = "123456";
					this._loginResult = await this._authService.LoginAsync(this._loginModel);
					if (this._loginResult != null)
					{
						if (this._loginResult.Successful == SuccessfulEnum.Successful)
						{
							//this._showSuccessful = true;
							Console.WriteLine($"Client.LoginComponentBase.LoginAsync() : Successful");
							this._navigationManager.NavigateTo("/customergrid");
						}
						else
						{
							Console.WriteLine($"Client.LoginComponentBase.LoginAsync() : Errors");
							Console.WriteLine($"{this._loginResult.Error}");
							//this._error = result.Error;
							//this._showErrors = true;
						}
					}
					else
					{
						Console.WriteLine($"Client.LoginComponentBase.LoginAsync() : _loginResult id null");
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.LoginComponentBase.LoginAsync() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.LoginComponentBase.LoginAsync() : end");
			}
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine("Client.LoginComponentBase.OnInitializedAsync() : start ");
			this.SessionStorageMode = "";
			this.StorageAuthenticationServer = "";
			this.StorageMonitorWebApiUrl = "";
			this.StorageSignalRHubUrl  = "";
			this.Ping = false;
			this.PingMonitor = false;
			this.PingSignalRHub	 = false;
			this._loginModel.Email = @"manager@profile.ftp";
			this._loginModel.Password = "123456";
			try
			{
				if (this._localStorage != null)
				{
					this.StorageAuthenticationServer = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
					this.StorageMonitorWebApiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
					this.StorageSignalRHubUrl  = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageAuthenticationServer authenticationWebapiUrl Get From  Storage {this.StorageAuthenticationServer}");
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageMonitorServer monitorWebapiUrl Get From  Storage {this.StorageMonitorWebApiUrl}");
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageMonitorServer Ping 1 {this.StorageSignalRHubUrl}");

					//first time  нет ничего в 	_localStorage
					if (string.IsNullOrWhiteSpace(this.StorageAuthenticationServer) || string.IsNullOrWhiteSpace(this.StorageMonitorWebApiUrl) || string.IsNullOrWhiteSpace(this.StorageSignalRHubUrl) == true)
					{
						if (this._claimService != null && this._claimService.WebAPISettings != null)
						{
							string authenticationServerGetFromSetting = await this._claimService.InitWebAPISettings();
							if (string.IsNullOrWhiteSpace(this.StorageAuthenticationServer) == true)
							{
								this.StorageAuthenticationServer = authenticationServerGetFromSetting;
							}
							if (string.IsNullOrWhiteSpace(this.StorageMonitorWebApiUrl) == true)
							{
								this.StorageMonitorWebApiUrl = this._claimService.WebAPISettings.monitorWebapiUrl;
							}

							if (string.IsNullOrWhiteSpace(this.StorageSignalRHubUrl) == true)
							{
								this.StorageSignalRHubUrl = this._claimService.WebAPISettings.signalRHubUrl;
							}
						}
					}

					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageAuthenticationServer authenticationWebapiUrl Get From  Storage {this.StorageAuthenticationServer}");
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageMonitorServer monitorWebapiUrl Get From  Storage {this.StorageMonitorWebApiUrl}");
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageMonitorServer Ping 1 {this.StorageSignalRHubUrl}");


					if (string.IsNullOrWhiteSpace(this.StorageAuthenticationServer) == false)
					{
						Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageAuthenticationServer Ping 2");
						string result = await this._claimService.PingWebApiAuthenticationAsync();
						Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageAuthenticationServer Ping 3 result {result}");
						if (result == PingOpetarion.Pong)
						{ this.Ping = true; }
					}
				
					if (string.IsNullOrWhiteSpace(this.StorageMonitorWebApiUrl) == false)
					{
						Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageMonitorServer PingMonitor 5");
						string result = await this._claimService.PingWebApiProfileAsync();
						Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageMonitorServer PingMonitor 7 result {result}");
						if (result == PingOpetarion.Pong)
						{ this.PingMonitor = true; }
					}

					if (string.IsNullOrWhiteSpace(this.StorageSignalRHubUrl) == false)
					{
						Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageSignalRHubUrl PingSignalRHub 8");
						string result = await this._claimService.PingSignalRHubAsync();
						Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : StorageMonitorServer PingSignalRHub 9 result {result}");
						if (result == PingOpetarion.Pong)
						{ this.PingSignalRHub = true; }
					
					}

				}
				if (this._sessionStorage != null)
				{
					string hostMode = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.hostMode);
					this.SessionStorageMode = hostMode;
					await this.GetAuthenticationUrls();
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : GetAuthenticationUrls");
					await this.GetMonitorUrls();
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : GetMonitorUrls");
					await this.GetSignalRHubUrls();
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : GetSignalRHubUrls");
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.LoginComponentBase.OnInitializedAsync() Exception : ");
				Console.WriteLine(ecx.Message);
				Console.WriteLine("Client.LoginComponentBase.OnInitializedAsync() : end ");
			}

		}
		public async Task AuthenticationServerSet()
		{
			if (this._localStorage != null)
			{
				if (string.IsNullOrWhiteSpace(this.StorageAuthenticationServer) == false)
				{
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : try AuthenticationServerClicked to  {this.StorageAuthenticationServer}");
					await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, this.StorageAuthenticationServer);
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : Changed StorageAuthenticationServer to  {this.StorageAuthenticationServer}");
					Console.WriteLine($"Client.LoginComponentBase.OnInitializedAsync() : try logout");

					this._navigationManager.NavigateTo("/logout");
				}
			}

		}

		public async Task MonitorWebApiUrlSet()
		{
			if (this._localStorage != null)
			{
				if (string.IsNullOrWhiteSpace(this.StorageMonitorWebApiUrl) == false)
				{
					Console.WriteLine($"Client.LoginComponentBase.MonitorServerClicked() : try MonitorServerClicked to  {this.StorageMonitorWebApiUrl}");
					await this._localStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrl, this.StorageMonitorWebApiUrl);
					Console.WriteLine($"Client.LoginComponentBase.MonitorServerClicked() : Changed StorageMonitorServer to  {this.StorageMonitorWebApiUrl}");

				}
			}
		}

		public async Task SignalRHubSet()
		{
			if (this._localStorage != null)
			{
				if (string.IsNullOrWhiteSpace(this.StorageSignalRHubUrl) == false)
				{
					Console.WriteLine($"Client.LoginComponentBase.TaskSignalRHubSet() : try StorageSignalRHubUrl to  {this.StorageSignalRHubUrl}");
					await this._localStorage.SetItemAsync(SessionStorageKey.signalRHubUrl, this.StorageSignalRHubUrl);
					Console.WriteLine($"Client.LoginComponentBase.TaskSignalRHubSet() : Set StorageSignalRHubUrl to  {this.StorageSignalRHubUrl}");
				}
			}
		}


		protected async Task GetAuthenticationUrls()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : start");
			if (this._sessionStorage != null)
			{
				try
				{
					string url = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrls);
					if (url == null)
					{
						Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : url is null");
					}
					else
					{
						Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : Url got : {url}");
						this._urls2 = url.Split(';').ToList();
						if (this._urls2 != null)
						{
							Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : Count Urls {this._urls2.Count}");
						}
						else
						{
							Console.WriteLine("Client.InfoContextBase.GetAuthenticationUrls() : urls is null");
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.InfoContextBase.GetAuthenticationUrls() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.InfoContextBase.GetAuthenticationUrls() : end");
			}
		}

		protected async Task GetMonitorUrls()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.LoginComponentBase.GetMonitorUrls() : start");
			if (this._localStorage != null)
			{
				try
				{
					string url = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrls);
					if (url == null)
					{
						Console.WriteLine($"Client.LoginComponentBase.GetMonitorUrls() : monitorurl is null");
					}
					else
					{
						Console.WriteLine($"Client.LoginComponentBase.GetMonitorUrls() : monitorUrl got : {url}");
						this._urls3 = url.Split(';').ToList();
						if (this._urls3 != null)
						{
							Console.WriteLine($"Client.LoginComponentBase.GetMonitorUrls() : Count monitorUrls {this._urls3.Count}");
						}
						else
						{
							Console.WriteLine("Client.LoginComponentBase.GetMonitorUrls() : monitor urls is null");
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.LoginComponentBase.GetMonitorUrls() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.LoginComponentBase.GetMonitorUrls() : end");
			}
		}

		protected async Task GetSignalRHubUrls()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.LoginComponentBase.GetSignalRHubUrls() : start");
			if (this._localStorage != null)
			{
				try
				{
					string url = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrls);
					if (url == null)
					{
						Console.WriteLine($"Client.LoginComponentBase.GetSignalRHubUrls() : monitorurl is null");
					}
					else
					{
						Console.WriteLine($"Client.LoginComponentBase.GetSignalRHubUrls() : monitorUrl got : {url}");
						this._urls4 = url.Split(';').ToList();
						if (this._urls4 != null)
						{
							Console.WriteLine($"Client.LoginComponentBase.GetSignalRHubUrls() : Count monitorUrls {this._urls4.Count}");
						}
						else
						{
							Console.WriteLine("Client.LoginComponentBase.GetSignalRHubUrls() : signalRHub Urls is null");
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.LoginComponentBase.GetSignalRHubUrls() Exception : ");
					Console.WriteLine(ecx.Message);
				}
				Console.WriteLine($"Client.LoginComponentBase.GetSignalRHubUrls() : end");
			}
		}

		//protected async Task SetAuthenticationServer()
		//{
		//	if (_localStorage != null)
		//	{
		//		StorageAuthenticationServer = await _localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
		//	}
		//}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{

			}
		}
	}
}




