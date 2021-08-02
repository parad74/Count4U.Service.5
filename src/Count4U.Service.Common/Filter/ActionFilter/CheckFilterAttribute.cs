//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace Count4U.Service.Common.Filter.ActionFilterFactory
//{
//	//Некоторые интерфейсы фильтров имеют соответствующие атрибуты, 
//	//	которые можно использовать как базовые классы для пользовательских реализаций.
//	//	ActionFilterAttribute
//	// ExceptionFilterAttribute
//	//ResultFilterAttribute
//	//FormatFilterAttribute
//	//ServiceFilterAttribute
//	//TypeFilterAttribute
//	public class CheckFilterAttribute : Attribute, IAsyncActionFilter
//	{
//		public async Task OnActionExecutionAsync(ActionExecutingContext context,
//														ActionExecutionDelegate next)
//		{
//			if (context.ModelState.IsValid == false)
//				context.ActionArguments["id"] = 34;

//			// вызов await next() для передаваемого в качестве параметра объекта ActionExecutionDelegate
//			//позволит выполнить последующие фильтры действий
//			await next();
//		}
//	}
//}
////how use
////public class HomeController : Controller
////{
////	[CheckFilter]
////	public IActionResult Index()
////	{
////		return View();
////	}
////}