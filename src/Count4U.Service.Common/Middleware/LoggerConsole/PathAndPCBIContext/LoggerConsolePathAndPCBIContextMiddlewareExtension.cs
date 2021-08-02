using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	public static class LoggerConsolePathAndMiddlewareExtension
	{
		public static IApplicationBuilder UseLoggerConsolePathAndPCBIContext(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<LoggerConsolePathAndPCBIContextMiddleware>();
		}
	}
}