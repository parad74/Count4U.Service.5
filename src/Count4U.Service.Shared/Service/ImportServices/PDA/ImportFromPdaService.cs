//using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Model;
using Count4U.Service.Contract;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared
{
	public interface IImportFromPdaService
	{
		Task<string> GetAdapterTitle(string adapterName, string dataServerAddressUrl);
		Task<CommandResult[]> AddToQueueClearRun(string adapterName, string dataServerAddressUrl, string monitorWebAPIAddressUrl, string  hubAddressUrl = "");
		Task<CommandResult[]> AddToQueueImportRun(string fileName, List<string> files, IsSingleFileOrDirectoryEnum isSingleFileOrDictionry,
			string adapterName, string dataServerAddressUrl, string monitorWebAPIAddressUrl, string  hubAddressUrl = "");   //command.AdapterName, command.Path, command.IsSingleFile
		FileItems FileItemsInData { get; set; }
		CommandResult[] RunImportCommandResults { get; set; }
		CommandResult[] RunClearCommandResults { get; set; }

	}
	public class ImportFromPdaService : IImportFromPdaService
	{
		public readonly HttpClient _httpClient;
		public FileItems FileItemsInData { get; set; }
		public CommandResult[] RunImportCommandResults { get; set; }
		public CommandResult[] RunClearCommandResults { get; set; }

		public ImportFromPdaService(HttpClient httpClient)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
		}

		public async Task<string> GetAdapterTitle(string adapterName, string dataServerAddressUrl)  //command.AdapterName
		{
			#region validate
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
			{
				return "dataServerAddressUrl is Empty";
			}
			#endregion

			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UImportFromPdaAdapter.GetAdapterTitle);
		//	var result = await this._httpClient.PostJsonAsync<string>(request, adapterName);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, adapterName);
			string result = await response.Content.ReadFromJsonAsync<string>();
			return result;
		}


		public async Task<CommandResult[]> AddToQueueClearRun(string adapterName, string dataServerAddressUrl, string monitorWebAPIAddressUrl, string  hubAddressUrl = "")  //command.AdapterName, command.Path, command.IsSingleFile
		{
			#region validate
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
			{
				return new CommandResult[] { new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.dataServerAddressUrlIsNull) { Error = "dataServerAddressUrl is empty" } };
			}
			if (string.IsNullOrWhiteSpace(adapterName) == true)
			{
				return new CommandResult[] { new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.AdapterNameIsNull) { Error = "AdapterName is empty" } };
			}
			#endregion

			CommandResult command = new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.none);
			command.AdapterName = adapterName;
			command.FileName = FolderName.inData;
			command.IsSingleFileOrDirectory = IsSingleFileOrDirectoryEnum.IsDirectory;
			command.MonitorAddress = monitorWebAPIAddressUrl;
			command.HubAddress = hubAddressUrl;
	
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UImportFromPdaAdapter.AddToQueueClearRun);
			//var result = await this._httpClient.PostJsonAsync<CommandResult[]>(request, command);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<CommandResult>(request, command);
			CommandResult[] result = await response.Content.ReadFromJsonAsync<CommandResult[]>();
			return result;
		}

		public async Task<CommandResult[]> AddToQueueImportRun(string fileName, List<string> files, IsSingleFileOrDirectoryEnum isSingleFileOrDirectory, string adapterName, string dataServerAddressUrl, string monitorWebAPIAddressUrl, string  hubAddressUrl = "")   //command.AdapterName, command.Path, command.IsSingleFile
		{
			#region validate
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
			{
				return new CommandResult[] { new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.dataServerAddressUrlIsNull) { Error = "dataServerAddressUrl is empty" } };
			}
			if (string.IsNullOrWhiteSpace(adapterName) == true)
			{
				return new CommandResult[] { new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.AdapterNameIsNull) { Error = "AdapterName is empty" } };
			}
			if (string.IsNullOrWhiteSpace(fileName) == true)
			{
				return new CommandResult[] { new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.FileNameIsNull) { Error = "path is empty" } };
			}
			Console.WriteLine($"adapterName {adapterName}; path {fileName}");
			#endregion


			CommandResult command = new CommandResult(fileName, files, isSingleFileOrDirectory, SuccessfulEnum.NotStart, CommandResultCodeEnum.Unknown, CommandErrorCodeEnum.none, dataServerAddressUrl, monitorWebAPIAddressUrl, hubAddressUrl);
			command.AdapterName = adapterName;
			
			//command.User = user;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UImportFromPdaAdapter.AddToQueueImportRun);
			//var result = await this._httpClient.PostJsonAsync<CommandResult[]>(request, command);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<CommandResult>(request, command);
			CommandResult[] result = await response.Content.ReadFromJsonAsync<CommandResult[]>();
			return result;
		}




	}
}

