using System.ComponentModel.DataAnnotations;
using Monitor.Service.Model.Settings;

namespace Monitor.Service.Shared.Settings
{
	public interface IEmailSettings
	{
		string From { get; set; }
		string SmtpServer { get; set; }
		string Port { get; set; }
		string UserName { get; set; }
		string Password { get; set; }
	}
	public class EmailSettings : IValidatable, IEmailSettings
	{
		[Required]
		public string From { get; set; }

		[Required]
		public string SmtpServer { get; set; }

		[Required]
		public string Port { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }

		public EmailSettings()
		{
			this.From = "parad74@yandex.ru";
			this.SmtpServer = "smtp.yandex.ru";
			this.Port = "465";
			this.UserName = "parad74";
			this.Password = "bosdimex73";
		}


		//    oMail.From = "parad74@yandex.ru";

		// // Set recipient email address
		// oMail.To = "parad74@mail.ru";

		// // Set email subject
		// oMail.Subject = "my Test application ";

		// // Set email body
		// oMail.TextBody = "this is a test email sent from c# project.";
		// // Hotmail SMTP server address
		//// SmtpServer oServer = new SmtpServer("smtp.gmail.com");
		//SmtpServer oServer = new SmtpServer("smtp.yandex.ru");

		// int pos = oMail.From.ToString().IndexOf("@");
		// string user = oMail.From.ToString().Substring(1, pos-1);

		// // Hotmail user authentication should use your
		// // email address as the user name.
		// oServer.User = "parad74";

		//// oServer.Password = "marina73parker74";//args[1];
		// oServer.Password = "bosdimex73";

		// // Set 587 port, if you want to use 25 port, please change 587 to 25
		// oServer.Port = 465;

		// // detect SSL/TLS connection automatically
		// oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

		public void Validate()
		{
			Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
		}
	}
}
