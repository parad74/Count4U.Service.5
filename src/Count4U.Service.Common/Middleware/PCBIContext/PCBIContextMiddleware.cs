using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Monitor.Service.Model;

namespace Count4U.Service.Common
{
	public class PCBIContextMiddleware
	{
		private readonly RequestDelegate _next;

		public PCBIContextMiddleware(RequestDelegate next)
		{
			this._next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext, IPCBIContext pcbiContext)
		{
			this.FillPCBIContext(httpContext, ref pcbiContext);
			await this._next.Invoke(httpContext);
		}

		public void FillPCBIContext(HttpContext httpContext, ref IPCBIContext pcbiContext)
		{
			if (httpContext.User == null)
				return;
			if (httpContext.User.Claims == null)
				return;
			List<Claim> clims = httpContext.User.Claims.ToList();
			if (clims.Count == 0)
				return;
			try
			{
				var processCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.AccessKey.ToString());
				if (processCode != null)
				{
					pcbiContext.ProcessCode = processCode.Value;
					httpContext.Request.Headers.Add(
					ClaimEnum.AccessKey.ToString(),
					processCode.Value);
				}

				var customerCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.CustomerCode.ToString());
				if (customerCode != null)
				{
					pcbiContext.CustomerCode = customerCode.Value;
					httpContext.Request.Headers.Add(
					ClaimEnum.CustomerCode.ToString(),
					customerCode.Value);
				}

				var branchCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.BranchCode.ToString());
				if (branchCode != null)
				{
					pcbiContext.BranchCode = branchCode.Value;
				}

				var inventorCode = clims.FirstOrDefault(c => c.Type == ClaimEnum.InventorCode.ToString());
				if (inventorCode != null)
				{
					pcbiContext.InventorCode = inventorCode.Value;
				}

				var dBPath = clims.FirstOrDefault(c => c.Type == ClaimEnum.DBPath.ToString());
				if (dBPath != null)
				{
					pcbiContext.DBPath = dBPath.Value;
				}



				//if (dics.ContainsKey(ClaimEnum.DataServerAddress.ToString()) == true)
				//{
				//	pcbiContext.ProcessCode = dics[ClaimEnum.DataServerAddress.ToString()].Value;
				//}
				//if (dics.ContainsKey(ClaimEnum.DataServerPort.ToString()) == true)
				//{
				//	pcbiContext.DataServerPort = dics[ClaimEnum.DataServerPort.ToString()].Value;
				//}
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
			return;
		}
	}
}