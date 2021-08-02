using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Count4U.Service.Common.Filter.ExceptionFilter
{
	//Для обработки исключения присвойте свойству ExceptionHandled значение true или напишите ответ.
	//Это предотвратит распространение исключения. Фильтр исключений не может преобразовать исключение 
	//в успешное выполнение. Это может сделать только фильтр действий.
	//Фильтры исключений:
	//Хорошо подходят для перехвата исключений, возникающих в действиях.
	//Не обладает такой гибкостью, как ПО промежуточного слоя обработки ошибок.
	public class CustomMyExceptionFilterAttribute : ExceptionFilterAttribute
	{
		private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IModelMetadataProvider _modelMetadataProvider;

		public CustomMyExceptionFilterAttribute(
			IHostingEnvironment hostingEnvironment,
			IModelMetadataProvider modelMetadataProvider)
		{
			this._hostingEnvironment = hostingEnvironment;
			this._modelMetadataProvider = modelMetadataProvider;
		}

		public override void OnException(ExceptionContext context)
		{
			if (!this._hostingEnvironment.IsDevelopment())
			{
				return;
			}
			//var result = new ViewResult { ViewName = "CustomError" };
			//result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
			//											context.ModelState);
			//result.ViewData.Add("Exception", context.Exception);
			//// TODO: Pass additional detailed data via ViewData
			//context.Result = result;
		}
	}
}
