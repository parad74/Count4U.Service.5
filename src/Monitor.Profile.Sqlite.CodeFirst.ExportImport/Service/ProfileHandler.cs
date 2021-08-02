using System;
using System.Threading.Tasks;
using CommonServiceLocator;
using Microsoft.Extensions.Logging;
using Unity;
using Monitor.Service.Model;
using Count4U.Model.Extensions;
using System.Threading;
using Monitor.Model.ServiceContract.Interface;
using Count4U.Model.Common;

namespace Monitor.Profile.Sqlite.CodeFirst.ExportImport
{

	public interface IProfileHandler
	{
		Task<ProfileFile[]> AddToQueueUpdateFtpAndDbRun(ProfileFile addToQueueProfileFile);
		Task<ProfileFile> SaveOrUpdatOnFtp(ProfileFile profileFile, CancellationToken cancellationToken);
		Task<ProfileFile> GetByInventorCodeFromFtp(ProfileFile profileFile, CancellationToken cancellationToken);
		Task<ProfileFile> UpdateOrInsertInventorFromFtpToDb(ProfileFile profileFile, CancellationToken cancellationToken);


	}
	public class ProfileHandler : IProfileHandler
	{
		protected readonly IServiceLocator _serviceLocator;
		private readonly ILogger<ProfileHandler> _logger;
		public Action<long> UpdateProgress = (x) => Console.WriteLine(x);
		protected readonly IProfileFileRepository _profileFileRepository;
		protected readonly ISettingsFtpRepository _settingsFtpRepository;
		


		//private readonly IHubChatSignalRRepository _hubSignalRRepository;
		//private readonly IHubCommandSignalRRepository _hubCommandSignalRRepository;
		protected readonly IUnityContainer _container;

		public ProfileHandler(
			ILoggerFactory loggerFactory
			//, IHubChatSignalRRepository hubSignalRRepository
			//, IHubCommandSignalRRepository hubCommandSignalRRepository
			 , ISettingsFtpRepository settingsFtpRepository
			, IProfileFileRepository profileFileRepository
			, IServiceLocator serviceLocator
			, IUnityContainer container)
		{
			this._logger = loggerFactory.CreateLogger<ProfileHandler>();
			//this._hubSignalRRepository = hubSignalRRepository ??
			//	   throw new ArgumentNullException(nameof(hubSignalRRepository));
			//this._hubCommandSignalRRepository = hubCommandSignalRRepository ??
			//			   throw new ArgumentNullException(nameof(hubCommandSignalRRepository));
			this._profileFileRepository = profileFileRepository ??
							  throw new ArgumentNullException(nameof(profileFileRepository));
			this._settingsFtpRepository = settingsFtpRepository ??
							  throw new ArgumentNullException(nameof(settingsFtpRepository));
			this._serviceLocator = serviceLocator ??
						  throw new ArgumentNullException(nameof(serviceLocator));

			this._container = container ??
						  throw new ArgumentNullException(nameof(container));
		}
	

		public async Task<ProfileFile[]> AddToQueueUpdateFtpAndDbRun(ProfileFile addToQueueProfileFile)
		{
			#region validate
			if (addToQueueProfileFile == null)
			{
				return new ProfileFile[] { new ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.ProfileFileIsNull) 
				{ 
					Error = $"ERROR AddToQueueUpdateFtpAndDbRun : addToQueueProfileFile is null" } 
				};
			}
			#endregion

			string sessionCode = Guid.NewGuid().ToString();
			ProfileFile[] profileFiles = new ProfileFile[]
			{
					//new Monitor.Service.Model.ProfileFile(OperationIndexEnum.i_11, ProfiFileStepEnum.AddInQueue, sessionCode, addToQueueProfileFile),
					new Monitor.Service.Model.ProfileFile(OperationIndexEnum.c_01,  ProfiFileStepEnum.SaveOrUpdatOnFtp,  sessionCode, addToQueueProfileFile),
					new Monitor.Service.Model.ProfileFile(OperationIndexEnum.c_02, ProfiFileStepEnum.UpdateOrInsertInventorFromFtpToDb, sessionCode, addToQueueProfileFile),
					new Monitor.Service.Model.ProfileFile(OperationIndexEnum.c_03, ProfiFileStepEnum.GetByInventorCodeFromFtp, sessionCode, addToQueueProfileFile)
			};

			//Save in Queue and DB 
			try
			{
				DataflowProfileQueue profileQueue1 = _container.Resolve<DataflowProfileQueue>();

			}
			catch (Exception ex)
			{
				;
			}

			DataflowProfileQueue profileQueue = _container.Resolve<DataflowProfileQueue>();
			ProfileFile[] addedProfileFiles = profileQueue.Enqueue(profileFiles);

			#region validate
			if (addedProfileFiles == null || addedProfileFiles.Length < 1)
			{
				foreach (var commandResult in addedProfileFiles)
				{
					commandResult.Successful = SuccessfulEnum.NotStart;
				}
				return addedProfileFiles;
			}

			#endregion

