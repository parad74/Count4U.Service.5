using Microsoft.AspNetCore.Authorization;
using Monitor.Service.Model;

namespace Count4U.Service.Shared
{
	public static class UserPolicy
	{
		public const string IsUser = "IsUser";
		public const string IsOwner = "IsOwner";
		public const string IsAdmin = "IsAdmin";
		public const string IsManager = "IsManager";
		public const string IsMonitor = "IsMonitor";
		public const string IsContext = "IsContext";
		public const string IsWorker = "IsWorker";
		public const string IsProfile = "IsProfile";
		public const string CanUseInventor = "CanUseInventor";
		public const string HaveInventorCode = "HaveInventorCode";
		
		//IAuthorizationFilter   
		//https://www.c-sharpcorner.com/article/how-to-override-customauthorization-class-in-net-core/   
		public static AuthorizationPolicy HaveInventorCodePolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireClaim(ClaimEnum.InventorCode.ToString())
												   .RequireClaim(ClaimEnum.DBPath.ToString())
												   .Build();
		}

		public static AuthorizationPolicy IsUserPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("User")
												   .Build();
		}

		public static AuthorizationPolicy IsOwnerPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Owner")
												   .Build();
		}

		public static AuthorizationPolicy IsAdminPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Admin")
												   .Build();
		}


		public static AuthorizationPolicy IsManagerPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Manager")
												   .Build();
		}
		public static AuthorizationPolicy IsMonitorPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Monitor")
												   .Build();
		}


		public static AuthorizationPolicy IsContextPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Context")
												   .Build();
		}

		public static AuthorizationPolicy IsWorkerPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Worker")
												   .Build();
		}

		public static AuthorizationPolicy IsProfilePolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Profile")
												   .Build();
		}

	
	}
}
