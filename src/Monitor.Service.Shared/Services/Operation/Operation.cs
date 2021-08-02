using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Monitor.Service.Model
{
	public static class Operation
	{
		public static OperationAuthorizationRequirement Create =
			new OperationAuthorizationRequirement { Name = "Create" };
		public static OperationAuthorizationRequirement Read =
			new OperationAuthorizationRequirement { Name = "Read" };
		public static OperationAuthorizationRequirement Update =
			new OperationAuthorizationRequirement { Name = "Update" };
		public static OperationAuthorizationRequirement Delete =
			new OperationAuthorizationRequirement { Name = "Delete" };
	}
}
