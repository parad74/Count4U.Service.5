using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
//using Blazored.LocalStorage;
//using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Monitor.Service.Model;
using Monitor.Service.Urls;
using System.Text.Json;

namespace Count4U.Service.Shared
{
	//Поскольку мы используем клиентскую версию Blazor, нам нужно предоставить собственную реализацию для класса AuthenticationStateProvider.
	//Поскольку существует множество вариантов клиентских приложений, нет способа создать класс по умолчанию, который бы работал для всех.
	//Нужно переопределить метод GetAuthenticationStateAsync.
	//В этом методе нам нужно определить, аутентифицирован ли текущий пользователь или нет.
	//также нужно добавить несколько вспомогательных методов, которые мы будем использовать для обновления состояния аутентификации, когда пользователь входит в систему или выходит из нее.
	public class ApiAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly HttpClient _httpClient;
		//private readonly ISessionStorageService _sessionStorage;
		//private readonly ILocalStorageService _localStorage;

		private readonly IJwtService _jwtService;

		public ApiAuthenticationStateProvider(HttpClient httpClient
		 //  , ISessionStorageService sessionStorage
			//, ILocalStorageService localStorage
		   , IJwtService jwtService)
		{

			this._httpClient = httpClient ??
							   throw new ArgumentNullException(nameof(httpClient));
			//this._sessionStorage = sessionStorage ??
			//				  throw new ArgumentNullException(nameof(sessionStorage));
			//this._localStorage = localStorage ??
			//				  throw new ArgumentNullException(nameof(localStorage));
			this._jwtService = jwtService ??
							  throw new ArgumentNullException(nameof(jwtService));
		}

		//Метод GetAuthenticationStateAsync вызывается компонентом CascadingAuthenticationState, чтобы определить, 
		//аутентифицирован ли текущий пользователь или нет.
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : start");
			//if (this._sessionStorage == null)
			//{
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : _sessionStorage is null");
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : end");
			//	return new AuthenticationState(new ClaimsPrincipal());
			//}
			//if (this._localStorage == null)
			//{
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : _localStorage is null");
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : end");
			//	return new AuthenticationState(new ClaimsPrincipal());
			//}

			//try
			//{
				//var savedToken = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
				//string authenticationWebapiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
				//// мы проверяем, есть ли токен аутентификации в локальном хранилище.Если есть, мы извлекаем его 
				////и устанавливаем заголовок авторизации по умолчанию для HttpClient.
				//if (!string.IsNullOrWhiteSpace(savedToken))
				//{
				//	this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
				//}

				//if (string.IsNullOrWhiteSpace(authenticationWebapiUrl) == true)
				//{
				//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : ERROR  Authentication Server Url is Empty. Can't get user from Server");
				//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : end");
				//	return new AuthenticationState(new ClaimsPrincipal());
				//}

				//string requestPing = Opetarion.UrlCombine(authenticationWebapiUrl, Common.Urls.WebApiAuthenticationPing.GetPing);
				//Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : request  {requestPing}");
				//try
				//{
				//	var resultPing = await this._httpClient.GetFromJsonAsync<string>(requestPing);
				//}
				//catch (Exception ecx) when (LogError(ecx))
				//{
				//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : can't ping Authentication Server");
				//	Console.WriteLine(ecx.Message);
				//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : end");
				//	return new AuthenticationState(new ClaimsPrincipal());
				//}

				//Затем мы делаем вызов конечной точке GetUser, которую мы видели ранее на контроллере учетных записей.
				//string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAccounts.GetUser);
				//Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : request {request}");
				//UserModel userInfo = await this._httpClient.GetFromJsonAsync<UserModel>(request); //"api/accounts/user");
				//if (userInfo == null)
				//{
				//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : userInfo is null. Can't get from Server");
				//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : end");
				//	return new AuthenticationState(new ClaimsPrincipal());
				//}

				//Если токен все еще действителен, то мы получим ответ, указывающий, что пользователь аутентифицирован, 
				//и мы можем затем создать новый принципал заявок с информацией о текущих пользователях.

				//Если токен в локальном хранилище отсутствует или токен больше не действителен, 
				//то мы создаем пустой субъект заявок. Это эквивалентно тому, что текущий пользователь не аутентифицирован.
				// 1 версия
				//var identity = userInfo.IsAuthenticated
				//             ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userInfo.Email) }, "apiauth")
				//             : new ClaimsIdentity();

