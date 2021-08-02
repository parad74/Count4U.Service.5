using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Count4U.Client.Shared.Service;
using Count4U.Admin.Client.Blazor.I18nText;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using Monitor.Service.Model;
using Monitor.Service.Shared;

namespace Count4U.Admin.Client.Page
{
	public class SignalRTraceBase : ComponentBase
	{
		protected GetResources LocalizationResources;// = new Localization.I18nText.GetResources();

		public HubConnection _hubConnection;

		public string userInput;
		public string messageInput;
		public List<string> _messages { get; set; }

		[Inject]
		protected IHubChatSignalRRepository _hubSignalRRepository { get; set; }

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		[Inject]
		protected NavigationManager NavigationManager { get; set; }

		[Inject]
		protected ISignalRTraceService _signalRTraceService { get; set; }

		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
		public SignalRTraceBase()
		{
			this._messages = new List<string>();
		}
		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.AboutBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.AboutBase.OnInitializedAsync() Exception : ");
				Console.WriteLine(ecx.Message);
			}
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await this.StartUpdateMessages();
			}
		}
		//protected override async Task OnAfterRenderAsync(bool firstRender)
		//{

		//	if (firstRender) 
		//	{
		//		Console.WriteLine($"Client.AboutBase.OnAfterRenderAsync() : start");
		//		try {
		//			userInput = "";
		//			if (this._hubSignalRRepository == null) {
		//				Console.WriteLine("ERROR : Client.AboutBase.OnAfterRenderAsync() _hubSignalRRepository is null");
		//				return;
		//			}
		//			string chatHubAddress = Opetarion.UrlCombine(Count4U.Service.Model.SignalRHub.HostHub, Count4U.Service.Model.SignalRHub.ChatHub);

		//			if (_hubSignalRRepository.HubChatConnection == null) {
		//				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() _hubConnection");
		//				Uri hubaddres = NavigationManager.ToAbsoluteUri(chatHubAddress);
		//				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() hubConnection  try build : " + hubaddres.AbsolutePath + "     " + hubaddres.AbsoluteUri);
		//				_hubSignalRRepository.HubChatConnection = new HubConnectionBuilder()
		//				  .WithUrl(NavigationManager.ToAbsoluteUri(chatHubAddress))
		//				  .WithAutomaticReconnect()
		//				  .Build();
		//				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() hubConnection : builded");
		//			}

		//			if (_hubSignalRRepository.HubChatConnection != null)
		//			{

		//				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() IsConnected1 : " + IsConnected);

		//				this._hubSignalRRepository.HubChatConnection.On<string, string>(SignalRHubPublishFunction.ReceiveMessage, (user, message) =>
		//				{
		//					var encodedMsg = user + " says " + message;
		//					Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() ReceiveMessage : " + encodedMsg);
		//					_signalRTraceService.Messages.Add(encodedMsg);
		//					StateHasChanged();
		//				});
		//				 this._hubSignalRRepository.HubChatConnection.On<string>(SignalRHubPublishFunction.Notify,(message)  =>
		//				{
		//					var encodedMsg = message;
		//					Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() Notify : " + encodedMsg);
		//					_signalRTraceService.Messages.Add(encodedMsg);
		//					StateHasChanged();
		//				});
		//				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() IsConnected2 : " + IsConnected);
		//				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() hubConnection : try ReceiveMessage");

		//				if (IsConnected == false)
		//				{
		//					await this._hubConnection.StartAsync();
		//				}
		//				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() StartAsync IsConnected3 : " + IsConnected);
		//			}
		//		}
		//		catch (Exception ecx) {
		//			Console.WriteLine("Client.AboutBase.OnAfterRenderAsync() hubConnection Exception : ");
		//			Console.WriteLine(ecx.Message);
		//		}

		//		Console.WriteLine($"Client.AboutBase.OnAfterRenderAsync() : end");
		//	}
		//}

		public void Clear()
		{
			this._signalRTraceService.Messages.Clear();
			this._messages = this._signalRTraceService.Messages;
			this.StateHasChanged();
		}

		public void Send()
		{
			if (this._hubSignalRRepository.HubChatConnection == null)
				return;
			this._hubSignalRRepository.HubChatConnection.SendAsync(SignalRClientRunFunctionOnHub.SendMessage, this.userInput, this.messageInput);
			this.StateHasChanged();

		}

		public List<string> Messages
		{
			get
			{
				return this._signalRTraceService.Messages;
			}
		}

		public async Task StartUpdateMessages()
		{
			var timer = new Timer(new TimerCallback(_ =>
			{
				if (this.Messages.Count <= 0)
					return;
				this.StateHasChanged();
			}), null, 200, 100);
		}


		public bool IsConnected
		{
			get
			{

				if (this._hubSignalRRepository.HubChatConnection == null)
					return false;
				return this._hubSignalRRepository.HubChatConnection.State == HubConnectionState.Connected;
			}
		}
	}
}



