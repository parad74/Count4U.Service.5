using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	public class LoggerInformationPathMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LoggerInformationPathMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this._next = next;
			this._logger = loggerFactory.CreateLogger<LoggerInformationPathMiddleware>();
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			this._logger.ControllerLogInformationPath(httpContext.Request.Method, httpContext.Request.Path);

			await this._next.Invoke(httpContext);

			this._logger.ControllerLogInformationPath("END", httpContext.Request.Path);
		}
	}
}