				// 2 версия
			//	var identity = userInfo.IsAuthenticated ? new ClaimsIdentity(this._jwtService.ParseClaimsFromJwt(savedToken), "jwt") : new ClaimsIdentity();

			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : end");
			//	return new AuthenticationState(new ClaimsPrincipal(identity));
			//}
			//catch (Exception exc) when (LogError(exc))
			//{
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() Exception ");
			//	Console.WriteLine(exc.Message);
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetAuthenticationStateAsync() : end with Exception");
				return new AuthenticationState(new ClaimsPrincipal());
			//}
		}

		//MarkUserAsAuthenticated - это вспомогательный метод, который используется при входе пользователя в систему.
		//Его единственная цель - вызвать метод NotifyAuthenticationStateChanged, который вызывает событие AuthenticationStateChanged.
		//Это каскадирует новое состояние аутентификации через компонент CascadingAuthenticationState.
		public void MarkUserAsAuthenticated(string token)
		{
			//1 версия
			//var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
			//2 версия
			Console.WriteLine($"Client.ApiAuthenticationStateProvider.MarkUserAsAuthenticated() : start");
			if (string.IsNullOrWhiteSpace(token) == true)
				Console.WriteLine("Client.ApiAuthenticationStateProvider.MarkUserAsAuthenticated() : token is empty");

			try
			{
				var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(this._jwtService.ParseClaimsFromJwt(token), "jwt"));
				if (authenticatedUser == null)
					Console.WriteLine("Client.ApiAuthenticationStateProvider.MarkUserAsAuthenticated() : authenticatedUser is null");
				var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
				this.NotifyAuthenticationStateChanged(authState);
				Console.WriteLine($"Client.ApiAuthenticationStateProvider.MarkUserAsAuthenticated() : end");
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ApiAuthenticationStateProvider.MarkUserAsAuthenticated() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ApiAuthenticationStateProvider.MarkUserAsAuthenticated() : end with Exception");
			}
		}

		//Как вы можете ожидать, MarkUserAsLoggedOut делает почти то же самое, что и предыдущий метод, 
		//но когда пользователь выходит из системы.
		public void MarkUserAsLoggedOut()
		{
			Console.WriteLine($"Client.ApiAuthenticationStateProvider.MarkUserAsLoggedOut() : start");
			try
			{
				var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
				var authState = Task.FromResult(new AuthenticationState(anonymousUser));
				this.NotifyAuthenticationStateChanged(authState);
			}
			catch (Exception exc) when (LogError(exc))
			{
				Console.WriteLine("Client.ApiAuthenticationStateProvider.MarkUserAsLoggedOut() Exception : ");
				Console.WriteLine(exc.Message);
				Console.WriteLine($"Client.ApiAuthenticationStateProvider.MarkUserAsLoggedOut() : end with Exception");
			}
			Console.WriteLine($"Client.ApiAuthenticationStateProvider.MarkUserAsLoggedOut() : end");
		}


		public async Task<IEnumerable<Claim>> GetClaimsFromTokenAsync()
		{
			Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetClaimsFromTokenAsync() : start");
			//if (this._sessionStorage == null)
			//{
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetClaimsFromTokenAsync() : _sessionStorage is null");
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetClaimsFromTokenAsync() : end");
			//	return new List<Claim>();
			//}

			//try
			//{
			//	var savedToken = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
			//	var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(this._jwtService.ParseClaimsFromJwt(savedToken), "jwt"));
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetClaimsFromTokenAsync() : end");
			//	if (authenticatedUser == null)
			//		return new List<Claim>();
			//	return authenticatedUser.Claims;
			//}
			//catch (Exception exc) when (LogError(exc))
			//{
			//	Console.WriteLine("Client.ApiAuthenticationStateProvider.GetClaimsFromTokenAsync() Exception : ");
			//	Console.WriteLine(exc.Message);
			//	Console.WriteLine($"Client.ApiAuthenticationStateProvider.GetClaimsFromTokenAsync() : end with Exception");
				return new List<Claim>();
			//}
		}

		//public ClaimsPrincipal GetClaimsPrincipalFromToken(string savedToken)
		//{
		//	ClaimsPrincipal authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt"));
		//	return authenticatedUser;
		//}



		static bool LogError(Exception ex)
		{
			return true;
		}
	}
}
