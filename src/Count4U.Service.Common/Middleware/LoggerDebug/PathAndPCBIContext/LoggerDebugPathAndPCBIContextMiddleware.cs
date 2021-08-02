using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	//все запросы должны попадать первыми в конвейер, который регистрирует тело запроса
	public class LoggerDebugPathAndPCBIContextMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LoggerDebugPathAndPCBIContextMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this._next = next;
			this._logger = loggerFactory.CreateLogger<LoggerDebugPathAndPCBIContextMiddleware>();
		}

		public async Task InvokeAsync(HttpContext httpContext, IPCBIContext pcbiContext)
		{
			string pcbiContextString = (pcbiContext as PCBIContext).ToStringDebug();

			this._logger.ControllerLogDebugPathAndCBIContext(httpContext.Request.Method, httpContext.Request.Path, pcbiContextString);

			await this._next.Invoke(httpContext);

			this._logger.ControllerLogDebugPathAndCBIContext("END", httpContext.Request.Path, pcbiContextString);
		}
	}
}

//Чтобы включить ведение журнала, мы внедрили ILoggerFactory,
//который является базовой службой dotNet Core нам не нужно беспокоиться о внедрении ILoggerFactory,
//так как dotnet Core позаботится о внедрении служб инфраструктуры
//(Пример служб инфраструктуры IApplicationBuilder, IHostingEnvironment, ILoggerFactory и т.д.).