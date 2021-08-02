using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	//метода расширения для предоставления промежуточного программного обеспечения.
 //Метод расширения промежуточного программного обеспечения 
 //предоставляет промежуточное программное обеспечение через IApplicationBuilder,
    public static class LoggerDebugPathAndCount4uContextMiddlewareExtension
	{
        public static IApplicationBuilder UseLoggerDebugPathAndCount4uContext(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LoggerDebugPathAndCount4uContextMiddleware>();
        }
    }
}