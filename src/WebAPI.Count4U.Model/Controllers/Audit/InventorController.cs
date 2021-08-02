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

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
	//[Route("api/[controller]")]
	public class InventorController : ControllerBase
	{
		private readonly ILogger<InventorController> _logger;
		private readonly ICount4uContext _count4uContext;
		private readonly IInventorRepository _inventorRepository;

		//private readonly IUnityContainer _container;
		//private readonly IServiceLocator _serviceLocator;
		public InventorController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, IInventorRepository inventorRepository
			//,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<InventorController>();
			this._count4uContext = count4uContext ??
						throw new ArgumentNullException(nameof(count4uContext));
			this._inventorRepository = inventorRepository ??
						throw new ArgumentNullException(nameof(inventorRepository));
			//_serviceLocator = serviceLocator;
			//_container = container;
		}

		//Inventors GetInventors();
		[HttpGet(WebApiCount4UModelInventor.GetInventors)]
		public ActionResult<IEnumerable<Inventor>> GetInventors()
		{
			Inventors inventors = this._inventorRepository.GetInventors();
		//	if (inventors == null) return NotFound();
			return inventors;
		}

		[HttpGet(WebApiCount4UModelInventor.GetCurrentInventor)]
		public ActionResult<Inventor> GetCurrentInventor()
		{
			if (string.IsNullOrWhiteSpace(this._count4uContext.InventorCode) == true) return null;//return NotFound();
			Inventor inventor = this._inventorRepository.GetInventorByCode(this._count4uContext.InventorCode);
		//	if (inventor == null) return NotFound();
			return inventor;
		}

		//Inventor GetInventorByCode(string сode);
		[HttpGet(WebApiCount4UModelInventor.GetInventorByCode)]
		public ActionResult<Inventor> GetInventorByCode([FromRoute] string сode)   //Не используйте, [FromRoute]когда значения могут содержать %2f(то есть /). %2fне будет неэкранированный к /. Используйте, [FromQuery]
		{
			Inventor inventor = this._inventorRepository.GetInventorByCode(сode);
		//	if (inventor == null) return NotFound();
			return inventor;
		}

		[HttpGet(WebApiCount4UModelInventor.GetInventorsByCurrentBranch)]
		public ActionResult<IEnumerable<Inventor>> GetInventorsByCurrentBranch()
		{
			if (string.IsNullOrWhiteSpace(this._count4uContext.BranchCode) == true) return null; //return NotFound();
			Inventors inventors = this._inventorRepository.GetInventorsByBranchCode(this._count4uContext.BranchCode);
		//	if (inventors == null) return NotFound();
			return inventors;
		}

		//Inventors GetInventorsByBranchCode(string branchCode);
		[HttpGet(WebApiCount4UModelInventor.GetInventorsByBranchCode)]
		public ActionResult<IEnumerable<Inventor>> GetInventorsByBranchCode([FromRoute] string branchCode)
		{
			Inventors inventors = this._inventorRepository.GetInventorsByBranchCode(branchCode);
	//		if (inventors == null) return NotFound();
			return inventors;
		}

		[HttpGet(WebApiCount4UModelInventor.GetInventorCodeListByCurrentCustomer)]
		public ActionResult<IEnumerable<string>> GetInventorCodeListByCurrentCustomer()
		{
			if (string.IsNullOrWhiteSpace(this._count4uContext.CustomerCode) == true) return null;//return NotFound();
			List<string> inventorCodes = this._inventorRepository.GetInventorCodeListByCustomerCode(this._count4uContext.CustomerCode);
	//		if (inventorCodes == null) return new List<string>();
			return inventorCodes;
		}

		//List<string> GetInventorCodeListByCustomerCode(string customerCode);
		[HttpGet(WebApiCount4UModelInventor.GetInventorCodeListByCustomerCode)]
		public ActionResult<IEnumerable<string>> GetInventorCodeListByCustomerCode([FromRoute] string customerCode)
		{
			List<string> inventorCodes = this._inventorRepository.GetInventorCodeListByCustomerCode(customerCode);
	//		if (inventorCodes == null) return new List<string>();
			return inventorCodes;
		}

		[HttpGet(WebApiCount4UModelInventor.GetInventorCodeListByCurrentBranch)]
		public ActionResult<IEnumerable<string>> GetInventorCodeListByCurrentBranch()
		{
			if (string.IsNullOrWhiteSpace(this._count4uContext.BranchCode) == true) return null; //return NotFound();
			List<string> brancheCodes = this._inventorRepository.GetInventorCodeListByBranchCode(this._count4uContext.BranchCode);
	//		if (brancheCodes == null) return new List<string>();
			return brancheCodes;
		}


		//List<string> GetInventorCodeListByBranchCode(string branchCode);
		[HttpGet(WebApiCount4UModelInventor.GetInventorCodeListByBranchCode)]
		public ActionResult<IEnumerable<string>> GetInventorCodeListByBranchCode([FromRoute] string branchCode)
		{
			List<string> brancheCodes = this._inventorRepository.GetInventorCodeListByBranchCode(branchCode);
			//if (brancheCodes == null) return new List<string>();
			return brancheCodes;
		}

	}
}

//string BuildRelativeDbPath(Inventor inventor);
//Inventors GetInventors();
//Inventors GetInventors(SelectParams selectParams);
//void SetInventors(Inventors inventors);
//Inventor GetInventorByCode(string сode);
//int GetInventorCountByBranchCode(string branchCode);
//Inventors GetInventorsByBranchCode(string branchCode);
//Inventors GetInventorsByCustomerCode(string customerCode);
//Inventors GetInventorsByStatus(string status);
//void SetCurrent(Inventor currentInventor, AuditConfig auditConfig);
//string GetCurrentCode(AuditConfig auditConfig);
//Inventor GetCurrent(AuditConfig auditConfig);
//List<string> GetCodeList();
//List<string> GetInventorCodeListByCustomerCode(string customerCode);
//List<string> GetInventorCodeListByBranchCode(string branchCode);
// void SetStatus(Inventor inventor, string statusCode, string statusName);
//void DeleteAllByBranchCode(string branchCode, bool full = true);
//void DeleteAllByCustomerCode(string customerCode, bool full = true);
//void Delete(Inventor inventor, bool full = true);
//void Delete(string code, bool full = true);
//void Insert(Inventor inventor, string inheritFromDBPath = null);
//void Insert(Inventors inventors);
//void InsertDomainInventorFromInventorConfig(Inventors inventors);
//IConnectionDB Connection { get; set; }
//void Update(Inventor inventor);
//void UpdateDomainInventorByInventorConfig(Inventors inventors);
//void RefillInventorConfigs(Inventor inventor);
//void RefillInventorConfigsAllInventorsInAuditDB();