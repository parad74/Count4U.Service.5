using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Count4U.Service.Common
{
	//все запросы должны попадать первыми в конвейер, который регистрирует тело запроса
	public class LoggerConsolePathMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LoggerConsolePathMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this._next = next;
			this._logger = loggerFactory.CreateLogger<LoggerConsolePathMiddleware>();
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			if (this._logger.IsEnabled(LogLevel.Debug) == true)
			{
				Console.WriteLine("LoggerConsolePathMiddleware >> " + "[" + httpContext.Request.Method + "]" + httpContext.Request.Path);
			}

			//Move to next delegate/middleware in the pipleline
			await this._next.Invoke(httpContext);
		}
	}
}

//Чтобы включить ведение журнала, мы внедрили ILoggerFactory,
//который является базовой службой dotNet Core нам не нужно беспокоиться о внедрении ILoggerFactory,
//так как dotnet Core позаботится о внедрении служб инфраструктуры
//(Пример служб инфраструктуры IApplicationBuilder, IHostingEnvironment, ILoggerFactory и т.д.).