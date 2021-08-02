//using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Model.Main;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared
{
	public interface IBranchService
	{
		Task<List<Branch>> GetBranches(string dataServerAddressUrl);            //Processes GetProcesses();
		Task<List<Branch>> GetBranchesByCurrnetCustomer(string dataServerAddressUrl);

	}
	public class BranchService : IBranchService
	{
		private readonly HttpClient _httpClient;
		//	private readonly IJwtService _jwtService;

		public BranchService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}


		public async Task<List<Branch>> GetBranches(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelBranch.GetBranches);
			Console.WriteLine($"BranchService.GetBranches() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Branch>>(request);
			return result;
		}

		public async Task<List<Branch>> GetBranchesByCurrnetCustomer(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelBranch.GetBranchesByCurrnetCustomer);
			Console.WriteLine($"BranchService.GetBranchesByCurrnetCustomer : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Branch>>(request);
			return result;
		}

	}
}

