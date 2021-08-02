using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	
	//public class InitController : Controller
	//{
	//	[HttpGet("error/{code}")]
	//	public IActionResult Error(int code)
	//	{
	//		return new ObjectResult(new ApiResponse(code));
	//	}

	//	//Каждый контроллер, наследуемый от базового класса Controller включает методы 
	//	//Controller.OnActionExecuting, Controller.OnActionExecutionAsync и Controller.OnActionExecuted OnActionExecuted. Эти методы:
	//	//		Заключают фильтры, которые выполняются для указанного действия.
	//	//		OnActionExecuting вызывается перед всеми фильтрами действий.
	//	//		OnActionExecuted вызывается после всех фильтров действий.
	//	//OnActionExecutionAsync вызывается перед всеми фильтрами действий. Код в фильтре после next выполняется после метода действия.
	//	[NonAction]
	//	public override void OnActionExecuting(ActionExecutingContext context)
	//	{
	//		// Do something before the action executes.
	//		base.OnActionExecuting(context);
	//	}

	//	[NonAction]
	//	public override void OnActionExecuted(ActionExecutedContext context)
	//	{
	//		// Do something after the action executes.
	//		base.OnActionExecuted(context);
	//	}
	//}
}
