using System.Security.Claims;

namespace Monitor.Service.Model
{
	public class UserModel
	{
		public string Email { get; set; }
		public bool IsAuthenticated { get; set; }
	}
}

  public static class UserExtensions
    {
	//public static string FirstName(this ClaimsPrincipal user)
	//    => user.FindFirst("firstname").Value;

	//public static string LastName(this ClaimsPrincipal user)
	//    => user.FindFirst("lastname").Value;

	//public static string Email(this ClaimsPrincipal user)
	//    => user.Identity.Name;

	public static string NameTest(this ClaimsPrincipal user)
	=> user.FindFirst("Email").Value;	//?? протестить и добавить что надо
}
