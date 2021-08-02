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
	public interface ICustomerService
	{
		Task<List<string>> GetCustomerCodes(string dataServerAddressUrl);
		Task<List<Customer>> GetCustomers(string dataServerAddressUrl);
	}

	public class CustomerService : ICustomerService
	{
		private readonly HttpClient _httpClient;
		//private readonly IJwtService _jwtService;

		public CustomerService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}


		public async Task<List<string>> GetCustomerCodes(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelCustomer.GetCustomerCodeList);
			Console.WriteLine($"CustomerService.GetCustomerCodes : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<string>>(request);
			return result;
		}

		public async Task<List<Customer>> GetCustomers(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelCustomer.GetCustomers);
			Console.WriteLine($"CustomerService.GetCustomers : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Customer>>(request);
			return result;
		}


	}
}

