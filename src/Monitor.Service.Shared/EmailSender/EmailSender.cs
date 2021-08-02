//using System;
//using System.Threading.Tasks;
//using Mailjet.Client;
//using Mailjet.Client.Resources;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json.Linq;

//namespace Monitor.Service.Model
//{
//	// This class is used by the application to send email for account confirmation and password reset.
//	// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
//	public interface IEmailSender
//	{
//		Task SendEmailConfirmationAsync(string email, string userName, string confirmationLink);
//		Task SendNewConversationAsync(string email, string tossCreatorUserName, string conversationUserName, string tossUrl);
//		Task SendPasswordForgetAsync(string email, string userName, string passwordResetLink);
//	}
//	public class EmailSender : IEmailSender
//	{
//		private readonly IConfiguration Configuration;
//		private readonly IHttpContextAccessor contextAccessor;

//		public EmailSender(IConfiguration configuration, IHttpContextAccessor contextAccessor)
//		{
//			this.Configuration = configuration;
//			this.contextAccessor = contextAccessor;
//		}



//		public async Task SendPasswordForgetAsync(string email, string userName, string passwordResetLink)
//		{
//			await this.SendMailjetTemplate(email, userName, 462997, "COUNT4U.SERVICE account password reset", new JObject { { "name", userName }, { "confirmation_link", passwordResetLink } });
//		}

//		public async Task SendEmailConfirmationAsync(string email, string userName, string confirmationLink)
//		{
//			await this.SendMailjetTemplate(email, userName, 462653, "Welcome to COUNT4U.SERVICE, please confirm your email", new JObject { { "name", userName }, { "confirmation_link", confirmationLink } });
//		}

//		public async Task SendNewConversationAsync(string email, string tossCreatorUserName, string conversationUserName, string tossUrl)
//		{
//			await this.SendMailjetTemplate(email, tossCreatorUserName, 943321, $"{conversationUserName} started a conversation with you.",
//			 new JObject {
//				 { "name", tossCreatorUserName },
//				 { "toss_url", tossUrl } ,
//				 {"conversationUserName", conversationUserName}
//				});
//		}


//		private async Task SendMailjetTemplate(string email, string userName, int templateId, string subject, JObject templateVariables)
//		{
//			var client = new MailjetClient(
//					this.Configuration.GetValue<string>("MailJetApiKey"),
//					this.Configuration.GetValue<string>("MailJetApiSecret"))
//			{
//				Version = ApiVersion.V3_1
//			};
//			MailjetRequest request = new MailjetRequest
//			{
//				Resource = Send.Resource,
//			}
//		   .Property(Send.Messages, new JArray {
//				new JObject {
//					 {"From", new JObject {{"Email", this.Configuration.GetValue<string>("MailJetSender")},{"Name", "Toss"}}},
//					 {"To", new JArray {new JObject {{"Email", email},{"Name", userName}}}},
//					 {"TemplateID", templateId},
//					 {"TemplateLanguage", true},
//					 {"TemplateErrorDeliver", true},
//                     //{"TemplateErrorReporting",new JObject  {{"Email", "" }, {"Name", "Rémi Bourgarel" } } },
//                     {"Subject", subject},
//					 {"Variables", templateVariables}
//				 }
//			   }
//			);
//			MailjetResponse response = await client.PostAsync(request);
//			if (!response.IsSuccessStatusCode)
//			{
//				throw new Exception(
//					string.Format("StatusCode: {0}    ", response.StatusCode) +
//					string.Format("ErrorInfo: {0}    ", response.GetErrorInfo()) +
//					string.Format("GetData: {0}    ", response.GetData()) +
//					string.Format("ErrorMessage: {0}    ", response.GetErrorMessage()));
//			}
//		}

//	}
//}
