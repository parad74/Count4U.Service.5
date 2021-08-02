using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model.Settings;
using System.Security.Claims;
using Microsoft.Extensions.Primitives;
using Count4U.Model.Interface;
using Monitor.Service.Urls;
using Monitor.Service.Model;
using Service.Model;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
	//[Route("api/[controller]")]
	public class ClaimWebApiController : ControllerBase
	{
		private readonly ILogger<ClaimWebApiController> _logger;
		//IUnityContainer _container;
		//IServiceLocator _serviceLocator;
		Count4uSettings _count4USettings;
		private readonly IJwtService _jwtService;

		public ClaimWebApiController(
			 ILoggerFactory loggerFactory
			, Count4uSettings count4USettings
			, IJwtService jwtService
			//IServiceLocator serviceLocator,
			//IUnityContainer container, 
			)
		{
			_logger = loggerFactory.CreateLogger<ClaimWebApiController>();
			this._jwtService = jwtService ??
					throw new ArgumentNullException(nameof(jwtService));
			this._count4USettings = count4USettings ??
						throw new ArgumentNullException(nameof(count4USettings));
			//_container = container;
			//_serviceLocator = serviceLocator;
		}

		//[HttpGet("count4u")]
		//public ActionResult<string> GetCount4UContext([FromServices] IDBSettings dbSettings)
		//{
		//	string processCode = dbSettings.ProcessCode;
		//	StringValues accessKey = new StringValues();
		//	this.HttpContext.Request.Headers.TryGetValue(ClaimEnum.AccessKey.ToString(), out accessKey);
		//	return processCode;
		//}

		//Тест синхронный
		[HttpGet(WebApiCount4UModelClaim.GetClaimWebApiConvertItems)]
		public ActionResult<IEnumerable<ClaimConvertItem>> GetClaimWebApiConvertItems([FromServices] IDBSettings dbSettings)
		{
			if (dbSettings == null) return NotFound();
			string dbSettingsProcessCode = dbSettings.ProcessCode;

			StringValues headersAccessKeys = new StringValues();
			this.HttpContext.Request.Headers.TryGetValue(ClaimEnum.AccessKey.ToString(), out headersAccessKeys);
			string headersAccessKey = "";
			if (headersAccessKeys.Count > 0)	 headersAccessKey = headersAccessKeys[0];
			if (dbSettingsProcessCode != headersAccessKey)
			{
				_logger.LogError($"GetClaimWebApiConvertItems : dbSettings.ProcessCode [{dbSettingsProcessCode}] not Equal AccessKey in Header {headersAccessKey}");
			}

			StringValues customerCodeKeys = new StringValues();
			this.HttpContext.Request.Headers.TryGetValue(ClaimEnum.CustomerCode.ToString(), out customerCodeKeys);
			string customerCodeKey = "";
			if (customerCodeKeys.Count > 0) customerCodeKey = customerCodeKeys[0];

			StringValues branchCodeKeys = new StringValues();
			this.HttpContext.Request.Headers.TryGetValue(ClaimEnum.BranchCode.ToString(), out branchCodeKeys);
			string branchCodeKey = "";
			if (branchCodeKeys.Count > 0) branchCodeKey = branchCodeKeys[0];

			StringValues inventorCodeKeys = new StringValues();
			this.HttpContext.Request.Headers.TryGetValue(ClaimEnum.InventorCode.ToString(), out inventorCodeKeys);
			string inventorCodeKey = "";
			if (inventorCodeKeys.Count > 0) inventorCodeKey = inventorCodeKeys[0];


			//saved JWT from header
			List<ClaimConvertItem> retList = new List<ClaimConvertItem>();
			ClaimsPrincipal authenticatedUser = _jwtService.GetClaimsPrincipalFromToken(this.HttpContext.Request);
			//ClaimsPrincipal authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt"));
			if (authenticatedUser == null)
				return NotFound();
			if (authenticatedUser.Claims == null)
				return NotFound();

			var claimList = authenticatedUser.Claims.ToList();
			if (claimList == null)
				return NotFound();

			foreach (var claim in claimList)
			{
				string name = claim.Subject != null ? claim.Subject.Name : "";
				string type = claim.Type != null ? claim.Type : "";
				string claimType = type.Split('/', '_').Last();
				ClaimConvertItem ret = new ClaimConvertItem(name, claim.Issuer, claimType, claim.Value);
				if (claimType == ClaimEnum.AccessKey.ToString())
				{
					ret.DBSettingsValue = dbSettingsProcessCode;
					ret.HeaderValue = headersAccessKey;
					if (claim.Value != dbSettingsProcessCode)
					{
						_logger.LogError($"GetClaimWebApiConvertItems: dbSettings.ProcessCode [{dbSettingsProcessCode}] not Equal AccessKey in JWT {claim.Value}");
					}
				}
				else if (claimType == ClaimEnum.CustomerCode.ToString())
				{
					ret.HeaderValue = customerCodeKey;
				}
				else if (claimType == ClaimEnum.BranchCode.ToString())
				{
					ret.HeaderValue = branchCodeKey;
				}
				else if (claimType == ClaimEnum.InventorCode.ToString())
				{
					ret.HeaderValue = inventorCodeKey;
				}

				
				retList.Add(ret);
			}

			return Ok(retList);
		}


	}
}
