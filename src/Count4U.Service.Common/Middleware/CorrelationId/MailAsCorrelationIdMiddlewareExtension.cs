using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	public static class MailAsCorrelationIdMiddlewareExtension
	{
		public static IApplicationBuilder UseMailAsCorrelationId(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<MailAsCorrelationIdMiddleware>();
		}
	}
}