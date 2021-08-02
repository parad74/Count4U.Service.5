using System;
using System.Collections.Generic;
using Monitor.Service.Model;
using Count4U.Model;

namespace Monitor.Sqlite.CodeFirst.MappingEF
{
	public static class CommandResultMapper
	{
		public static Monitor.Service.Model.CommandResult ToDomainObject(this Monitor.Sqlite.CodeFirst.CommandResult entity)
		{
			if (entity == null)
				return null;
			return new Monitor.Service.Model.CommandResult()
			{
				ID = entity.ID,
				ParentID = Convert.ToInt64(entity.ParentID),
				CommandUID = entity.CommandUID != null ? entity.CommandUID : "",
				QueueCode = entity.QueueCode != null ? entity.QueueCode : "",
				QueueParentCode = entity.QueueParentCode != null ? entity.QueueParentCode : "",
				CommandResultCode = entity.CommandResultCode != null ? entity.CommandResultCode : "",           //Здесь будет ID 
				ParentCommandResultCode = entity.ParentCommandResultCode != null ? entity.ParentCommandResultCode : "",  //Здесь будет ParentID 
				IsSingleFileOrDirectory = (IsSingleFileOrDirectoryEnum)IsSingleFileOrDirectoryEnum.Unknown.GetEnumFromInt(entity.IsSingleFileOrDirectory),
				FileName = entity.FileName != null ? entity.FileName : "",
				SessionCode = entity.SessionCode != null ? entity.SessionCode : "",
				OperationIndexCode = (OperationIndexEnum)OperationIndexEnum.none.GetEnumFromInt(entity.OperationIndexCode),
				ClientAddress = entity.ClientAddress != null ? entity.ClientAddress : "",
				WebApiAddress = entity.WebApiAddress != null ? entity.WebApiAddress : "",
				HubAddress = entity.HubAddress != null ? entity.HubAddress : "",
				User = entity.User != null ? entity.User : "",
				AuthenticationAddress = entity.AuthenticationAddress != null ? entity.AuthenticationAddress : "",
				MonitorAddress = entity.MonitorAddress != null ? entity.MonitorAddress : "",
				Email = entity.Email != null ? entity.Email : "",
				TrySendEmailAfter = (TrySendEmailAfterEnum)TrySendEmailAfterEnum.no.GetEnumFromInt(entity.TrySendEmailAfter),
				EmailTemplate = (EmailTemplateEnum)EmailTemplateEnum.none.GetEnumFromInt(entity.EmailTemplate),
				SendedEmailDateTimeString = entity.SendedEmailDateTimeString != null ? entity.SendedEmailDateTimeString : "",
				AdapterName = entity.AdapterName != null ? entity.AdapterName : "",
				ProcessCode = entity.ProcessCode != null ? entity.ProcessCode : "",
				CustomerCode = entity.CustomerCode != null ? entity.CustomerCode : "",
				BranchCode = entity.BranchCode != null ? entity.BranchCode : "",
				InventorCode = entity.InventorCode != null ? entity.InventorCode : "",
				DBPath = entity.DBPath != null ? entity.DBPath : "",
				AdapterType = (ImportDomainEnum)ImportDomainEnum.ImportInventProduct.GetEnumFromString(entity.AdapterType),
				ServiceName = entity.ServiceName != null ? entity.ServiceName : "",               //пока просто инфа
				ControllerName = entity.ControllerName != null ? entity.ControllerName : "",    //пока просто инфа
				Step = (AdapterCommandStepEnum)AdapterCommandStepEnum.None.GetEnumFromInt(entity.Step),
				Notify = entity.Notify != null ? entity.Notify : "",
				Notify1 = entity.Notify1 != null ? entity.Notify1 : "",
				Notify2 = entity.Notify2 != null ? entity.Notify2 : "",
				Notify3 = entity.Notify3 != null ? entity.Notify3 : "",
				Successful = (SuccessfulEnum)SuccessfulEnum.NotStart.GetEnumFromInt(entity.Successful),
				Error = entity.Error != null ? entity.Error : "",
				Message = entity.Message != null ? entity.Message : "",
				ErrorCode = (CommandErrorCodeEnum)CommandErrorCodeEnum.none.GetEnumFromInt(entity.ErrorCode),
				ResultCode = (CommandResultCodeEnum)CommandResultCodeEnum.Unknown.GetEnumFromInt(entity.ResultCode),
				AddInQueueTimeString = entity.AddInQueueTimeString != null ? entity.AddInQueueTimeString : "",
				StartTimeString = entity.StartTimeString != null ? entity.StartTimeString : "",
				CompleteTimeString = entity.CompleteTimeString != null ? entity.CompleteTimeString : "",
				IsCompleteProcess = (CompleteProcessEnum)CompleteProcessEnum.Unknown.GetEnumFromInt(entity.IsCompleteProcess),
				ConnectionID = entity.ConnectionID != null ? entity.ConnectionID : "",
				Tag = entity.Tag != null ? entity.Tag : "",
				Tag1 = entity.Tag1 != null ? entity.Tag1 : "",
				Tag2 = entity.Tag2 != null ? entity.Tag2 : "",
				Tag3 = entity.Tag3 != null ? entity.Tag3 : "",
				FileItemsInData = Convert.ToInt32(entity.FileItemsInData),
				TotalItemImported = entity.TotalItemImported != null ? Convert.ToInt64(entity.TotalItemImported) : 0,
				TotalProductImported = entity.TotalProductImported != null ? Convert.ToInt64(entity.TotalProductImported) : 0,
				TotalInventProductImported = entity.TotalInventProductImported != null ? Convert.ToInt64(entity.TotalInventProductImported) : 0,
				TotalIturImported = entity.TotalIturImported != null ? Convert.ToInt64(entity.TotalIturImported) : 0,
				TotalLocationImported = entity.TotalLocationImported != null ? Convert.ToInt64(entity.TotalLocationImported) : 0,
				TotalSuppliearImported = entity.TotalSuppliearImported != null ? Convert.ToInt64(entity.TotalSuppliearImported) : 0,
				TotalSectionImported = entity.TotalSectionImported != null ? Convert.ToInt32(entity.TotalSectionImported) : 0,
				TotalDocumentImported = entity.TotalDocumentImported != null ? Convert.ToInt64(entity.TotalDocumentImported) : 0,
				CountDocumentWithoutError = entity.CountDocumentWithoutError != null ? Convert.ToInt64(entity.CountDocumentWithoutError) : 0,
				CountDocumentWithError = entity.CountDocumentWithError != null ? Convert.ToInt64(entity.CountDocumentWithError) : 0,
				LastSessionCountItem = entity.LastSessionCountItem != null ? Convert.ToInt64(entity.LastSessionCountItem) : 0,
				SumQuantityEdit = Convert.ToDouble(entity.SumQuantityEdit),
				LastSessionSumQuantityEdit = Convert.ToDouble(entity.LastSessionSumQuantityEdit),
				SetInQueueDateTime = entity.SetInQueueDateTime != null ? entity.SetInQueueDateTime : DateTime.Now,
				StartDateTime = entity.StartDateTime != null ? entity.StartDateTime : DateTime.Now,
				CompleteDateTime = entity.CompleteDateTime != null ? entity.CompleteDateTime : DateTime.Now,
				ExecutionTimeString = entity.ExecutionTimeString != null ? entity.ExecutionTimeString : "",
				TotalTimeString = entity.TotalTimeString != null ? entity.TotalTimeString : "",
				Path = entity.Path != null ? entity.Path : "",
				Path1 = entity.Path1 != null ? entity.Path1 : "",
				Path2 = entity.Path2 != null ? entity.Path2 : "",
				IturCodes = new List<string>(),
				DocumentHeaderCodes = new List<string>(),
				Files = new List<string>(),
				UnsureFiles = new List<string>()
			};
		}

