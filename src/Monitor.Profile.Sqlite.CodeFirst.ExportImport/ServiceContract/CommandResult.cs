using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Monitor.Sqlite.CodeFirst
{
	[Table("CommandResult")] 
	public class CommandResult
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long ID { get; set; }
		public long ParentID { get; set; }
		public string CommandUID { get; set; }                       //промежуточная синхронизация объекта в БД
		public string QueueCode { get; set; }
		public string QueueParentCode { get; set; }

		public string FileName { get; set; }                                                                 //!!! OperationIndexCode + FileName UI ключ синхронизации 
		public int OperationIndexCode { get; set; }                   //использую для синхронизации UI

		public string CommandResultCode { get; set; }                      //ключ в БД  		ID
		public string ParentCommandResultCode { get; set; }          //ключ в БД  		 ParentID
		public int IsSingleFileOrDirectory { get; set; }

		public string ClientAddress { get; set; }
		public string WebApiAddress { get; set; }
		public string HubAddress { get; set; }
		public string AuthenticationAddress { get; set; } //added
		public string MonitorAddress { get; set; }			 //added
		public string User { get; set; }					       //added
		public string Email { get; set; }					       //added
		public int TrySendEmailAfter { get; set; }		//added
		public int EmailTemplate { get; set; }		//added
		public string SendedEmailDateTimeString { get; set; }	   //added
		public string AdapterName { get; set; }
		public string ProcessCode { get; set; }
		public string CustomerCode { get; set; }
		public string BranchCode { get; set; }
		public string InventorCode { get; set; }
		public string DBPath { get; set; }                    //Todo add "Inventor\" где-то автоматически, что бы не забывать
		public string SessionCode { get; set; }
		public string AdapterType { get; set; }
		public string ServiceName { get; set; }                      //пока просто инфа
		public string ControllerName { get; set; }                  //пока просто инфа
		public int Step { get; set; }
		public string AddInQueueTimeString { get; set; }
		public string StartTimeString { get; set; }
		public string ExecutionTimeString { get; set; }
		public string TotalTimeString { get; set; }
		public string CompleteTimeString { get; set; }
		public DateTime SetInQueueDateTime { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime CompleteDateTime { get; set; }
		public int ErrorCode { get; set; }
		public int ValidateDataErrorCode { get; set; }
		public string Error { get; set; }
		public string Message { get; set; }
		public int Successful { get; set; }                   //использую для синхронизации UI
		public int ResultCode { get; set; }
		public string Path { get; set; }
		public string Path1 { get; set; }
		public string Path2 { get; set; }
		public int IsCompleteProcess { get; set; }
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
		
		public CommandResult()
		{
			ParentID = 0;
			CommandUID = Guid.NewGuid().ToString();
			QueueCode = "";
			QueueParentCode = "";
			CommandResultCode = "";    //Здесь будет ID 
			ParentCommandResultCode = "";    //Здесь будет ParentID 
			IsSingleFileOrDirectory = 0;
			FileName = "";
			SessionCode = "";
			OperationIndexCode = 0;
			ClientAddress = "";
			WebApiAddress = "";
			HubAddress = "";
			User = "";
			AuthenticationAddress = "";
			MonitorAddress = "";
			Email = "";
			TrySendEmailAfter = 0;
			EmailTemplate = 0;
			SendedEmailDateTimeString = "";
			AdapterName = "";
			ProcessCode = "";
			CustomerCode = "";
			BranchCode = "";
			InventorCode = "";
			DBPath = "";
			AdapterType =  "";
			ServiceName = "";                    //пока просто инфа
			ControllerName = "";                    //пока просто инфа
			Step =  0;
			Notify = "";
			Notify1 = "";
			Notify2 = "";
			Notify3 = "";
			Successful =  0;
			Error = "";
			Message = "";
			ErrorCode =  0;
			ResultCode =  0;
			AddInQueueTimeString = "";
			StartTimeString = "";
			CompleteTimeString = "";
			IsCompleteProcess =  0;
			ConnectionID = "";
			Tag = "";
			Tag1 = "";
			Tag2 = "";
			Tag3 = "";
			FileItemsInData = 0;
			TotalItemImported = 0;
			TotalProductImported = 0;
			TotalInventProductImported = 0;
			TotalIturImported = 0;
			TotalLocationImported = 0;
			TotalSuppliearImported = 0;
			TotalSectionImported = 0;
			TotalDocumentImported = 0;
			CountDocumentWithoutError = 0;
			CountDocumentWithError = 0;
			LastSessionCountItem = 0;
			SumQuantityEdit = 0;
			LastSessionSumQuantityEdit = 0;
			SetInQueueDateTime = DateTime.Now; //todo
			StartDateTime = DateTime.Now;
			CompleteDateTime = DateTime.Now;
			ExecutionTimeString = "";
			TotalTimeString = "";
			Path = "";
			Path1 = "";
			Path2 = "";
		}

	
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(CommandResult))
				return false;
			return Equals((CommandResult)obj);
		}

		public bool Equals(CommandResult other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return Equals(other.ID, this.ID);
		}

		public override int GetHashCode()
		{
			return (ID.ToString() != null ? ID.ToString().GetHashCode() : 0);
		}

	}

}





					

