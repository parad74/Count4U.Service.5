using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Model.Audit;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared
{
	public interface IInventorService
	{
		Task<List<Inventor>> GetInventors(string dataServerAddressUrl);            //Processes GetProcesses();
		Task<List<Inventor>> GetInventoresByCurrnetBranch(string dataServerAddressUrl);

	}
	public class InventorService : IInventorService
	{
		private readonly HttpClient _httpClient;
		//private readonly IJwtService _jwtService;

		public InventorService(HttpClient httpClient/*, IJwtService jwtService*/)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}


		public async Task<List<Inventor>> GetInventors(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelInventor.GetInventors);
			Console.WriteLine($"InventorService.GetInventors() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Inventor>>(request);
			return result;
		}

		public async Task<List<Inventor>> GetInventoresByCurrnetBranch(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelInventor.GetInventorsByCurrentBranch);
			Console.WriteLine($"InventorService.GetInventoresByCurrnetBranch() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Inventor>>(request);
			return result;
		}

	}
}

