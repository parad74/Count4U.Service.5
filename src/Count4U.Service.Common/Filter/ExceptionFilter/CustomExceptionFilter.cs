using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Count4U.Service.Common.Filter.ExceptionFilter
{
	// В метод OnException() в качестве параметра передается объект ExceptionContext, 
	//который содержит всю информацию о возникшем исключении.
	//При установке свойства context.ExceptionHandled равным true мы можем получить эффект, 
	//как будто мы обработали исключение. И в этому случае обработка запроса продолжится, 
	//	как будто никакого исключения и не было,   а браузеру будет отправлен статусный код 200 OK.

	public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			//С помощью параметра ExceptionContext получаем разные сведения об исключении, 
			//а также имя действия, в котором возникло исключение, и создаем из полученной информации объект ContentResult. 
			//Чтобы исключение считалось обработанным, устанавливаем context.ExceptionHandled = true
			string actionName = context.ActionDescriptor.DisplayName;
			string exceptionStack = context.Exception.StackTrace;
			string exceptionMessage = context.Exception.Message;
			context.Result = new ContentResult
			{
				Content = $"В методе {actionName} возникло исключение: \n {exceptionMessage} \n {exceptionStack}"
			};
			context.ExceptionHandled = true;
		}
	}
	//how use
	//public class HomeController : Controller
	//{
	//	[CustomExceptionFilter]
	//	public IActionResult Index()
	//	{
	//		int x = 0;
	//		int y = 8 / x;
	//		return View();
	//	}
	//}

	//public class CustomExceptionFilter : IExceptionFilter
	//{
	//	private readonly IModelMetadataProvider _modelMetadataProvider;

	//	public CustomExceptionFilter(
	//		IModelMetadataProvider modelMetadataProvider)
	//	{
	//		_modelMetadataProvider = modelMetadataProvider;
	//	}

	//	public void OnException(ExceptionContext context)
	//	{
	//		var result = new ViewResult { ViewName = "CustomError" };
	//		result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
	//		result.ViewData.Add("Exception", context.Exception);

	//		// Here we can pass additional detailed data via ViewData
	//		context.ExceptionHandled = true; // mark exception as handled
	//		context.Result = result;
	//	}
	//}
}

