namespace Count4U.Service.Common.Filter.ResultFilter
{
	//Интерфейсы IAlwaysRunResultFilter и IAsyncAlwaysRunResultFilter объявляют реализацию IResultFilter, 
	//которая выполняется для всех результатов действий. Фильтр применяется для всех результатов действий, если:
	//public class UnprocessableResultFilter : Attribute, IAlwaysRunResultFilter
	//{
	//	public void OnResultExecuting(ResultExecutingContext context)
	//	{
	//		if (context.Result is StatusCodeResult statusCodeResult &&
	//			statusCodeResult.StatusCode == 415)
	//		{
	//			context.Result = new ObjectResult("Can't process this!")
	//			{
	//				StatusCode = 422,
	//			};
	//		}
	//	}

	//	public void OnResultExecuted(ResultExecutedContext context)
	//	{
	//	}
	//}
}
