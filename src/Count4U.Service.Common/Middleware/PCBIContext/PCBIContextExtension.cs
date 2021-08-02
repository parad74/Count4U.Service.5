using System;
using Microsoft.AspNetCore.Builder;

namespace Count4U.Service.Common
{
	public static class PCBIContextExtension
	{
		public static IApplicationBuilder UsePCBIContext(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<PCBIContextMiddleware>();
		}

		public static string ToStringDebug(this PCBIContext pcbiContext)
		{
			if (pcbiContext == null)
				return "";
			string ret = "";
			try
			{
				ret = pcbiContext.ProcessCode + " | " + pcbiContext.CustomerCode + " | " + pcbiContext.BranchCode + " | " + pcbiContext.InventorCode;
			}
			catch (Exception ex)
			{
				ret = ex.Message;
			}
			return ret;
		}
	}
}