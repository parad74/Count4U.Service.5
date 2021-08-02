using Count4U.Client.Shared.Service;
using Count4U.Model.Common;
using Count4U.Service.Common;
using Monitor.Service.Urls;
using Count4U.Service.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Monitor.Service.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Count4U.Service.WebAPI.Model
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
			_chatHubAddress = Opetarion.UrlCombine(Monitor.Service.Model.SignalRHub.HostHub, Monitor.Service.Model.SignalRHub.ChatHub);
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
