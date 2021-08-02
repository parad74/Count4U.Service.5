//using Blazored.LocalStorage;
using Count4U.Admin.Client.Blazor.I18nText;
using Monitor.Service.Urls;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Count4U.Admin.Client.Page
{
	public class IndexBase : ComponentBase
	{
		public GetResources LocalizationResources = new GetResources();

		[Inject]
		protected IClaimService _claimService { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		//[Inject]
		//protected ILocalStorageService _localStorage { get; set; }

		public string _authenticationWebapiUrl { get; set; }
		public string TextSubmit = "Submit";
		public string TextRegister = "Register";
		public string PingServer { get; set; }
	public IndexBase()
		{
			string register = LocalizationResources.Login_Register;
		}

		protected override async Task OnInitializedAsync()
		{
			//await _claimService.InitWebAPISettings();
			this._authenticationWebapiUrl = "";

			string authenticationServerGetFromSetting = "";

			string authenticationServerUrlFromLocalStorage = "";


			if (this._claimService != null)
			{
				string result = await this._claimService.PingServerAsync();
				this.PingServer = "CLIENT";
				if (result == PingOpetarion.Pong) this.PingServer = "SERVER";
				Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : result {result}");
				authenticationServerGetFromSetting = await this._claimService.InitWebAPISettings();
				Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : authenticationServerGetFromSetting : {authenticationServerGetFromSetting}");

			}

			//if (this._localStorage != null)
			//{
			//	authenticationServerUrlFromLocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.authenticationWebapiUrl);
			//	Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : authenticationServerUrlFromLocalStorage : {authenticationServerUrlFromLocalStorage}");
			//}
		
			if (string.IsNullOrWhiteSpace(authenticationServerUrlFromLocalStorage) == false)
			{
				this._authenticationWebapiUrl = authenticationServerUrlFromLocalStorage;
				Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : _authenticationWebapiUrl set as : {authenticationServerUrlFromLocalStorage}");
			}
			else 
			{
				this._authenticationWebapiUrl = authenticationServerGetFromSetting;
				Console.WriteLine($"Client.IndexBase.OnInitializedAsync() : _authenticationWebapiUrl set as : {authenticationServerGetFromSetting}");
				//if (this._localStorage != null)
				//{
				//	await this._localStorage.SetItemAsync(SessionStorageKey.authenticationWebapiUrl, authenticationServerGetFromSetting);
				//}
			}

			this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
			this.TextSubmit = LocalizationResources.Login_Submit;
			this.TextRegister = LocalizationResources.Login_Register;

		}

	
	}
}
