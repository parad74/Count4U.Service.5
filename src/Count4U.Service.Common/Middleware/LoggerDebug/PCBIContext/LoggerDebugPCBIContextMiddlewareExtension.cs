using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	public static class LoggerDebugPCBIContextMiddlewareExtension
	{
		public static IApplicationBuilder UseLoggerDebugPCBIContext(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<LoggerDebugPCBIContextMiddleware>();
		}
	}
}