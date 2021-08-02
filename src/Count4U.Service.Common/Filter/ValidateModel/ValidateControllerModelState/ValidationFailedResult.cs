using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Count4U.Service.Common.Filter
{
	//https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/
	//создать свой собственный обычай, IActionResultкоторый верну. yе хочу возвращать, 
	//	BadRequestObjectResultпотому что это возвращает HTTP Status Code 400, и я хочу вместо этого вернуть 422.
	public class ValidationFailedResult : ObjectResult
	{
		public ValidationFailedResult(ModelStateDictionary modelState)
			: base(new ValidationResultModel(modelState))
		{
			this.StatusCode = StatusCodes.Status422UnprocessableEntity;
		}
	}
}
