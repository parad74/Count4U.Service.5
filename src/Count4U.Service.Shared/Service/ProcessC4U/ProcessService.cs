using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Count4U.Model.ProcessC4U;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Count4U.Service.Shared
{
	public interface IProcessService
	{
		//Task<Process> GetProcessByProcessCode(string processCode);          //Process GetProcessByProcessCode(string processCode);
		Task<Processes> GetProcesses(string dataServerAddressUrl);          //Processes GetProcesses();

		//void Delete(long id);	 
		//Process GetProcess(long id);
		//void Delete(string processCode);
		//void Insert(Process Process);
		//void Update(Process Process);
	}
	public class ProcessService : IProcessService
	{
		private readonly HttpClient _httpClient;
		//		private readonly IJwtService _jwtService;


		public ProcessService(HttpClient httpClient, IJwtService jwtService)
		{
			this._httpClient = httpClient ??
							  throw new ArgumentNullException(nameof(httpClient));
			//_jwtService = jwtService ??
			//				  throw new ArgumentNullException(nameof(jwtService));
		}

		public async Task<Processes> GetProcesses(string dataServerAddressUrl)
		{
			if (string.IsNullOrWhiteSpace(dataServerAddressUrl) == true)
				return null;
			string request = Opetarion.UrlCombine(dataServerAddressUrl, WebApiCount4UModelProcess.GetProcesses);
			Console.WriteLine($"ProcessService.GetProcesses : request {request}");
			var result = await this._httpClient.GetFromJsonAsync<Processes>(request);
			//return await Task.FromResult(result);
			return result;
		}


	}
}

