using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Count4U.Service.WebAPI.Model
{
	//Некоторые интерфейсы фильтров имеют соответствующие атрибуты, 
	//	которые можно использовать как базовые классы для пользовательских реализаций.
//	ActionFilterAttribute
// ExceptionFilterAttribute
//ResultFilterAttribute
//FormatFilterAttribute
//ServiceFilterAttribute
//TypeFilterAttribute
	public class CheckTestFilterAttribute : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context,
														ActionExecutionDelegate next)
		{
			if (context.ModelState.IsValid == false)
				context.ActionArguments["id"] = 34;
			
			// вызов await next() для передаваемого в качестве параметра объекта ActionExecutionDelegate
			//позволит выполнить последующие фильтры действий
			await next();
		}
	}
}
//how use
//public class HomeController : Controller
//{
//	[CheckFilter]
//	public IActionResult Index()
//	{
//		return View();
//	}
//}