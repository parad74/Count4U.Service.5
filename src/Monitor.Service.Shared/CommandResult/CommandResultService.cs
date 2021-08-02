using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Model.SelectionParams;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Monitor.Service.Shared
{
	public interface ICommandResultService
	{
		Task<CommandResults> GetCommandResults(string dataServerAddressUrl);
		Task<CommandResults> GetCommandResultsWithSelectParam(SelectParams selectParams, string dataServerAddressUrl);
		Task<CommandResult> GetCommandResultById(long id, string dataServerAddressUrl);
		Task<CommandResult> GetCommandResultByCommandResultCode(string commandResultCode, string dataServerAddressUrl);
		Task<CommandResults> GetCommandResultsByParentCode(string parentCommandResultCode, string dataServerAddressUrl);
		Task<long> DeleteById(long id, string dataServerAddressUrl);
		Task<string> DeleteByCommandResultCode(string commandResultCode, string dataServerAddressUrl);
		Task<long> Insert(CommandResult commandResult, string dataServerAddressUrl);
		Task<long> Update(CommandResult commandResult, string dataServerAddressUrl);

	}


	public class CommandResultService : ICommandResultService
	{
		private readonly HttpClient _httpClient;


		public CommandResultService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}

		public async Task<CommandResults> GetCommandResults(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.GetCommandResults);
			Console.WriteLine($"CommandResultService.GetCommandResults : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<CommandResults>(request);
			//return await Task.FromResult(result);
			return result;
		}


		//public const string GetCommandResultsWithSelectParam = @"api/commandresult/GetCommandResultsWithSelectParam";
		public async Task<CommandResults> GetCommandResultsWithSelectParam(SelectParams selectParams, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.GetCommandResultsWithSelectParam);
			//CommandResults result = await this._httpClient.PostJsonAsync<CommandResults>(request, selectParams);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<SelectParams>(request, selectParams);
			CommandResults result = await response.Content.ReadFromJsonAsync<CommandResults>();
			return result;
		}


		//public const string GetCommandResultById = @"api/commandresult/GetCommandResultById";
		public async Task<CommandResult> GetCommandResultById(long id, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.GetCommandResultById);
			//CommandResult result = await this._httpClient.PostJsonAsync<CommandResult>(request, id);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<long>(request, id);
			CommandResult result = await response.Content.ReadFromJsonAsync<CommandResult>();
			return result;
		}

		//public const string GetCommandResultByCommandResultCode = @"api/commandresult/GetCommandResultByCommandResultCode";
		public async Task<CommandResult> GetCommandResultByCommandResultCode(string commandResultCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.GetCommandResultByCommandResultCode);
			//CommandResult result = await this._httpClient.PostJsonAsync<CommandResult>(request, commandResultCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, commandResultCode);
			CommandResult result = await response.Content.ReadFromJsonAsync<CommandResult>();
			return result;
		}

		//public const string GetCommandResultsByParentCode = @"api/commandresult/GetCommandResultsByParentCode";
		public async Task<CommandResults> GetCommandResultsByParentCode(string parentCommandResultCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.GetCommandResultsByParentCode);
			//CommandResults result = await this._httpClient.PostJsonAsync<CommandResults>(request, parentCommandResultCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, parentCommandResultCode);
			CommandResults result = await response.Content.ReadFromJsonAsync<CommandResults>();
			return result;
		}

		//public const string DeleteById = @"api/commandresult/DeleteById";
		public async Task<long> DeleteById(long id, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return -1;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, Urls.WebApiMonitorCommandResult.DeleteById);
		//	long result = await this._httpClient.PostJsonAsync<long>(request, id);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<long>(request, id);
			long result = await response.Content.ReadFromJsonAsync<long>();
			return result;
		}

		//public const string DeleteByCommandResultCode = @"api/commandresult/DeleteByCommandResultCode";
		public async Task<string> DeleteByCommandResultCode(string commandResultCode, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return "0";
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.DeleteByCommandResultCode);
			//string result = await this._httpClient.PostJsonAsync<string>(request, commandResultCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, commandResultCode);
			string result = await response.Content.ReadFromJsonAsync<string>();
			return result;
		}

		//public const string Insert = @"api/commandresult/Insert";
		public async Task<long> Insert(CommandResult commandResult, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return -1;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.Insert);
			//long result = await this._httpClient.PostJsonAsync<long>(request, commandResult);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<CommandResult>(request, commandResult);
			long result = await response.Content.ReadFromJsonAsync<long>();
			return result;
		}

		//public const string Update = @"api/commandresult/Update";
		public async Task<long> Update(CommandResult commandResult, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return -1;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiMonitorCommandResult.Update);
			//long result = await this._httpClient.PostJsonAsync<long>(request, commandResult);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<CommandResult>(request, commandResult);
			long result = await response.Content.ReadFromJsonAsync<long>();
			return result;
		}
	}
}

