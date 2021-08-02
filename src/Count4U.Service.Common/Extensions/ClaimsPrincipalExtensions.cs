using System;
using System.Security.Claims;

namespace Count4U.Service.Common.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
		public static string GetUserEmail(this ClaimsPrincipal principal)
		{
			return principal.FindFirst(ClaimTypes.Email).Value;
		}

		public static string GetUserId(this ClaimsPrincipal principal)
		{
			return principal.FindFirst(ClaimTypes.NameIdentifier).Value;
		}

		public static string GetUserName(this ClaimsPrincipal principal)
		{
			return principal.FindFirst(ClaimTypes.Name).Value;
		}

		public static bool IsCurrentUser(this ClaimsPrincipal principal, string id)
		{
			var currentUserId = GetUserId(principal);

			return string.Equals(currentUserId, id, StringComparison.OrdinalIgnoreCase);
		}
	}
}
