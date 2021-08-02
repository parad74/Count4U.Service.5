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
	public class CustomerController : ControllerBase
	{
		private readonly ILogger<CustomerController> _logger;
		private readonly ICount4uContext _count4uContext;
		private readonly ICustomerRepository _customerRepository;

		//private readonly IUnityContainer _container;
		//private readonly IServiceLocator _serviceLocator;

		public CustomerController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, ICustomerRepository customerRepository
			//,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<CustomerController>();
			this._count4uContext = count4uContext ??
						   throw new ArgumentNullException(nameof(count4uContext));
			this._customerRepository = customerRepository ??
						   throw new ArgumentNullException(nameof(customerRepository));
			//_serviceLocator = serviceLocator;
			//_container = container;
		}

		//Customers GetCustomers();
		[HttpGet(WebApiCount4UModelCustomer.GetCustomers)]
		public ActionResult<IEnumerable<Customer>> GetCustomers()
		{
			Customers customers = this._customerRepository.GetCustomers();
			//if (customers == null) return NotFound();
			return customers;
		}

		[HttpGet(WebApiCount4UModelCustomer.GetCustomerCodeList)]
		public ActionResult<List<string>> GetCustomerCodeList()
		{
			List<string> customerCodes = this._customerRepository.GetCodeList();
			//if (customers == null) return NotFound();
			return customerCodes;
		}


		[HttpGet(WebApiCount4UModelCustomer.GetCurrentCustomer)]
		public ActionResult<Customer> GetCurrentCustomer()
		{
			if (string.IsNullOrWhiteSpace(this._count4uContext.CustomerCode) == true) return null;//NotFound();
			Customer customer = this._customerRepository.GetCustomerByCode(this._count4uContext.CustomerCode);
			//if (customer == null) return NotFound();
			return customer;
		}

		//Customer GetCustomerByCode(string customerCode);
		[HttpGet(WebApiCount4UModelCustomer.GetCustomerByCode)]
		public ActionResult<Customer> GetCustomerByCode([FromRoute] string customerCode)    //Не используйте, [FromRoute]когда значения могут содержать %2f(то есть /). %2fне будет неэкранированный к /. Используйте, [FromQuery]
		{
			Customer customer = this._customerRepository.GetCustomerByCode(customerCode);
			//if (customer == null) return NotFound();
			return customer;
		}


		//List<string> GetCodeList();
		[HttpGet(WebApiCount4UModelCustomer.GetCodeList)]
		public ActionResult<IEnumerable<string>> GetCodeList()
		{
			List<string> customerCodes = this._customerRepository.GetCodeList();
			//if (customerCodes == null) return new List<string>();
			return customerCodes;
		}

	}
}

//string BuildRelativeDbPath(Customer customer);
//Customers GetCustomers()
// Customers GetCustomers(CBIContext contextCBI);
//Customers GetCustomers(SelectParams selectParams);
//void SetCustomers(Customers customers);
//Customer GetCustomer(string Code);
// Customers GetCustomersDetails();
// Customer GetCustomerByCode(string customerCode);
//List<string> GetCodeList();
//void SetCurrent(Customer currentCustomer, AuditConfig auditConfig);
//Customer GetCurrent(AuditConfig auditConfig);
//string GetCurrentCode(AuditConfig auditConfig);
//void Update(Customer customer);
//void UpdateDomainСustomerByInventorConfig(Customers customers);
//void Delete(Customer customer);
//void Delete(List<string> customerCodeList);
//void DeleteDomainObjectOnly(List<string> customerCodeList);
//void Delete(string customerCode);
//void InsertDomainСustomerFromInventorConfig(Customers customers);
//void Insert(Customer customer);
//IConnectionDB Connection { get; set; }
//void RefillInventorConfigs(Customer customer);
//void RefillInventorConfigsAllCustomersInMainDB();
//Dictionary<string, Customer> FillCustomerDictionary();
