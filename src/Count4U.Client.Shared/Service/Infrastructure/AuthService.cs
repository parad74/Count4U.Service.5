using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Monitor.Service.Model;
using Monitor.Service.Urls;
using System.Text.Json;


namespace Count4U.Service.Shared
{
	//Служба аутентификации будет тем, что мы используем в наших компонентах для регистрации пользователей и входа в них и выхода из приложения.
	//Это абстракция для всего, что происходит в фоновом режиме.
	public interface IAuthService
	{
		Task<LoginResult> LoginAsync(LoginModel loginModel);
		Task LogoutAaync();
		Task<RegisterResult> RegisterAsync(RegisterModel registerModel);
		Task<ProfileResult> ProfileAsync(ProfileModel profileModel);
		Task<ProfileResult> UpdateProfileAsync(ProfileModel profileModel);
		Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel);
		Task<UserViewModel> GetUser(UserViewModel userViewModel);

		Task<UserResult> UpdateUserAsync(UserViewModel userViewModel);
	}

	public class AuthService : IAuthService
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly ISessionStorageService _sessionStorage;
		private readonly ILocalStorageService _localStorage;

		public AuthService(HttpClient httpClient
						   , AuthenticationStateProvider authenticationStateProvider
						   , ISessionStorageService sessionStorage
							, ILocalStorageService localStorage)
		{
			this._httpClient = httpClient ??
						   throw new ArgumentNullException(nameof(httpClient));
			this._authenticationStateProvider = authenticationStateProvider ??
						   throw new ArgumentNullException(nameof(authenticationStateProvider));
			this._sessionStorage = sessionStorage ??
						   throw new ArgumentNullException(nameof(sessionStorage));
			this._localStorage = localStorage ??
						   throw new ArgumentNullException(nameof(localStorage));
		}

		//The Register method posts the registerModel to the accounts controller and then returns the RegisterResult to the caller.

		public async Task<RegisterResult> RegisterAsync(RegisterModel registerModel)
		{
			//!!! НЕ убирать 
			//Console.WriteLine($"Client.AuthService.Register() : start");
			//var authenticationWebApiUrls = await this._webAPISettingsService.GetAuthenticationWebApiUrls("AuthService");
			//if (authenticationWebApiUrls != null)
			//{
			//	Console.WriteLine($"Client.AuthService.Register() : start1  {authenticationWebApiUrls}");
			//}

			//var count4UWebApiUrls = await this._webAPISettingsService.GetCount4UWebApiUrls("AuthService");
			//if (count4UWebApiUrls != null)
			//{
			//	Console.WriteLine($"Client.AuthService.Register() : start2  {count4UWebApiUrls}");
			//}

			//var authenticationWebApiUrl = await this._webAPISettingsService.GetAuthenticationWebApiUrl("AuthService");
			//if (authenticationWebApiUrl != null)
			//{
			//	Console.WriteLine($"Client.AuthService.Register() : start3  {authenticationWebApiUrl}");
			//}

			//var webAPISettingsAsync = await this._webAPISettingsService.GetWebAPISettingsAsync("AuthService");
			//if (webAPISettingsAsync != null)
			//{
			//	Console.WriteLine($"Client.AuthService.Register() : start4  {webAPISettingsAsync.authenticationWebapiUrl} ||  {webAPISettingsAsync.authenticationWebapiUrls} ||   {webAPISettingsAsync.count4uWebapiUrls}");
			//}

			Console.WriteLine($"Client.AuthService.Register() : start");
			if (registerModel == null)
			{
				Console.WriteLine($"Client.AuthService.Register() : in registerModel is null");
				//var error = new RegisterResult { Successful = false, Error = "registerModel is null" };
				var error = new RegisterResult { Successful = SuccessfulEnum.NotSuccessful, Error = "inRegisterModel is null" };
				return error;
			}
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.Register() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					//var error = new RegisterResult { Successful = false, Error = $"Authentication Server Url is Empty. Can't get user from Server" };
					var error = new RegisterResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Authentication Server Url is Empty. Can't get user from Server" };
					Console.WriteLine($"Client.AuthService.Register() : end");
					return error;
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAccounts.PostRegister);
				Console.WriteLine($"Client.AuthService.Register() : request {request}");
				//var result = await this._httpClient.PostJsonAsync<RegisterResult>(request, registerModel);   //	  "api/accounts/register"

																											 //HttpResponseMessage response = await Http.PostAsJsonAsync <WeatherForecast>("", new WeatherForecast());
																											 //WeatherForecast ret =  await response.Content.ReadFromJsonAsync<WeatherForecast>();

				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<RegisterModel>(request, registerModel);
				RegisterResult result = await response.Content.ReadFromJsonAsync<RegisterResult>();
				Console.WriteLine($"Client.AuthService.Register() : end");
				return result;
			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.Register() Exception : ");
				//	var error = new RegisterResult { Successful = false, Error = ecx.Message };
				var error = new RegisterResult { Successful = SuccessfulEnum.NotSuccessful, Error = ecx.Message };
				Console.WriteLine($"Client.AuthService.Register() : end with Exception");
				return error;
			}
		}

		//The Register method posts the profileModel to the accounts controller and then returns the RegisterResult to the caller.
		public async Task<ProfileResult> ProfileAsync(ProfileModel profileModel)
		{
			Console.WriteLine($"Client.AuthService.Profile() : start");
			if (profileModel == null)
			{
				Console.WriteLine($"Client.AuthService.Profile() : in profileModel is null");
				//var error = new RegisterResult { Successful = false, Error = "profileModel is null"  };
				var error = new ProfileResult { Successful = SuccessfulEnum.NotSuccessful, Error = "inRegisterModel is null" };
				return error;
			}
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.Profile() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					//var error = new RegisterResult { Successful = false, Error = "Authentication Server Url is Empty. Can't get user from Server" };
					var error = new ProfileResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Authentication Server Url is Empty. Can't get user from Server" };
					Console.WriteLine($"Client.AuthService.Profile() : end");
					return error;
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAccounts.PostProfile);
				Console.WriteLine($"Client.AuthService.Profile() : request {request}");
			//	var result = await this._httpClient.PostJsonAsync<ProfileResult>(request, profileModel);   // "api/accounts/profile"

				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileModel>(request, profileModel);
				ProfileResult result = await response.Content.ReadFromJsonAsync<ProfileResult>();

				Console.WriteLine($"Client.AuthService.Profile() : end");
				return result;
			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.Profile() Exception : ");
				Console.WriteLine(ecx.Message);
				// var error = new RegisterResult { Successful = false, Error = ecx.Message };
				var error = new ProfileResult { Successful = SuccessfulEnum.NotSuccessful, Error = ecx.Message };
				Console.WriteLine($"Client.AuthService.Profile() : end with Exception");
				return error;
			}
		}


		public async Task<UserResult> UpdateUserAsync(UserViewModel userViewModel)
		{
			Console.WriteLine($"Client.AuthService.UpdateUserAsync() : start");
			if (userViewModel == null)
			{
				Console.WriteLine($"Client.AuthService.UpdateUserAsync() : in userViewModel is null");
				//var error = new RegisterResult { Successful = false, Error = "profileModel is null"  };
				var error = new UserResult { Successful = SuccessfulEnum.NotSuccessful, Error = "in userViewModel is null" };
				return error;
			}
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.UpdateUserAsync() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					//var error = new RegisterResult { Successful = false, Error = "Authentication Server Url is Empty. Can't get user from Server" };
					var error = new UserResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Authentication Server Url is Empty. Can't get user from Server" };
					Console.WriteLine($"Client.AuthService.UpdateUserAsync() : end");
					return error;
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAccounts.UpdateUser);
				Console.WriteLine($"Client.AuthService.UpdateUserAsync() : request {request}");
				//	var result = await this._httpClient.PostJsonAsync<ProfileResult>(request, profileModel);   // "api/accounts/profile"

				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<UserViewModel>(request, userViewModel);
				UserResult result = await response.Content.ReadFromJsonAsync<UserResult>();

				Console.WriteLine($"Client.AuthService.UpdateUserAsync() : end");
				return result;
			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.UpdateUserAsync() Exception : ");
				Console.WriteLine(ecx.Message);
				// var error = new RegisterResult { Successful = false, Error = ecx.Message };
				var error = new UserResult { Successful = SuccessfulEnum.NotSuccessful, Error = ecx.Message };
				Console.WriteLine($"Client.AuthService.UpdateUserAsync() : end with Exception");
				return error;
			}
		}

		//The Login method is similar to the Register method, it posts the LoginModel to the login controller. 
		//But when a successful result is returned it strips out the auth token and persists it to local storage.	
		public async Task<ProfileResult> UpdateProfileAsync(ProfileModel profileModel)
		{
			Console.WriteLine($"Client.AuthService.UpdateProfile() : start");
			if (profileModel == null)
			{
				Console.WriteLine($"Client.AuthService.Login() : in profileModel is null");
				//var error = new LoginResult { Successful = false, Error = "profileModel is null" };
				var error = new ProfileResult { Successful = SuccessfulEnum.NotSuccessful, Error = "inProfileModel is null" };
				return error;
			}
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.Profile() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					//	var error = new LoginResult { Successful = false, Error = $"Authentication Server Url is Empty. Can't get user from Server.  [ Authentication Server Address { authenticationWebapiUrl} ]" };
					var error = new ProfileResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Authentication Server Url is Empty. Can't get user from Server" };
					Console.WriteLine($"Client.AuthService.Profile() : end");
					return error;
				}
				// profileModel.ID = "";
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAccounts.PostUpdateprofile);
				Console.WriteLine($"Client.AuthService.UpdateProfile() : request {request}");
				//var result = await this._httpClient.PostJsonAsync<ProfileResult>(request, profileModel);   //					 "api/accounts/updateprofile"
				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ProfileModel>(request, profileModel);
				ProfileResult result = await response.Content.ReadFromJsonAsync<ProfileResult>();

				if (result == null)
				{
					Console.WriteLine($"Client.AuthService.UpdateProfile() : Can't login to Server");
					//var error = new LoginResult { Successful = false, Error = "Can't login to Server" };
					var error = new ProfileResult { Successful = SuccessfulEnum.NotSuccessful, Error = "Can't login to Server" };
					return error;
				}
				Console.WriteLine($"Client.AuthService.UpdateProfile() : Token {result.Token}");
				//	if (result.Successful)
				if (result.Successful == SuccessfulEnum.Successful)
				{
					Console.WriteLine($"Client.AuthService.UpdateProfile() : Get Token from Server Successfuly");

					if (this._sessionStorage == null)
					{
						Console.WriteLine($"Client.AuthService.UpdateProfile() : _sessionStorage is null. Can't save Token on Client");
					}
					else
					{
						//Но когда возвращается успешный результат, он извлекает токен аутентификации и сохраняет его в локальном хранилище.
						await this._sessionStorage.SetItemAsync(SessionStorageKey.authToken, result.Token);
						Console.WriteLine($"Client.AuthService.UpdateProfile() : Save Token to Client Successfuly");
					}
					//Затем вызовите метод MarkUserAsAuthenticated, который мы только что рассмотрели на ApiAuthenticationStateProvider.
					//1 вариант((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
					((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
					//Наконец, он устанавливает заголовок авторизации по умолчанию для HttpClient.
					this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
					Console.WriteLine($"Client.AuthService.UpdateProfile() : end");
					return result;
				}
				else
				{
					Console.WriteLine($"Client.AuthService.UpdateProfile() : Get Token from Server Not Successfuly");
					Console.WriteLine($"Client.AuthService.UpdateProfile() : end");
					return result;
				}
			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.UpdateProfile() Exception : ");
				Console.WriteLine(ecx.Message);
				//var error = new LoginResult { Successful = false, Error = ecx.Message };
				var error = new ProfileResult { Successful = SuccessfulEnum.NotSuccessful, Error = ecx.Message };
				Console.WriteLine($"Client.AuthService.UpdateProfile() : end with Exception");
				return error;
			}
		}



		//The Login method is similar to the Register method, it posts the LoginModel to the login controller. 
		//But when a successful result is returned it strips out the auth token and persists it to local storage.	
		public async Task<LoginResult> LoginAsync(LoginModel loginModel)
		{
			Console.WriteLine($"Client.AuthService.LoginAsync() : start");
			if (loginModel == null)
			{
				Console.WriteLine($"Client.AuthService.LoginAsync() : in loginModel is null");
				//var error = new LoginResult { Successful = false, Error = "loginModel is null" };
				var error = new LoginResult { Successful = SuccessfulEnum.NotSuccessful, Error = @"inLoginModel is null" };
				Console.WriteLine($"Client.AuthService.LoginAsync() : end1");
				return error;
			}
			//var ret = this._webAPISettingsService.GetAuthenticationWebApiUrl("ApiAuthenticationStateProvider");
			//if (ret != null)
			//{
			//	if (ret.Result != null) this._webAPISettings.authenticationWebapiUrl = ret.Result;
			//}
			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.LoginAsync() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					//var error = new LoginResult { Successful = false, Error = $"Authentication Server Url is Empty. Can't get user from Server.  [ Authentication Server Address { authenticationWebapiUrl} ]" };
					var error = new LoginResult { Successful = SuccessfulEnum.NotSuccessful, Error = @"Authentication Server Url is Empty. Can't get user from Server" };
					Console.WriteLine($"Client.AuthService.LoginAsync() : end");
					return error;
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationLogin.PostLogin);
				Console.WriteLine($"Client.AuthService.LoginAsync() : request {request}");
				//var result = await this._httpClient.PostJsonAsync<LoginResult>(request, loginModel);                //   "api/login"
				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<LoginModel>(request, loginModel);
				LoginResult result = await response.Content.ReadFromJsonAsync<LoginResult>();

				if (result == null)
				{
					Console.WriteLine($"Client.AuthService.LoginAsync() : Can't login to Server");
					//var error = new LoginResult { Successful = false, Error = "Can't login to Server" };
					var error = new LoginResult { Successful = SuccessfulEnum.NotSuccessful, Error = @"Can't login to Server" };
					Console.WriteLine($"Client.AuthService.LoginAsync() : end2");
					return error;
				}

				//if (result.Successful == false)
				if (result.Successful == SuccessfulEnum.NotSuccessful)
				{
					Console.WriteLine($"Client.AuthService.LoginAsync() : Can't login to Server : " + result.Error);
					Console.WriteLine($"Client.AuthService.LoginAsync() : end3");
					return result;
				}

				else // (result.Successful == true)
				{
					Console.WriteLine($"Client.AuthService.LoginAsync() : Successful");

					if (this._sessionStorage == null)
					{
						Console.WriteLine($"Client.AuthService.LoginAsync() : _sessionStorage is null. Can't save Token on Client");
					}
					else
					{
						//Но когда возвращается успешный результат, он извлекает токен аутентификации и сохраняет его в локальном хранилище.
						await this._sessionStorage.SetItemAsync(SessionStorageKey.authToken, result.Token);
						Console.WriteLine($"Client.AuthService.LoginAsync() : Save Token to Client Successfuly");
					}

					//Затем вызовите метод MarkUserAsAuthenticated, который мы только что рассмотрели на ApiAuthenticationStateProvider.
					//1 вариант((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
					((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
					//Наконец, он устанавливает заголовок авторизации по умолчанию для HttpClient.
					this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
					Console.WriteLine($"Client.AuthService.LoginAsync() : end4");
					return result;
				}
			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.LoginAsync() Exception : ");
				Console.WriteLine(ecx.Message);
				//var error = new LoginResult { Successful = false, Error = ecx.Message };
				var error = new LoginResult { Successful = SuccessfulEnum.NotSuccessful, Error = ecx.Message };
				Console.WriteLine($"Client.AuthService.LoginAsync() : end with Exception");
				return error;
			}
		}


		public async Task<UserViewModel> GetUser(UserViewModel userViewModel)
		{
			Console.WriteLine($"Client.AuthService.GetUser() : start");
			if (userViewModel == null)
			{
				Console.WriteLine($"Client.AuthService.GetUser() : in userViewModel is null");
				var error = new UserViewModel { Successful = SuccessfulEnum.NotSuccessful, Error = @"userViewModel is null" };
				Console.WriteLine($"Client.AuthService.GetUser() : end1");
				return error;
			}

			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.GetUser() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					//var error = new LoginResult { Successful = false, Error = $"Authentication Server Url is Empty. Can't get user from Server.  [ Authentication Server Address { authenticationWebapiUrl} ]" };
					var error = new UserViewModel { Successful = SuccessfulEnum.NotSuccessful, Error = @"Authentication Server Url is Empty. Can't get user from Server" };
					Console.WriteLine($"Client.AuthService.GetUser() : end");
					return error;
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.GetUser);
				Console.WriteLine($"Client.AuthService.GetUser() : request {request}");
				//var result = await this._httpClient.PostJsonAsync<LoginResult>(request, loginModel);                //   "api/admin/getuser"
				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<UserViewModel>(request, userViewModel);
				UserViewModel result = await response.Content.ReadFromJsonAsync<UserViewModel>();

				if (result == null)
				{
					Console.WriteLine($"Client.AuthService.GetUser() : Can't login to Server");
					//var error = new LoginResult { Successful = false, Error = "Can't login to Server" };
					var error = new UserViewModel { Successful = SuccessfulEnum.NotSuccessful, Error = @"Can't login to Server" };
					Console.WriteLine($"Client.AuthService.GetUser() : end2");
					return error;
				}
				else
				{
					Console.WriteLine($"Client.AuthService.GetUser() : end");
					return result;

				}

			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.GetUser() Exception : ");
				Console.WriteLine(ecx.Message);
				var error = new UserViewModel { Successful = SuccessfulEnum.NotSuccessful, Error = ecx.Message };
				Console.WriteLine($"Client.AuthService.GetUser() : end with Exception");
				return error;
			}
		}

		public async Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
		{
			Console.WriteLine($"Client.AuthService.LoginAsync() : start");
			if (forgotPasswordModel == null)
			{
				Console.WriteLine($"Client.AuthService.ForgotPassword() : in forgotPasswordModel is null");
				var error = new ForgotPasswordResult { Successful = SuccessfulEnum.NotSuccessful, Error = @"forgotPasswordModel is null" };
				Console.WriteLine($"Client.AuthService.ForgotPassword() : end1");
				return error;
			}

			try
			{
				string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				{
					Console.WriteLine($"Client.AuthService.ForgotPassword() : ERROR Authentication Server Url is Empty. Can't get user from Server");
					//var error = new LoginResult { Successful = false, Error = $"Authentication Server Url is Empty. Can't get user from Server.  [ Authentication Server Address { authenticationWebapiUrl} ]" };
					var error = new ForgotPasswordResult { Successful = SuccessfulEnum.NotSuccessful, Error = @"Authentication Server Url is Empty. Can't get user from Server" };
					Console.WriteLine($"Client.AuthService.ForgotPassword() : end");
					return error;
				}
				string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAdmin.ForgotPassword);
				Console.WriteLine($"Client.AuthService.ForgotPassword() : request {request}");
				//var result = await this._httpClient.PostJsonAsync<LoginResult>(request, loginModel);                //   "api/forgotpassword"
				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<ForgotPasswordModel>(request, forgotPasswordModel);
				ForgotPasswordResult result = await response.Content.ReadFromJsonAsync<ForgotPasswordResult>();

				if (result == null)
				{
					Console.WriteLine($"Client.AuthService.ForgotPassword() : Can't login to Server");
					//var error = new LoginResult { Successful = false, Error = "Can't login to Server" };
					var error = new ForgotPasswordResult { Successful = SuccessfulEnum.NotSuccessful, Error = @"Can't login to Server" };
					Console.WriteLine($"Client.AuthService.ForgotPassword() : end2");
					return error;
				}
				else
				{
					Console.WriteLine($"Client.AuthService.ForgotPassword() : end");
				   return result;
			
				}

			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.ForgotPassword() Exception : ");
				Console.WriteLine(ecx.Message);
				var error = new ForgotPasswordResult { Successful = SuccessfulEnum.NotSuccessful, Error = ecx.Message };
				Console.WriteLine($"Client.AuthService.ForgotPassword() : end with Exception");
				return error;
			}
		}

		public async Task LogoutAaync()
		{
			Console.WriteLine($"Client.AuthService.LogoutAaync() : start");
			try
			{
				await this._sessionStorage.RemoveItemAsync(SessionStorageKey.authToken);
				((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsLoggedOut();
				this._httpClient.DefaultRequestHeaders.Authorization = null;
			}
			catch (Exception ecx) when (LogError(ecx))
			{
				Console.WriteLine("Client.AuthService.LogoutAaync() Exception : ");
				Console.WriteLine(ecx.Message);
				Console.WriteLine($"Client.AuthService.LogoutAaync() : end with Exception");
				return;
			}
			Console.WriteLine($"Client.AuthService.LogoutAaync() : end");
		}

	


		static bool LogError(Exception ex)
		{
			return true;
		}

		// Два варианта добавления данных
		//		localStorage.userName = "Петя";
		//localStorage.setItem("favoriteColor", "чёрный");
		//		localStorage.removeItem("userName");
		//localStorage.removeItem("favoriteColor");

		//public async Task<LoginResult> Login(LoginModel loginModel)
		//{
		//	var result = await _httpClient.PostJsonAsync<LoginResult>(ServerLogin.PostLogin, loginModel);

		//	if (result.Successful)
		//	{
		//		await _localStorage.SetItemAsync(SessionStorageKey.authToken, result.Token);
		//		((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
		//		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

		//		return result;
		//	}

		//	return result;
		//}

		//The Logout method is just doing the reverse of the Login method.

	}
}


// About Component 
//Register.razor
//The register component contains a form which allows the user to enter their email address and desired password.
//When the form is submitted the Register method on the AuthService is called passing in the RegisterModel. 
//If the result of the registration is a success then the user is navigated to the login page.
//Otherwise any errors are displayed to the user.


//	Login.razor
//When the form is submitted the AuthService is called and the result is returned. 
//If the login was successful then the user is redirected to the home page, otherwise they are shown the error message.
