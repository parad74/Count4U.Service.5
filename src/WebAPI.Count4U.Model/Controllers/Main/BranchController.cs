using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model.Settings;
using System.Collections.Generic;
using Count4U.Model.Interface.Main;
using Count4U.Model.Main;
using Count4U.Service.Common;
using System;
using Monitor.Service.Urls;
using Monitor.Service.Model;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
	//[Route("api/[controller]")]
	public class BranchController : ControllerBase
	{
		private readonly ILogger<BranchController> _logger;
		private readonly ICount4uContext _count4uContext;
		private readonly IBranchRepository _branchRepository;

		//private readonly IUnityContainer _container;
		//private readonly IServiceLocator _serviceLocator;
		public BranchController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, IBranchRepository branchRepository
			//,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<BranchController>();
			this._count4uContext = count4uContext ??
						  throw new ArgumentNullException(nameof(count4uContext));
			this._branchRepository = branchRepository ??
						   throw new ArgumentNullException(nameof(branchRepository));

			//_serviceLocator = serviceLocator;
			//_container = container;
		}

		//Branches GetBranches();
		[HttpGet(WebApiCount4UModelBranch.GetBranches)]
		public ActionResult<IEnumerable<Branch>> GetBranches()
		{
			Branches branches = this._branchRepository.GetBranches();
			//if (branches == null) return NotFound();
			return branches;
		}

		[HttpGet(WebApiCount4UModelBranch.GetCurrentBranch)]
		public ActionResult<Branch> GetCurrentBranch()
		{
			if (string.IsNullOrWhiteSpace(this._count4uContext.BranchCode) == true) return null;// return NotFound();
			Branch branch = this._branchRepository.GetBranchByCode(this._count4uContext.BranchCode);
		//	if (branch == null) return NotFound();
			return branch;
		}

		//Branch GetBranchByCode(string branchCode);
		[HttpGet(WebApiCount4UModelBranch.GetBranchByCode)]
		public ActionResult<Branch> GetBranchByCode([FromRoute] string branchCode)  //Не используйте, [FromRoute]когда значения могут содержать %2f(то есть /). %2fне будет неэкранированный к /. Используйте, [FromQuery]
		{
			Branch branch = this._branchRepository.GetBranchByCode(branchCode);
			//if (branch == null) return NotFound();
			return branch;
		}


		[HttpGet(WebApiCount4UModelBranch.GetBranchesByCurrnetCustomer)]
		public ActionResult<IEnumerable<Branch>> GetBranchesByCurrnetCustomer()
		{
			if (string.IsNullOrWhiteSpace(this._count4uContext.CustomerCode) == true) return null;// NotFound();
			Branches branches = this._branchRepository.GetBranchesByCustomerCode(this._count4uContext.CustomerCode);
			//if (branches == null) return NotFound();
			return branches;
		}

		//Branches GetBranchesByCustomerCode(string customerCode);
		[HttpGet(WebApiCount4UModelBranch.GetBranchesByCustomerCode)]
		public ActionResult<IEnumerable<Branch>> GetBranchesByCustomerCode([FromRoute] string customerCode)  //Не используйте, [FromRoute]когда значения могут содержать %2f(то есть /). %2fне будет неэкранированный к /. Используйте, [FromQuery]
		{
			Branches branches = this._branchRepository.GetBranchesByCustomerCode(customerCode);
		//	if (branches == null) return NotFound();
			return branches;
		}

		//List<string> GetBranchCodeListByCustomerCode(string customerCode);
		[HttpGet(WebApiCount4UModelBranch.GetBranchCodeListByCustomerCode)]
		public ActionResult<IEnumerable<string>> GetBranchCodeListByCustomerCode([FromRoute] string customerCode)  //Не используйте, [FromRoute]когда значения могут содержать %2f(то есть /). %2fне будет неэкранированный к /. Используйте, [FromQuery]
		{
			List<string> brancheCodes = this._branchRepository.GetBranchCodeListByCustomerCode(customerCode);
		//	if (brancheCodes == null) return new List<string>();
			return brancheCodes;
		}


	}
}

//string BuildRelativeDbPath(Branch branche);
//Branches GetBranches();
//Branches GetBranches(SelectParams selectParams);
//Branches GetBranches(CBIContext contextCBI);
//void SetBranches(Branches branches);
//Branch GetBranchByCode(string branchCode);
//Branches GetBranchesByCustomer(Customer customer);
//Branches GetBranchesByCustomerCode(string customerCode, CBIContext contextCBI);
//Branches GetBranchesByCustomerCode(string customerCode)
//Branches GetBranchesDetailsByCustomer(Customer customer);
//void SetCurrent(Branch currentBranch, AuditConfig auditConfig);
//Branch GetCurrent(AuditConfig auditConfig);
//string GetCurrentCode(AuditConfig auditConfig);
//List<string> GetCodeList();
//List<string> GetBranchCodeListByCustomerCode(string customerCode);
//void Delete(Branch branch);
//void Delete(string branchCode);
//void Delete(List<string> branchCodeList);
//void DeleteDomainObjectOnly(List<string> branchCodeList);
//void DeleteAllByCustomerCode(string customerCode, bool full = false);
//void Insert(Branches branchs);
//void Insert(string customerCode, Branch branch, bool copyEmptyDB = true);
//void Insert(Customer customer, Branch branch, bool copyEmptyDB = true);
//void Insert(Branch branch, bool copyEmptyDB = true, string inheritFromDBPath = null);
//void Insert(Dictionary<string, Branch> branchToDBDictionary, bool copyEmptyDB = true);
//void InsertDomainBranchFromInventorConfig(Branches branches);
//void Update(Branch branch);
//void UpdateBranchName(Branch branch);
//void UpdateDomainBranchByInventorConfig(Branches branches);
//IConnectionDB Connection { get; set; }
//void RefillInventorConfigs(Branch branch);
//void RefillInventorConfigsAllBranchesInMainDB();
//Dictionary<string, Branch> FillBranchDictionary();
//void DeleteBranchWithDoubleCode(string description = "Repair");
