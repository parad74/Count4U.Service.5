using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model.Settings
{
	//Validate() метод выдает исключение, если есть проблема с вашей конфигурацией и привязкой.
	// https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-in-asp-net-core/

	public interface IWebAPISettings
	{
		string count4uWebapiUrls { get; set; }
		string authenticationWebapiUrls { get; set; }
		string authenticationWebapiUrl { get; set; }
		string monitorWebapiUrls { get; set; }
		string monitorWebapiUrl { get; set; }
		string signalRHubUrl { get; set; }
		string signalRHubUrls { get; set; }
		string defaultuser { get; set; }
		string defaultpassword { get; set; }
		string useDefaultUser { get; set; }

	}

	public class WebAPISettings : IValidatable, IWebAPISettings
	{
		[Required]
		public string count4uWebapiUrls { get; set; }

		[Required]
		public string authenticationWebapiUrls { get; set; }
		[Required]
		public string authenticationWebapiUrl { get; set; }

		[Required]
		public string monitorWebapiUrls { get; set; }
		[Required]
		public string monitorWebapiUrl { get; set; }

		[Required]
		public string signalRHubUrl { get; set; }
	
		[Required]
		public string signalRHubUrls { get; set; }

		public string defaultuser { get; set; }
		public string defaultpassword { get; set; }

		[Required]
		public string useDefaultUser { get; set; }
	
		public WebAPISettings()
		{
			this.count4uWebapiUrls = @"http://localhost:12347";
			this.authenticationWebapiUrls = @"http://localhost:52025";
			this.authenticationWebapiUrl = @"http://localhost:52025";
			this.monitorWebapiUrls = @"http://localhost:12389";		//Совместим CommandResult and ProfileFile
			this.monitorWebapiUrl = @"http://localhost:12389";
			this.signalRHubUrl = @"http://localhost:21029";
			this.signalRHubUrls = @"http://localhost:21029";        //http://0.0.0.0:27027;http://0.0.0.0:15015
			this.defaultuser = @"manager@profile.ftp";
			this.defaultpassword = @"123456";
			this.useDefaultUser = "no";
		}
		public void Validate()
		{
			Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
		}

	}
}

