using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace Monitor.Service.Shared
{
	public interface IHubCommandSignalRRepository
	{
		HubConnection HubCommandConnection { get; set; }
		Task SendCommandFromWebAPIAsync(AdapterInitCommand command, bool startAsync = false);
		Task SendNotifyFromWebAPIAsync(string notify, bool startAsync = false);
		//Task SendCommandStepResultFromWebAPIAsync(AdapterCommandStepEnum step, string notify, string result, bool startAsync = false) ;
		Task SendCommandResultFromWebAPIAsync(CommandResult result, bool startAsync = false);
		Task SendProfileFileFromWebAPIAsync(ProfileFile result, bool startAsync = false);
		Task StartAsync();
		Task StopAsync();
	}


	public class HubCommandSignalRRepository : IHubCommandSignalRRepository
	{
		private readonly ILogger<HubCommandSignalRRepository> _logger;
		public HubConnection HubCommandConnection { get; set; }
		//public List<string> Messages {	get; set;}

		private string _commandHubAddress;
		public HubCommandSignalRRepository(ILoggerFactory loggerFactory)
		{
			this._logger = loggerFactory.CreateLogger<HubCommandSignalRRepository>();
			//	if (Messages == null) Messages = new List<string>();
			this._commandHubAddress = Opetarion.UrlCombine(Monitor.Service.Model.SignalRHub.HostHub, Monitor.Service.Model.SignalRHub.CommandHub);
			//HubChatConnection = new HubConnectionBuilder()..WithAutomaticReconnect().Build();
			if (this.HubCommandConnection == null)
			{
				this.HubCommandConnection = new HubConnectionBuilder()
				  .WithUrl(this._commandHubAddress)
				  .WithAutomaticReconnect()
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


		public async Task SendCommandFromWebAPIAsync(AdapterInitCommand command, bool startAsync = false)
		{
			try
			{
				if (startAsync == true)
					await this.HubCommandConnection.StartAsync();
				await this.HubCommandConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendCommand, command);
			}
			catch (Exception ecx)
			{
				this._logger.LogError(ecx.Message, ecx);
			}
			finally
			{
				if (startAsync == true)
					await this.HubCommandConnection.StopAsync();
			}
		}


		public async Task SendNotifyFromWebAPIAsync(string notify, bool startAsync = false)
		{
			try
			{
				if (startAsync == true)
					await this.HubCommandConnection.StartAsync();
				string dt = DateTime.Now.ToString("HH:mm:ss.f");
				await this.HubCommandConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendCommandNotify, $"{dt} -- {notify}");
			}
			catch (Exception ecx)
			{
				this._logger.LogError(ecx.Message, ecx);
			}
			finally
			{
				if (startAsync == true)
					await this.HubCommandConnection.StopAsync();
			}
		}

		//public async Task SendCommandStepResultFromWebAPIAsync(AdapterCommandStepEnum step, string notify, string result, bool startAsync = false)
		//{ 
		//	try
		//	{						
		//		if (startAsync == true)	  await HubCommandConnection.StartAsync();
		//		string dt = DateTime.Now.ToString("HH:mm:ss.f");
		//		await HubCommandConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendCommandStepResult, step, $"{dt} --- {notify}", result);
		//	}
		//	catch (Exception ecx) 
		//	{ 
		//		this._logger.LogError(ecx.Message, ecx); 
		//	}
		//	finally 
		//	{
		//		if (startAsync == true)	  await HubCommandConnection.StopAsync();
		//	}
		//}

		public async Task SendCommandResultFromWebAPIAsync(CommandResult result, bool startAsync = false)
		{
			try
			{
				if (startAsync == true)
					await this.HubCommandConnection.StartAsync();
				result.CompleteTimeString = DateTime.Now.ToString("HH:mm:ss.f");
				await this.HubCommandConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendCommandResult, result);
			}
			catch (Exception ecx)
			{
				this._logger.LogError(ecx.Message, ecx);
			}
			finally
			{
				if (startAsync == true)
					await this.HubCommandConnection.StopAsync();
			}
		}

		public async Task SendProfileFileFromWebAPIAsync(ProfileFile result, bool startAsync = false)
		{
			try
			{
				if (startAsync == true)
					await this.HubCommandConnection.StartAsync();
				//result.CompleteTimeString = DateTime.Now.ToString("HH:mm:ss.f");
				await this.HubCommandConnection.InvokeAsync(SignalRClientRunFunctionOnHub.SendProfileFile, result);
			}
			catch (Exception ecx)
			{
				this._logger.LogError(ecx.Message, ecx);
			}
			finally
			{
				if (startAsync == true)
					await this.HubCommandConnection.StopAsync();
			}
		}
		public async Task StartAsync()
		{
			if (this.HubCommandConnection.State != HubConnectionState.Connected)
				await this.HubCommandConnection.StartAsync();
		}

		public async Task StopAsync()
		{
			if (this.HubCommandConnection.State == HubConnectionState.Connected)
				await this.HubCommandConnection.StopAsync();
		}


	}
}
