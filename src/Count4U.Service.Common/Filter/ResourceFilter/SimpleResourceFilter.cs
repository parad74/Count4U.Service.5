using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Count4U.Service.Common.Filter.ResourceFilter
{
	public class SimpleResourceFilter : Attribute, IResourceFilter
	{
		int _age;
		string _message;
		public SimpleResourceFilter(int age, string message)
		{
			this._age = age;
			this._message = message;
		}
		public void OnResourceExecuted(ResourceExecutedContext context)
		{
		}

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			context.HttpContext.Response.Headers.Add("Age", this._age.ToString());
			context.HttpContext.Response.Headers.Add("Message", this._message);
		}
	}
}

//how use
//public class HomeController : Controller
//{
//	[SimpleResourceFilter(30, "hello world!")]
//	public IActionResult Index()
//	{
//		return View();
//	}
//}