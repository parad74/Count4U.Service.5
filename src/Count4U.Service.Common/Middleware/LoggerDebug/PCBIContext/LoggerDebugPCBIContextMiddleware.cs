using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	public class LoggerDebugPCBIContextMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LoggerDebugPCBIContextMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this._next = next;
			this._logger = loggerFactory.CreateLogger<LoggerDebugPCBIContextMiddleware>();
		}

		public async Task InvokeAsync(HttpContext httpContext, IPCBIContext pcbiContext)
		{
			string pcbiContextString = (pcbiContext as PCBIContext).ToStringDebug();

			this._logger.ControllerLogDebugCBIContext(pcbiContextString);

			await this._next.Invoke(httpContext);
		}
	}
}
