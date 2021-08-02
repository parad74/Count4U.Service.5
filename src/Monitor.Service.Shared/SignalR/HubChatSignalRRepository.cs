using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Monitor.Service.Shared
{
	public interface IHubChatSignalRRepository
	{
		HubConnection HubChatConnection { get; set; }
		//List<string> Messages { get; set; }
		Task SendMessageFromWebAPIAsync(string user, string message, bool startAsync = false);
		Task SendNotifyFromWebAPIAsync(string notify, bool startAsync = false);
		Task StartAsync();
		Task StopAsync();
	}


	public class HubChatSignalRRepository : IHubChatSignalRRepository
	{
		private readonly ILogger<HubChatSignalRRepository> _logger;
		public HubConnection HubChatConnection { get; set; }
		//public List<string> Messages {	get; set;}

		private string _chatHubAddress;
		public HubChatSignalRRepository(ILoggerFactory loggerFactory)
		{
			this._logger = loggerFactory.CreateLogger<HubChatSignalRRepository>();
			//	if (Messages == null) Messages = new List<string>();
			this._chatHubAddress = Opetarion.UrlCombine(Monitor.Service.Model.SignalRHub.HostHub, Monitor.Service.Model.SignalRHub.ChatHub);
			//HubChatConnection = new HubConnectionBuilder()..WithAutomaticReconnect().Build();
			if (this.HubChatConnection == null)
			{
				this.HubChatConnection = new HubConnectionBuilder()
				  .WithUrl(this._chatHubAddress)
				  .WithAutomaticReconnect()
				  		   // .ConfigureLogging(logging => {
				//	logging.SetMinimumLevel(LogLevel.Information);
				//	logging.AddConsole();
				//})
				  .Build();

				//HubChatConnection.On<string, string>(SignalRHubPublishFunction.ReceiveMessage, (user, message) =>
				//{
				//	//_logger.LogInformation("HubSignalRRepository.SendMessageFromWebAPIAsync" + " create SignalR Cient HubChatConnection ");
				//});

				//HubChatConnection.On<string>(SignalRHubPublishFunction.ReceiveNotify, (notify) =>
				//{
				//	//_logger.LogInformation("HubSignalRRepository.SendMessageFromWebAPIAsync" + " create SignalR Cient HubChatConnection ");
				//});
			}
		}


		public async Task SendNotifyFromWebAPIAsync(string notify, bool startAsync = false)
		{
			try
			{
				if (startAsync == true)
					await this.HubChatConnection.StartAsync();
				string dt = DateTime.Now.ToString("HH:mm:ss.f");
				await this.HubChatConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendNotify, $"{dt}   {notify}");
			}
			catch (Exception ecx)
			{
				this._logger.LogError(ecx.Message, ecx);
			}
			finally
			{
				if (startAsync == true)
					await this.HubChatConnection.StopAsync();
			}
		}

		public async Task SendMessageFromWebAPIAsync(string user, string message, bool startAsync = false)
		{
			try
			{
				//if (HubChatConnection == null)
				//{
				//	HubChatConnection = new HubConnectionBuilder()
				//	  .WithUrl(_chatHubAddress)
				//	  .WithAutomaticReconnect()
				//	  .Build();

				//	HubChatConnection.On<string, string>(SignalRHubPublishFunction.ReceiveMessage, (user, message) =>
				//	{
				//		_logger.LogInformation("HubSignalRRepository.SendMessageFromWebAPIAsync" + " create SignalR Cient HubChatConnection ");
				//	});
				//}
				if (startAsync == true)
					await this.HubChatConnection.StartAsync();
				await this.HubChatConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendMessage, user, message);
			}
			catch (Exception ecx)
			{
				this._logger.LogError(ecx.Message, ecx);
			}
			finally
			{
				if (startAsync == true)
					await this.HubChatConnection.StopAsync();
			}
		}
		public async Task StartAsync()
		{
			if (this.HubChatConnection.State != HubConnectionState.Connected)
				await this.HubChatConnection.StartAsync();
		}

		public async Task StopAsync()
		{
			if (this.HubChatConnection.State == HubConnectionState.Connected)
				await this.HubChatConnection.StopAsync();
		}


	}
}
