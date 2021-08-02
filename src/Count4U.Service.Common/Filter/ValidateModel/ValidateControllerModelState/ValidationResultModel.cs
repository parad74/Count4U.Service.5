using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Count4U.Service.Common.Filter
{
	//https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/
	public class ValidationResultModel
	{
		public string Message { get; }

		public List<ValidationError> Errors { get; }

		public ValidationResultModel(ModelStateDictionary modelState)
		{
			this.Message = "Validation Failed";
			this.Errors = modelState.Keys
					.SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
					.ToList();
		}
	}
}
