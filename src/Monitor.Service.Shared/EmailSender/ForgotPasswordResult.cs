namespace Monitor.Service.Model
{
	public class ForgotPasswordResult : AuthenticationCommandResult
	{
		public string Email { get; set; }
	}
}
