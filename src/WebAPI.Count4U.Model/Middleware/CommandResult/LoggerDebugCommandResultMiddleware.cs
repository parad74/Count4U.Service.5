using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace Count4U.Service.Common
{
	//все запросы должны попадать первыми в конвейер, который регистрирует тело запроса
	public class LoggerDebugCommandResultMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerDebugCommandResultMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggerDebugCommandResultMiddleware>();
        }


		public async Task InvokeAsync(HttpContext httpContext)
        {
			//string count4uContextString = (count4uContext as Count4uContext).ToStringDebug();

			//_logger.ControllerLogDebugPathAndCBIContext(httpContext.Request.Method, httpContext.Request.Path, count4uContextString);
			
			await _next.Invoke(httpContext);	 
   
			//_logger.ControllerLogDebugPathAndCBIContext("END", httpContext.Request.Path, count4uContextString);
		}
    }
}

//Чтобы включить ведение журнала, мы внедрили ILoggerFactory,
//который является базовой службой dotNet Core нам не нужно беспокоиться о внедрении ILoggerFactory,
//так как dotnet Core позаботится о внедрении служб инфраструктуры
//(Пример служб инфраструктуры IApplicationBuilder, IHostingEnvironment, ILoggerFactory и т.д.).