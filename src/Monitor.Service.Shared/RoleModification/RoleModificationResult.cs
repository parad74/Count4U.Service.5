namespace Monitor.Service.Model
{
	public class RoleModificationResult : AuthenticationCommandResult
	{
		public string RoleID { get; set; }
		public string ApplicationUserID { get; set; }
	}
}
