using Monitor.Service.Model;

namespace Monitor.Sqlite.CodeFirst.MappingEF
{
	public static class ProfileFileMapper
	{
		public static Monitor.Service.Model.ProfileFile ToDomainObject(this Monitor.Sqlite.CodeFirst.ProfileFile entity)
		{
			if (entity == null)
				return null;
			return new Monitor.Service.Model.ProfileFile()
			{
				ID = entity.ID,
				ProfileFileUID = entity.ProfileFileUID != null ? entity.ProfileFileUID : "",
				Code = entity.Code != null ? entity.Code : "",
				ParentCode = entity.ParentCode != null ? entity.ParentCode : "",
				CustomerCode = entity.CustomerCode != null ? entity.CustomerCode : "",
				BranchCode = entity.BranchCode != null ? entity.BranchCode : "",
				InventorCode = entity.InventorCode != null ? entity.InventorCode : "",
				CustomerName = entity.CustomerName != null ? entity.CustomerName : "",
				BranchName = entity.BranchName != null ? entity.BranchName : "",
				InventorName = entity.InventorName != null ? entity.InventorName : "",
				SubFolder =  entity.SubFolder != null ? entity.SubFolder : "",
				InventorDBPath = entity.InventorDBPath != null ? entity.InventorDBPath : "",
				DomainObject = entity.DomainObject != null ? entity.DomainObject : "",               //пока просто инфа
				AuditCode = entity.AuditCode != null ? entity.AuditCode : "",    //пока просто инфа
				Successful = (SuccessfulEnum)SuccessfulEnum.NotStart.GetEnumFromInt(entity.Successful),
				Error = entity.Error != null ? entity.Error : "",
				Message = entity.Message != null ? entity.Message : "",
				ValidateDataErrorCode = (CommandErrorCodeEnum)CommandErrorCodeEnum.none.GetEnumFromInt(entity.ValidateDataErrorCode),
				ErrorCode = (CommandErrorCodeEnum)CommandErrorCodeEnum.none.GetEnumFromInt(entity.ErrorCode),
				ResultCode = (CommandResultCodeEnum)CommandResultCodeEnum.Unknown.GetEnumFromInt(entity.ResultCode),
				CurrentPath = entity.CurrentPath != null ? entity.CurrentPath : "",
				ProfileXml = entity.ProfileXml != null ? entity.ProfileXml : "",
				ProfileJosn = entity.ProfileJosn != null ? entity.ProfileJosn : "",
				OperationIndexCode = (OperationIndexEnum)OperationIndexEnum.none.GetEnumFromInt(entity.OperationIndexCode),
			};
		}

		public static Monitor.Service.Model.ProfileFile ToSimpleDomainObject(this Monitor.Sqlite.CodeFirst.ProfileFile entity)
		{
			if (entity == null)
				return null;
			return new Monitor.Service.Model.ProfileFile()
			{
				ID = entity.ID,
				ProfileFileUID = entity.ProfileFileUID != null ? entity.ProfileFileUID : "",
				Code = entity.Code != null ? entity.Code : "",
				ParentCode = entity.ParentCode != null ? entity.ParentCode : "",
				CustomerCode = entity.CustomerCode != null ? entity.CustomerCode : "",
				BranchCode = entity.BranchCode != null ? entity.BranchCode : "",
				InventorCode = entity.InventorCode != null ? entity.InventorCode : "",
				CustomerName = entity.CustomerName != null ? entity.CustomerName : "",
				BranchName = entity.BranchName != null ? entity.BranchName : "",
				InventorName = entity.InventorName != null ? entity.InventorName : "",
				SubFolder = entity.SubFolder != null ? entity.SubFolder : "",
				InventorDBPath = entity.InventorDBPath != null ? entity.InventorDBPath : "",
				DomainObject = entity.DomainObject != null ? entity.DomainObject : "",               //пока просто инфа
				AuditCode = entity.AuditCode != null ? entity.AuditCode : "",    //пока просто инфа
				Successful = (SuccessfulEnum)SuccessfulEnum.NotStart.GetEnumFromInt(entity.Successful),
				Error = entity.Error != null ? entity.Error : "",
				Message = entity.Message != null ? entity.Message : "",
				ValidateDataErrorCode = (CommandErrorCodeEnum)CommandErrorCodeEnum.none.GetEnumFromInt(entity.ValidateDataErrorCode),
				ErrorCode = (CommandErrorCodeEnum)CommandErrorCodeEnum.none.GetEnumFromInt(entity.ErrorCode),
				ResultCode = (CommandResultCodeEnum)CommandResultCodeEnum.Unknown.GetEnumFromInt(entity.ResultCode),
				CurrentPath = entity.CurrentPath != null ? entity.CurrentPath : "",
			};
		}

