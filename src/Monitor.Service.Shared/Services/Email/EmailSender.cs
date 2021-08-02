using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Monitor.Service.Shared.Settings;

namespace Monitor.Service.Shared
{
	public interface IEmailSender
	{
		void SendEmail(EmailMessage message);
		Task SendEmailAsync(EmailMessage message);
	}
	public class EmailSender : IEmailSender
	{
		private readonly EmailSettings _emailSettings;

		public EmailSender(EmailSettings emailSettings)              //EmailSettings
		{
			this._emailSettings = emailSettings;
		}

		public void SendEmail(EmailMessage message)
		{
			var emailMessage = this.CreateEmailMessage(message);

			this.Send(emailMessage);
		}

		public async Task SendEmailAsync(EmailMessage message)
		{
			var mailMessage = this.CreateEmailMessage(message);

			await this.SendAsync(mailMessage);
		}

		private MimeMessage CreateEmailMessage(EmailMessage message)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress(this._emailSettings.From));
			emailMessage.To.AddRange(message.To);
			emailMessage.Subject = message.Subject;
			// emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

			var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("{0}", message.Content) };

			if (message.Attachments != null && message.Attachments.Any())
			{
				byte[] fileBytes;
				foreach (var attachment in message.Attachments)
				{
					using (var ms = new MemoryStream())
					{
						attachment.CopyTo(ms);
						fileBytes = ms.ToArray();
					}

					bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
				}
			}

			emailMessage.Body = bodyBuilder.ToMessageBody();
			return emailMessage;
		}

		private void Send(MimeMessage mailMessage)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect(this._emailSettings.SmtpServer, Convert.ToInt32(this._emailSettings.Port), true);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					client.Authenticate(this._emailSettings.UserName, this._emailSettings.Password);

					client.Send(mailMessage);
				}
				catch
				{
					//log an error message or throw an exception, or both.
					throw;
				}
				finally
				{
					client.Disconnect(true);
					client.Dispose();
				}
			}
		}

		private async Task SendAsync(MimeMessage mailMessage)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					await client.ConnectAsync(this._emailSettings.SmtpServer, Convert.ToInt32(this._emailSettings.Port), true);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					await client.AuthenticateAsync(this._emailSettings.UserName, this._emailSettings.Password);

					await client.SendAsync(mailMessage);
				}
				catch
				{
					//log an error message or throw an exception, or both.
					throw;
				}
				finally
				{
					await client.DisconnectAsync(true);
					client.Dispose();
				}
			}
		}
	}
}

//https://code-maze.com/send-email-with-attachments-aspnetcore-2/
//var message = new Message(new string[] { "codemazetest@mailinator.com" }, "Test email async", "This is the content from our async email.");
//await _emailSender.SendEmailAsync(message);

//----------
// var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
//    var message = new Message(new string[] { "codemazetest@mailinator.com" }, "Test mail with Attachments", "This is the content from our mail with attachments.", files);
//    await _emailSender.SendEmailAsync(message);