		public static Monitor.Service.Model.CommandResult ToSimpleDomainObject(this Monitor.Sqlite.CodeFirst.CommandResult entity)
		{
			throw new NotImplementedException();
		}

		public static Monitor.Sqlite.CodeFirst.CommandResult ToEntity(this Monitor.Service.Model.CommandResult domainObject)
		{
			if (domainObject == null)
				return null;
			return new Monitor.Sqlite.CodeFirst.CommandResult()
			{
				ID = domainObject.ID,
				ParentID = Convert.ToInt64(domainObject.ParentID),
				CommandUID = domainObject.CommandUID != null ? domainObject.CommandUID : "",
				QueueCode = domainObject.QueueCode != null ? domainObject.QueueCode : "",
				QueueParentCode = domainObject.QueueParentCode != null ? domainObject.QueueParentCode : "",
				CommandResultCode = domainObject.CommandResultCode != null ? domainObject.CommandResultCode : "",           //Здесь будет ID 
				ParentCommandResultCode = domainObject.ParentCommandResultCode != null ? domainObject.ParentCommandResultCode : "",  //Здесь будет ParentID 
				IsSingleFileOrDirectory = (int)domainObject.IsSingleFileOrDirectory,
				FileName = domainObject.FileName != null ? domainObject.FileName.CutLength(250) : "",
				SessionCode = domainObject.SessionCode != null ? domainObject.SessionCode : "",
				OperationIndexCode = (int)domainObject.OperationIndexCode,
				ClientAddress = domainObject.ClientAddress != null ? domainObject.ClientAddress : "",
				WebApiAddress = domainObject.WebApiAddress != null ? domainObject.WebApiAddress : "",
				HubAddress = domainObject.HubAddress != null ? domainObject.HubAddress : "",
				User = domainObject.User != null ? domainObject.User : "",
				AuthenticationAddress = domainObject.AuthenticationAddress != null ? domainObject.AuthenticationAddress : "",
				MonitorAddress = domainObject.MonitorAddress != null ? domainObject.MonitorAddress : "",
				Email = domainObject.Email != null ? domainObject.Email.CutLength(250) : "",
				TrySendEmailAfter = (int)domainObject.TrySendEmailAfter,
				EmailTemplate = (int)domainObject.EmailTemplate,
				SendedEmailDateTimeString = domainObject.SendedEmailDateTimeString != null ? domainObject.SendedEmailDateTimeString : "",
				AdapterName = domainObject.AdapterName != null ? domainObject.AdapterName : "",
				ProcessCode = domainObject.ProcessCode != null ? domainObject.ProcessCode : "",
				CustomerCode = domainObject.CustomerCode != null ? domainObject.CustomerCode : "",
				BranchCode = domainObject.BranchCode != null ? domainObject.BranchCode : "",
				InventorCode = domainObject.InventorCode != null ? domainObject.InventorCode : "",
				DBPath = domainObject.DBPath != null ? domainObject.DBPath.CutLength(250) : "",
				AdapterType = domainObject.AdapterType.ToString(),
				ServiceName = domainObject.ServiceName != null ? domainObject.ServiceName : "",               //пока просто инфа
				ControllerName = domainObject.ControllerName != null ? domainObject.ControllerName : "",    //пока просто инфа
				Step = (int)domainObject.Step,
				Notify = domainObject.Notify != null ? domainObject.Notify.CutLength(250) : "",
				Notify1 = domainObject.Notify1 != null ? domainObject.Notify1.CutLength(250) : "",
				Notify2 = domainObject.Notify2 != null ? domainObject.Notify2.CutLength(250) : "",
				Notify3 = domainObject.Notify3 != null ? domainObject.Notify3.CutLength(250) : "",
				Successful = (int)domainObject.Successful,
				Error = domainObject.Error != null ? domainObject.Error.CutLength(500) : "",
				Message = domainObject.Message != null ? domainObject.Message.CutLength(500) : "",
				ErrorCode = (int)domainObject.ErrorCode,
				ResultCode = (int)domainObject.ResultCode,
				AddInQueueTimeString = domainObject.AddInQueueTimeString != null ? domainObject.AddInQueueTimeString : "",
				StartTimeString = domainObject.StartTimeString != null ? domainObject.StartTimeString : "",
				CompleteTimeString = domainObject.CompleteTimeString != null ? domainObject.CompleteTimeString : "",
				IsCompleteProcess = (int)domainObject.IsCompleteProcess,
				ConnectionID = domainObject.ConnectionID != null ? domainObject.ConnectionID : "",
				Tag = domainObject.Tag != null ? domainObject.Tag.CutLength(50) : "",
				Tag1 = domainObject.Tag1 != null ? domainObject.Tag1.CutLength(50) : "",
				Tag2 = domainObject.Tag2 != null ? domainObject.Tag2.CutLength(50) : "",
				Tag3 = domainObject.Tag3 != null ? domainObject.Tag3.CutLength(50) : "",
				FileItemsInData = Convert.ToInt32(domainObject.FileItemsInData),
				TotalItemImported = domainObject.TotalItemImported,
				TotalProductImported = domainObject.TotalProductImported,
				TotalInventProductImported = domainObject.TotalInventProductImported,
				TotalIturImported = domainObject.TotalIturImported,
				TotalLocationImported = domainObject.TotalLocationImported,
				TotalSuppliearImported = domainObject.TotalSuppliearImported,
				TotalSectionImported = domainObject.TotalSectionImported,
				TotalDocumentImported = domainObject.TotalDocumentImported,
				CountDocumentWithoutError = domainObject.CountDocumentWithoutError,
				CountDocumentWithError = domainObject.CountDocumentWithError,
				LastSessionCountItem = domainObject.LastSessionCountItem,
				SumQuantityEdit = Convert.ToDouble(domainObject.SumQuantityEdit),
				LastSessionSumQuantityEdit = Convert.ToDouble(domainObject.LastSessionSumQuantityEdit),
				SetInQueueDateTime = domainObject.SetInQueueDateTime != null ? domainObject.SetInQueueDateTime : DateTime.Now,
				StartDateTime = domainObject.StartDateTime != null ? domainObject.StartDateTime : DateTime.Now,
				CompleteDateTime = domainObject.CompleteDateTime != null ? domainObject.CompleteDateTime : DateTime.Now,
				ExecutionTimeString = domainObject.ExecutionTimeString != null ? domainObject.ExecutionTimeString : "",
				TotalTimeString = domainObject.TotalTimeString != null ? domainObject.TotalTimeString : "",
				Path = domainObject.Path != null ? domainObject.Path.CutLength(500) : "",
				Path1 = domainObject.Path1 != null ? domainObject.Path1.CutLength(500) : "",
				Path2 = domainObject.Path2 != null ? domainObject.Path2.CutLength(500) : "",

			};
		}


