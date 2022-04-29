using System;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CommonServiceLocator;
using Unity;
using System.Threading;
using Monitor.Service.Shared;
using Monitor.Service.Model;

namespace Monitor.Profile.Sqlite.CodeFirst.ExportImport
{
	public class DataflowProfileQueue
	{
		private ActionBlock<ProfileFile[]>	  _profileFiles;
		private readonly ILogger<DataflowProfileQueue> _logger;
	//	private readonly ITemporaryInventoryRepository _temporaryInventoryRepository;
	//	private readonly IProfileFileService _profileFileService;
		private readonly IProfileHandler _profileHandler;

		//protected readonly IServiceLocator _serviceLocator;
		//protected readonly IUnityContainer _container;
		//private readonly IHubChatSignalRRepository _hubSignalRRepository;
		private readonly IHubCommandSignalRRepository _hubCommandSignalRRepository;



		public DataflowProfileQueue(ILoggerFactory loggerFactory
			//, ITemporaryInventoryRepository temporaryInventoryRepository
			//, IServiceLocator serviceLocator
			//, IProfileFileService profileFileService
			 , IProfileHandler profileHandler
			//, IHubChatSignalRRepository hubSignalRRepository
			, IHubCommandSignalRRepository hubCommandSignalRRepository
			// IUnityContainer container
			)
		{
			this._logger = loggerFactory.CreateLogger<DataflowProfileQueue>();
			//this._hubSignalRRepository = hubSignalRRepository ??
			//	   throw new ArgumentNullException(nameof(hubSignalRRepository));
			this._hubCommandSignalRRepository = hubCommandSignalRRepository ??
						   throw new ArgumentNullException(nameof(hubCommandSignalRRepository));
			//this._serviceLocator = serviceLocator ??
			//				  throw new ArgumentNullException(nameof(serviceLocator));
			//this._profileFileService = profileFileService ??
			//				  throw new ArgumentNullException(nameof(profileFileService));
			this._profileHandler = profileHandler ??
							  throw new ArgumentNullException(nameof(profileHandler));

			

			//this._container = container ??
			//				  throw new ArgumentNullException(nameof(container));
			this._hubCommandSignalRRepository.StartAsync();
			//this._hubSignalRRepository.StartAsync();

			CancellationTokenSource cts = new CancellationTokenSource();
			CancellationToken cancellationToken = cts.Token;

			_profileFiles = new ActionBlock<ProfileFile[]>((ProfileFileArray) =>
			 {
				// long ID = -1;
			 //if (ProfileFileArray.Length > 0)
			 //{

			 // ID = this._profileFileService.Insert(ProfileFileArray[0], ProfileFileArray[0].WebApiAddress).Result;     //TODO address
			 // ProfileFileArray[0].ID = ID;
			 // ProfileFileArray[0].QueueCode = ID.ToString();
			 // ProfileFileArray[0].CommandResultCode = ID.ToString();
			 // ProfileFileArray[0].Successful = SuccessfulEnum.Successful;
			 // this._profileFileService.Update(ProfileFileArray[0], ProfileFileArray[0].MonitorAddress);
			 // //this._hubCommandSignalRRepository.SendCommandResultFromWebAPIAsync(ProfileFileArray[0]);
			 // //this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($"Q[{ProfileFileArray[0].CommandResultCode}] from [{ProfileFileArray[0].FileName}] and   [{ProfileFileArray[0].Step.GetDisplayDescription()}]");

			 //}


			 for (int i = 0; i < ProfileFileArray.Length; i++)
			 {
				 this._logger.LogWarning(ProfileFileArray[i].Step.GetDisplayDescription());
				 ProfileFileArray[i].Successful = SuccessfulEnum.Waiting;
				 this._hubCommandSignalRRepository.SendProfileFileFromWebAPIAsync(ProfileFileArray[i]);
				 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($"Q[{ProfileFileArray[i].Code}] with result [{ProfileFileArray[i].Successful.ToString()}]");

				 switch (ProfileFileArray[i].Step)
				 {
					 case ProfiFileStepEnum.SaveOrUpdatOnFtp:
						 {
								 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step Start [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");
								 ProfileFileArray[i] = this._profileHandler.SaveOrUpdateOnFtp(ProfileFileArray[i], cancellationToken).Result;
								 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step End [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");

								 break;
						 }
					 case ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb:
						 {
								 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step Start [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");
								
								 ProfileFileArray[i] = this._profileHandler.UpdateOrInsertObjectFromFtpToDb(ProfileFileArray[i], cancellationToken).Result;
								 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step End [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");
								 break;
						 }
					 //case ProfiFileStepEnum.GetByCodeFromFtp:
						// {
						//		 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step Start [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");
						//		 ProfileFileArray[i] = this._profileHandler.GetByInventorCodeFromFtp(ProfileFileArray[i], cancellationToken).Result;
						//		 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step End [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");
						//		 break;
						// }
					//case ProfiFileStepEnum.GetByCodeFromFtp:
					//		 {
					//			 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step Start [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");
					//			 ProfileFileArray[i] = this._profileHandler.GetByCodeFromFtp(ProfileFileArray[i], cancellationToken).Result;
					//			 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($" Step End [{ProfileFileArray[i].Step}] with result [{ProfileFileArray[i].Successful.ToString()}]");
					//			 break;
					//		 }

						 default:
						 {
								ProfileFileArray[i].Successful = SuccessfulEnum.NotSuccessful;
								ProfileFileArray[i].ResultCode = CommandResultCodeEnum.Unknown;
								ProfileFileArray[i].Message += $"step {ProfileFileArray[i].Step.ToString()} has no implementation";
							 break;
						 }
				 }

					 //Записать изменения в БД
					 //this._profileFileService.Update(ProfileFileArray[i], ProfileFileArray[0].MonitorAddress);

					 this._hubCommandSignalRRepository.SendNotifyFromWebAPIAsync($"[{ProfileFileArray[i].Code}] with result [{ProfileFileArray[i].Successful.ToString()}]");
					 this._hubCommandSignalRRepository.SendProfileFileFromWebAPIAsync(ProfileFileArray[i]);



					 //		 // Console.WriteLine($"{ commandArray[i].InventorCode}   {commandArray[i].Step.GetDisplayDescription()}");
				 }
			 });
		}

		
		public ProfileFile[] Enqueue(ProfileFile[] profileFiles)
		{
			_profileFiles.Post<ProfileFile[]>(profileFiles);
			return profileFiles;
		}


       }
}