		public static Monitor.Sqlite.CodeFirst.ProfileFile ToEntity(this Monitor.Service.Model.ProfileFile domainObject)
		{
			if (domainObject == null)
				return null;
			return new Monitor.Sqlite.CodeFirst.ProfileFile()
			{
				ID = domainObject.ID,
				ProfileFileUID = domainObject.ProfileFileUID != null ? domainObject.ProfileFileUID : "",
				Code = domainObject.Code != null ? domainObject.Code : "",
				ParentCode = domainObject.ParentCode != null ? domainObject.ParentCode : "",
				CustomerCode = domainObject.CustomerCode != null ? domainObject.CustomerCode : "",
				BranchCode = domainObject.BranchCode != null ? domainObject.BranchCode : "",
				InventorCode = domainObject.InventorCode != null ? domainObject.InventorCode : "",
				CustomerName = domainObject.CustomerName != null ? domainObject.CustomerName : "",
				BranchName = domainObject.BranchName != null ? domainObject.BranchName : "",
				InventorName = domainObject.InventorName != null ? domainObject.InventorName : "",
				SubFolder = domainObject.SubFolder != null ? domainObject.SubFolder : "",
				InventorDBPath = domainObject.InventorDBPath != null ? domainObject.InventorDBPath : "",
				DomainObject = domainObject.DomainObject != null ? domainObject.DomainObject : "",               //пока просто инфа
				AuditCode = domainObject.AuditCode != null ? domainObject.AuditCode : "",    //пока просто инфа
				Successful = (int)domainObject.Successful,
				Error = domainObject.Error != null ? domainObject.Error.CutLength(500) : "",
				ValidateDataErrorCode = (int)domainObject.ValidateDataErrorCode,
				Message = domainObject.Message != null ? domainObject.Message.CutLength(500) : "",
				ErrorCode = (int)domainObject.ErrorCode,
				ResultCode = (int)domainObject.ResultCode,
				CurrentPath = domainObject.CurrentPath != null ? domainObject.CurrentPath : "",
				ProfileXml = domainObject.ProfileXml != null ? domainObject.ProfileXml : "",
				ProfileJosn = domainObject.ProfileJosn != null ? domainObject.ProfileJosn : "",
				OperationIndexCode = (int)domainObject.OperationIndexCode,
			};
		}


		public static void ApplyChanges(this Monitor.Sqlite.CodeFirst.ProfileFile entity, Monitor.Service.Model.ProfileFile domainObject)
		{
			if (domainObject == null)
				return;
			entity.ID = domainObject.ID;
			entity.ProfileFileUID = domainObject.ProfileFileUID != null ? domainObject.ProfileFileUID : "";
			entity.Code = domainObject.Code != null ? domainObject.Code : "";
			entity.ParentCode = domainObject.ParentCode != null ? domainObject.ParentCode : "";
			entity.CustomerCode = domainObject.CustomerCode != null ? domainObject.CustomerCode : "";
			entity.BranchCode = domainObject.BranchCode != null ? domainObject.BranchCode : "";
			entity.InventorCode = domainObject.InventorCode != null ? domainObject.InventorCode : "";
			entity.CustomerName = domainObject.CustomerName != null ? domainObject.CustomerName : "";
			entity.BranchName = domainObject.BranchName != null ? domainObject.BranchName : "";
			entity.InventorName = domainObject.InventorName != null ? domainObject.InventorName : "";
			entity.SubFolder = domainObject.SubFolder != null ? domainObject.SubFolder : "";
			entity.InventorDBPath = domainObject.InventorDBPath != null ? domainObject.InventorDBPath : "";
			entity.DomainObject = domainObject.DomainObject != null ? domainObject.DomainObject : "";             //пока просто инфа
			entity.AuditCode = domainObject.AuditCode != null ? domainObject.AuditCode : "";  //пока просто инфа
			entity.Successful = (int)domainObject.Successful;
			entity.Error = domainObject.Error != null ? domainObject.Error.CutLength(500) : "";
			entity.ValidateDataErrorCode = (int)domainObject.ValidateDataErrorCode;
			entity.Message = domainObject.Message != null ? domainObject.Message.CutLength(500) : "";
			entity.ErrorCode = (int)domainObject.ErrorCode;
			entity.ResultCode = (int)domainObject.ResultCode;
			entity.CurrentPath = domainObject.CurrentPath != null ? domainObject.CurrentPath : "";
			entity.ProfileXml = domainObject.ProfileXml != null ? domainObject.ProfileXml : "";
			entity.ProfileJosn = domainObject.ProfileJosn != null ? domainObject.ProfileJosn : "";
			entity.OperationIndexCode = (int)domainObject.OperationIndexCode;
		}
	}


	public static class StringLenth
	{
		public static string CutLength(this string stringValue, int MaxLength)
		{
			stringValue = stringValue.Trim();
			if (string.IsNullOrWhiteSpace(stringValue) == true)
				return "";
			if (stringValue.Length <= MaxLength)
				return stringValue;
			else
				return stringValue.Substring(0, MaxLength);
		}
	}
}