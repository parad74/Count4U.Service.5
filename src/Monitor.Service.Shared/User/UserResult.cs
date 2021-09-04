namespace Monitor.Service.Model
{
	public class UserResult : AuthenticationCommandResult
	{
		public string UserName { get; set; }
		public string UserID { get; set; }
	}
}
