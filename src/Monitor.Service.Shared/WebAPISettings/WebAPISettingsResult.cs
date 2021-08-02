namespace Monitor.Service.Model.Settings
{
	public class WebAPISettingsResult
	{
		//public bool Successful { get; set; }
		public SuccessfulEnum Successful { get; set; }
		public string Error { get; set; }
		public WebAPISettings _webAPISettings { get; set; }
	}
}
