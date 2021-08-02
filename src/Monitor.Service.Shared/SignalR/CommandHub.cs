using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace Monitor.Service.Model
{
	public interface ICommandClient
	{
		//   Task ReceiveMessage(string user, string message);
		Task ReceiveCommandNotify(string notify);
		Task ReceiveCommand(AdapterInitCommand command);
		Task ReceiveCommandResult(CommandResult result);
		Task ReceiveProfileFile(ProfileFile profile);
		//  Task ReceiveCommandStepResult(AdapterCommandStepEnum step, string notify, string result)  ;
	}
	public class CommandHub : Hub<ICommandClient>
	{
		public string UserName => this.Context.User.Identity.Name;
		public static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();


		[HubMethodName(SignalRClientRunFunctionOnHub.SendCommand)]
		public async Task SendCommand(AdapterInitCommand command)
		{
			string dt = DateTime.Now.ToString("HH:mm:ss.f");
			await this.Clients.All.ReceiveCommand(command);
			//await Clients.Caller.SendAsync(SignalRHubPublishFunction.ReceiveNotify, $"{dt}   {notify}" );
			// await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"your ConnectionID = {Context.ConnectionId}");
		}

		[HubMethodName(SignalRClientRunFunctionOnHub.SendCommandNotify)]
		public async Task SendCommandNotify(string notify)
		{
			string dt = DateTime.Now.ToString("HH:mm:ss.f");
			await this.Clients.All.ReceiveCommandNotify($"{dt}   {notify}");
			// await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"your ConnectionID = {Context.ConnectionId}");
		}

		// [HubMethodName(SignalRClientRunFunctionOnHub.SendCommandStepResult)]
		//public async Task SendCommandStepResult(AdapterCommandStepEnum step, string notify, string result)
		//{
		//   		string dt = DateTime.Now.ToString("HH:mm:ss.f");
		//     await Clients.All.ReceiveCommandStepResult( step, notify, result);
		//   // await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"your ConnectionID = {Context.ConnectionId}");
		//}


		[HubMethodName(SignalRClientRunFunctionOnHub.SendCommandResult)]
		public async Task SendCommandResult(CommandResult result)
		{
			result.CompleteTimeString = DateTime.Now.ToString("HH:mm:ss.f");
			await this.Clients.All.ReceiveCommandResult(result);
			//await this.Clients.User(result.User).ReceiveCommandResult(result);
			//return Clients.User(user).SendAsync("ReceiveMessage", message);
			// await Clients.All.SendAsync(SignalRHubPublishFunction.Notify, $"your ConnectionID = {Context.ConnectionId}");
		}

	
		[HubMethodName(SignalRClientRunFunctionOnHub.SendProfileFile)]
		public async Task SendProfileFile(ProfileFile profile)
		{
			//profile.CompleteTimeString = DateTime.Now.ToString("HH:mm:ss.f");
			await this.Clients.All.ReceiveProfileFile(profile);
			//await this.Clients.User(result.User).ReceiveCommandResult(result);
			//return Clients.User(user).SendAsync("ReceiveMessage", message);
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

