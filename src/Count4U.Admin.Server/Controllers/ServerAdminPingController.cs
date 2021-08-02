using Monitor.Service.Urls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Count4U.Service.Core.Server.Controllers
{
	[ApiController]
	public class ServerAdminPingController : ControllerBase
	{
		[Produces("application/json")]
		[HttpGet(ServerAdminPing.GetPing)]
		public string Ping()
		{
			return PingOpetarion.Pong;
		}

		[Authorize]
		[Produces("application/json")]
		[HttpGet(ServerAdminPing.GetPingSecure)]
		public string PingSecured()
		{
			// "All good. You only get this message if you are authenticated.";
			return PingOpetarion.Pong;
		}

		//[Authorize]
		//[HttpGet("claims")]
		//public object Claims()
		//{
		//	return User.Claims.Select(c =>
		//	new
		//	{
		//		Type = c.Type,
		//		Value = c.Value
		//	});
		//}
	}
}
