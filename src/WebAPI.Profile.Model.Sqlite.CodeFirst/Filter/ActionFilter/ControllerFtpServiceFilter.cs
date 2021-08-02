using Count4U.Model.Common;
using Count4U.Service.Common;
using Count4U.Service.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Monitor.Service.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Filter.Sqlite.CodeFirst
{
	public class ControllerFtpServiceFilter : Attribute, IActionFilter
	{
		//объект ActionExecutingContext, который имеет ряд свойств. Посредством 
		//изменения значения ActionExecutingContext.ActionArguments можно манипулировать параметрами метода. 
		//Либо через значение ActionExecutingContext.Controller можно управлять контроллером
		//метод OnActionExecuting() может завершить обработку запроса путем установки свойства ActionExecutingContext.Result.
		private readonly ILogger _logger;
		private ISettingsFtpRepository _settingsFtpRepository;

		public ControllerFtpServiceFilter(ILoggerFactory loggerFactory, ISettingsFtpRepository settingsFtpRepository)
		{
			_logger = loggerFactory.CreateLogger<ControllerFtpServiceFilter>();
			_settingsFtpRepository = settingsFtpRepository;
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			StringValues inventorCodeKeys = new StringValues();
			context.HttpContext.Request.Headers.TryGetValue(ClaimEnum.InventorCode.ToString(), out inventorCodeKeys);
			string inventorCodeKey = "";
			if (inventorCodeKeys.Count > 0) inventorCodeKey = inventorCodeKeys[0];
		//	_settingsFtpRepository.InitProperty(inventorCodeKey);		//TO DO
			_logger.ControllerOnStart(context.HttpContext, context.RouteData);
		}
	

		//На этом этапе мы можем увидеть результат выполнения и как-то его изменить через свойство ActionExecutedContext.Result.
		public void OnActionExecuted(ActionExecutedContext context)
		{
			_logger.ControllerOnEnd(context.HttpContext, context.RouteData);
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
