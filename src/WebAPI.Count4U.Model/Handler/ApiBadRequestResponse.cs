using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api
namespace Count4U.Service.WebAPI.Model
{
	public class ApiBadRequestResponse : ApiResponse
	{
		public IEnumerable<string> Errors { get; }

		public ApiBadRequestResponse(ModelStateDictionary modelState)
			: base(400)
		{
			if (modelState.IsValid)
			{
				throw new ArgumentException("ModelState must be invalid", nameof(modelState));
			}

			Errors = modelState.SelectMany(x => x.Value.Errors)
				.Select(x => x.ErrorMessage).ToArray();
		}
	}
}

// how use
//[HttpGet("product")]
//public async Task<IActionResult> GetProduct(GetProductRequest request)
//{
//	if (!ModelState.IsValid)
//	{
//		return BadRequest(new ApiBadRequestResponse(ModelState));
//	}

//	var model = await _db.Get(...);

//	if (model == null)
//	{
//		return NotFound(new ApiResponse(404, $"Product not found with id {request.ProductId}"));
//	}

//	return Ok(new ApiOkResponse(model));
//}
