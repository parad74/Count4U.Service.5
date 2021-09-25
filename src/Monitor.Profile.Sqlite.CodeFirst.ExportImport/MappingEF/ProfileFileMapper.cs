using Monitor.Service.Model;

namespace Monitor.Sqlite.CodeFirst.MappingEF
{
	public static class ProfileFileMapper
	{
		public static Monitor.Service.Model.ProfileFile ToDomainObject(this Monitor.Sqlite.CodeFirst.ProfileFile entity)
		{
			if (entity == null)
				return null;
			string email = "";
			string name = "";
			if (entity.DomainObject == "Customer")
			{
				email = entity.Code + @"@customer.com";
				name = entity.CustomerName;
			}
			else if (entity.DomainObject == "Branch")
			{
				name = entity.BranchName;
			}
			else if (entity.DomainObject == "Inventor")
			{
				name = entity.InventorName;
			}

			return new Monitor.Service.Model.ProfileFile()
			{
				ID = entity.ID,
				ProfileFileUID = entity.ProfileFileUID != null ? entity.ProfileFileUID : "",
				Code = entity.Code != null ? entity.Code : "",
				Name = name,
				ParentCode = entity.ParentCode != null ? entity.ParentCode : "",
				CustomerCode = entity.CustomerCode != null ? entity.CustomerCode : "",
				BranchCode = entity.BranchCode != null ? entity.BranchCode : "",
				InventorCode = entity.InventorCode != null ? entity.InventorCode : "",
				CustomerName = entity.CustomerName != null ? entity.CustomerName : "",
				CustomerDescription = entity.CustomerDescription != null ? entity.CustomerDescription : "",
				BranchName = entity.BranchName != null ? entity.BranchName : "",
				InventorName = entity.InventorName != null ? entity.InventorName : "",
				SubFolder =  entity.SubFolder != null ? entity.SubFolder : "",
				InventorDBPath = entity.InventorDBPath != null ? entity.InventorDBPath : "",
				DomainObject = entity.DomainObject != null ? entity.DomainObject : "",               
				AuditCode = entity.AuditCode != null ? entity.AuditCode : "",    //пока просто инфа
				Email = email,
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
			string email = "";
			string name = "";
			if (entity.DomainObject == "Customer")
			{
				email = entity.Code + @"@customer.com";
				name = entity.CustomerName;
			}
			else if (entity.DomainObject == "Branch")
			{
				name = entity.BranchName;
			}
			else if (entity.DomainObject == "Inventor")
			{
				name = entity.InventorName;
			}
			return new Monitor.Service.Model.ProfileFile()
			{
				ID = entity.ID,
				ProfileFileUID = entity.ProfileFileUID != null ? entity.ProfileFileUID : "",
				Code = entity.Code != null ? entity.Code : "",
				Name = name,
				ParentCode = entity.ParentCode != null ? entity.ParentCode : "",
				CustomerCode = entity.CustomerCode != null ? entity.CustomerCode : "",
				BranchCode = entity.BranchCode != null ? entity.BranchCode : "",
				InventorCode = entity.InventorCode != null ? entity.InventorCode : "",
				CustomerName = entity.CustomerName != null ? entity.CustomerName : "",
				CustomerDescription = entity.CustomerDescription != null ? entity.CustomerDescription : "",
				BranchName = entity.BranchName != null ? entity.BranchName : "",
				InventorName = entity.InventorName != null ? entity.InventorName : "",
				SubFolder = entity.SubFolder != null ? entity.SubFolder : "",
				InventorDBPath = entity.InventorDBPath != null ? entity.InventorDBPath : "",
				DomainObject = entity.DomainObject != null ? entity.DomainObject : "",             
				AuditCode = entity.AuditCode != null ? entity.AuditCode : "",    //пока просто инфа
				Email = email,
				Successful = (SuccessfulEnum)SuccessfulEnum.Successful.GetEnumFromInt(entity.Successful),
				Error = entity.Error != null ? entity.Error : "",
				Message = entity.Message != null ? entity.Message : "",
				ValidateDataErrorCode = (CommandErrorCodeEnum)CommandErrorCodeEnum.none.GetEnumFromInt(entity.ValidateDataErrorCode),
				ErrorCode = (CommandErrorCodeEnum)CommandErrorCodeEnum.none.GetEnumFromInt(entity.ErrorCode),
				ResultCode = (CommandResultCodeEnum)CommandResultCodeEnum.Unknown.GetEnumFromInt(entity.ResultCode),
				CurrentPath = entity.CurrentPath != null ? entity.CurrentPath : "",
			};
		}


		public static Monitor.Service.Model.ProfileFileLite ToProfileFileLiteDomainObject(this Monitor.Sqlite.CodeFirst.ProfileFile entity)
		{
			if (entity == null)
				return null;
			string email = "";
			string name = "";
			if (entity.DomainObject == "Customer")
			{
				email = entity.Code + @"@customer.com";
				name = entity.CustomerName;
			}
			else if (entity.DomainObject == "Branch")
			{
				name = entity.BranchName;
			}
			else if (entity.DomainObject == "Inventor")
			{
				name = entity.InventorName;
			}
			return new Monitor.Service.Model.ProfileFileLite()
			{
				Code = entity.Code != null ? entity.Code : "",
				Name = name,
				DomainObject = entity.DomainObject != null ? entity.DomainObject : "",
				Email = email,
				Successful = (SuccessfulEnum)SuccessfulEnum.Successful.GetEnumFromInt(entity.Successful),
				Error = entity.Error != null ? entity.Error : "",
			};
		}

		public static Monitor.Sqlite.CodeFirst.ProfileFile ToEntity(this Monitor.Service.Model.ProfileFile domainObject)
		{
			if (domainObject == null)
				return null;
			string email = "";
			string name = "";
			if (domainObject.DomainObject == "Customer")
			{
				email = domainObject.Code + @"@customer.com";
				name = domainObject.CustomerName;
			}
			else if (domainObject.DomainObject == "Branch")
			{
				name = domainObject.BranchName;
			}
			else if (domainObject.DomainObject == "Inventor")
			{
				name = domainObject.InventorName;
			}
			return new Monitor.Sqlite.CodeFirst.ProfileFile()
			{
				ID = domainObject.ID,
				ProfileFileUID = domainObject.ProfileFileUID != null ? domainObject.ProfileFileUID : "",
				Code = domainObject.Code != null ? domainObject.Code : "",
				Name = name,
				ParentCode = domainObject.ParentCode != null ? domainObject.ParentCode : "",
				CustomerCode = domainObject.CustomerCode != null ? domainObject.CustomerCode : "",
				BranchCode = domainObject.BranchCode != null ? domainObject.BranchCode : "",
				InventorCode = domainObject.InventorCode != null ? domainObject.InventorCode : "",
				CustomerName = domainObject.CustomerName != null ? domainObject.CustomerName : "",
				CustomerDescription = domainObject.CustomerDescription != null ? domainObject.CustomerDescription : "",
				BranchName = domainObject.BranchName != null ? domainObject.BranchName : "",
				InventorName = domainObject.InventorName != null ? domainObject.InventorName : "",
				SubFolder = domainObject.SubFolder != null ? domainObject.SubFolder : "",
				InventorDBPath = domainObject.InventorDBPath != null ? domainObject.InventorDBPath : "",
				DomainObject = domainObject.DomainObject != null ? domainObject.DomainObject : "",               
				AuditCode = domainObject.AuditCode != null ? domainObject.AuditCode : "",    //пока просто инфа
				Email = email,    
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
			string email = "";
			string name = "";
			if (entity.DomainObject == "Customer")
			{
				email = entity.Code + @"@customer.com";
				name = entity.CustomerName;
			}
			else if (entity.DomainObject == "Branch")
			{
				name = entity.BranchName;
			}
			else if (entity.DomainObject == "Inventor")
			{
				name = entity.InventorName;
			}
			entity.ID = domainObject.ID;
			entity.ProfileFileUID = domainObject.ProfileFileUID != null ? domainObject.ProfileFileUID : "";
			entity.Code = domainObject.Code != null ? domainObject.Code : "";
			entity.Name = name;
			entity.ParentCode = domainObject.ParentCode != null ? domainObject.ParentCode : "";
			entity.CustomerCode = domainObject.CustomerCode != null ? domainObject.CustomerCode : "";
			entity.BranchCode = domainObject.BranchCode != null ? domainObject.BranchCode : "";
			entity.InventorCode = domainObject.InventorCode != null ? domainObject.InventorCode : "";
			entity.CustomerName = domainObject.CustomerName != null ? domainObject.CustomerName : "";
			entity.CustomerDescription = domainObject.CustomerDescription != null ? domainObject.CustomerDescription : "";
			entity.BranchName = domainObject.BranchName != null ? domainObject.BranchName : "";
			entity.InventorName = domainObject.InventorName != null ? domainObject.InventorName : "";
			entity.SubFolder = domainObject.SubFolder != null ? domainObject.SubFolder : "";
			entity.InventorDBPath = domainObject.InventorDBPath != null ? domainObject.InventorDBPath : "";
			entity.DomainObject = domainObject.DomainObject != null ? domainObject.DomainObject : "";            
			entity.AuditCode = domainObject.AuditCode != null ? domainObject.AuditCode : "";  //пока просто инфа
			entity.Email = email;
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