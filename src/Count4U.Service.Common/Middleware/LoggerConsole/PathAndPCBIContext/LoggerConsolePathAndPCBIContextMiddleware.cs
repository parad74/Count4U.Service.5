using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	public class LoggerConsolePathAndPCBIContextMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LoggerConsolePathAndPCBIContextMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this._next = next;
			this._logger = loggerFactory.CreateLogger<LoggerConsolePathAndPCBIContextMiddleware>();
		}

		public async Task InvokeAsync(HttpContext httpContext, IPCBIContext pcbiContext)
		{
			if (this._logger.IsEnabled(LogLevel.Debug) == true)
			{
				string pcbiContextString = (pcbiContext as PCBIContext).ToStringDebug();
				this._logger.LogDebug("[" + httpContext.Request.Method + "]" + httpContext.Request.Path + "[" + pcbiContextString + "]");
			}

			//Move to next delegate/middleware in the pipleline
			await this._next.Invoke(httpContext);
		}
	}
}
