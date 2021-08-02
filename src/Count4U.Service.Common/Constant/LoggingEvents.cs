namespace Count4U.Service.Model
{
	public class EventId
	{
		//1#####- Trace , Info
		//2#####- Debuge 
		//3#####- Warning
		//4#####- Error 
		//5#####- Success 

		//##10##- Controller 
		//####01 - OnExecuting 
		//####02 - OnExecuted
		//####03 - OnStart 
		//####04 - OnEnd

		public const int ControllerOnStart = 001003;
		public const int ControllerOnEnd = 001004;
		public const int ControllerErrorOnStart = 401003;
		public const int ControllerErrorOnEnd = 401004;
		public const int ControllerWarningOnStart = 301003;
		public const int ControllerWarningOnEnd = 301004;

		public const int ControllerLogDebugPath = 201001;
		public const int ControllerLogDebugPathAndCBIContext = 201002;
		public const int ControllerLogDebugCBIContext = 201003;

		public const int ControllerLogInformationPath = 101001;
		public const int ControllerLogInformationPathAndCBIContext = 101002;
		public const int ControllerLogInformationCBIContext = 101003;

		public const int ControllerLogInformationCommandResult = 101021;




	}


	//public class LoggingEvents
	//{
	//	public const int GenerateItems = 1000;
	//	public const int ListItems = 1001;
	//	public const int GetItem = 1002;
	//	public const int InsertItem = 1003;
	//	public const int UpdateItem = 1004;
	//	public const int DeleteItem = 1005;

	//	public const int ControllerActionStrat = 1005;
	//	public const int ControllerActionEnd = 1005;

	//	public const int GetItemNotFound = 4000;
	//	public const int UpdateItemNotFound = 4001;
	//}




}
