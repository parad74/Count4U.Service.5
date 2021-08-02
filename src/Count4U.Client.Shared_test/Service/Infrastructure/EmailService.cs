using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text.Json;

namespace Count4U.Service.Shared
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("parad74", "parad74@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("parad74", "parad74@mail.ru"));  //emailMessage.To.Add(new MailboxAddress("FromMe", email)); 
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("parad74@yandex.ru", "bosdimex73");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

		//!!! work
		//  <PackageReference Include="EASendMail" Version="7.7.0.2" />
		//static void Main(string[] args)
		//{

		//	SmtpMail oMail = new SmtpMail("TryIt");
		//	SmtpClient oSmtp = new SmtpClient();

		//	// Your email address
		//	oMail.From = "parad74@yandex.ru";

		//	// Set recipient email address
		//	oMail.To = "parad74@mail.ru";

		//	// Set email subject
		//	oMail.Subject = "my Test application ";

		//	// Set email body
		//	oMail.TextBody = "this is a test email sent from c# project.";
		//	// Hotmail SMTP server address
		//	SmtpServer oServer = new SmtpServer("smtp.yandex.ru");

		//	int pos = oMail.From.ToString().IndexOf("@");
		//	string user = oMail.From.ToString().Substring(1, pos - 1);

		//	// Hotmail user authentication should use your
		//	// email address as the user name.
		//	oServer.User = "parad74";

		//	// oServer.Password = "marina73parker74";//args[1];
		//	oServer.Password = "bosdimex73";

		//	// Set 587 port, if you want to use 25 port, please change 587 to 25
		//	oServer.Port = 465;

		//	// detect SSL/TLS connection automatically
		//	oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;


		//	try
		//	{
		//		Console.WriteLine("start to send email over SSL...");
		//		oSmtp.SendMail(oServer, oMail);
		//		Console.WriteLine("email was sent successfully!");
		//	}
		//	catch (Exception ep)
		//	{
		//		Console.WriteLine("failed to send email with the following error:");
		//		Console.WriteLine(ep.Message);
		//	}
		//}

		//public async Task SendEmailAsync1(string email, string subject, string message)
		//{
		//    var message = new MimeMessage();
		//    message.From.Add(new MailboxAddress("TheCodeBuzz", "xxxx@gmail.com"));
		//    message.To.Add(new MailboxAddress("TheCodeBuzz", "info@thecodebuzz.com"));
		//    message.Subject = "My First Email";
		//    message.Body = new TextPart("plain")
		//    {
		//        Text = emailData
		//    };

	}

}

