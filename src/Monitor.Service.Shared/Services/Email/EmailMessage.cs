using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace Monitor.Service.Shared
{
	public class EmailMessage
	{
		public List<MailboxAddress> To { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }

		public IFormFileCollection Attachments { get; set; }

		public EmailMessage(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
		{
			this.To = new List<MailboxAddress>();

			this.To.AddRange(to.Select(x => new MailboxAddress(x)));
			this.Subject = subject;
			this.Content = content;
			this.Attachments = attachments;
		}
	}
}

