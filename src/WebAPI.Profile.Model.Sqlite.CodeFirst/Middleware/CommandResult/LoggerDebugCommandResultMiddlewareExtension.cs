using Microsoft.AspNetCore.Builder;

namespace WebAPI.Monitor.Sqlite.CodeFirst
{
	//метода расширения для предоставления промежуточного программного обеспечения.
 //Метод расширения промежуточного программного обеспечения 
 //предоставляет промежуточное программное обеспечение через IApplicationBuilder,
    public static class LoggerDebugCommandResultMiddlewareExtension
	{
        public static IApplicationBuilder UseLoggerDebugCommandResultt(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LoggerDebugCommandResultMiddleware>();
        }
    }
}