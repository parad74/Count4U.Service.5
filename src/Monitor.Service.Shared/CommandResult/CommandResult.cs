using System;
using System.Collections.Generic;
using Count4U.Model;
//using Count4U.Service.Model;
//Monitor.Service.Model

namespace Monitor.Service.Model
{
	public class CommandResult
	{
		public long ID { get; set; }
		public long ParentID { get; set; }
		public string CommandUID { get; set; }                       //промежуточная синхронизация объекта в БД
		public string QueueCode { get; set; }
		public string QueueParentCode { get; set; }

		public string FileName { get; set; }                                                                 //!!! OperationIndexCode + FileName UI ключ синхронизации 
		public OperationIndexEnum OperationIndexCode { get; set; }                   //использую для синхронизации UI

		public string CommandResultCode { get; set; }                      //ключ в БД  		ID
		public string ParentCommandResultCode { get; set; }          //ключ в БД  		 ParentID
		public IsSingleFileOrDirectoryEnum IsSingleFileOrDirectory { get; set; }

		public string ClientAddress { get; set; }			   //Source	 Address
		public string WebApiAddress { get; set; }			 //Count4U WebApiAddress
		public string HubAddress { get; set; }				   //SignalR HubAddress
		public string AuthenticationAddress { get; set; } //Authentication WebApiAddress
		public string MonitorAddress { get; set; }           //DB CommandResult WebApiAddress
		public string User { get; set; }                           //added
		public string Email { get; set; }                          //added
		public TrySendEmailAfterEnum TrySendEmailAfter { get; set; }        //added
		public EmailTemplateEnum EmailTemplate { get; set; }        //added
		public string SendedEmailDateTimeString { get; set; }      //added
		public string AdapterName { get; set; }
		public string ProcessCode { get; set; }
		public string CustomerCode { get; set; }
		public string BranchCode { get; set; }
		public string InventorCode { get; set; }
		public string DBPath { get; set; }                    //Todo add "Inventor\" где-то автоматически, что бы не забывать
		public string SessionCode { get; set; }
		public ImportDomainEnum AdapterType { get; set; }
		public string ServiceName { get; set; }                      //пока просто инфа
		public string ControllerName { get; set; }                  //пока просто инфа
		public AdapterCommandStepEnum Step { get; set; }
		public string AddInQueueTimeString { get; set; }
		public string StartTimeString { get; set; }
		public string ExecutionTimeString { get; set; }
		public string TotalTimeString { get; set; }
		public string CompleteTimeString { get; set; }
		public DateTime SetInQueueDateTime { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime CompleteDateTime { get; set; }
		public CommandErrorCodeEnum ErrorCode { get; set; }
		public CommandErrorCodeEnum ValidateDataErrorCode { get; set; }
		public string Error { get; set; }
		public string Message { get; set; }
		public SuccessfulEnum Successful { get; set; }                   //использую для синхронизации UI
		public CommandResultCodeEnum ResultCode { get; set; }
		public string Path { get; set; }
		public string Path1 { get; set; }
		public string Path2 { get; set; }
		public CompleteProcessEnum IsCompleteProcess { get; set; }
		public string Notify { get; set; }
		public string Notify1 { get; set; }
		public string Notify2 { get; set; }
		public string Notify3 { get; set; }
		public string Tag { get; set; }
		public string Tag1 { get; set; }
		public string Tag2 { get; set; }
		public string Tag3 { get; set; }
		public string ConnectionID { get; set; }                          //Для хаба - не понятно надо или нет
		public int FileItemsInData { get; set; }
		public long TotalItemImported { get; set; }
		public long TotalProductImported { get; set; }
		public long TotalInventProductImported { get; set; }
		public long TotalIturImported { get; set; }
		public long TotalLocationImported { get; set; }
		public long TotalSuppliearImported { get; set; }
		public long TotalSectionImported { get; set; }
		public long TotalDocumentImported { get; set; }
		public long CountDocumentWithoutError { get; set; }
		public long CountDocumentWithError { get; set; }
		public long LastSessionCountItem { get; set; }
		public double SumQuantityEdit { get; set; }
		public double LastSessionSumQuantityEdit { get; set; }
		public List<string> IturCodes { get; set; }
		public List<string> DocumentHeaderCodes { get; set; }
		public List<string> Files { get; set; }
		public List<string> UnsureFiles { get; set; }

		public CommandResult()
		{
			this.ID = 0;
			this.ParentID = 0;
			this.CommandUID = Guid.NewGuid().ToString();
			this.QueueCode = "";
			this.QueueParentCode = "";
			this.CommandResultCode = "";    //Здесь будет ID 
			this.ParentCommandResultCode = "";    //Здесь будет ParentID 
			this.IsSingleFileOrDirectory = IsSingleFileOrDirectoryEnum.Unknown;
			this.FileName = "";
			this.SessionCode = "";
			this.OperationIndexCode = OperationIndexEnum.none;
			this.ClientAddress = "";
			this.WebApiAddress = "";
			this.HubAddress = "";
			this.User = "";
			this.AuthenticationAddress = "";
			this.MonitorAddress = "";
			this.Email = "";
			this.TrySendEmailAfter = TrySendEmailAfterEnum.no;
			this.EmailTemplate = EmailTemplateEnum.none;
			this.SendedEmailDateTimeString = "";
			this.AdapterName = "";
			this.ProcessCode = "";
			this.CustomerCode = "";
			this.BranchCode = "";
			this.InventorCode = "";
			this.DBPath = "";
			this.AdapterType = ImportDomainEnum.ImportInventProduct;
			this.ServiceName = "";                    //пока просто инфа
			this.ControllerName = "";                    //пока просто инфа
			this.Step = AdapterCommandStepEnum.None;
			this.Notify = "";
			this.Notify1 = "";
			this.Notify2 = "";
			this.Notify3 = "";
			this.Successful = SuccessfulEnum.NotStart;
			this.Error = "";
			this.Message = "";
			this.ErrorCode = CommandErrorCodeEnum.none;
			this.ResultCode = CommandResultCodeEnum.Unknown;
			this.AddInQueueTimeString = "";
			this.StartTimeString = "";
			this.CompleteTimeString = "";
			this.IsCompleteProcess = CompleteProcessEnum.Unknown;
			this.ConnectionID = "";
			this.Tag = "";
			this.Tag1 = "";
			this.Tag2 = "";
			this.Tag3 = "";
			this.FileItemsInData = 0;
			this.TotalItemImported = 0;
			this.TotalProductImported = 0;
			this.TotalInventProductImported = 0;
			this.TotalIturImported = 0;
			this.TotalLocationImported = 0;
			this.TotalSuppliearImported = 0;
			this.TotalSectionImported = 0;
			this.TotalDocumentImported = 0;
			this.CountDocumentWithoutError = 0;
			this.CountDocumentWithError = 0;
			this.LastSessionCountItem = 0;
			this.SumQuantityEdit = 0;
			this.LastSessionSumQuantityEdit = 0;
			this.SetInQueueDateTime = DateTime.Now; //todo
			this.StartDateTime = DateTime.Now;
			this.CompleteDateTime = DateTime.Now;
			this.ExecutionTimeString = "";
			this.TotalTimeString = "";
			this.Path = "";
			this.Path1 = "";
			this.Path2 = "";
			this.IturCodes = new List<string>();
			this.DocumentHeaderCodes = new List<string>();
			this.Files = new List<string>();
			this.UnsureFiles = new List<string>();
		}

		public CommandResult(OperationIndexEnum operationIndexCode
			, AdapterCommandStepEnum step
			, string sessionCode
			, CommandResult addToQueueCommandResult
			, ICount4uContext count4uContext
			, string adapterName = "") : this()
		{
			this.OperationIndexCode = operationIndexCode;
			this.Step = step;
			this.SessionCode = sessionCode;
			if (addToQueueCommandResult != null)
			{
				this.FileName = addToQueueCommandResult.FileName;            //UI key - должно вернуться неизменным
				this.Path = addToQueueCommandResult.FileName;                   // это используем IsSingle
				this.Files = addToQueueCommandResult.Files;                      // это используем IsDirectory
				this.IsSingleFileOrDirectory = addToQueueCommandResult.IsSingleFileOrDirectory;
				this.MonitorAddress = addToQueueCommandResult.MonitorAddress;
				this.WebApiAddress = addToQueueCommandResult.WebApiAddress;
				this.HubAddress = addToQueueCommandResult.HubAddress;
				this.User = addToQueueCommandResult.User;
			}
			if (count4uContext != null)
			{
				this.ProcessCode = count4uContext.ProcessCode;
				this.CustomerCode = count4uContext.CustomerCode;
				this.BranchCode = count4uContext.BranchCode;
				this.InventorCode = count4uContext.InventorCode;
				this.DBPath = FolderName.Inventor + @"\" + count4uContext.DBPath;
			}
			this.AdapterName = adapterName;
			this.Successful = SuccessfulEnum.Waiting;

		}

		public CommandResult(OperationIndexEnum operationIndexCode, string sessionCode, AdapterCommandStepEnum step = AdapterCommandStepEnum.None) : this()
		{
			this.OperationIndexCode = operationIndexCode;
			this.SessionCode = sessionCode;
			this.Step = step;
		}


		public CommandResult(string fileName
			, List<string> files
			, IsSingleFileOrDirectoryEnum isSingleFileOrDirectory
			, SuccessfulEnum successful
			, CommandResultCodeEnum validateResultErrorCode
			, CommandErrorCodeEnum validateDataErrorCode
			, string dataServerWebApiAddressUrl
			, string monitorWebApiAddressUrl
			, string hubAddressUrl) : this()
		{

			this.Path = fileName;
			this.FileName = fileName;        // string path in FileName == UIkey
			this.Files = files;
			this.IsSingleFileOrDirectory = isSingleFileOrDirectory;
			this.Successful = successful;
			this.ResultCode = validateResultErrorCode;
			this.ErrorCode = validateDataErrorCode;
			this.WebApiAddress = dataServerWebApiAddressUrl;
			this.MonitorAddress = monitorWebApiAddressUrl;
			this.HubAddress = hubAddressUrl;
		}

		public CommandResult(SuccessfulEnum successful
			, CommandResultCodeEnum validateResultErrorCode
			, CommandErrorCodeEnum validateDataErrorCode)
		{
			this.Successful = successful;
			this.ResultCode = validateResultErrorCode;
			this.ErrorCode = validateDataErrorCode;
		}



		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(CommandResult))
				return false;
			return this.Equals((CommandResult)obj);
		}

		public bool Equals(CommandResult other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return Equals(other.OperationIndexCode, this.OperationIndexCode);
		}

		public override int GetHashCode()
		{
			return (this.OperationIndexCode.ToString() != null ? this.OperationIndexCode.ToString().GetHashCode() : 0);
		}

	}

}







