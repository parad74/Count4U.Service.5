using Microsoft.AspNetCore.Mvc.Filters;

//https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/
namespace Count4U.Service.Common.Filter
{
	public class ValidateControllerModelStateAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			//var param = context.ActionArguments.SingleOrDefault();

			//if (param.Value == null)
			//{
			//	context.Result = new BadRequestObjectResult("Model is null");
			//	return;
			//}

			if (!context.ModelState.IsValid)
			{
				context.Result = new ValidationFailedResult(context.ModelState);
			}
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
