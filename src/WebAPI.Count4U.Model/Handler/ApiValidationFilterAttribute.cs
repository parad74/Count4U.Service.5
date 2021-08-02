using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Count4U.Service.WebAPI.Model
{
	//https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api
	public class ApiValidationFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(new ApiBadRequestResponse(context.ModelState));
			}

			base.OnActionExecuting(context);
		}
	}
}
