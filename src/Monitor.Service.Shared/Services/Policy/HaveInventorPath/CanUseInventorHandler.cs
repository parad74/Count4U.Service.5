using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Monitor.Service.Model
{
	public class CanUseInventorHandler : AuthorizationHandler<CanUseInventorRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanUseInventorRequirement requirement)
		{
			bool hasDBPath = context.User.HasClaim(c => c.Type == ClaimEnum.DBPath.ToString());
			if (hasDBPath == false)
			{
				context.Fail();
				return Task.CompletedTask;
			}

			bool hasInventorCode = context.User.HasClaim(c => c.Type == ClaimEnum.InventorCode.ToString());
			if (hasInventorCode == false)
			{
				context.Fail();
				return Task.CompletedTask;
			}
			string DBPathValue = context.User.FindFirst(c => c.Type == ClaimEnum.DBPath.ToString())?.Value;
			string InventorCodeValue = context.User.FindFirst(c => c.Type == ClaimEnum.InventorCode.ToString())?.Value;

			if ((string.IsNullOrEmpty(DBPathValue) == false) && (string.IsNullOrEmpty(InventorCodeValue) == false))
			{
				context.Succeed(requirement);
			}
			else
			{
				context.Fail();
			}
			return Task.CompletedTask;
		}
	}
}
