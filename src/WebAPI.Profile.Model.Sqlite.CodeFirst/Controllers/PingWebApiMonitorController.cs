using Monitor.Service.Urls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Profile.Sqlite.CodeFirst.Controllers
{
	[ApiController]
	[Produces("application/json")]
	//Route("api/[controller]")]
	public class PingWebApiProfileController : Controller
	{
		[HttpGet]
		[Route(WebApiProfilePing.GetPing)]
		public string Ping()
		{
			return PingOpetarion.Pong;
		}

		[Authorize]
		[HttpGet]
		[Route(WebApiProfilePing.GetPingSecure)]
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
