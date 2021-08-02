using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Count4U.Service.Common.Filter.ResourceFilter
{
	public class IEFilterAttribute : Attribute, IResourceFilter
	{
		public void OnResourceExecuted(ResourceExecutedContext context)
		{

		}

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			// получаем информацию о браузере пользователя
			string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
			if (Regex.IsMatch(userAgent, "MSIE [6-9]"))
			{
				context.Result = new ContentResult { Content = "Yuor browser cann't be used" };
			}
		}
	}
}

//Интерфейс IResourceFilter предоставляет два метода:
//OnResourceExecuting() : срабатывает после фильтров авторизации, но до выполнения метода и работы фильтров действий, исключений и результатов
// OnResourceExecuted(): срабатывает после выполнения метода и фильтров действий, исключений и результатов
//В качестве параметра в оба метода передается параметр типа ResourceExecutedContext, который позволяет получить данные запроса и управлять ответом.