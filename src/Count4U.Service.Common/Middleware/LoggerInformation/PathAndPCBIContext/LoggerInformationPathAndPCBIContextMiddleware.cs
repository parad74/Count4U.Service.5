using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	public class LoggerInformationPathAndPCBIContextMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LoggerInformationPathAndPCBIContextMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this._next = next;
			this._logger = loggerFactory.CreateLogger<LoggerInformationPathAndPCBIContextMiddleware>();
		}

		public async Task InvokeAsync(HttpContext httpContext, IPCBIContext pcbiContext)
		{
			string pcbiContextString = (pcbiContext as PCBIContext).ToStringDebug();

			this._logger.ControllerLogInformationPathAndCBIContext(httpContext.Request.Method, httpContext.Request.Path, pcbiContextString);

			await this._next.Invoke(httpContext);

			this._logger.ControllerLogInformationPathAndCBIContext("END", httpContext.Request.Path, pcbiContextString);

		}
	}
}
