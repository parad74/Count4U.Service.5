using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	//public interface IProfileFile
	//{
	//	long ID { get; set; }
	//	string DomainObject { get; set; }
	//	string Code { get; set; }
	//	string ParentCode { get; set; }
	//	string AuditCode { get; set; }
	//	string CustomerCode { get; set; }
	//	string BranchCode { get; set; }
	//	string InventorCode { get; set; }
	//	string InventorDBPath { get; set; }
	//	string CurrentPath { get; set; }
	//	string ProfileXml { get; set; }
	//	string ProfileJosn { get; set; }
	//	CommandErrorCodeEnum ErrorCode { get; set; }
	//	CommandErrorCodeEnum ValidateDataErrorCode { get; set; }
	//	string Error { get; set; }
	//	string Message { get; set; }
	//	SuccessfulEnum Successful { get; set; }                   //использую для синхронизации UI
	//	CommandResultCodeEnum ResultCode { get; set; }
	//	string ProfileFileUID { get; set; }
	//	Count4U.Service.Format.Json.Profile ProfileJsonObject { get; set; }
	//}


	public class ProfileFile// : IProfileFile
	{
		public long ID { get; set; }
		public string Code { get; set; }
		public string ParentCode { get; set; }
		public string AuditCode { get; set; }
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public string InventorCode { get; set; }
		public string InventorName { get; set; }
		public string SubFolder { get; set; }
		public string InventorDBPath { get; set; }
		public string DomainObject { get; set; }
		public string CurrentPath { get; set; }
		public string ProfileXml { get; set; }
		public string ProfileJosn { get; set; }
		public string ProfileFileUID { get; set; }
		public CommandErrorCodeEnum ErrorCode { get; set; }
		public CommandErrorCodeEnum ValidateDataErrorCode { get; set; }
		public string Error { get; set; }
		public string Message { get; set; }
   		public SuccessfulEnum Successful { get; set; }
		public CommandResultCodeEnum ResultCode { get; set; }
		public Count4U.Service.Format.Json.Profile ProfileJsonObject { get; set; }

		public List<string> Members { get; set; }
		public override string ToString() => string.Join(" | ", this.Members.Select(x => x).ToList());


		public OperationIndexEnum OperationIndexCode { get; set; }                   //использую для синхронизации UI
		public string ClientAddress { get; set; }              //Source	 Address
		public string WebApiAddress { get; set; }            //Count4U WebApiAddress
		public string HubAddress { get; set; }                 //SignalR HubAddress
		public string AuthenticationAddress { get; set; } //Authentication WebApiAddress
		public string MonitorAddress { get; set; }           //DB CommandResult WebApiAddress
		public string User { get; set; }                           //added
		public string Email { get; set; }                          //added
		public string SessionCode { get; set; }
		public ProfiFileStepEnum Step { get; set; }


		public ProfileFile()
		{
			this.Code = "";
			this.ParentCode = "";
			this.AuditCode = "";
			this.CustomerCode = "";
			this.BranchCode = "";
			this.InventorCode = "";
			this.CustomerName = "";
			this.BranchName = "";
			this.InventorName = "";
			this.SubFolder = "";
			this.DomainObject = "";
			this.CurrentPath = "";
			this.ProfileXml = "";
			this.ProfileJosn = "";
			this.InventorDBPath = "";
			this.ProfileFileUID = Guid.NewGuid().ToString();
			this.ProfileJsonObject = null;
			this.ErrorCode = CommandErrorCodeEnum.none;
			this.ValidateDataErrorCode = CommandErrorCodeEnum.none;
			this.Error = "";
			this.Message = "";
			this.Successful = SuccessfulEnum.NotStart;
			this.ResultCode = CommandResultCodeEnum.Unknown;
			this.Members = new List<string>();


			this.ClientAddress = "";
			this.WebApiAddress = "";
			this.HubAddress = "";
			this.AuthenticationAddress = "";
			this.MonitorAddress = "";
			this.User = "";
			this.Email = "";
			this.SessionCode = "";
			this.Step = ProfiFileStepEnum.None; 
		}

		public ProfileFile(SuccessfulEnum successful
		, CommandResultCodeEnum validateResultErrorCode
		, CommandErrorCodeEnum validateDataErrorCode)
		{
			this.Successful = successful;
			this.ResultCode = validateResultErrorCode;
			this.ErrorCode = validateDataErrorCode;
		}


		public ProfileFile(OperationIndexEnum operationIndexCode
		, ProfiFileStepEnum step
		, string sessionCode
		, ProfileFile addToQueueProfileFile) : this()
		{
			if (addToQueueProfileFile != null)
			{

				this.Code = addToQueueProfileFile.Code; 
				this.ParentCode = addToQueueProfileFile.ParentCode;
				this.AuditCode = addToQueueProfileFile.AuditCode;
				this.CustomerCode = addToQueueProfileFile.CustomerCode;
				this.BranchCode = addToQueueProfileFile.BranchCode;
				this.InventorCode = addToQueueProfileFile.InventorCode;
				this.CustomerName = addToQueueProfileFile.CustomerName;
				this.BranchName = addToQueueProfileFile.BranchName;
				this.InventorName = addToQueueProfileFile.InventorName;
				this.SubFolder = addToQueueProfileFile.SubFolder;
				this.DomainObject = addToQueueProfileFile.DomainObject;
				this.CurrentPath = addToQueueProfileFile.CurrentPath;
				this.ProfileXml = addToQueueProfileFile.ProfileXml;
				this.ProfileJosn = addToQueueProfileFile.ProfileJosn;
				this.InventorDBPath = addToQueueProfileFile.InventorDBPath;
				this.ProfileFileUID = addToQueueProfileFile.ProfileFileUID;
				this.ProfileJsonObject = addToQueueProfileFile.ProfileJsonObject;
				this.ErrorCode = addToQueueProfileFile.ErrorCode;
				this.ValidateDataErrorCode = addToQueueProfileFile.ValidateDataErrorCode;
				this.Error = addToQueueProfileFile.Error;
				this.Message = addToQueueProfileFile.Message;
				this.Successful = addToQueueProfileFile.Successful;
				this.ResultCode = addToQueueProfileFile.ResultCode;
				this.Members = addToQueueProfileFile.Members;
				this.ClientAddress = addToQueueProfileFile.ClientAddress;
				this.WebApiAddress = addToQueueProfileFile.WebApiAddress;
				this.HubAddress = addToQueueProfileFile.HubAddress;
				this.AuthenticationAddress = addToQueueProfileFile.AuthenticationAddress;
				this.MonitorAddress = addToQueueProfileFile.MonitorAddress;
				this.User = addToQueueProfileFile.User;
				this.Email = addToQueueProfileFile.Email;
			}
			this.OperationIndexCode = operationIndexCode;
			this.Step = step;
			this.SessionCode = sessionCode;
			//if (count4uContext != null)
			//{
			//	this.CustomerCode = count4uContext.CustomerCode;
			//	this.BranchCode = count4uContext.BranchCode;
			//	this.InventorCode = count4uContext.InventorCode;
			//}
			this.Successful = SuccessfulEnum.Waiting;

		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ProfileFile))
				return false;
			return this.Equals((ProfileFile)obj);
		}

		public bool Equals(ProfileFile other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return Equals(other.ProfileFileUID, this.ProfileFileUID);
		}

		public override int GetHashCode()
		{
			return (this.ProfileFileUID.ToString() != null ? this.ProfileFileUID.ToString().GetHashCode() : 0);
		}

	}
}
