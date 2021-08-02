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
using Count4U.Model;
using Count4U.Model.Common;
using System.IO;
using Count4U.Model.ExportImport.ImportPdaNativPlusSqliteAdapter;
using CommonServiceLocator;
using Count4U.Common.Constants;
using Count4U.Service.Contract;
using Count4U.Service.Model;
using Monitor.Service.Model;
using System.Security.Claims;

namespace Count4U.Service.WebAPI.Model.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Consumes("application/json")]
	public class ImportFromPdaAdapterController : ControllerBase
	{
		private readonly ILogger<ImportFromPdaAdapterController> _logger;
		private readonly ICount4uContext _count4uContext;
		private readonly IJwtService _jwtService;

		private readonly IServiceLocator _serviceLocator;
		public ImportFromPdaAdapterController(
			  ILoggerFactory loggerFactory
			, ICount4uContext count4uContext
			, IServiceLocator serviceLocator
			, IJwtService jwtService
		)
		{
			this._logger = loggerFactory.CreateLogger<ImportFromPdaAdapterController>();
			this._count4uContext = count4uContext ??
						throw new ArgumentNullException(nameof(count4uContext));
			this._serviceLocator = serviceLocator ??
					   throw new ArgumentNullException(nameof(serviceLocator));
			this._jwtService = jwtService ??
					   throw new ArgumentNullException(nameof(jwtService));
		}


		[HttpPost(WebApiCount4UImportFromPdaAdapter.AddToQueueClearRun)]
		public async Task<CommandResult[]> AddToQueueClearRun([FromBody]CommandResult command)  //command.AdapterName
		{
			try
			{
				string adapterName = command.AdapterName;
				ClaimsPrincipal authenticatedUser = _jwtService.GetClaimsPrincipalFromToken(this.HttpContext.Request);
				if (authenticatedUser != null)	command.User = authenticatedUser.Identity.Name;
				IImportAdapterHandler importAdapterHandler = this._serviceLocator.GetInstance<IImportAdapterHandler>(adapterName);
				return await importAdapterHandler.AddToQueueClearRun(command, this._count4uContext);
			}
			catch (Exception ex)
			{
				return new CommandResult[] { new CommandResult(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.Error, CommandErrorCodeEnum.CommandResultWithException) { Message = $"ERROR AddToQueueImportRun : {ex.Message}" } };
			}
		}

		[HttpPost(WebApiCount4UImportFromPdaAdapter.AddToQueueImportRun)]
		public async Task<CommandResult[]> AddToQueueImportRun([FromBody]CommandResult command) //command.AdapterName
		{
			try
			{
				string adapterName = command.AdapterName;
				ClaimsPrincipal authenticatedUser = _jwtService.GetClaimsPrincipalFromToken(this.HttpContext.Request);
				if (authenticatedUser != null)	command.User = authenticatedUser.Identity.Name;
				IImportAdapterHandler importAdapterHandler = this._serviceLocator.GetInstance<IImportAdapterHandler>(adapterName);
				return await importAdapterHandler.AddToQueueImportRun(command, this._count4uContext);
			}
			catch (Exception ex)
			{
				return new CommandResult[] { new CommandResult(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.Error, CommandErrorCodeEnum.CommandResultWithException) { Message = $"ERROR AddToQueueImportRun : {ex.Message}" } };
			}
		}

		[HttpPost(WebApiCount4UImportFromPdaAdapter.GetAdapterTitle)]
		public ActionResult<string> GetAdapterTitle([FromBody]string adapterName)   //command.AdapterName
		{
			try
			{
				IImportAdapterHandler importAdapterHandler = this._serviceLocator.GetInstance<IImportAdapterHandler>(adapterName);
				return importAdapterHandler.GetAdapterTitle();
			}
			catch (Exception ex)
			{
				return "";
			}
		}

	}
}