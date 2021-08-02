using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Count4U.Admin.Client.Blazor.I18nText;
using Count4U.Client.Shared.Service;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using Monitor.Service.Model;
using Monitor.Service.Shared;

namespace Count4U.Admin.Client.Page
{
	public class AboutBase : ComponentBase
	{
		protected GetResources LocalizationResources;// = new Localization.I18nText.GetResources();

		public HubConnection hubConnection;
		public string _userInput;
		public string messageInput;
		public List<string> _messages;

		[Inject]
		protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

		[Inject]
		protected NavigationManager NavigationManager { get; set; }

		[Inject]
		protected IHubChatSignalRRepository _hubSignalRRepository { get; set; }


		[Inject]
		protected ISignalRTraceService _signalRTraceService { get; set; }

		[Inject]
		protected IClaimService _claimService { get; set; }

		[Inject]
		protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[CascadingParameter]
		public Task<AuthenticationState> authenticationStateTask { get; set; }



		public AboutBase()
		{
		}

		protected override async Task OnInitializedAsync()
		{
			Console.WriteLine();
			Console.WriteLine($"Client.AboutBase.OnInitializedAsync() : start");
			try
			{
				this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
				this._messages = this._signalRTraceService.Messages;

			}
			catch (Exception ecx)
			{
				Console.WriteLine("Client.AboutBase.OnInitializedAsync() Exception : ");
				Console.WriteLine(ecx.Message);
			}

			try
			{
				var authState = await this.authenticationStateTask;
				var user = authState.User;

				if (user.Identity.IsAuthenticated)
				{
					Console.WriteLine($"{user.Identity.Name} is authenticated.");
					this._userInput = user.Identity.Name;

				}
				else
				{
					Console.WriteLine("The user is NOT authenticated.");
				}
			}
			catch (Exception exc)
			{
				Console.WriteLine("Client.AboutBase.OnAfterRenderAsync()  Exception : ");
				Console.WriteLine(exc.Message);
			}
			//string chatHubAddress = Opetarion.UrlCombine(Monitor.Service.Model.SignalRHub.HostHub, Monitor.Service.Model.SignalRHub.ChatHub);

			//try 
			//{

			//	Console.WriteLine("Client.AboutBase.OnInitializedAsync() hubConnection Exception : ");
			//	hubConnection = new HubConnectionBuilder()
			//   .WithUrl(NavigationManager.ToAbsoluteUri(chatHubAddress))
			//   .WithAutomaticReconnect()
			//   .Build();

			//	hubConnection.On<string, string>(SignalRHubPublishFunction.ReceiveMessage, (user, message) =>
			//	{
			//		var encodedMsg = user + " says " + message;
			//		_signalRTraceService.Messages.Add(encodedMsg);
			//		StateHasChanged();
			//	});

			//	await hubConnection.StartAsync();
			//}
			//catch (Exception ecx)
			//{
			//	Console.WriteLine("Client.AboutBase.OnInitializedAsync() hubConnection Exception : ");
			//	Console.WriteLine(ecx.Message);
			//}

			Console.WriteLine($"Client.AboutBase.OnInitializedAsync() : end");
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{

			}

		}

		public void Clear()
		{
			this._signalRTraceService.Messages.Clear();
			this._messages.Clear();
		}
		public async Task Send()
		{
			if (this._hubSignalRRepository.HubChatConnection == null)
				return;
			await this._hubSignalRRepository.HubChatConnection.SendAsync(SignalRClientRunFunctionOnHub.SendMessage, this._userInput, this.messageInput);
			await Task.Delay(1000);
			this._messages = this._signalRTraceService.Messages;
			this.StateHasChanged();
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


//https://github.com/dotnet-presentations/blazor-workshop/blob/master/docs/04-refactor-state-management.md
//@page "/myorders/{orderId:int}"
//@implements IDisposable
//@code {
//    [Parameter] public int OrderId { get; set; }

//    OrderWithStatus orderWithStatus;
//    bool invalidOrder;
//    CancellationTokenSource pollingCancellationToken;

//OnParametersSetэто еще один метод жизненного цикла компонента, 
//который запускается, когда компонент создается впервые, и каждый раз, когда его параметры меняют значение
//Если пользователь щелкает ссылку непосредственно из myorders/2к myorders/3, каркас сохранит OrderDetails экземпляр 
//и просто обновит свой OrderIdпараметр на месте.
//    protected override void OnParametersSet()
//    {
//        // If we were already polling for a different order, stop doing so
//        pollingCancellationToken?.Cancel();

//        // Start a new poll loop
//        PollForUpdates();
//    }

//    private async void PollForUpdates()
//    {
//        pollingCancellationToken = new CancellationTokenSource();
//        while (!pollingCancellationToken.IsCancellationRequested)
//        {
//            try
//            {
//                invalidOrder = false;
//                orderWithStatus = await HttpClient.GetFromJsonAsync<OrderWithStatus>($"orders/{OrderId}");
//            }
//            catch (Exception ex)
//            {
//                invalidOrder = true;
//                pollingCancellationToken.Cancel();
//                Console.Error.WriteLine(ex);
//            }

//            StateHasChanged();

//            await Task.Delay(4000);
//        }

//Инфраструктура вызывает Disposeавтоматически, 
//	когда любой данный экземпляр компонента сносится и удаляется из пользовательского интерфейса.
//void IDisposable.Dispose()
//{
//    pollingCancellationToken?.Cancel();
//}

//async Task PlaceOrder()
//{
//    var response = await HttpClient.PostAsJsonAsync("orders", order);
//    var newOrderId = await response.Content.ReadFromJsonAsync<int>();
 
//}
//    }
//}


