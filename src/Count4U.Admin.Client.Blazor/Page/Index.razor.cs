using Blazored.LocalStorage;
using Count4U.Admin.Client.Blazor.I18nText;
using Monitor.Service.Urls;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Monitor.Service.Shared;
using Count4U.Client.Shared.Service;
using Microsoft.AspNetCore.SignalR.Client;
using Monitor.Service.Model;

namespace Count4U.Admin.Client.Page
{
	public class IndexBase : ComponentBase
	{
		public GetResources LocalizationResources = new GetResources();

		[Inject]
		protected IHubChatSignalRRepository _hubSignalRRepository { get; set; }

		[Inject]
		protected IHubCommandSignalRRepository _hubCommandSignalRRepository { get; set; }

		[Inject]
		protected ISignalRTraceService _signalRTraceService { get; set; }

		[Inject]
		protected IClaimService _claimService { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		[Inject]
		protected ILocalStorageService _localStorage { get; set; }

		[Inject]
		protected ISessionStorageService _sessionStorage { get; set; }

		[Inject]
		protected NavigationManager NavigationManager { get; set; }

		public string _authenticationWebapiUrl { get; set; }
		public string _monitorWebapiUrl { get; set; }
		public string _signalRHubUrl { get; set; }
		public string _count4uWebapiUrl { get; set; }

		public string TextSubmit = "Submit";
		public string TextRegister = "Register";
		public string PingServer { get; set; }
		public IndexBase()
		{
			//string register = LocalizationResources.Login_Register;
		}

		protected override async Task OnInitializedAsync()
		{
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
				this.TextSubmit = LocalizationResources.Login_Submit;
				this.TextRegister = LocalizationResources.Login_Register;
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() I18nText Init Exception : ");
				Console.WriteLine(ecx.Message);
			}

			//await _claimService.InitWebAPISettings();
			this._authenticationWebapiUrl = "";
			this._monitorWebapiUrl = "";
			this._signalRHubUrl = "";
			this._count4uWebapiUrl = "";

			string authenticationServerGetFromSetting = "";
			string authenticationServerUrlFromLocalStorage = "";
			string monitorWebApiUrlFromLocalStorage = "";
			string signalRHubFromLocalStorage = "";
			//string coutn4uFromLocalStorage = "";

			try
			{
				if (this._claimService != null)
				{
					string result = await this._claimService.PingServerAsync();
					this.PingServer = "CLIENT";
					if (result == PingOpetarion.Pong) this.PingServer = "SERVER";
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : result {result}");
					authenticationServerGetFromSetting = await this._claimService.InitWebAPISettings();
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : authenticationServerGetFromSetting : {authenticationServerGetFromSetting}");

				}
				else
				{
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : ERROR _claimService IS NULL");
				}

				if (this._localStorage != null)
				{
					authenticationServerUrlFromLocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : authenticationServerUrlFromLocalStorage : {authenticationServerUrlFromLocalStorage}");

					monitorWebApiUrlFromLocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : monitorServerUrlFromLocalStorage : {monitorWebApiUrlFromLocalStorage}");

					signalRHubFromLocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : signalRHubFromLocalStorage : {signalRHubFromLocalStorage}");

					//coutn4uFromLocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.count4uWebapiUrl);
					//Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : coutn4uFromLocalStorage : {coutn4uFromLocalStorage}");

				}
				else
				{
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : ERROR _localStorage IS NULL");
				}


				if (string.IsNullOrWhiteSpace(authenticationServerUrlFromLocalStorage) == false)
				{
					this._authenticationWebapiUrl = authenticationServerUrlFromLocalStorage;
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : _authenticationWebapiUrl set as : {authenticationServerUrlFromLocalStorage}");
				}
				else
				{
					if (this._claimService != null && this._claimService.WebAPISettings != null)
					{
						this._authenticationWebapiUrl = authenticationServerGetFromSetting;
						Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : _authenticationWebapiUrl set as : {authenticationServerGetFromSetting}");
						if (this._localStorage != null)
						{
							await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, authenticationServerGetFromSetting);
						}
					}
				}

				if (string.IsNullOrWhiteSpace(signalRHubFromLocalStorage) == false)
				{
					this._signalRHubUrl = signalRHubFromLocalStorage;
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : 5 _signalRHubUrl set as Local: {signalRHubFromLocalStorage}");
				}
				else
				{
					if (this._claimService != null && this._claimService.WebAPISettings != null)
					{
						this._signalRHubUrl = this._claimService.WebAPISettings.signalRHubUrl;
						Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : 6 _signalRHubUrl set as Setting: {this._signalRHubUrl}");
						if (this._localStorage != null)
						{
							await this._localStorage.SetItemAsync(SessionStorageKey.signalRHubUrl, this._signalRHubUrl);
						}
					}
				}

		

				if (string.IsNullOrWhiteSpace(monitorWebApiUrlFromLocalStorage) == false)
				{
					this._monitorWebapiUrl = monitorWebApiUrlFromLocalStorage;
					Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : 3 _monitorWebapiUrl set as Local : {monitorWebApiUrlFromLocalStorage}");
				}
				else
				{
					if (this._claimService != null && this._claimService.WebAPISettings != null)
					{
						this._monitorWebapiUrl = this._claimService.WebAPISettings.monitorWebapiUrl;
						Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : 4 _monitorWebapiUrl set as Setting : {this._monitorWebapiUrl }");
						if (this._localStorage != null)
						{
							await this._localStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrl, this._monitorWebapiUrl);
						}
					}
				}


				Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() IsCommandConnected1 : " + IsCommandConnected);
				await _hubCommandSignalRRepository.HubCommandConnection.StartAsync();
				Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() StartAsync IsCommandConnected2 : " + IsCommandConnected);


