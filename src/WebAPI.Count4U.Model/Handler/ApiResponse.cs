using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

//https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api
namespace Count4U.Service.WebAPI.Model
{
	[DataContract]
	public class ApiResponse
	{
		public int StatusCode { get; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; }

		public ApiResponse(int statusCode, string message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(statusCode);
		}

		private static string GetDefaultMessageForStatusCode(int statusCode)
		{
			switch (statusCode)
			{
				case 404:
					return "Resource not found";
				case 500:
					return "An unhandled error occurred";
				default:
					return null;
			}
		}
	}

}

