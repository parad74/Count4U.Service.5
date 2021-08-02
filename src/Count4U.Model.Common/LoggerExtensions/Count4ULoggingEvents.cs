namespace Count4U.Model
{
	public class Count4UEventId
	{
		//1#####- Trace , Info
		//2#####- Debuge 
		//3#####- Warning
		//4#####- Error 
		//5#####- Success 

		//##10##- Controller 
		//##40##- Count4U 

		//####01 - Message 
		//####02 - Message
		//####03 - MessageAndException 
		//####04 - MessageAndException 


		public const int Information = 104001;
		public const int Trace = 104002;
		public const int TraceException = 104004;
		public const int Debug = 204001;
		public const int DebugException = 204004;
		public const int Warning = 304001;
		public const int WarningException = 304004;
		public const int Error = 404001;
		public const int ErrorException = 404004;
		

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
