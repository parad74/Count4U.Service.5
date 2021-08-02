using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;
using Monitor.Service.Urls;
using Service.Model;
using System.Text.Json;
using Count4U.Service.Shared.Settings;

namespace Count4U.Service.Shared
{
	//Claims можно запрашивать c WebApi
	public interface IClaimService
	{
		Task<IEnumerable<Claim>> GetClaimsFromStoragedTokenAsync(); //Client из  Token
		Task<ProfileModel> GetProfileModelFromStoragedTokenAsync();   //Client из  Token
		Task<ClaimConvertItem> GetClaimFirstFromServerAsync();      //это просто тест	Server
		Task<List<ClaimConvertItem>> GetClaimsFromServerAsync();    //Server
		Task<List<ClaimConvertItem>> GetClaimsFromWebApiAsync();                 //WebApi
		Task<ProfileModel> GetProfileModelFromServerAsync();
		Task<string> PingWebApiAsync(ProfileModel _rofileModel);                      //WebApi
		Task<string> PingWebApiAuthenticationAsync();            //WebApiAuthenticationPing.GetPing
		Task<string> PingWebApiCount4UFileAsync(ProfileModel _rofileModel);      //WebApi
		Task<string> PingWebApiMonitorAsync();           //WebApi
		Task<string> PingWebApiProfileAsync();           //WebApi пересечение с    PingWebApiMonitorAsync
		Task<string> PingServerAsync();                      //Server
		Task<string> PingSignalRHubAsync();
		Task<string> InitWebAPISettings();             //From Server
		IWebAPISettings WebAPISettings { get; }
	}

	public class ClaimService : IClaimService
	{
		private readonly HttpClient _httpClient;
		private readonly IClaimConvertRepository _claimConvertRepository;

		private readonly ISessionStorageService _sessionStorage;
		private readonly ILocalStorageService _localStorage;

		private readonly IJwtService _jwtService;

		private IWebAPISettingsService _webAPISettingsService;
		private IWebAPISettings _webAPISettings;
		public IWebAPISettings WebAPISettings 	  {	get{ 		return this._webAPISettings; 	} 	}

		public ClaimService(HttpClient httpClient
						, IWebAPISettingsService webAPISettingsService
						, IWebAPISettings webAPISettings
						, IClaimConvertRepository claimConvertRepository
						, ISessionStorageService sessionStorage
						, ILocalStorageService localStorage
						, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			this._webAPISettingsService = webAPISettingsService ??
					   throw new ArgumentNullException(nameof(webAPISettingsService));
			this._webAPISettings = webAPISettings ??
				   throw new ArgumentNullException(nameof(webAPISettings));
			this._claimConvertRepository = claimConvertRepository ??
									 throw new ArgumentNullException(nameof(claimConvertRepository));
			this._sessionStorage = sessionStorage ??
							  throw new ArgumentNullException(nameof(sessionStorage));
			this._localStorage = localStorage ??
						  throw new ArgumentNullException(nameof(localStorage));
			this._jwtService = jwtService ??
							  throw new ArgumentNullException(nameof(jwtService));

		}



		//Это с Клиента из JWT - это закон 
		public async Task<IEnumerable<Claim>> GetClaimsFromStoragedTokenAsync()
		{
			Console.WriteLine($"Client.ClaimService.GetClaimsFromStoragedTokenAsync() : start");
			if (this._sessionStorage == null)
			{
				Console.WriteLine($"Client.ClaimService.GetClaimsFromStoragedTokenAsync() : _sessionStorage is null");
				Console.WriteLine($"Client.ClaimService.GetClaimsFromStoragedTokenAsync() : end");
				return new List<Claim>();
			}
			try
			{
				var savedToken = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
				var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(this._jwtService.ParseClaimsFromJwt(savedToken), "jwt"));
				Console.WriteLine($"Client.ClaimService.GetClaimsFromStoragedTokenAsync() : end");
				if (authenticatedUser == null)
					return new List<Claim>();
				return authenticatedUser.Claims;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("$Client.ClaimService.GetClaimsFromStoragedTokenAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.GetClaimsFromStoragedTokenAsync() : end  with Exception");
				return new List<Claim>();
			}
		}

