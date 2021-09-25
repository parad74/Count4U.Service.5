using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Count4U.Model.SelectionParams;
using Microsoft.AspNetCore.Mvc;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Monitor.Service.Shared
{
	public interface IFileDefaultService
	{

		//Task<XDocument> GetDefaultProfileXDocument(string dataServerAddressUrl);
		//Task<string> GetDefaultProfileString(string dataServerAddressUrl);
		Task<ProfileFile> GetDefaultProfileFile(string dataServerAddressUrl);

	}


	public class FileDefaultService : IFileDefaultService
	{
		private readonly HttpClient _httpClient;
	

		public FileDefaultService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
		}

		//public async Task<XDocument> GetDefaultProfileXDocument(string dataServerAddressUrl)
		//{
		//	if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
		//		return null;
		//	string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiFileFetcher.GetDefaultProfileXDocument);
		//	Console.WriteLine($"FileDefaultService.GetDefaultProfileXDocument : request {request}");
		//	var result = await this._httpClient.GetFromJsonAsync<XDocument>(request);
		//	return result;
		//}

		//public async Task<string> GetDefaultProfileString(string dataServerAddressUrl)
		//{
		//	if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
		//		return null;
		//	try
		//	{
		//		string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiFileFetcher.GetDefaultProfileFile);
		//		Console.WriteLine($"FileDefaultService.GetDefaultProfileString : request {request}");
		//		var result = await this._httpClient.GetAsync(request);
		//		Console.WriteLine($"FileDefaultService.GetDefaultProfileString : result {result}");
		//		Console.WriteLine($"FileDefaultService.GetDefaultProfileString : result.Content {result.Content}");
		//		return result.Content.ToString();
		//	}
		//	catch (Exception excp)
		//	{
		//		Console.WriteLine($"FileDefaultService.GetDefaultProfileString : Error {excp.Message}");
		//		return "";
		//	}
		//}

		public async Task<ProfileFile> GetDefaultProfileFile(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiFileFetcher.GetDefaultProfileFile);
			Console.WriteLine($"ProfileFileService.GetInventoriesProfileFiles : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<ProfileFile>(request);
			return result;
		}

	}
}

