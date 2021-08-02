using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	//все запросы должны попадать первыми в конвейер, который регистрирует тело запроса
	public class LoggerDebugPathMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LoggerDebugPathMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this._next = next;
			this._logger = loggerFactory.CreateLogger<LoggerDebugPathMiddleware>();
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			this._logger.ControllerLogDebugPath(httpContext.Request.Method, httpContext.Request.Path);

			await this._next.Invoke(httpContext);

			this._logger.ControllerLogDebugPath("END", httpContext.Request.Path);
		}
	}
}

//Чтобы включить ведение журнала, мы внедрили ILoggerFactory,
//который является базовой службой dotNet Core нам не нужно беспокоиться о внедрении ILoggerFactory,
//так как dotnet Core позаботится о внедрении служб инфраструктуры
//(Пример служб инфраструктуры IApplicationBuilder, IHostingEnvironment, ILoggerFactory и т.д.).