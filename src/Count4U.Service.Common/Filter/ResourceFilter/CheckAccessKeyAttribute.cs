using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Monitor.Service.Model;

namespace Count4U.Service.Common.Filter.ResourceFilter
{
	public class CheckAccessKeyAttribute : Attribute, IResourceFilter
	{
		public void OnResourceExecuted(ResourceExecutedContext context)
		{

		}

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			string AccessKey = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimEnum.AccessKey.ToString())?.Value;
			if (string.IsNullOrEmpty(AccessKey) == true)
			{
				context.Result = new ContentResult { Content = "AccessKey can't be Empty. Set AccessKey in Profile" };
			}
		}
	}
}

//Интерфейс IResourceFilter предоставляет два метода:
//OnResourceExecuting() : срабатывает после фильтров авторизации, но до выполнения метода и работы фильтров действий, исключений и результатов
// OnResourceExecuted(): срабатывает после выполнения метода и фильтров действий, исключений и результатов
//В качестве параметра в оба метода передается параметр типа ResourceExecutedContext, который позволяет получить данные запроса и управлять ответом.