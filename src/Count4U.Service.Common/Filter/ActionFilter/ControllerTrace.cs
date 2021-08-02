using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common.Filter.ActionFilterFactory
{
	public class ControllerTraceServiceFilter : Attribute, IActionFilter
	{
		//объект ActionExecutingContext, который имеет ряд свойств. Посредством 
		//изменения значения ActionExecutingContext.ActionArguments можно манипулировать параметрами метода. 
		//Либо через значение ActionExecutingContext.Controller можно управлять контроллером
		//метод OnActionExecuting() может завершить обработку запроса путем установки свойства ActionExecutingContext.Result.
		private readonly ILogger _logger;
		private IPCBIContext _pcbiContext;

		public ControllerTraceServiceFilter(ILoggerFactory loggerFactory, IPCBIContext pcbiContext)
		{
			this._logger = loggerFactory.CreateLogger<ControllerTraceServiceFilter>();
			this._pcbiContext = pcbiContext;
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			//ControllerOnStart(this ILogger logger, HttpContext httpContext, RouteData routeData)
			this._logger.ControllerOnStart(context.HttpContext, context.RouteData);
		}


		//На этом этапе мы можем увидеть результат выполнения и как-то его изменить через свойство ActionExecutedContext.Result.
		public void OnActionExecuted(ActionExecutedContext context)
		{
			this._logger.ControllerOnEnd(context.HttpContext, context.RouteData);
		}

		// вспомогательный класс для удаления пробелов


		//how use
		//public class HomeController : Controller
		//{
		//	[ControllerTrace]
		//	public IActionResult Index()
		//	{
		//		return View();
		//	}
		//}
	}
}
