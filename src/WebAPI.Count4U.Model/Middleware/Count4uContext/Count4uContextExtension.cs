using Microsoft.AspNetCore.Builder;
using System;
using Monitor.Service.Model;

namespace Count4U.Service.Common
{
    public static class Count4uContextExtension
	{
 		public static string ToStringDebug(this Count4uContext count4uContext)
		{
			if (count4uContext == null)	return "";
			string ret = "";
			try
			{
				ret = count4uContext.ProcessCode + " | " + count4uContext.CustomerCode + " | " + count4uContext.BranchCode + " | " + count4uContext.InventorCode;
			}
			catch (Exception ex)
			{
				ret = ex.Message;
			}
			return ret;
		}
	}
}