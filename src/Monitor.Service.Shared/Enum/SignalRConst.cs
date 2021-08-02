namespace Monitor.Service.Model
{

	public static class SignalRHub
	{
		public const string HostHub = @"http://localhost:21029";	 //@"http://localhost:24024";    //@"http://localhost:27027";	 //@"http://localhost:15015";				  
		public const string ChatHub = @"/chathub";
		public const string CommandHub = @"/commandhub";

	}
	public static class SignalRHubPublishFunction
	{
		public const string ReceiveMessage = @"ReceiveMessage";
		public const string ReceiveNotify = @"ReceiveNotify";
		public const string ReceiveCommandNotify = @"ReceiveCommandNotify";
		public const string ReceiveCommand = @"ReceiveCommand";
		//public const string ReceiveCommandStepResult = @"ReceiveCommandStepResult";
		public const string ReceiveCommandResult = @"ReceiveCommandResult";
		public const string ReceiveProfileFile = @"ReceiveProfileFile";
		
	}


	public static class SignalRClientRunFunctionOnHub
	{
		public const string SendMessage = @"SendMessage";
		public const string SendNotify = @"SendNotify";
		public const string SendCommand = @"SendCommand";
		public const string SendCommandNotify = @"SendCommandNotify";
		//public const string SendCommandStepResult = @"SendCommandStepResult";
		public const string SendCommandResult = @"SendCommandResult";
		public const string SendProfileFile = @"SendProfileFile";
		
	}

}
