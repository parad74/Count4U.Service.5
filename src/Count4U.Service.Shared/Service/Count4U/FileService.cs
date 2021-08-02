using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Service.Contract;
using Microsoft.Extensions.Logging;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared
{
	public interface IFileService
	{
		Task<string> GetProcessFolderAsync(string dataServerAddressUrl);
		Task<List<FileInfo>> GetFilesInfoInDataFolderAsync(string dataServerAddressUrl);
		Task<FileItems> GetFileItemsInDataFolderAsync(string dataServerAddressUrl);


	}
	public class FileService : IFileService
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		public FileService(HttpClient httpClient, ILoggerFactory loggerFactory)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			this._logger = loggerFactory.CreateLogger<FileService>();
		}


		public async Task<string> GetProcessFolderAsync(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
			{
				return "";
			}
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UPathSetting.FromPdaProcessPath);
			Console.WriteLine($"FileService.GetProcessFolder() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<string>(request);
			return result;
		}

		public async Task<List<FileInfo>> GetFilesInfoInDataFolderAsync(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
			{
				return new List<FileInfo>();
			}

			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UPathSetting.GetFilesInfoInDataFolder);
			Console.WriteLine($"FileService.GetFilesInfoInDataFolder() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<FileInfo>>(request);
			if (result == null)
			{
				return new List<FileInfo>();
			}
			foreach (var r in result)
			{
				this._logger.LogWarning($" NameInfo {r.Name}");
				this._logger.LogWarning($" SizeInfo {r.Length}");
			}
			return result;
		}

		public async Task<FileItems> GetFileItemsInDataFolderAsync(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
			{
				return new FileItems();
			}

			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UPathSetting.GetFilesItemInDataFolder);
			Console.WriteLine($"FileService.GetFilesItemInDataFolder() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<FileItems>(request);
			if (result == null)
			{
				return new FileItems();
			}
			else
			{
				foreach (var r in result)
				{
					this._logger.LogWarning($" Name {r.Name}");
					this._logger.LogWarning($" Size {r.Size}");
				}
				return result;
			}

		}



	}
}

