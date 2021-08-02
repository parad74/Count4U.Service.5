using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monitor.Service.Model.Settings;
using System.Collections.Generic;
using Count4U.Model.Interface.Count4U;
using Count4U.Model.Count4U;
using Count4U.Service.Common;
using System;
using Monitor.Service.Urls;
using System.Threading.Tasks;
using Count4U.Model.SelectionParams;
using Microsoft.AspNetCore.SignalR;
using Count4U.Client.Shared.Service;
using Count4U.Service.Model;
using Count4U.Service.Contract;
using Count4U.Common.Constants;
using Monitor.Service.Shared;
using Monitor.Service.Model;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
//	[Route("api/[controller]")]
	[Produces("application/json")]
	[Consumes("application/json")]
	public class IturController : ControllerBase
	{
		private readonly ILogger<IturController> _logger;
		private readonly IIturRepository _iturRepository;
		private readonly ICount4uContext _count4uContext;
		private readonly IHubContext<ChatHub> _hubContext;
		private readonly IHubChatSignalRRepository _hubSignalRRepository;

		//private readonly IUnityContainer _container;
		//private readonly IServiceLocator _serviceLocator;
		public IturController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, IIturRepository iturRepository
			, IHubContext<ChatHub>	hubContext
			, IHubChatSignalRRepository hubSignalRRepository
			//,IServiceLocator serviceLocator
			//,IUnityContainer container 
			)
		{
			this._logger = loggerFactory.CreateLogger<IturController>();
			this._count4uContext = count4uContext ??
						throw new ArgumentNullException(nameof(count4uContext));
			this._iturRepository = iturRepository ??
						throw new ArgumentNullException(nameof(iturRepository));
			this._hubSignalRRepository = hubSignalRRepository ??
						   throw new ArgumentNullException(nameof(hubSignalRRepository));
			this._hubContext = hubContext ??
						   throw new ArgumentNullException(nameof(hubContext));

			//_serviceLocator = serviceLocator;
			//_container = container;
		}

		//Iturs GetIturs(string pathDB);
		[HttpGet(WebApiCount4UModelItur.GetIturs)]
		public ActionResult<IEnumerable<Itur>> GetIturs()
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return null;//return NotFound();
			Iturs iturs = this._iturRepository.GetIturs($"Inventor\\{_count4uContext.DBPath}");
			//	if (iturs == null) return NotFound();
			return iturs;
		}

		[HttpGet(WebApiCount4UModelItur.GetIturTotalCount)]
		public ActionResult<long> GetIturTotalCount()
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return null;//return NotFound();
			long count = this._iturRepository.GetItursTotal($"Inventor\\{_count4uContext.DBPath}");
			return count;
		}

		
		[HttpPost(WebApiCount4UModelItur.GetTopIturs)]
		public ActionResult<IEnumerable<Itur>> GetTopIturs([FromBody] int top)
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return null;//return NotFound();
			Iturs iturs = this._iturRepository.GetTopIturs(top,$"Inventor\\{_count4uContext.DBPath}");
			//	if (iturs == null) return NotFound();
			return iturs;
		}

		
		[HttpPost(WebApiCount4UModelItur.GetSelectParamsIturs)]
		public ActionResult<IEnumerable<Itur>> GetSelectParamsIturs([FromBody] SelectParams sp)
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return null;//return NotFound();
			Iturs iturs = this._iturRepository.GetIturs(sp,$"Inventor\\{_count4uContext.DBPath}");
			//	if (iturs == null) return NotFound();
			return iturs;
		}

		
		[HttpPost(WebApiCount4UModelItur.GetIturByCode)]
		public ActionResult<Itur> GetIturByCode([FromBody] string iturCode)
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return null;//return NotFound();
			Itur itur = this._iturRepository.GetIturByCode(iturCode, $"Inventor\\{_count4uContext.DBPath}");
		//	if (iturs == null) return NotFound();
			return itur;
		}

		[HttpPost(WebApiCount4UModelItur.GetRefillApproveStatusBitByIturCode)]
		public async Task<Itur>  GetRefillApproveStatusBitByIturCode([FromBody] string iturCode)
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return new Itur();//return NotFound();
			int satus = await Task.Run(()=>this._iturRepository.RefillApproveStatusBitByIturCode(iturCode, $"Inventor\\{_count4uContext.DBPath}"));
			Itur itur = await Task.Run(()=>this._iturRepository.GetIturByCode(iturCode, $"Inventor\\{_count4uContext.DBPath}"));
			return itur;
		}

		[HttpPost(WebApiCount4UModelItur.RefillApproveStatusBitByIturCode)]
		public async Task<int> RefillApproveStatusBitByIturCode([FromBody] string iturCode)
		{
			try
			{
				await this._hubSignalRRepository.StartAsync();
				if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true)
					return 0;
				await this._hubSignalRRepository.SendNotifyFromWebAPIAsync($"start RefillApproveStatusBit {iturCode}");
				int satus = await Task.Run(() => this._iturRepository.RefillApproveStatusBitByIturCode(iturCode, $"Inventor\\{_count4uContext.DBPath}"));
				return satus;
			}
			catch (Exception ex)
			{
				await this._hubSignalRRepository.SendNotifyFromWebAPIAsync($"end Clear with Exception >> {ex.Message}");
				return -1;
			}
			finally
			{
				await this._hubSignalRRepository.StopAsync();
			}
		}

		[HttpPost(WebApiCount4UModelItur.RefillApproveStatusBitByIturCodeList)]
		public async Task<int> RefillApproveStatusBitByIturCodeList([FromBody] List<string> iturCodeList)
		{
			try
			{
				await this._hubSignalRRepository.StartAsync();
				await this._hubSignalRRepository.SendNotifyFromWebAPIAsync($"start iturs updated {iturCodeList.Count}");
				if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true)
					return 0;
				int i = 0;
				foreach(string iturCode in iturCodeList) 
				{
					await this._hubSignalRRepository.SendNotifyFromWebAPIAsync($"start RefillApproveStatusBit {iturCode}");
					i ++;
					int bit = await Task.Run(() => this._iturRepository.RefillApproveStatusBitByIturCode(iturCode, $"Inventor\\{_count4uContext.DBPath}"));
					await this._hubSignalRRepository.SendNotifyFromWebAPIAsync($"end RefillApproveStatusBit {iturCode} : {bit} ");
				}
				await this._hubSignalRRepository.SendNotifyFromWebAPIAsync($"end iturs updated {i}");
				return i;
			}
			catch (Exception ex)
			{
				await this._hubSignalRRepository.SendNotifyFromWebAPIAsync($"end Clear with Exception >> {ex.Message}");
				return -1;
			}
			finally
			{
				await this._hubSignalRRepository.StopAsync();
			}
		}

		[HttpGet(WebApiCount4UModelItur.RefillParallelApproveStatusBit)]
		public async Task<int>  RefillParallelApproveStatusBit()
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return -2;//return NotFound();
			int satus = await Task.Run(()=>this._iturRepository.RefillParallelApproveStatusBit($"Inventor\\{_count4uContext.DBPath}"));
			return satus;
		}

		[HttpPost(WebApiCount4UModelItur.RefillParallelApproveStatusBitSelectParams)]
		public async Task<int>  RefillParallelApproveStatusBitSelectParams([FromBody] SelectParams sp)
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return -2;//return NotFound();
			int satus = await Task.Run(()=>this._iturRepository.RefillParallelApproveStatusBitSelectParams(sp, $"Inventor\\{_count4uContext.DBPath}"));
			return satus;
		}

		 [HttpGet(WebApiCount4UModelItur.TestUpdateFileItemsInData)]
        public ActionResult<bool> TestUpdateFileItemsInData()
         {
		//FileItem fileItem  = new FileItem();
		//fileItem.CommandResults =new CommandResult[] {
		//			new CommandResult("1", "TestUpdateFileItemsInData", AdapterCommandStepEnum.AddInQueue),
		//			new CommandResult("2", "TestUpdateFileItemsInData", AdapterCommandStepEnum.Init),
		//			new CommandResult("3", "TestUpdateFileItemsInData", AdapterCommandStepEnum.Import),
		//			new CommandResult("4", "TestUpdateFileItemsInData",  AdapterCommandStepEnum.MoveFileAfter),
		//			new CommandResult("5", "TestUpdateFileItemsInData", AdapterCommandStepEnum.RefreshIturStatus)
		//			};
  //         FileItems fileItems = new FileItems();
  //          fileItems.Add(fileItem) ;
  //          string fileName = fileItem.Name;
  //          CommandResult result1 = new CommandResult("1", "TestUpdateFileItemsInData", AdapterCommandStepEnum.Init);
  //          result1.FileName = fileName;
  //          result1.Successful = SuccessfulEnum.Successful;
  //          result1.ResultCode = CommandResultCodeEnum.Ok;
  //         	fileItems = fileItems.UpdateCommandResultInFileItems(fileItems, result1);

  //          CommandResult result2 = new CommandResult("2", "TestUpdateFileItemsInData", AdapterCommandStepEnum.GetQueue);
  //          result2.Successful =  SuccessfulEnum.Successful;
  //           result2.FileName = fileName;
  //          result2.ResultCode = CommandResultCodeEnum.Ok;
		//	fileItems.UpdateCommandResultInFileItems(result2);

  //          CommandResult result3 = new CommandResult("3", "TestUpdateFileItemsInData", AdapterCommandStepEnum.CopyFileBefore);
  //          result3.Successful =  SuccessfulEnum.NotSuccessful;
  //           result3.FileName = fileName;
  //          result3.ResultCode = CommandResultCodeEnum.Error;
		//	fileItems.UpdateCommandResultInFileItems(result3);

  //          CommandResult result4 = new CommandResult("4", "TestUpdateFileItemsInData", AdapterCommandStepEnum.Clear);
  //          result4.Successful =  SuccessfulEnum.Successful;
  //           result4.FileName = fileName;
  //          result4.ResultCode = CommandResultCodeEnum.Ok;
  //         	fileItems = fileItems.UpdateCommandResultInFileItems(fileItems, result4);

  //          CommandResult result5 = new CommandResult("10", "TestUpdateFileItemsInData", AdapterCommandStepEnum.Clear);
  //          result5.Successful =  SuccessfulEnum.NotSuccessful;
  //           result5.FileName = fileName;
  //          result5.ResultCode = CommandResultCodeEnum.Error;
  //         	fileItems = fileItems.UpdateCommandResultInFileItems(fileItems, result5);

  //           CommandResult result6 = new CommandResult("33", "TestUpdateFileItemsInData", AdapterCommandStepEnum.CopyFileBefore);
  //          result6.Successful =  SuccessfulEnum.Successful;
  //           result6.FileName = fileName;
  //          result6.ResultCode = CommandResultCodeEnum.Error;
		//	fileItems.UpdateCommandResultInFileItems(result6);
      
            return true;
        }

		
				
		[HttpGet(WebApiCount4UModelItur.ClearStatusBit)]
		public async Task<bool>  ClearStatusBit()
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return false;//return NotFound();
			await Task.Run(()=>this._iturRepository.ClearStatusBit($"Inventor\\{_count4uContext.DBPath}"));
		//	if (iturs == null) return NotFound();
			return true;
		}

		//[HttpGet("turn_security_on/{id}")]
		//public async Task<ActionResult> TurnSecurityOn(string id)
		//{
		//}

		//List<string> GetIturCodesForLocationCode(string locationCode, string pathDB);
		[HttpGet(WebApiCount4UModelItur.GetIturCodesForLocationCode)]
		public ActionResult<IEnumerable<string>> GetIturCodesForLocationCode([FromRoute] string locationCode)
		{
			if (string.IsNullOrWhiteSpace(_count4uContext.DBPath) == true) return null;//return NotFound();
			List<string> itruCodes = this._iturRepository.GetIturCodesForLocationCode(locationCode, $"Inventor\\{_count4uContext.DBPath}");
		//	if (itruCodes == null) return new List<string>();
			return itruCodes;
		}

	}
}


