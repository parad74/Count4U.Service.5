//using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Count4U.Model.Count4U;
using Count4U.Model.SelectionParams;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared
{
	public interface IIturService
	{
		Task<List<Itur>> GetIturs(string dataServerAddressUrl);
		Task<List<Itur>> GetIturCodesForLocationCode(string dataServerAddressUrl, string locationCode);
		Task<Itur> GetRefillApproveStatusBitByIturCode(string dataServerAddressUrl, string iturCode);
		Task<int> RefillApproveStatusBitByIturCode(string dataServerAddressUrl, string iturCode);
		Task<int> RefillApproveStatusBitByIturCodeList(string dataServerAddressUrl, List<string> iturCodeList);
		Task<bool> ClearStatusBit(string dataServerAddressUrl);
		IAsyncEnumerable<Itur> RefillApproveStatusBitByIturListAsync(List<Itur> iturs, string dataServerAddressUrl, CancellationToken ct = default);
		Task<int> RefillParallelApproveStatusBit(string dataServerAddressUrl);

		Task<List<Itur>> GetTopIturs(int top, string dataServerAddressUrl);
		Task<long> GetIturTotalCount(string dataServerAddressUrl);
		Task<List<Itur>> GetSelectParamsIturs(SelectParams sp, string dataServerAddressUrl);
		IAsyncEnumerable<int> RefillParallelApproveStatusBitSelectParamsAsync(List<SelectParams> spl, string dataServerAddressUrl, CancellationToken ct = default);
		Task<bool> TestUpdateFileItemsInData(string dataServerAddressUrl);

	}		
	//https://habr.com/ru/post/573434/
	//	static async IAsyncEnumerable<int> PrintNumbers(int n)
	//	{
	//		for (int i = 0; i < n; i++) yield return i;
	//	}

	//using Stream stream = Console.OpenStandardOutput();
	//var data = new { Data = PrintNumbers(3) };
	//	await JsonSerializer.SerializeAsync(stream, data); // prints {"Data":[0,1,2]}
//	===========
//	var stream = new MemoryStream(Encoding.UTF8.GetBytes("[0,1,2,3,4]"));
//	await foreach (int item in JsonSerializer.DeserializeAsyncEnumerable<int>(stream))
//{
//    Console.WriteLine(item);
//}
public class IturService : IIturService
	{
		private readonly HttpClient _httpClient;
		//private readonly IJwtService _jwtService;

		public IturService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}


		public async Task<List<Itur>> GetIturs(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetIturs);
			Console.WriteLine($"IturService.GetIturs() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Itur>>(request);
			return result;
		}


		public async Task<long> GetIturTotalCount(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return 0;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetIturTotalCount);
			Console.WriteLine($"IturService.GetIturTotalCount() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<long>(request);
			return result;
		}

		public async Task<List<Itur>> GetTopIturs(int top, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return new List<Itur>();
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetTopIturs);
			//var result = await this._httpClient.PostJsonAsync<List<Itur>>(request, top);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<int>(request, top);
			List<Itur> result = await response.Content.ReadFromJsonAsync<List<Itur>>();
			return result;
		}


		public async Task<List<Itur>> GetSelectParamsIturs(SelectParams sp, string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return new List<Itur>();
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetSelectParamsIturs);
			//var result = await this._httpClient.PostJsonAsync<List<Itur>>(request, sp);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<SelectParams>(request, sp);
			List<Itur> result = await response.Content.ReadFromJsonAsync<List<Itur>>();
			return result;
		}

		public async Task<Itur> GetIturByCode(string dataServerAddressUrl, string iturCode)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return new Itur();
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetIturByCode);
		//	var itur = await this._httpClient.PostJsonAsync<Itur>(request, iturCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, iturCode);
			Itur result = await response.Content.ReadFromJsonAsync<Itur>();
			return result;
		}

		public async Task<Itur> GetRefillApproveStatusBitByIturCode(string dataServerAddressUrl, string iturCode)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return new Itur();
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetRefillApproveStatusBitByIturCode); //Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode);
			Console.WriteLine($"IturService.GetRefillApproveStatusBitByIturCode() : request {request}");
			//var itur = await this._httpClient.PostJsonAsync<Itur>(request, iturCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, iturCode);
			Itur result = await response.Content.ReadFromJsonAsync<Itur>();
			return result;
		}

		public async Task<int> RefillApproveStatusBitByIturCode(string dataServerAddressUrl, string iturCode)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return 0;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.RefillApproveStatusBitByIturCode); //Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode);
			Console.WriteLine($"IturService.RefillApproveStatusBitByIturCode() : request {request}");
			//var itur = await this._httpClient.PostJsonAsync<int>(request, iturCode);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, iturCode);
			int result = await response.Content.ReadFromJsonAsync<int>();
			return result;
		}


		public async Task<int> RefillApproveStatusBitByIturCodeList(string dataServerAddressUrl, List<string> iturCodeList)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return 0;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.RefillApproveStatusBitByIturCodeList); //Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode);
			Console.WriteLine($"IturService.RefillApproveStatusBitByIturCodeList() : request {request}");
		//	var itur = await this._httpClient.PostJsonAsync<int>(request, iturCodeList);
			HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<List<string>>(request, iturCodeList);
			int result = await response.Content.ReadFromJsonAsync<int>();
			return result;
		}

		public async Task<bool> TestUpdateFileItemsInData(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return false;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.TestUpdateFileItemsInData);
			Console.WriteLine($"IturService.TestUpdateFileItemsInData() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<bool>(request);
			return result;
		}

		public async IAsyncEnumerable<Itur> RefillApproveStatusBitByIturListAsync(List<Itur> iturs, string dataServerAddressUrl, CancellationToken ct = default)
		{
			//for (int i = 0; i < 10; i++) {
			//    int result = await GetServiceDataAsync(ct)
			//        .ConfigureAwait(false);
			//    yield return result;
			//}
			//как использовать
			//await foreach (int r in GetResultsAsync().WithCancellation(cancellationToken).ConfigureAwait(false))
			// Console.WriteLine(r);

			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetRefillApproveStatusBitByIturCode); //Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode);
			foreach (var itur in iturs)
			{
				//ct.ThrowIfCancellationRequested();
			//	Itur resultItur = await this._httpClient.PostJsonAsync<Itur>(request, itur.IturCode);//.ConfigureAwait(false);
				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<string>(request, itur.IturCode);
				Itur result = await response.Content.ReadFromJsonAsync<Itur>();
				yield return result;
			}

		}


		//public async Task<Itur> RefillApproveStatusBit(string dataServerAddressUrl)
		//{
		//	if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true) return new Itur();
		//	string request = Opetarion.UrlCombine(dataServerAddressUrl, Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode); //Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode);
		//	Console.WriteLine($"IturService.RefillApproveStatusBitByIturCode() : request {request}");
		//	var itur = await this._httpClient.PostJsonAsync<Itur>(request, iturCode);
		//	return itur;
		//}

		public async Task<int> RefillParallelApproveStatusBit(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return -2;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.RefillParallelApproveStatusBit);
			Console.WriteLine($"IturService.ClearStatusBit() : request {request}");
			int ret = await this._httpClient.GetFromJsonAsync<int>(request);
			return ret;
		}

		public async IAsyncEnumerable<int> RefillParallelApproveStatusBitSelectParamsAsync(List<SelectParams> spl, string dataServerAddressUrl, CancellationToken ct = default)
		{

			//	string request = Opetarion.UrlCombine(dataServerAddressUrl, Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode); //Common.Urls.WebApiCount4UModelItur.RefillApproveStatusBitByIturCode);
			////ct.ThrowIfCancellationRequested();
			//Itur resultItur = await this._httpClient.PostJsonAsync<Itur>(request, itur.IturCode);//.ConfigureAwait(false);
			//yield return result;

			foreach (SelectParams sp in spl)
			{
				if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
					yield return -2;
				string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.RefillParallelApproveStatusBitSelectParams);
				Console.WriteLine($"IturService.RefillParallelApproveStatusBitSelectParamsAsync() : request {request}");
			//	int ret = await this._httpClient.PostJsonAsync<int>(request, sp);
				HttpResponseMessage response = await this._httpClient.PostAsJsonAsync<SelectParams>(request, sp);
				int ret = await response.Content.ReadFromJsonAsync<int>();
				yield return ret;
			}
		}




		public async Task<bool> ClearStatusBit(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return false;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.ClearStatusBit);
			Console.WriteLine($"IturService.ClearStatusBit() : request {request}");
			bool ret = await this._httpClient.GetFromJsonAsync<bool>(request);
			return ret;
		}



		//string request = Opetarion.UrlCombine(authenticationWebapiUrl, WebApiAuthenticationAccounts.PostProfile);
		//	Console.WriteLine($"Client.AuthService.Profile() : request {request}");
		//	var result = await _httpClient.PostJsonAsync<RegisterResult>(request, profileModel);   // "api/accounts/profile"
		//	Console.WriteLine($"Client.AuthService.Profile() : end");
		//	return result;

		public async Task<List<Itur>> GetIturCodesForLocationCode(string dataServerAddressUrl, string locationCode)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelItur.GetIturCodesForLocationCode, locationCode);
			Console.WriteLine($"GetIturCodesForLocationCode.GetIturCodesForLocationCode() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Itur>>(request);
			return result;
		}



	}
}