		public static void ApplyChanges(this Monitor.Sqlite.CodeFirst.CommandResult entity, Monitor.Service.Model.CommandResult domainObject)
		{
			if (domainObject == null)
				return;
			entity.ID = domainObject.ID;
			entity.ParentID = Convert.ToInt64(domainObject.ParentID);
			entity.CommandUID = domainObject.CommandUID != null ? domainObject.CommandUID : "";
			entity.QueueCode = domainObject.QueueCode != null ? domainObject.QueueCode : "";
			entity.QueueParentCode = domainObject.QueueParentCode != null ? domainObject.QueueParentCode : "";
			entity.CommandResultCode = domainObject.CommandResultCode != null ? domainObject.CommandResultCode : "";           //Здесь будет ID 
			entity.ParentCommandResultCode = domainObject.ParentCommandResultCode != null ? domainObject.ParentCommandResultCode : "";  //Здесь будет ParentID 
			entity.IsSingleFileOrDirectory = (int)domainObject.IsSingleFileOrDirectory;
			entity.FileName = domainObject.FileName != null ? domainObject.FileName.CutLength(250) : "";
			entity.SessionCode = domainObject.SessionCode != null ? domainObject.SessionCode : "";
			entity.OperationIndexCode = (int)domainObject.OperationIndexCode;
			entity.ClientAddress = domainObject.ClientAddress != null ? domainObject.ClientAddress : "";
			entity.WebApiAddress = domainObject.WebApiAddress != null ? domainObject.WebApiAddress : "";
			entity.HubAddress = domainObject.HubAddress != null ? domainObject.HubAddress : "";
			entity.User = domainObject.User != null ? domainObject.User : "";
			
			entity.AuthenticationAddress = domainObject.AuthenticationAddress != null ? domainObject.AuthenticationAddress : "";
			entity.MonitorAddress = domainObject.MonitorAddress != null ? domainObject.MonitorAddress : "";
			entity.Email = domainObject.Email != null ? domainObject.Email.CutLength(250) : "";
			entity.TrySendEmailAfter = (int)domainObject.TrySendEmailAfter;
			entity.EmailTemplate = (int)domainObject.EmailTemplate;
			entity.SendedEmailDateTimeString = domainObject.SendedEmailDateTimeString != null ? domainObject.SendedEmailDateTimeString : "";

			entity.AdapterName = domainObject.AdapterName != null ? domainObject.AdapterName : "";
			entity.ProcessCode = domainObject.ProcessCode != null ? domainObject.ProcessCode : "";
			entity.CustomerCode = domainObject.CustomerCode != null ? domainObject.CustomerCode : "";
			entity.BranchCode = domainObject.BranchCode != null ? domainObject.BranchCode : "";
			entity.InventorCode = domainObject.InventorCode != null ? domainObject.InventorCode : "";
			entity.DBPath = domainObject.DBPath != null ? domainObject.DBPath.CutLength(250) : "";
			entity.AdapterType = domainObject.AdapterType.ToString();
			entity.ServiceName = domainObject.ServiceName != null ? domainObject.ServiceName : "";               //пока просто инфа
			entity.ControllerName = domainObject.ControllerName != null ? domainObject.ControllerName : "";    //пока просто инфа
			entity.Step = (int)domainObject.Step;
			entity.Notify = domainObject.Notify != null ? domainObject.Notify.CutLength(250) : "";
			entity.Notify1 = domainObject.Notify1 != null ? domainObject.Notify1.CutLength(250) : "";
			entity.Notify2 = domainObject.Notify2 != null ? domainObject.Notify2.CutLength(250) : "";
			entity.Notify3 = domainObject.Notify3 != null ? domainObject.Notify3.CutLength(250) : "";
			entity.Successful = (int)domainObject.Successful;
			entity.Error = domainObject.Error != null ? domainObject.Error.CutLength(500) : "";
			entity.Message = domainObject.Message != null ? domainObject.Message.CutLength(500) : "";
			entity.ErrorCode = (int)domainObject.ErrorCode;
			entity.ResultCode = (int)domainObject.ResultCode;
			entity.AddInQueueTimeString = domainObject.AddInQueueTimeString != null ? domainObject.AddInQueueTimeString : "";
			entity.StartTimeString = domainObject.StartTimeString != null ? domainObject.StartTimeString : "";
			entity.CompleteTimeString = domainObject.CompleteTimeString != null ? domainObject.CompleteTimeString : "";
			entity.IsCompleteProcess = (int)domainObject.IsCompleteProcess;
			entity.ConnectionID = domainObject.ConnectionID != null ? domainObject.ConnectionID : "";
			entity.Tag = domainObject.Tag != null ? domainObject.Tag.CutLength(50) : "";
			entity.Tag1 = domainObject.Tag1 != null ? domainObject.Tag1.CutLength(50) : "";
			entity.Tag2 = domainObject.Tag2 != null ? domainObject.Tag2.CutLength(50) : "";
			entity.Tag3 = domainObject.Tag3 != null ? domainObject.Tag3.CutLength(50) : "";
			entity.FileItemsInData = Convert.ToInt32(domainObject.FileItemsInData);
			entity.TotalItemImported = domainObject.TotalItemImported;
			entity.TotalProductImported = domainObject.TotalProductImported;
			entity.TotalInventProductImported = domainObject.TotalInventProductImported;
			entity.TotalIturImported = domainObject.TotalIturImported;
			entity.TotalLocationImported = domainObject.TotalLocationImported;
			entity.TotalSuppliearImported = domainObject.TotalSuppliearImported;
			entity.TotalSectionImported = domainObject.TotalSectionImported;
			entity.TotalDocumentImported = domainObject.TotalDocumentImported;
			entity.CountDocumentWithoutError = domainObject.CountDocumentWithoutError;
			entity.CountDocumentWithError = domainObject.CountDocumentWithError;
			entity.LastSessionCountItem = domainObject.LastSessionCountItem;
			entity.SumQuantityEdit = Convert.ToDouble(domainObject.SumQuantityEdit);
			entity.LastSessionSumQuantityEdit = Convert.ToDouble(domainObject.LastSessionSumQuantityEdit);
			entity.SetInQueueDateTime = domainObject.SetInQueueDateTime != null ? domainObject.SetInQueueDateTime : DateTime.Now;
			entity.StartDateTime = domainObject.StartDateTime != null ? domainObject.StartDateTime : DateTime.Now;
			entity.CompleteDateTime = domainObject.CompleteDateTime != null ? domainObject.CompleteDateTime : DateTime.Now;
			entity.ExecutionTimeString = domainObject.ExecutionTimeString != null ? domainObject.ExecutionTimeString : "";
			entity.TotalTimeString = domainObject.TotalTimeString != null ? domainObject.TotalTimeString : "";
			entity.Path = domainObject.Path != null ? domainObject.Path.CutLength(500) : "";
			entity.Path1 = domainObject.Path1 != null ? domainObject.Path1.CutLength(500) : "";
			entity.Path2 = domainObject.Path2 != null ? domainObject.Path2.CutLength(500) : "";
		}
	}


	//public static class StringLenth
	//{
	//	public static string CutLength(this string stringValue, int MaxLength)
	//	{
	//		stringValue = stringValue.Trim();
	//		if (string.IsNullOrWhiteSpace(stringValue) == true)
	//			return "";
	//		if (stringValue.Length <= MaxLength)
	//			return stringValue;
	//		else
	//			return stringValue.Substring(0, MaxLength);
	//	}
	//}
}