//Iturs GetIturs(string pathDB);
//Iturs GetItursAndLocationName(string pathDB);
//Iturs GetItursAndLocationName(SelectParams selectParams, string pathDB);
// Locations GetLocationList(string pathDB);
//StatusIturs GetStatusIturList(string pathDB);
//List<string> GetIturCodeListByTag(string pathDB, string tag);
//List<string> GetIturCodeListIncludedTag(string pathDB, string tag);
//List<string> GetTagList(string pathDB);
//BitArray GetResultStatusBitOrByIturCode(string code, string pathDB, bool refill = false);
//int GetResultStatusIntOrByIturCode(string code, string pathDB, bool refill = false);
//void RefillApproveStatusBit(string pathDB);
//void RefillApproveStatusBit(string iturCode, List<string> docCodes, string pathDB);
//void ClearStatusBit(string pathDB);
//int RefillApproveStatusBitByIturCode(string iturCode, string pathDB);
//void SetDisabledStatusBitByIturCode(Iturs iturs, bool disabled, string pathDB);
//void RefillApproveStatusBit(Iturs iturs, string pathDB);
//void RefillApproveStatusBit(List<string> docCodes, List<string> sessionCodeList, string pathDB);
//bool RefillApproveStatus { get; set; }
//string[] GetIturCodes(string pathDB);
//List<string> GetIturCodesWithInventProduct(string pathDB);
//int[] GetIturNumbers(string pathDB);
//int GetItursTotal(string pathDB);
//Iturs GetItursByUnitPlanCode(string unitPlanCode, string pathDB);
//List<string> GetIturCodesUnitPlanCode(string unitPlanCode, string pathDB);
//List<string> GetIturCodesForLocationCode(string locationCode, string pathDB);
//List<string> GetIturCodesForLocationCodes(string[] locationCodes, string pathDB);
//void RefillIturStatistic(string pathDB);
//Iturs GetIturs(SelectParams selectParams, string pathDB);
//Itur GetIturByCode(string iturCode, string pathDB);
//Itur GetIturByErpIturCode(string erpIturCode, string pathDB, bool nativ = false);
//Iturs GetItursByLocation(Location location, string pathDB);
//Iturs GetItursByLocationCode(string locationCode, string pathDB);
//Itur GetIturByDocumentCode(string documentCode, string pathDB);
//int GetMaxNumber(string prefix, string pathDB);
// Iturs GetItursByStatusCode(string statusCode, string pathDB);
// Iturs GetItursByNumber(string number, string pathDB);
//IEnumerable<Itur> GetItursByNumber(int number, string pathDB);
//Iturs GetItursByDate(DateTime createDate, string pathDB);
// void Delete(Itur itur, string pathDB);
//void Delete(string iturCode, string pathDB);
//void DeleteOnlyEmpty(Iturs iturs, string pathDB);
//void DeleteHierarchical(Itur itur, string pathDB);
//void ClearIturHierarchical(Itur itur, string pathDB);
//void DeleteAllByLocationCode(string locationCode, string pathDB);
//void Insert(Itur itur, DocumentHeader documentHeader, string pathDB);
//void Insert(Itur itur, string pathDB);
//void Insert(Iturs iturs, string pathDB);
//void Insert(Itur itur, Location location, string pathDB);
//void Insert(Itur itur, string locationCode, string pathDB);
//void Update(Itur itur, string pathDB);
//void Update(Iturs iturs, string pathDB);
//void UpdateIturCode(Iturs iturs, string pathDB);
//void UpdatePrefix(string prefixNew, string pathDB);
//void UpdateIturCode(string pathDB);
//Dictionary<string, Itur> GetIturDictionary(string pathDB, bool refill = false);
//Dictionary<string, Itur> GetERPIturDictionary(string pathDB);
//void ClearIturDictionary();
//void AddIturInDictionary(string code, Itur itur);
//void RemoveIturFromDictionary(string code);
//bool IsExistIturInDictionary(string code);
//Itur GetIturByCodeFromDictionary(string code);
//void FillIturDictionary(string pathDB);
//Dictionary<int, int> GetIturTotalGroupByStatuses(string pathDB);
//List<string> GetIturCodeList(string pathDB);
//List<string> GetIturCodeListWithAnyDocument(string pathDB);
//List<string> GetLocationCodeList(string pathDB);
//void RepairCodeFromDB(string pathDB);
//double GetIturTotalDone(SelectParams selectParams, string pathDB);
//double GetIturTotalDone(Iturs iturs, string pathDB);