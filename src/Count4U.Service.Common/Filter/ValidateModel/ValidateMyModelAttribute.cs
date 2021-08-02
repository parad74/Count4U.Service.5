using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

//https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/
//https://code-maze.com/filters-in-asp-net-core-mvc/  <=
namespace Count4U.Service.Common.Filter
{
	public class ValidateMyModelAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var param = context.ActionArguments.SingleOrDefault();

			if (param.Value == null)
			{
				context.Result = new BadRequestObjectResult("Model is null");
				return;
			}

			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}



		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var result = context.Result;
			// Do something with Result.
			if (context.Canceled == true)
			{
				// Action execution was short-circuited by another filter.
			}

			if (context.Exception != null)
			{
				// Exception thrown by action or action filter.
				// Set to null to handle the exception.
				//context.Exception = null;
			}
			base.OnActionExecuted(context);
		}
	}


}
//how use

//[ValidateModel]
//[HttpPost]
//public IActionResult Create([FromForm]Book book)
//{
//	return View();
//}

////??зарегистрироваить
//??services.AddScoped<ValidationFilterAttribute>();	   тогда пользовать по другому [ServiceFilter(typeof(ValidationFilterAttribute))]
