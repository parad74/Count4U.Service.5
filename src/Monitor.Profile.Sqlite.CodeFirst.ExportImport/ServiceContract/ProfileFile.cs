using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Monitor.Service.Model;

namespace Monitor.Sqlite.CodeFirst
{
	[Table("ProfileFile")] 
	public class ProfileFile
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long ID { get; set; }
		public string Code { get; set; }
		public string ParentCode { get; set; }
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public string InventorCode { get; set; }
		public string InventorName { get; set; }
		public string SubFolder { get; set; }
		public string InventorDBPath { get; set; }
		public string DomainObject { get; set; }
		public string AuditCode { get; set; }
		public string CurrentPath { get; set; }
		public string ProfileXml { get; set; }
		public string ProfileJosn { get; set; }
		public string ProfileFileUID { get; set; }
		public int OperationIndexCode { get; set; }                   //использую для синхронизации UI

		public int ErrorCode { get; set; }
		public int ValidateDataErrorCode { get; set; }
		public string Error { get; set; }
		public string Message { get; set; }
		public int Successful { get; set; }                   //использую для синхронизации UI
		public int ResultCode { get; set; }



		public ProfileFile()
		{
			ProfileFileUID = Guid.NewGuid().ToString();
			Code = "";
			ParentCode = "";
			AuditCode = "";
			CustomerCode = "";
			BranchCode = "";
			InventorCode = "";
			InventorDBPath = "";
			DomainObject = "";
			CurrentPath = "";
			ProfileXml = "";
			ProfileJosn = "";
			ParentCode = "";
			AuditCode = "";
			CustomerCode = "";
			BranchCode = "";
			InventorCode = "";
			CustomerName = "";
			BranchName = "";
			InventorName = "";
			SubFolder = "";
			InventorDBPath = "";
			DomainObject = "";
			CurrentPath = "";
			ProfileXml = "";
			ProfileJosn = "";

			Successful = 0;
			Error = "";
			Message = "";
			ErrorCode = 0;
			ResultCode = 0;
			ValidateDataErrorCode = 0;
			OperationIndexCode = 0;
		}

	
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ProfileFile))
				return false;
			return Equals((ProfileFile)obj);
		}

		public bool Equals(ProfileFile other)
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





					

