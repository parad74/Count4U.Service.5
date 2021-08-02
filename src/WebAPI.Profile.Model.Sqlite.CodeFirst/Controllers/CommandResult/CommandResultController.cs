//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using Count4U.Model.SelectionParams;
//using Monitor.Model.ServiceContract.Interface;
//using System.Data.Common;
//using System.IO;
//using System.Data;
//using Monitor.Service.Model;
//using Monitor.Service.Urls;

//namespace WebAPI.Monitor.Sqlite.CodeFirst.Controllers
//{
//	[ApiController]
//	//[Route("api/[controller]")]
//	public class CommandResultController : ControllerBase
//	{
//		private readonly ILogger<CommandResultController> _logger;
//		private readonly ICommandResultRepository _commandResultRepository;
		

//		//private readonly IJwtService _jwtService;
//		//private readonly IUnityContainer _container;
//		//private readonly IServiceLocator _serviceLocator;

//		public CommandResultController(
//			  ILoggerFactory loggerFactory
//			, ICommandResultRepository commandResultRepository
//			//, IJwtService jwtService
//			//,IServiceLocator serviceLocator
//			//,IUnityContainer container 
//			)
//		{
//			this._logger = loggerFactory.CreateLogger<CommandResultController>();
//			this._commandResultRepository = commandResultRepository ??
//						   throw new ArgumentNullException(nameof(commandResultRepository));
//			//_jwtService = jwtService;
//			//_serviceLocator = serviceLocator;
//			//_container = container;
//		}

//		[HttpGet(WebApiMonitorCommandResult.GetCommandResults)]
//		public ActionResult<CommandResults> GetCommandResults()
//		{
//			CommandResults commandResults = this._commandResultRepository.GetCommandResults();
//			return commandResults;
//		}

//		[HttpPost(WebApiMonitorCommandResult.GetCommandResultsWithSelectParam)]
//		public ActionResult<CommandResults> GetCommandResultsWithSelectParam([FromBody]SelectParams selectParams)
//		{
//			CommandResults commandResults = this._commandResultRepository.GetCommandResults(selectParams);
//			return commandResults;
//		}

//		[HttpPost(WebApiMonitorCommandResult.GetCommandResultsWithSelectParamTest)]
//		public ActionResult<CommandResults> GetCommandResultsWithSelectParamTest([FromBody]SelectParams selectParams)
//		{
//			//selectParams = new SelectParams();            //Test убрать
//			SelectParams sp = new SelectParams();
//			List<string> param = new List<string>();
//			param.Add("testSessionCode1");
//			param.Add("testSessionCode2");
//			param.Add("testSessionCode3");
//			param.Add("testSessionCode4");
//			if (param.Count != 0)
//			{
//			       sp.FilterStringListParams.Add("SessionCode", new FilterStringListParam()
//                {
//                    Values = param
//                });
//			}
//			selectParams = sp;

//			//sp.FilterParams.Add("SessionCode",
//			//                                   new FilterParam() { Operator = FilterOperator.Contains, Value = "testSessionCode1" });
//			//selectParams = sp;

//			CommandResults commandResults = this._commandResultRepository.GetCommandResults(selectParams);
//			return commandResults;
//		}

//		[HttpPost(WebApiMonitorCommandResult.GetCommandResultById)]
//		public ActionResult<CommandResult> GetCommandResultById([FromBody]long id)
//		{
//			CommandResult commandResult = this._commandResultRepository.GetCommandResult(id);
//			return commandResult;
//		}


//		[HttpPost(WebApiMonitorCommandResult.GetCommandResultsByParentCode)]
//		public ActionResult<CommandResults> GetCommandResultsByParentCode([FromBody]string parentCommandResultCode)
//		{
//			CommandResults commandResults = this._commandResultRepository.GetCommandResultsByParentCode(parentCommandResultCode);
//			return commandResults;
//		}

//		[HttpPost(WebApiMonitorCommandResult.GetCommandResultByCommandResultCode)]
//		public ActionResult<CommandResult> GetCommandResultByCommandResultCode([FromBody]string commandResultCode)
//		{
//			CommandResult commandResult = this._commandResultRepository.GetCommandResultByCommandResultCode(commandResultCode);
//			return commandResult;
//		}

//		[HttpPost(WebApiMonitorCommandResult.DeleteById)]
//		public ActionResult<long> DeleteById([FromBody]long id)
//		{
//			this._commandResultRepository.Delete(id);
//			return id;
//		}

//		[HttpPost(WebApiMonitorCommandResult.DeleteByCommandResultCode)]
//		public ActionResult<string> DeleteByCommandResultCode([FromBody]string commandResultCode)
//		{
//			this._commandResultRepository.Delete(commandResultCode);
//			return commandResultCode;
//		}

//		[HttpPost(WebApiMonitorCommandResult.Insert)]
//		public ActionResult<long> Insert([FromBody]CommandResult commandResult)
//		{
//			long id = this._commandResultRepository.Insert(commandResult);
//			return id;
//		}

//		[HttpPost(WebApiMonitorCommandResult.InsertArray)]
//		public Task InsertArray([FromBody]CommandResult[] commandResultArray)
//		{
//			return this._commandResultRepository.Insert(commandResultArray);
//		}

//		[HttpPost(WebApiMonitorCommandResult.Update)]
//		public ActionResult<long> Update([FromBody]CommandResult commandResult)
//		{
//			this._commandResultRepository.Update(commandResult);
//			return commandResult.ID;
//		}

//		[HttpPost(WebApiMonitorCommandResult.DeleteAll)]
//		public Task DeleteAll()
//		{
//			return  this._commandResultRepository.DeleteAll();
//		}

//		[HttpGet(WebApiMonitorCommandResult.GetTestDataCommandResults)]
//		public ActionResult<CommandResults> GetTestDataCommandResults()
//		{
//			CommandResults commandResults = this._commandResultRepository.GetTestDataCommandResults();
//			return commandResults;
//		}	

	
//	}
//}