			var result = await Task<ProfileFile[]>.Factory.StartNew(() =>
			{
				return addedProfileFiles;
			});
			return result;
		}


		//    this._profileXmlFile = await this._profileFileService.SaveOrUpdateProfileFileOnFtp(this._profileXmlFile, @"http://localhost:12389");
		//Console.WriteLine("Client.InventorProfileFileEditBase.SaveObjectAsync() SaveOrUpdateProfileFileOnFtp ok ");
		//              this._profileXmlFile = await this._profileFileService.UpdateOrInsertProfileFileInventorFromFtpToDb(this._profileXmlFile, @"http://localhost:12389");
		//Console.WriteLine("Client.InventorProfileFileEditBase.SaveObjectAsync() UpdateOrInsertProfileFileInventorFromFtpToDb ok ");
		//              this._profileXmlFile = await this._profileFileService.GetProfileFileByInventorCode(inventorCode, @"http://localhost:12389");
		//Console.WriteLine("Client.InventorProfileFileEditBase.SaveObjectAsync() GetProfileFileByInventorCode ok ");


		//======================== SaveOrUpdatOnFtp ==================================================
		[StepProfile(Name = ProfiFileStepEnum.SaveOrUpdatOnFtp)]
		public async Task<ProfileFile> SaveOrUpdatOnFtp(ProfileFile profileFile, CancellationToken cancellationToken)
		{
			var result = await Task<ProfileFile>.Factory.StartNew(() =>
			{
				return this.SaveOrUpdatOnFtpPrivate(profileFile, cancellationToken);
			});
			return result;
		}

