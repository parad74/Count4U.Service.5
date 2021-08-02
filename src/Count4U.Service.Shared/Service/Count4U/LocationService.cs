using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Model.Count4U;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared
{
	public interface ILocationService
	{
		Task<List<Location>> GetLocations(string dataServerAddressUrl);
	}
	public class LocationService : ILocationService
	{
		private readonly HttpClient _httpClient;
		//private readonly IJwtService _jwtService;

		public LocationService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}


		public async Task<List<Location>> GetLocations(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelLocation.GetLocations);
			Console.WriteLine($"LocationService.GetLocations() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<List<Location>>(request);
			return result;
		}



	}
}

