using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Monitor.Service.Model;
using Monitor.Service.Model.Settings;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared.Settings
{
	public interface IWebAPISettingsService
	{
		Task<string> GetCount4UWebApiUrls(string fromContext);
		Task<string> GetAuthenticationWebApiUrls(string fromContext);
		Task<string> GetAuthenticationWebApiUrl(string fromContext);
		Task<string> GetMonitorWebApiUrls(string fromContext);
		Task<string> GetMonitorWebApiUrl(string fromContext);

		Task<string> GetWebApiUrls(string fromContext); //work old 
		Task<WebAPISettings> GetWebAPISettingsAsync(string fromContext);
	}
	public class WebAPISettingsService : IWebAPISettingsService
	{
		private readonly HttpClient _httpClient;

		public WebAPISettingsService(HttpClient httpClient)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			int i = 0;
		}


		public async Task<WebAPISettings> GetWebAPISettingsAsync(string fromContext)
		{
			try
			{
				Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : start from context {fromContext}");
				var path = ServerSettings.GetWebAPISettings;
				Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : path : {path}");
				WebAPISettingsResult result = null;
				try
				{
					result = await this._httpClient.GetFromJsonAsync<WebAPISettingsResult>(path);
				}
				catch (Exception ecx) { Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : end with error {ecx.Message}"); }

				if (result == null)
				{
					Console.WriteLine($"result is null");
					Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : end");
					return new WebAPISettings();
				}
				if (result.Successful == SuccessfulEnum.Successful)
				{
					Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : result.Successful == true end");
					if (result._webAPISettings != null)
					{
						Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : authenticationWebapiUrl ={result._webAPISettings.authenticationWebapiUrls} | count4uWebapiUrl = {result._webAPISettings.count4uWebapiUrls} | monitorWebapiUrls = {result._webAPISettings.monitorWebapiUrls}");
						Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : end");
						return result._webAPISettings;
					}
					else
					{
						Console.WriteLine($"result._webAPISettings is null");
						Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() : end");
						return new WebAPISettings();
					}
				}
				else      //(result.Successful == false)
				{
					Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() :  : result.Successful == false  end");
					return new WebAPISettings();
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine($"WebAPISettingsService.GetWebAPISettings() :  end with Exception {exp.Message}");
				return new WebAPISettings();
			}
		}


		public async Task<string> GetWebApiUrls(string fromContext)
		{
			try
			{
				Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() : start from {fromContext}");
				var path = ServerSettings.Count4uWebapiUrl;
				Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() : path : {path}");
				string settings = await this._httpClient.GetFromJsonAsync<string>(path);
				if (string.IsNullOrEmpty(settings) == true)
				{
					Console.WriteLine($"WebAPISettings is empty");
					Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() : end");
					return "";
				}
				else
				{
					Console.WriteLine($"webapiUrl: {settings}");
					Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() : end");
					return settings;
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() :  end with Exception {exp.Message}");
				return "";
			}
		}

		public async Task<string> GetCount4UWebApiUrls(string fromContext)
		{
			try
			{
				Console.WriteLine($"WebAPISettingsService.GetCount4UWebApiUrls() : start from {fromContext}");
				var path = ServerSettings.Count4uWebapiUrl;
				Console.WriteLine($"WebAPISettingsService.GetCount4UWebApiUrls() : path : {path}");
				string settings = await this._httpClient.GetFromJsonAsync<string>(path);
				if (string.IsNullOrEmpty(settings) == true)
				{
					Console.WriteLine($"WebAPISettings is empty");
					Console.WriteLine($"WebAPISettingsService.GetCount4UWebApiUrls() : end");
					return "";
				}
				else
				{
					Console.WriteLine($"count4uWebapiUrl: {settings}");
					Console.WriteLine($"WebAPISettingsService.GetCount4UWebApiUrls() : end");
					return settings;
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() :  end with Exception {exp.Message}");
				return "";
			}

		}

		public async Task<string> GetAuthenticationWebApiUrls(string fromContext)
		{
			//Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrls() : start");
			//var tempPath = "http://localhost:52025";
			//Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrls() : end");
			//return tempPath;
			try
			{
				Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrls() : start from {fromContext}");
				var path = ServerSettings.AuthenticationWebapiUrls;
				Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrls() : path : {path}");
				string settings = await this._httpClient.GetFromJsonAsync<string>(path);
				if (string.IsNullOrEmpty(settings) == true)
				{
					Console.WriteLine($"WebAPISettings is empty");
					Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrls() : end");
					return "";
				}
				else
				{
					Console.WriteLine($"count4uWebapiUrl: {settings}");
					Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrls() : end");
					return settings;
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() :  end with Exception {exp.Message}");
				return "";
			}

		}

		public async Task<string> GetAuthenticationWebApiUrl(string fromContext)
		{
			//Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : start");
			//string tempPath = "http://localhost:52025";
			//Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : {tempPath}");
			//Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : end");
			//return tempPath;

			try
			{
				Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : start from {fromContext}");
				var path = ServerSettings.AuthenticationWebapiUrl;
				//var path = ServerPing.GetPing;
				Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : path : {path}");
				var settings = "";
				try
				{
					settings = await this._httpClient.GetFromJsonAsync<string>(path);
					Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : settings : {settings}");
				}
				catch (Exception ecx) { Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : end with error {ecx.Message}"); }
				Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : setting : {settings}");
				if (string.IsNullOrEmpty(settings) == true)
				{
					Console.WriteLine($"WebAPISettings is empty");
					Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : end");
					return "";
				}
				else
				{
					Console.WriteLine($"count4uWebapiUrl: {settings}");
					Console.WriteLine($"WebAPISettingsService.GetAuthenticationWebApiUrl() : end");
					List<string> urls = settings.Split(';').ToList();
					if (urls != null)
					{
						if (urls.Count > 0)
						{
							return urls[0];
						}
					}
					return "";
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine($"WebAPISettingsService.GetWebApiUrls() :  end with Exception {exp.Message}");
				return "";
			}
		}

		//=====================
		public async Task<string> GetMonitorWebApiUrls(string fromContext)
		{
			//Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrls() : start");
			//var tempPath = "http://localhost:12349";
			//Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrls() : end");
			//return tempPath;
			try
			{
				Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrls() : start from {fromContext}");
				var path = ServerSettings.MonitorWebapiUrls;
				Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrls() : path : {path}");
				string settings = await this._httpClient.GetFromJsonAsync<string>(path);
				if (string.IsNullOrEmpty(settings) == true)
				{
					Console.WriteLine($"WebAPISettings is empty");
					Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrls() : end");
					return "";
				}
				else
				{
					Console.WriteLine($"count4uWebapiUrl: {settings}");
					Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrls() : end");
					return settings;
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrls() :  end with Exception {exp.Message}");
				return "";
			}

		}

		public async Task<string> GetMonitorWebApiUrl(string fromContext)
		{
			//Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : start");
			//string tempPath = "http://localhost:12349";
			//Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : {tempPath}");
			//Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : end");
			//return tempPath;

			try
			{
				Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : start from {fromContext}");
				var path = ServerSettings.MonitorWebapiUrl;
				//var path = ServerPing.GetPing;
				Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : path : {path}");
				var settings = "";
				try
				{
					settings = await this._httpClient.GetFromJsonAsync<string>(path);
					Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : settings : {settings}");
				}
				catch (Exception ecx) { Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : end with error {ecx.Message}"); }
				Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : setting : {settings}");
				if (string.IsNullOrEmpty(settings) == true)
				{
					Console.WriteLine($"WebAPISettings is empty");
					Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : end");
					return "";
				}
				else
				{
					Console.WriteLine($"count4uWebapiUrl: {settings}");
					Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() : end");
					List<string> urls = settings.Split(';').ToList();
					if (urls != null)
					{
						if (urls.Count > 0)
						{
							return urls[0];
						}
					}
					return "";
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine($"WebAPISettingsService.GetMonitorWebApiUrl() :  end with Exception {exp.Message}");
				return "";
			}
		}

	}
}