		private ProfileFile SaveOrUpdatOnFtpPrivate(ProfileFile profileFile, CancellationToken cancellationToken)
		{
			try
			{
				#region validate
				if (profileFile == null)
				{
					return new ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.ProfileFileIsNull) { Error = $"ERROR SaveOrUpdatOnFtpPrivate : ProfileFile is null" };
				}
				#endregion
	  			this._settingsFtpRepository.InitProperty(profileFile);
				ProfileFile retProfileFile = this._settingsFtpRepository.ProfileFileSendToFtp(profileFile, false);
				if (retProfileFile.Successful == SuccessfulEnum.NotSuccessful) return retProfileFile;

				profileFile.Successful = SuccessfulEnum.Successful;
				profileFile.ResultCode = CommandResultCodeEnum.Ok;
				return profileFile;
			}
			catch (Exception ecx)
			{
				profileFile.Successful = SuccessfulEnum.NotSuccessful;
				profileFile.ResultCode = CommandResultCodeEnum.Error;
				profileFile.ErrorCode = CommandErrorCodeEnum.CommandResultWithException;
				profileFile.Message += " ERROR SaveOrUpdatOnFtpPrivate >> " + ecx.Message;
				return profileFile;
			}

		}

		//======================== GetByInventorCodeFromFtp ==================================================
		[StepProfile(Name = ProfiFileStepEnum.GetByInventorCodeFromFtp)]
		public async Task<ProfileFile> GetByInventorCodeFromFtp(ProfileFile profileFile, CancellationToken cancellationToken)
		{
			var result = await Task<ProfileFile>.Factory.StartNew(() =>
			{
				return this.GetByInventorCodeFromFtpPrivate(profileFile, cancellationToken);
			});
			return result;
		}

		private ProfileFile GetByInventorCodeFromFtpPrivate(ProfileFile profileFile, CancellationToken cancellationToken)
		{
			try
			{
				#region validate
				if (profileFile == null)
				{
					return new ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.ProfileFileIsNull) { Error = $"ERROR UpdateOrInsertInventorFromFtpToDbPrivate : ProfileFile is null" };
				}
				#endregion

				this._settingsFtpRepository.InitProperty(profileFile);
				ProfileFile retProfileFile = this._profileFileRepository.InsertInventoriesByCBI(profileFile);
				if (retProfileFile.Successful == SuccessfulEnum.NotSuccessful) return retProfileFile;

				profileFile.Successful = SuccessfulEnum.Successful;
				profileFile.ResultCode = CommandResultCodeEnum.Ok;
				return profileFile;
			}
			catch (Exception ecx)
			{
				profileFile.Successful = SuccessfulEnum.NotSuccessful;
				profileFile.ResultCode = CommandResultCodeEnum.Error;
				profileFile.ErrorCode = CommandErrorCodeEnum.CommandResultWithException;
				profileFile.Message += " ERROR UpdateOrInsertInventorFromFtpToDbPrivate >> " + ecx.Message;
				return profileFile;
			}

		}


		//======================== UpdateOrInsertInventorFromFtpToDb ==================================================
		[StepProfile(Name = ProfiFileStepEnum.UpdateOrInsertInventorFromFtpToDb)]
		public async Task<ProfileFile> UpdateOrInsertInventorFromFtpToDb(ProfileFile profileFile, CancellationToken cancellationToken)
		{
			var result = await Task<ProfileFile>.Factory.StartNew(() =>
			{
				return this.UpdateOrInsertInventorFromFtpToDbPrivate(profileFile, cancellationToken);
			});
			return result;
		}

		private ProfileFile UpdateOrInsertInventorFromFtpToDbPrivate(ProfileFile profileFile, CancellationToken cancellationToken)
		{
			try
			{
				#region validate
				if (profileFile == null)
				{
					return new ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.ProfileFileIsNull) { Error = $"ERROR UpdateOrInsertInventorFromFtpToDbPrivate : ProfileFile is null" };
				}
				#endregion

				this._settingsFtpRepository.InitProperty(profileFile);
				ProfileFile retProfileFile = this._profileFileRepository.GetProfileFileInventor(profileFile);
				if (retProfileFile.Successful == SuccessfulEnum.NotSuccessful) return retProfileFile;

				profileFile.Successful = SuccessfulEnum.Successful;
				profileFile.ResultCode = CommandResultCodeEnum.Ok;
				return profileFile;
			}
			catch (Exception ecx)
			{
				profileFile.Successful = SuccessfulEnum.NotSuccessful;
				profileFile.ResultCode = CommandResultCodeEnum.Error;
				profileFile.ErrorCode = CommandErrorCodeEnum.CommandResultWithException;
				profileFile.Message += " ERROR UpdateOrInsertInventorFromFtpToDbPrivate >> " + ecx.Message;
				return profileFile;
			}

		}

		//public async Task<ProfileFile[]> AddToQueueImportRun(ProfileFile addToQueueCommandResult, ICount4uContext count4uContext)
		//{
		//	#region validate
		//	if (addToQueueCommandResult == null)
		//	{
		//		return new ProfileFile[] { new ProfileFile(SuccessfulEnum.NotSuccessful, CommandResultCodeEnum.ValidateError, CommandErrorCodeEnum.CommandResultIsNull) { Error = $"ERROR AddToQueueImportRun : CommandResult is null" } };
		//	}
		//	#endregion

		//	string sessionCode = Guid.NewGuid().ToString();
		//	string adapterName = "";
		//	ProfileFile[] profileFiles = new ProfileFile[]
		//	{
		//			new Monitor.Service.Model.ProfileFile(OperationIndexEnum.i_11, AdapterCommandStepEnum.AddInQueue, sessionCode, addToQueueCommandResult, count4uContext, adapterName),
		//			new Monitor.Service.Model.ProfileFile(OperationIndexEnum.i_12, AdapterCommandStepEnum.Import, sessionCode, addToQueueCommandResult, count4uContext, adapterName),
		//			new Monitor.Service.Model.ProfileFile(OperationIndexEnum.i_13, AdapterCommandStepEnum.RefreshIturStatus, sessionCode, addToQueueCommandResult, count4uContext, adapterName),
		//			new Monitor.Service.Model.ProfileFile(OperationIndexEnum.i_14, AdapterCommandStepEnum.MoveFileAfter, sessionCode, addToQueueCommandResult, count4uContext, adapterName)
		//	};

		//	//Save in Queue and DB 
		//	try
		//	{
		//		DataflowProfileQueue commandQueue1 = _container.Resolve<DataflowProfileQueue>();

		//	}
		//	catch (Exception ex)
		//	{
		//		;
		//	}

		//	DataflowProfileQueue profileQueue = _container.Resolve<DataflowProfileQueue>();
		//	ProfileFile[] addedProfileFiles = profileQueue.Enqueue(profileFiles);
		//	#region validate
		//	if (addedProfileFiles == null || addedProfileFiles.Length < 1)
		//	{
		//		foreach (var profileFile in profileFiles)
		//		{
		//			profileFile.Successful = SuccessfulEnum.NotStart;
		//		}
		//		return profileFiles;
		//	}
		//	#endregion

		//	var result = await Task<ProfileFile[]>.Factory.StartNew(() =>
		//	{
		//		return addedProfileFiles;
		//	});
		//	return result;
		//}


		//[Step(Name = AdapterCommandStepEnum.Clear)]
		//public async Task<CommandResult> Clear(CommandResult commandResult, CancellationToken cancellationToken)
		//{
		//	var result = await Task<CommandResult>.Factory.StartNew(() =>
		//	{
		//		return ClearPrivate(commandResult, cancellationToken);
		//	});
		//	return result;
		//}

		//[Step(Name = AdapterCommandStepEnum.ClearStatusBit)]
		//public async Task<CommandResult> ClearStatusBit(CommandResult commandResult, CancellationToken cancellationToken)
		//{
		//	var result = await Task<CommandResult>.Factory.StartNew(() =>
		//	{
		//		return ClearStatusBitPrivate(commandResult, cancellationToken);
		//	});
		//	return result;
		//}


		//[Step(Name = AdapterCommandStepEnum.RefreshIturStatus)]
		//public async Task<CommandResult> RefreshIturStatus(CommandResult commandResult, CancellationToken cancellationToken)
		//{
		//	var result = await Task<CommandResult>.Factory.StartNew(() =>
		//		{
		//			//return this.RefreshItursStatusPrivate(commandResult, cancellationToken);
		//		});
		//	return result;
		//}




	}

}
