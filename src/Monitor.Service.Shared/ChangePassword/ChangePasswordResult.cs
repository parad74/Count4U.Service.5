using System;

namespace Monitor.Service.Model
{
	public class ChangePasswordResult
	{
		public long ID { get; set; }
		public string Error { get; set; }
		public string Message { get; set; }
		public string Token { get; set; }
		public string ExecutionTimeString { get; set; }
		public DateTime ExecutionDateTime { get; set; }
		public CommandErrorCodeEnum ErrorCode { get; set; }
		public CommandErrorCodeEnum ValidateDataErrorCode { get; set; }
		public SuccessfulEnum Successful { get; set; }                   //использую для синхронизации UI
		public CommandResultCodeEnum ResultCode { get; set; }
	}
}
