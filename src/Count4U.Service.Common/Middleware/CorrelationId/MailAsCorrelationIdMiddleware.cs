using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Count4U.Service.Common
{
	public class MailAsCorrelationIdMiddleware
	{
		private readonly RequestDelegate _next;

		public MailAsCorrelationIdMiddleware(RequestDelegate next)
		{
			this._next = next ?? throw new ArgumentNullException(nameof(next));
		}

		public Task Invoke(HttpContext httpContext)
		{
			string traceIdentifier;
			try
			{
				traceIdentifier = httpContext.User.Identity.Name;
				if (traceIdentifier == null)
					traceIdentifier = "";
			}
			catch { traceIdentifier = ""; }

			httpContext.Response.Headers.Add("X-eMail", traceIdentifier);
			return this._next(httpContext);
		}
	}

}
