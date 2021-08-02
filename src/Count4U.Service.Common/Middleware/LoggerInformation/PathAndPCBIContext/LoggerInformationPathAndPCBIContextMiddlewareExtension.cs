using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	public static class LoggerInformationPathAndPCBIContextMiddlewareExtension
	{
		public static IApplicationBuilder UseLoggerInformationPathAndPCBIContext(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<LoggerInformationPathAndPCBIContextMiddleware>();
		}
	}
}