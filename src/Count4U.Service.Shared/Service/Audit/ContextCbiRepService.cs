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
	public interface IContextCbiRepService
	{
		Task<AuditConfig> GetProcessCBIConfig(string dataServerAddressUrl);            
	}
	public class ContextCbiRepService : IContextCbiRepService
	{
		private readonly HttpClient _httpClient;
		//private readonly IJwtService _jwtService;

		public ContextCbiRepService(HttpClient httpClient/*, IJwtService jwtService*/)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}

		public async Task<AuditConfig> GetProcessCBIConfig(string dataServerAddressUrl)    
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelContextCBI.GetProcessCBIConfig);
			Console.WriteLine($"ContextCbiRepService.GetProcessCBIConfig() : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<AuditConfig>(request);
			return result;
		}

	

	}
}

