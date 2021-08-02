using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	//метода расширения для предоставления промежуточного программного обеспечения.
	//Метод расширения промежуточного программного обеспечения 
	//предоставляет промежуточное программное обеспечение через IApplicationBuilder,
	public static class LoggerDebugPathMiddlewareExtension
	{
		public static IApplicationBuilder UseLoggerDebugPath(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<LoggerDebugPathMiddleware>();
		}
	}
}