		//Это с Клиента из JWT - это закон 
		public async Task<ProfileModel> GetProfileModelFromStoragedTokenAsync()
		{
			Console.WriteLine($"Client.ClaimService.GetProfileModelFromStoragedTokenAsync() : start");
			if (this._sessionStorage == null)
			{
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromStoragedTokenAsync() : _sessionStorage is null");
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromStoragedTokenAsync() : end");
				return new ProfileModel();
			}
			try
			{
				var savedToken = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromStoragedTokenAsync() : savedToken  {savedToken}");

				var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(this._jwtService.ParseClaimsFromJwt(savedToken), "jwt"));
				if (authenticatedUser == null)
				{
					Console.WriteLine("Client.ClaimService.GetProfileModelFromStoragedTokenAsync() : Error authenticatedUser is null");
					return new ProfileModel();
				}

				ProfileModel userProfileModel = this._jwtService.GetUserProfileModel(authenticatedUser.Claims);
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromStoragedTokenAsync() : end");
				return userProfileModel;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.GetProfileModelFromStoragedTokenAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromStoragedTokenAsync() : end with Exception");
				return new ProfileModel();
			}
		}

		//Это с сервера	- должен совпадать с клиентом, но клиентов много, для каждого свой набор
		public async Task<ProfileModel> GetProfileModelFromServerAsync()
		{
			Console.WriteLine($"Client.ClaimService.GetProfileModelFromServerAsync() : start");
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.Profile() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					Console.WriteLine($"Client.AuthService.Profile() : end");
					return new ProfileModel();
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationClaim.GetClaimConvertItems);   //"Claim/GetClaimConvertItems");
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromServerAsync() : request {request}");
				List<ClaimConvertItem> result = await this._httpClient.GetFromJsonAsync<List<ClaimConvertItem>>(request);//"Claim/GetClaimConvertItems");
				ProfileModel userProfileModel = this._claimConvertRepository.FillUserProfileModel(result);
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromServerAsync() : end");
				return userProfileModel;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.GetProfileModelFromServerAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.GetProfileModelFromServerAsync() : end with Exception");
				return new ProfileModel();
			}
		}

		//Это с  AuthenticationServer
		public async Task<ClaimConvertItem> GetClaimFirstFromServerAsync()     //тест работает
		{
			Console.WriteLine($"Client.ClaimService.GetClaimFirstFromServerAsync() : start");
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.Profile() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					Console.WriteLine($"Client.AuthService.Profile() : end");
					return new ClaimConvertItem();
				}

				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationClaim.GetClaimConvertItemFirstAsync);   //"Claim/GetClaimConvertItems");
				Console.WriteLine($"Client.ClaimService.GetClaimFirstFromServerAsync() : request {request}");
				ClaimConvertItem result = await this._httpClient.GetFromJsonAsync<ClaimConvertItem>(request);//"Claim/GetClaimConvertItem"
				Console.WriteLine($"Client.ClaimService.GetClaimFirstFromServerAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.GetClaimFirstFromServerAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.GetClaimFirstFromServerAsync() : end with Exception");
				return new ClaimConvertItem();
			}
		}

		//Это с сервера
		public async Task<List<ClaimConvertItem>> GetClaimsFromServerAsync()
		{
			Console.WriteLine($"Client.ClaimService.GetClaimsFromServerAsync() : start");
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.Profile() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					Console.WriteLine($"Client.AuthService.Profile() : end");
					return new List<ClaimConvertItem>();
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationClaim.GetClaimConvertItems);   //"Claim/GetClaimConvertItems");
				Console.WriteLine($"Client.ClaimService.GetClaimsFromServerAsync() : request {request}");
				List<ClaimConvertItem> result = await this._httpClient.GetFromJsonAsync<List<ClaimConvertItem>>(request);//"Claim/GetClaimConvertItems"
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.GetClaimsFromServerAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.GetClaimsFromServerAsync() : end with Exception");
				return new List<ClaimConvertItem>();
			}
		}


		//Это с WebApi по адресу из токена		- должен совпадать с клиентом, но клиентов много, для каждого свой набор
		public async Task<List<ClaimConvertItem>> GetClaimsFromWebApiAsync()
		{
			Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : start");
			try
			{
				//сначала надо получить адресс WebApi на клиенте у текущего пользователя!
				// из токена 
				ProfileModel profileModel = await this.GetProfileModelFromStoragedTokenAsync();

				if (profileModel == null)
				{
					Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : profileModel is null");
					Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : end");
					return new List<ClaimConvertItem>();
				}

				if (string.IsNullOrWhiteSpace(profileModel.DataServerAddress) == true)
				{
					Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : profileModel.DataServerAddress is Empty");
					Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : end");
					return new List<ClaimConvertItem>();
				}

				string request = Opetarion.UrlCombine(profileModel.DataServerAddress, WebApiCount4UModelClaim.GetClaimWebApiConvertItems);
				Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<List<ClaimConvertItem>>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : end");
					return new List<ClaimConvertItem>();
				}

				if (result.Count > 0)
					Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : result.Count: {result.Count}");
				Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.GetClaimsFromWebApiAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.GetClaimsFromWebApiAsync() : end with Exception");
				return new List<ClaimConvertItem>();
			}
		}


		public async Task<string> PingWebApiAsync(ProfileModel _rofileModel)
		{
			Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : start");
			try
			{
				//сначала надо получить адресс WebApi на клиенте у текущего пользователя!
				// из токена 
				//ProfileModel profileModel = await GetProfileModelFromStoragedTokenAsync();

				if (_rofileModel == null)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : profileModel is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : end");
					return "";
				}

				if (string.IsNullOrWhiteSpace(_rofileModel.DataServerAddress) == true)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : profileModel.DataServerAddress is Empty");
					Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : end");
					return "";
				}

				string request = Opetarion.UrlCombine(_rofileModel.DataServerAddress, WebApiCount4UModelPing.GetPing);
				Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<string>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : end");
					return "";
				}
				Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.PingWebApiAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.PingWebApiAsync() : end with Exception");
				return "";
			}
		}


		public async Task<string> PingWebApiCount4UFileAsync(ProfileModel _rofileModel)
		{
			Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : start");
			try
			{
				//сначала надо получить адресс WebApi на клиенте у текущего пользователя!
				// из токена 
				//ProfileModel profileModel = await GetProfileModelFromStoragedTokenAsync();

				if (_rofileModel == null)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : profileModel is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : end");
					return "";
				}

				if (string.IsNullOrWhiteSpace(_rofileModel.DataServerAddress) == true)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : profileModel.DataServerAddress is Empty");
					Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : end");
					return "";
				}

				string request = Opetarion.UrlCombine(_rofileModel.DataServerAddress, WebApiCount4UModelConnectionDB.GetPing);
				Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<string>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : end");
					return "";
				}
				Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.PingWebApiCount4UFileAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.PingWebApiCount4UFileAsync() : end with Exception");
				return "";
			}
		}

		//WebApiAuthenticationPing.GetPing
		public async Task<string> PingWebApiAuthenticationAsync()
		{
			Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : start");
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : authenticationWebapiUrl is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : end");
					return "";
				}

				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationPing.GetPing);
				Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<string>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : end");
					return "";
				}
				Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.PingWebApiAuthenticationAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.PingWebApiAuthenticationAsync() : end with Exception");
				return "";
			}
		}

		public async Task<string> PingWebApiMonitorAsync()
		{
			Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : start");
			try
			{
				string monitorWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
				if (string.IsNullOrWhiteSpace(monitorWebapiUrl) == true)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : monitorWebapiUrl is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : end");
					return "";
				}

				string request = Opetarion.UrlCombine(monitorWebapiUrl, WebApiMonitorPing.GetPing);
				Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<string>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : end");
					return "";
				}
				Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : result  {result}");
				Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.PingWebApiMonitorAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.PingWebApiMonitorAsync() : end with Exception");
				return "";
			}
		}

		public async Task<string> PingWebApiProfileAsync()
		{
			Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : start");
			try
			{
				string monitorWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
				if (string.IsNullOrWhiteSpace(monitorWebapiUrl) == true)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : monitorWebapiUrl is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : end");
					return "";
				}

				string request = Opetarion.UrlCombine(monitorWebapiUrl, WebApiProfilePing.GetPing);
				Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<string>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : end");
					return "";
				}
				Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : result  {result}");
				Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.PingWebApiProfileAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.PingWebApiProfileAsync() : end with Exception");
				return "";
			}
		}

		public async Task<string> PingSignalRHubAsync()
		{
			Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : start");
			try
			{
				string signalRHubUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
				if (string.IsNullOrWhiteSpace(signalRHubUrl) == true)
				{
					Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : signalRHubUrl is null");
					Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : end");
					return "";
				}

				string request = Opetarion.UrlCombine(signalRHubUrl, SignalRHubPing.GetPing);
				Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<string>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : end");
					return "";
				}
				Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : result  {result}");
				Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.PingSignalRHubAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.PingSignalRHubAsync() : end with Exception");
				return "";
			}
		}

		//источник сервер (appsettings.json) или клиент (из конструктора)
		public async Task<string> InitWebAPISettings()
		{
			if (this._sessionStorage == null)
			{
				Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : _sessionStorage is null");
				Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : end");
				return "";
			}
			if (this._localStorage == null)
			{
				Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : _localStorage is null");
				Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : end");
				return "";
			}
			try
			{
				Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : start ping Server");
				string result = "wait";
				result = await this.PingServerAsync();
				Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : result {result}");
				//if (result !=  Ping.Pong)
				//{
				//	if (result == "wait") Thread.Sleep(500);
				//	if (result == "wait") Thread.Sleep(500);
				//	if (result == "wait") Thread.Sleep(500);
				//}

				//========== authenticationWebapiUrl from 	localStorage
				string authenticationWebapiUrllocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				string monitorWebapiUrllocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
				string signalRHubUrllocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
				if (result != PingOpetarion.Pong)    //источник клиент - данные по умлдчанию из кода
				{
					if (result == "wait")
					{
						Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : ATTANTION FOR DEVELOPER result == wait");
					}

					Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : NO ping Server. Get WebAPISettings from Client");
					await this._sessionStorage.SetItemAsync(SessionStorageKey.hostMode, "client");
					if (string.IsNullOrWhiteSpace(authenticationWebapiUrllocalStorage) == true)
					{
						await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, this._webAPISettings.authenticationWebapiUrl);
					}
					await this._sessionStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrls, this._webAPISettings.authenticationWebapiUrls);
					//========== monitorWebapiUrl from 	localStorage

					if (string.IsNullOrWhiteSpace(monitorWebapiUrllocalStorage) == true)
					{
						await this._localStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrl, this._webAPISettings.monitorWebapiUrl);
					}
					await this._sessionStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrls, this._webAPISettings.monitorWebapiUrls);

					//========== signalRHubUrl from 	localStorage

					if (string.IsNullOrWhiteSpace(signalRHubUrllocalStorage) == true)
					{
						await this._localStorage.SetItemAsync(SessionStorageKey.signalRHubUrl, this._webAPISettings.signalRHubUrl);
					}
					await this._sessionStorage.SetItemAsync(SessionStorageKey.signalRHubUrls, this._webAPISettings.signalRHubUrls);


					//========== count4uWebapiUrls from 	localStorage
					await this._sessionStorage.SetItemAsync(SessionStorageKey.count4uWebapiUrls, this._webAPISettings.count4uWebapiUrls);

					Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : _webAPISettings  {this._webAPISettings.authenticationWebapiUrl} ||  {this._webAPISettings.authenticationWebapiUrls} ||   {this._webAPISettings.count4uWebapiUrls} ||   {this._webAPISettings.monitorWebapiUrl}  ||   {this._webAPISettings.monitorWebapiUrls} ||   {this._webAPISettings.monitorWebapiUrl} || {this._webAPISettings.signalRHubUrls} || {this._webAPISettings.signalRHubUrl} ");
					return this._webAPISettings.authenticationWebapiUrl;
				}
				else         //источник сервер (appsettings.json) 
				{
					Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : ping Server successfully");
					await this._sessionStorage.SetItemAsync(SessionStorageKey.hostMode, "server");
					var webAPISettingsAsync = await this._webAPISettingsService.GetWebAPISettingsAsync("Client.ApiAuthenticationStateProvider.InitWebAPISettings");
					if (webAPISettingsAsync != null)
					{
						Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : got from  webAPISettingsAsync {webAPISettingsAsync.authenticationWebapiUrl} ||  {webAPISettingsAsync.authenticationWebapiUrls} ||   {webAPISettingsAsync.count4uWebapiUrls} ||   {this._webAPISettings.monitorWebapiUrl}  ||   {this._webAPISettings.monitorWebapiUrls}||   {this._webAPISettings.signalRHubUrl}  ||   {this._webAPISettings.signalRHubUrls}");
						this._webAPISettings = webAPISettingsAsync as IWebAPISettings;
						Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : _webAPISettings  {this._webAPISettings.authenticationWebapiUrl} ||   {this._webAPISettings.monitorWebapiUrl}");
						Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : Got WebAPISettings from Server");
					}
					if (string.IsNullOrWhiteSpace(authenticationWebapiUrllocalStorage) == true)
					{
						await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, this._webAPISettings.authenticationWebapiUrl);
					}

					if (string.IsNullOrWhiteSpace(monitorWebapiUrllocalStorage) == true)
					{
						await this._localStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrl, this._webAPISettings.monitorWebapiUrl);
					}
					if (string.IsNullOrWhiteSpace(signalRHubUrllocalStorage) == true)
					{
						await this._localStorage.SetItemAsync(SessionStorageKey.signalRHubUrl, this._webAPISettings.signalRHubUrl);
					}

					await this._sessionStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrls, this._webAPISettings.authenticationWebapiUrls);
					await this._sessionStorage.SetItemAsync(SessionStorageKey.monitorWebapiUrls, this._webAPISettings.monitorWebapiUrls);
					await this._sessionStorage.SetItemAsync(SessionStorageKey.signalRHubUrls, this._webAPISettings.signalRHubUrls);
					await this._sessionStorage.SetItemAsync(SessionStorageKey.count4uWebapiUrls, this._webAPISettings.count4uWebapiUrls);
					Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : Save WebAPISettings to _sessionStorage");
					return this._webAPISettings.authenticationWebapiUrl;
				}
			}
			catch (Exception ecx)
			{
				Console.WriteLine($"Client.ClaimService.InitWebAPISettings() : with Error  {ecx.Message}");
				return "";
			}
		}


		public async Task<string> PingServerAsync()
		{
			Console.WriteLine($"Client.ClaimService.PingServerAsync() : start");
			try
			{
				string request = ServerPing.GetPing;
				Console.WriteLine($"Client.ClaimService.PingServerAsync() : request  {request}");
				var result = await this._httpClient.GetFromJsonAsync<string>(request);

				if (result == null)
				{
					Console.WriteLine($"Client.ClaimService.PingServerAsync() : result is null");
					Console.WriteLine($"Client.ClaimService.PingServerAsync() : end");
					return "";
				}
				Console.WriteLine($"Client.ClaimService.PingServerAsync() : end");
				return result;
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ClaimService.PingServerAsync() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ClaimService.PingServerAsync() : end with Exception");
				return "";
			}
		}

		static bool LogError(Exception ex)
		{
			return true;
		}
	}
}
