using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Monitor.Service.Model
{
	public interface IChatClient
	{
		Task ReceiveMessage(string user, string message);
		Task ReceiveNotify(string notify);
	}
	public class ChatHub : Hub<IChatClient>
	{
		public string UserName => this.Context.User.Identity.Name;
		public static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

		[HubMethodName(SignalRClientRunFunctionOnHub.SendMessage)]
		public async Task SendMessage(string user, string message)
		{
			if (string.IsNullOrWhiteSpace(user) == true)
				user = this.UserName;
			await this.Clients.All.ReceiveMessage(user, message);
			// await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"your ConnectionID = {Context.ConnectionId}");

			//await Clients.Client(Context.ConnectionId).SendAsync("Notify", "Ваш товар добавлен");
			//await Clients.AllExcept(new List<string> { Context.ConnectionId }).SendAsync("Receive", $"Добавлено: {product} в {DateTime.Now.ToShortTimeString()}");

			//await Clients.Caller.SendAsync("Notify", "Ваш товар добавлен");
			//await Clients.Others.SendAsync("Receive", $"Добавлено: {product} в {DateTime.Now.ToShortTimeString()}");

		}

		[HubMethodName(SignalRClientRunFunctionOnHub.SendNotify)]
		public async Task SendNotify(string notify)
		{
			string dt = DateTime.Now.ToString("HH:mm:ss.f");
			await this.Clients.All.ReceiveNotify($"{dt}   {notify}");
			// await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"your ConnectionID = {Context.ConnectionId}");
		}




		public override async Task OnConnectedAsync()
		{
			var user = this.Context.User.Identity.Name;

			Connections.AddOrUpdate(this.Context.ConnectionId, user, (key, oldValue) => user);

			//  await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"{Context.ConnectionId} login");
			await base.OnConnectedAsync();
		}
		public override async Task OnDisconnectedAsync(Exception exception)
		{
			//  await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"{Context.ConnectionId} logout");
			await base.OnDisconnectedAsync(exception);
		}
		//   public async Task SendMessage(string message)
		//{
		//    await Clients.All.SendAsync(SignalRHubFunction.ReceiveMessage, UserName, message);
		//}
	}

	//=====================
	//  https://issue.life/questions/51921488
	//?? это был вопрос задан
	// public interface INlgClient {
	//    Task GetAllTraits(ICharacterTrait[] apContextTraits);
	//    Task GetTrait(ICharacterTrait trait);
	//    Task GetAllEmotions(Emotion[] apContextEmotions);
	//    Task GetEmotion(Emotion emotion);   
	//    Task GetTraitEmotions(string traitName);
	//    Task CheckConnection(string connectMessage);
	//}
	//public class ApHub : Hub<INlgClient> {
	//    private readonly IApContext _apContext;

	//    public ApHub(IApContext apContext) {
	//        _apContext = apContext;
	//    }

	//    public async Task GetTraits() {
	//        await Clients.Caller.GetAllTraits(_apContext.Traits);
	//    }

	//    public async Task GetEmotions() {
	//        await Clients.Caller.GetAllEmotions(_apContext.Emotions);
	//    }

	//    public async Task ConnectionMessage() {
	//        await Clients.Caller.CheckConnection("You are connected");
	//    }
	//}
	////===============
	///

	//    Что считается наилучшей практикой для использования одного / нескольких типов dto для методов одного / нескольких клиентов?
	//Например, 3 варианта решения проблемы «уведомить о прогрессе и ошибках»:
	//Один метод, отдельные типы DTO.
	//class ProgressResponse { int Progress; T IntermediateResult .. }
	//class FinalResponse { int Progress; T FinalResult .. }
	//class ErrorResponse { int StatusCode; string Message .. }
	//...
	//Clients.Caller.onProgress(new ProgressResponse(..));
	//Clients.Caller.onProgress(new FinalResponse(..));
	//Clients.Caller.onProgress(new ErrorResponse(..));

	//Отдельные методы, отдельные типы dto.
	//class ProgressResponse { int Progress; T IntermediateResult .. }
	//class FinalResponse { int Progress; T FinalResult .. }
	//class ErrorResponse { int StatusCode; string Message .. }
	//...
	//Clients.Caller.onProgress(new ProgressResponse(..));
	//Clients.Caller.onCompleted(new FinalResponse(..));
	//Clients.Caller.onError(new ErrorResponse(..));

	//Отдельные методы, один тип dto.
	//class HugeResponse { int Progress; int IsFinal; T IntermediateResult; .. int StatusCode; string Message .. }
	//...
	//Clients.Caller.onProgress(new HugeResponse(..));
	//Clients.Caller.onCompleted(new HugeResponse(..));
	//Clients.Caller.onError(new HugeResponse(..));


	// public class UTTHub : Hub
	//{
	//    public string UserName => Context.User.Identity.Name;

	//    public override async Task OnConnectedAsync()
	//    {
	//        if (Context.User.Identity.IsAuthenticated)
	//        {
	//            User.AddUser(UserName);
	//        }

	//        Interlocked.Increment(ref User.Count);

	//        await Clients.All.SendAsync("GameUpdated", Game.GetGames());
	//        await Clients.All.SendAsync("UsersChanged", User.Count);
	//    }

	//    [Authorize]
	//    public Task SendToLobby(string message)
	//    {
	//        return Clients.All.SendAsync("LobbyMessage", UserName, message);
	//    }

	//    [Authorize]
	//    public Task CreateGame(string name)
	//    {
	//        if (string.IsNullOrEmpty(UserName))
	//        {
	//            return Task.CompletedTask;
	//        }

	//        Game.CreateGame(UserName, name);
	//        return Clients.All.SendAsync("GameUpdated", Game.GetGames());
	//    }

	//    [Authorize]
	//    public Task JoinGame(int id)
	//    {
	//        Game.JoinGame(id, UserName);
	//        return Clients.All.SendAsync("GameUpdated", Game.GetGames());
	//    }

	//    [Authorize]
	//    public Task PlayTurn(int id, int outerRowIndex, int outerColIndex, int innerRowIndex, int innerColIndex)
	//    {
	//        if (Game.PlayTurn(UserName,
	//                          id,
	//                          outerRowIndex,
	//                          outerColIndex,
	//                          innerRowIndex,
	//                          innerColIndex,
	//                          out var nextMove))
	//        {
	//            return Clients.All.SendAsync("PlayMove", id, nextMove);
	//        }
	//        return Task.CompletedTask;
	//    }

	//    public override Task OnDisconnectedAsync(Exception exception)
	//    {
	//        if (Context.User.Identity.IsAuthenticated)
	//        {
	//            // TODO: Handle stopping games that include this user
	//            User.Remove(UserName);
	//        }

	//        Interlocked.Decrement(ref User.Count);

	//        return Clients.All.SendAsync("UsersChanged", User.Count);
	//    }
	//}
}

