using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model.Settings;
using Count4U.Model.Interface.ProcessC4U;
using Count4U.Model.ProcessC4U;
using System.Collections.Generic;
using Count4U.Service.Common;
using System;
using System.Linq;
using Monitor.Service.Urls;
using Microsoft.AspNetCore.SignalR;
using  Count4U.Service.Model;
using Count4U.Client.Shared.Service;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using Monitor.Service.Shared;
using Monitor.Service.Model;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
	//[Route("api/[controller]")]
	public class ProcessController : ControllerBase
	{
		private readonly ILogger<ProcessController> _logger;
		private readonly ICount4uContext _count4uContext;
		private readonly IProcessRepository _processRepository;
		private readonly IHubContext<ChatHub> _hubContext;
		private readonly IHubChatSignalRRepository _hubSignalRRepository;
		

		//private readonly IJwtService _jwtService;
		//private readonly IUnityContainer _container;
		//private readonly IServiceLocator _serviceLocator;

		public ProcessController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, IProcessRepository processRepository
			,IHubContext<ChatHub>	hubContext
			, IHubChatSignalRRepository hubSignalRRepository
			//, IJwtService jwtService
			//,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<ProcessController>();
			this._count4uContext = count4uContext ??
						   throw new ArgumentNullException(nameof(count4uContext));
			this._processRepository = processRepository ??
						   throw new ArgumentNullException(nameof(processRepository));
			this._hubSignalRRepository = hubSignalRRepository ??
						   throw new ArgumentNullException(nameof(hubSignalRRepository));
			this._hubContext = hubContext ??
						   throw new ArgumentNullException(nameof(hubContext));
			

			//_jwtService = jwtService;
			//_serviceLocator = serviceLocator;
			//_container = container;
		}

		//[ServiceFilter(typeof(ControllerSignalRChatHubAsynActionFilter))]
		[HttpGet(WebApiCount4UModelProcess.GetProcesses)]
		public async Task<Processes> GetProcesses()
		{
			Processes processes = new Processes();
			processes = this._processRepository.GetProcesses();
			//await this._hubSignalRRepository.SendMessageFromWebAPIAsync("GetProcesses", "Count = " + processes.Count);
			return processes;
			//try
			//{
			//	await this._hubSignalRRepository.HubChatConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendMessage, "GetProcesses", "Count = " + processes.Count);
			//}
			//catch (Exception ecx) 
			//{ 
			//	this._logger.LogError(ecx.Message, ecx); 
			//}
			//finally 
			//{
			//	await this._hubSignalRRepository.HubChatConnection.StopAsync();
			//}
			
		}

		//Processes GetProcesses();
		//[HttpGet(WebApiCount4UModelProcess.GetProcesses)]
		//public async Task<Processes> GetProcesses()
		//{
		//	Processes processes = new Processes();
		//	try
		//	{
		
		//		try
		//		{
		//			this._hubSignalRRepository.HubChatConnection = new HubConnectionBuilder()
		//			  .WithUrl("http://localhost:15015/chathub")
		//			  .Build();
		//				_hubSignalRRepository.HubChatConnection.On<string, string>(SignalRHubFunction.ReceiveMessage, (user, message) =>
		//				{
		//					_logger.LogInformation("OnActionExecuting.ControllerSignalRChatHubFilter" + " create SignalR Cient ");
		//				});

		//				await this._hubSignalRRepository.HubChatConnection.StartAsync();
		//			   await this._hubSignalRRepository.HubChatConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendMessage, "_hubSignalRRepository", "Processes");

		//			//this._hubSignalRRepository.HubChatConnection.SendCoreAsync(SignalRClientRunFunctionOnHub.SendMessage, new object[] { "_hubSignalRRepository", WebApiCount4UModelProcess.GetProcesses });
		//		}
		//		catch (Exception ecx) { this._logger.LogError(ecx.Message, ecx); }
		//		try
		//		{
		//			await this._hubContext.Clients.All.SendAsync(SignalRClientRunFunctionOnHub.SendMessage, "ProcessController", "GetProcesses");
		//		}
		//		catch (Exception ecx)
		//		{
		//			this._logger.LogError(ecx.Message, ecx);
		//		}
		//		finally { await this._hubSignalRRepository.HubChatConnection.StopAsync();}

				
		//	}
		//	catch (Exception ecx) 
		//	{
		//		this._logger.LogError(ecx.Message, ecx); 
		//	}
		//	processes = this._processRepository.GetProcesses();
		//	return processes;
		//}

		//[HttpGet("GetProcesses1")]
		//public IEnumerable<Process> GetProcesses1()
		//{
		//	Processes processes = new Processes();
		//	try
		//	{
		//		processes = this._processRepository.GetProcesses();
		//	}
		//	catch (Exception ecx) { this._logger.LogError(ecx.Message, ecx); }
		//	return processes;
		//}

			//private readonly IHubContext<NotificationHub> _hubContext;

   //     public HomeController(IHubContext<NotificationHub> hubContext)
   //     {
   //         _hubContext = hubContext;
   //     }

   //     public async Task<IActionResult> Index()
   //     {
   //         await _hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");
   //         return View();
   //     }

		[HttpGet(WebApiCount4UModelProcess.GetProcessByProcessCode)]
		public ActionResult<Process> GetProcessByProcessCode([FromRoute] string processCode)    //Не используйте, [FromRoute]когда значения могут содержать %2f(то есть /). %2fне будет неэкранированный к /. Используйте, [FromQuery]
		{
			Process process = this._processRepository.GetProcessByProcessCode(processCode);
			//if (process == null) return NotFound();
			return process;
		}

		//[HttpGet("[action]")]
		//public ActionResult<Process> GetContextProcessCode()
		//{
		//	GetContextProcess
		//	if (process == null) return NotFound();
		//	return process;
		//}



		//Processes GetProcesses(SelectParams selectParams);
		//Process GetProcess(long id);
		//Process GetProcessByProcessCode(string processCode);
		//void SetStatusInProcess(string processCode);
		//void ResetStatusInProcess();
		//Process GetProcess_InProcess();
		//string GetProcessCode_InProcess(Count4USettings count4USettings);
		//Process GetProcessByCode(string code);
		//void Delete(long id);
		//void Delete(string processCode);
		//void Insert(Process Process);
		//void Update(Process Process);

	}
}
