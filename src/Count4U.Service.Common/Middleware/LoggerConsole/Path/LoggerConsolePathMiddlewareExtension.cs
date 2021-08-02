using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	//метода расширения для предоставления промежуточного программного обеспечения.
	//Метод расширения промежуточного программного обеспечения 
	//предоставляет промежуточное программное обеспечение через IApplicationBuilder,
	public static class LoggerConsolePathMiddlewareExtension
	{
		public static IApplicationBuilder UseLoggerConsolePath(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<LoggerConsolePathMiddleware>();
		}
	}
}