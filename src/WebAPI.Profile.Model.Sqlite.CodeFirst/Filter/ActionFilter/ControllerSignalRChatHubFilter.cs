using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model;
using Monitor.Service.Shared;
using Monitor.Service.Urls;
using System;

namespace WebAPI.Monitor.Sqlite.CodeFirst
{

	public class ControllerSignalRChatHubFilter : Attribute, IActionFilter
	{
		//объект ActionExecutingContext, который имеет ряд свойств. Посредством 
		//изменения значения ActionExecutingContext.ActionArguments можно манипулировать параметрами метода. 
		//Либо через значение ActionExecutingContext.Controller можно управлять контроллером
		//метод OnActionExecuting() может завершить обработку запроса путем установки свойства ActionExecutingContext.Result.
		private readonly ILogger _logger;
		private IHubChatSignalRRepository _hubSignalRRepository;
		private string _chatHubAddress; 

		public ControllerSignalRChatHubFilter(ILoggerFactory loggerFactory , IHubChatSignalRRepository hubSignalRRepository)
		{
			_logger = loggerFactory.CreateLogger<ControllerSignalRChatHubFilter>();
			_hubSignalRRepository = hubSignalRRepository;
			_chatHubAddress = Opetarion.UrlCombine(SignalRHub.HostHub, SignalRHub.ChatHub);
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			//try
			//{
			//	if (_hubSignalRRepository.HubChatConnection == null)
			//	{
			//		_hubSignalRRepository.HubChatConnection = new HubConnectionBuilder()
			//		  .WithUrl(_chatHubAddress)
			//		  .WithAutomaticReconnect()
			//		  .Build();
			
			//		_hubSignalRRepository.HubChatConnection.On<string, string>(SignalRHubPublishFunction.ReceiveMessage, (user, message) =>
			//		{
			//			//_logger.LogInformation("OnActionExecuting.ControllerSignalRChatHubFilter" + " create SignalR Cient ");
			//		});

			//		_hubSignalRRepository.HubChatConnection.On<string>(SignalRHubPublishFunction.ReceiveNotify, (notify) =>
			//		{
			//			//_logger.LogInformation("OnActionExecuting.ControllerSignalRChatHubFilter" + " create SignalR Cient ");
			//		});

			//	}
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine("ERROR OnActionExecuting.ControllerSignalRChatHubFilter  " + ex.Message);

			//}
		}
	

		//На этом этапе мы можем увидеть результат выполнения и как-то его изменить через свойство ActionExecutedContext.Result.
		public void OnActionExecuted(ActionExecutedContext context)
		{
			
 		}

		// вспомогательный класс для удаления пробелов


		//how use
		//public class HomeController : Controller
		//{
		//	[ControllerTrace]
		//	public IActionResult Index()
		//	{
		//		return View();
		//	}
		//}
	}
}