				//this must be set in 	  this._claimService.InitWebAPISettings();
				if (this._sessionStorage != null)
				{
					if (this._claimService != null && this._claimService.WebAPISettings != null)
					{
						Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : 11 _sessionStorage set");
						await _sessionStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrls, this._claimService.WebAPISettings.authenticationWebapiUrls);
						await _sessionStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrls, this._claimService.WebAPISettings.monitorWebapiUrls);
						await _sessionStorage.SetItemAsync(SessionStorageKey.signalRHubUrls, this._claimService.WebAPISettings.signalRHubUrls);
						Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : 13 _sessionStorage set");

					}
				}

			
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() hubConnection Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}


		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				try
				{
					Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() 1 1 ");
					string signalRHubFromLocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
					{
						Console.WriteLine($"Client.IndexBase.OnAfterRenderAsync() 1 2 {signalRHubFromLocalStorage}");
						//========================    ChatHub	 =============================
						string chatHubAddress = Opetarion.UrlCombine(signalRHubFromLocalStorage, Monitor.Service.Model.SignalRHub.ChatHub);
						Console.WriteLine($"Client.IndexBase.OnAfterRenderAsync() 1 3 {chatHubAddress}");
						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() hubConnection : ");
						Uri hubaddres = NavigationManager.ToAbsoluteUri(chatHubAddress);
						if (_hubSignalRRepository == null)
						{
							Console.WriteLine("ERROR : Client.IndexBase.OnAfterRenderAsync() _hubSignalRRepository is null");
							return;
						}

						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() hubConnection  try build : " + hubaddres.AbsolutePath + "     " + hubaddres.AbsoluteUri);
						_hubSignalRRepository.HubChatConnection = new HubConnectionBuilder()
						  .WithUrl(hubaddres)
						  .WithAutomaticReconnect()
						  // .ConfigureLogging(logging => {
						  //	logging.SetMinimumLevel(LogLevel.Information);
						  //	logging.AddConsole();
						  //})
						  .Build();
						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() hubConnection : builded");
						if (this._hubSignalRRepository.HubChatConnection == null)
						{
							Console.WriteLine("ERROR : Client.IndexBase.OnAfterRenderAsync() _hubSignalRRepository.HubChatConnection is null");
							return;
						}

						this._hubSignalRRepository.HubChatConnection.On<string, string>(SignalRHubPublishFunction.ReceiveMessage, (user, message) =>
						{
							var encodedMsg = user + " says " + message;
							_signalRTraceService.Messages.Add(encodedMsg);
							StateHasChanged();
						});

						this._hubSignalRRepository.HubChatConnection.On<string>(SignalRHubPublishFunction.ReceiveNotify, (notify) =>
						{
							Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() Notify : " + notify);
							_signalRTraceService.Messages.Add($"# {notify}");
							StateHasChanged();
						});

						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() IsConnected1 : " + IsConnected);
						await _hubSignalRRepository.HubChatConnection.StartAsync();
						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() StartAsync IsConnected2 : " + IsConnected);
					}

					//========================    CommandHub	 =============================
					{

						string commandHubAddress = Opetarion.UrlCombine(signalRHubFromLocalStorage, Monitor.Service.Model.SignalRHub.CommandHub);

						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() command hubConnection : ");
						Uri hubaddres = NavigationManager.ToAbsoluteUri(commandHubAddress);
						if (_hubCommandSignalRRepository == null)
						{
							Console.WriteLine("ERROR : Client.IndexBase.OnAfterRenderAsync() _hubSignalRRepository is null");
							return;
						}

						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() hubConnection  try build : " + hubaddres.AbsolutePath + "     " + hubaddres.AbsoluteUri);
						_hubCommandSignalRRepository.HubCommandConnection = new HubConnectionBuilder()
						  .WithUrl(hubaddres)
						  .WithAutomaticReconnect()
						  // .ConfigureLogging(logging => {
						  //	logging.SetMinimumLevel(LogLevel.Information);
						  //	logging.AddConsole();
						  //})
						  .Build();
						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() hubConnection : builded");
						if (this._hubCommandSignalRRepository.HubCommandConnection == null)
						{
							Console.WriteLine("ERROR : Client.IndexBase.OnAfterRenderAsync() _hubCommandSignalRRepository.HubCommandConnection is null");
							return;
						}


						this._hubCommandSignalRRepository.HubCommandConnection.On<string>(SignalRHubPublishFunction.ReceiveCommandNotify, (notify) =>
						{
							Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() ReceiveCommandNotify : " + notify);
							_signalRTraceService.Messages.Add($"% {notify}");
							StateHasChanged();
						});

			
						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() IsCommandConnected1R : " + IsCommandConnected);
						await _hubCommandSignalRRepository.HubCommandConnection.StartAsync();
						Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() StartAsync IsCommandConnected2R : " + IsCommandConnected);


						//this must be set in 	  this._claimService.InitWebAPISettings();
						if (this._sessionStorage != null)
						{
							if (this._claimService != null && this._claimService.WebAPISettings != null)
							{
								await _sessionStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrls, this._claimService.WebAPISettings.authenticationWebapiUrls);
								await _sessionStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrls, this._claimService.WebAPISettings.monitorWebapiUrls);
								await _sessionStorage.SetItemAsync(SessionStorageKey.signalRHubUrls, this._claimService.WebAPISettings.signalRHubUrls);
							}
						}
					}
				}
				catch (Exception ecx)
				{
					Console.WriteLine("Client.IndexBase.OnAfterRenderAsync() hubConnection Exception : ");
					Console.WriteLine(ecx.Message);
				}

				Console.WriteLine($"Client.IndexBase.OnAfterRenderAsync() : end");
			}
		}

		public bool IsConnected => _hubSignalRRepository.HubChatConnection.State == HubConnectionState.Connected;
		public bool IsCommandConnected => _hubCommandSignalRRepository.HubCommandConnection.State == HubConnectionState.Connected;



	}
}
