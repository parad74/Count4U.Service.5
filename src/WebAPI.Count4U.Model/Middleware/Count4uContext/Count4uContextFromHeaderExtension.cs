using Microsoft.AspNetCore.Builder;
using System;

namespace Count4U.Service.Common
{
    public static class Count4uContextFromHeaderExtension
	{
        public static IApplicationBuilder UseCount4uContextFromHeader(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<Count4uContextFromHeaderMiddleware>();
        }
  	
	}
}