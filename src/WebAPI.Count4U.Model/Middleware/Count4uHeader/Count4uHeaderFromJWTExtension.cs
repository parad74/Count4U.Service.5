using Microsoft.AspNetCore.Builder;
using System;

namespace Count4U.Service.Common
{
    public static class Count4uHeaderFromJWTExtension
	{
        public static IApplicationBuilder UseCount4uHeaderFromJWT(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<Count4uHeaderFromJWTMiddleware>();
        }
  	
	}
}