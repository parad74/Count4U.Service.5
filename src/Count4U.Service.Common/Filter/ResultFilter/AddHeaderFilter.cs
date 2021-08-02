using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Count4U.Service.Common.Filter.ResultFilter
{
	// внимание!!! есть встроинный фильтр 
	//Некоторые интерфейсы фильтров имеют соответствующие атрибуты, 
	//	которые можно использовать как базовые классы для пользовательских реализаций.
	//	ActionFilterAttribute
	// ExceptionFilterAttribute
	//ResultFilterAttribute
	//FormatFilterAttribute
	//ServiceFilterAttribute
	//TypeFilterAttribute
	//public class AddHeaderAttribute : ResultFilterAttribute
	//{
	//	private readonly string _name;
	//	private readonly string _value;

	//	public AddHeaderAttribute(string name, string value)
	//	{
	//		_name = name;
	//		_value = value;
	//	}

	//	public override void OnResultExecuting(ResultExecutingContext context)
	//	{
	//		context.HttpContext.Response.Headers.Add(_name, new string[] { _value });
	//		base.OnResultExecuting(context);
	//	}
	//}
	//how use
	//[AddHeader("Author", "Joe Smith")]
	//public class SampleController : Controller
	//{



	//При добавлении каких-нибудь заголовков в ответ в фильтре результатов это следует делать 
	//до выполнения результата, то есть в методе OnResultExecuting(), а не в OnResultExecuted().
	public class AddMyHeaderFilter : IResultFilter                // а можно так Attribute, IResultFilter тогда не надо оборачивать в аттрибут
	{
		//С помощью его свойства ResultExecutingContext.Result мы можем манипулировать результатом метода. 
		//В методе OnResultExecuting() можно предотвратить дальнейшее выполнение фильтров и обработку запроса, 
		//установив свойство ResultExecutingContext.Cancel равным true.
		public void OnResultExecuting(ResultExecutingContext context)
		{
			context.HttpContext.Response.Headers.Add(
				"OnResultExecuting",
				"This header was added by result filter.");        //TO DO 
		}

		//Метод OnResultExecuted() вызывается после выполнения результата действия.
		//	На этой стадии также можно предтвратить дальнейшую обработку запроса на других фильтрах, 
		//	присвоив свойству ResultExecutedContext.Canceled значение true.
		public void OnResultExecuted(ResultExecutedContext context)
		{
		}
	}

	public class AddMyHeaderAttribute : TypeFilterAttribute
	{
		public AddMyHeaderAttribute() : base(typeof(AddMyHeaderFilter))
		{
		}
	}

}

//how use
//[AddHeader]
//public IActionResult TestResultFilter()
//{
//	return View();
//}