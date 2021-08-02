using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model.Settings;
using System.Collections.Generic;
using Count4U.Model.Interface.Audit;
using Count4U.Model.Audit;
using Count4U.Service.Common;
using System;
using Monitor.Service.Urls;
using Monitor.Service.Model;
using Count4U.Service.Common.Filter.ActionFilterFactory;
using Count4U.Model;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
	//[Route("api/[controller]")]
	public class ContextCBIController : ControllerBase
	{
		private readonly ILogger<InventorController> _logger;
		private readonly ICount4uContext _count4uContext;
		private readonly IInventorRepository _inventorRepository;
		private readonly IContextCBIRepository _contextCBIRepository;
		

		//private readonly IUnityContainer _container;
		//private readonly IServiceLocator _serviceLocator;
		public ContextCBIController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, IInventorRepository inventorRepository
			,IContextCBIRepository contextCBIRepository
			//,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<InventorController>();
			this._count4uContext = count4uContext ??
						throw new ArgumentNullException(nameof(count4uContext));
			this._inventorRepository = inventorRepository ??
						throw new ArgumentNullException(nameof(inventorRepository));
			this._contextCBIRepository = contextCBIRepository ??
						throw new ArgumentNullException(nameof(contextCBIRepository));
			//_serviceLocator = serviceLocator;
			//_container = container;
		}

		
		//AuditConfig GetProcessCBIConfig(CBIContext contextCBI)
		//Inventors GetInventors();
	
		[HttpGet(WebApiCount4UModelContextCBI.GetProcessCBIConfig)]
		public ActionResult<AuditConfig> GetProcessCBIConfig()
		{
			AuditConfig auditConfig = this._contextCBIRepository.GetProcessCBIConfig(CBIContext.History);
			return auditConfig;
		}


	}
}

