using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;
using Count4U.Model.Interface;
using Monitor.Service.Model;

namespace Count4U.Service.Common
{
	//после разбивки на заголовки в Count4uHeaderFromJWTMiddleware
	//из заголовков заполняем контекст-объект для работы с Count4U
	public class Count4uContextFromHeaderMiddleware
	{
        private readonly RequestDelegate _next;

		public Count4uContextFromHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
		}

        public async Task InvokeAsync(HttpContext httpContext, ICount4uContext count4uContext, IDBSettings dBSettings)
        {
			try
			{
				//========== ProcessCode =======================
				{
					dBSettings.ProcessCode = "";
					StringValues accessKeys = new StringValues();
					httpContext.Request.Headers.TryGetValue(ClaimEnum.AccessKey.ToString(), out accessKeys);
					if (accessKeys.Count > 0)
					{
						string processCode = accessKeys[0];
						if (processCode != null)
						{
							dBSettings.ProcessCode = processCode;
							count4uContext.ProcessCode = processCode;
						}
					}
				}

				//========== CustomerCode =======================
				{
					StringValues customerCodes = new StringValues();
					httpContext.Request.Headers.TryGetValue(ClaimEnum.CustomerCode.ToString(), out customerCodes);
					if (customerCodes.Count > 0)
					{
						string customerCode1 = customerCodes[0];
						if (customerCode1 != null)
						{
							count4uContext.CustomerCode = customerCode1;
						}
					}

				}

				//========== BranchCode =======================
				{
					StringValues branchCodes = new StringValues();
					httpContext.Request.Headers.TryGetValue(ClaimEnum.BranchCode.ToString(), out branchCodes);
					if (branchCodes.Count > 0)
					{
						string branchCode = branchCodes[0];
						if (branchCode != null)
						{
							count4uContext.BranchCode = branchCode;
						}
					}
				}

				//========== InventorCode =======================
				{
					StringValues inventorCodes = new StringValues();
					httpContext.Request.Headers.TryGetValue(ClaimEnum.InventorCode.ToString(), out inventorCodes);
					if (inventorCodes.Count > 0)
					{
						string inventorCode = inventorCodes[0];
						if (inventorCode != null)
						{
							count4uContext.InventorCode = inventorCode;
						}
					}
				}
				//========== DBPath =======================
				{
					StringValues dbPaths = new StringValues();
					httpContext.Request.Headers.TryGetValue(ClaimEnum.DBPath.ToString(), out dbPaths);
					if (dbPaths.Count > 0)
					{
						string dbPath = dbPaths[0];
						if (dbPath != null)
						{
							count4uContext.DBPath = dbPath;
						}
					}
				}
				
   			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
			}

		   //=================== next ==============
			await _next.Invoke(httpContext);
		}


	}
}