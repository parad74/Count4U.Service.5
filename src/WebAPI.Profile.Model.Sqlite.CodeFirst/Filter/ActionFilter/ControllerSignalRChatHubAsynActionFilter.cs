using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model;
using Monitor.Service.Shared;
using Monitor.Service.Urls;
using System;
using System.Threading.Tasks;

namespace WebAPI.Monitor.Sqlite.CodeFirst
{

	public class ControllerSignalRChatHubAsynActionFilter : Attribute, IAsyncActionFilter
    {
		private readonly ILogger _logger;
		private IHubChatSignalRRepository _hubSignalRRepository;
		private string _chatHubAddress; 


		public ControllerSignalRChatHubAsynActionFilter(ILoggerFactory loggerFactory , IHubChatSignalRRepository hubSignalRRepository)
		{
			_logger = loggerFactory.CreateLogger<ControllerSignalRChatHubFilter>();
			_hubSignalRRepository = hubSignalRRepository;
			_chatHubAddress = Opetarion.UrlCombine(SignalRHub.HostHub, SignalRHub.ChatHub);
		}
        public async Task OnActionExecutionAsync(ActionExecutingContext context, 
                                    ActionExecutionDelegate next)
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
   //         // код метода

            await next();
        }
    }
	
}
