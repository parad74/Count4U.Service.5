using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	public static class LoggerInformationPathMiddlewareExtension
	{
		public static IApplicationBuilder UseLoggerInformationPath(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<LoggerInformationPathMiddleware>();
		}
	}
}