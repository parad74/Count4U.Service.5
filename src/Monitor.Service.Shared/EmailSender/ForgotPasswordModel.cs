using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class ForgotPasswordModel
	{
		[Required]
		[EmailAddress]
		[DataType(DataType.Password)]
		public string Email { get; set; }

		public string ApplicationUserID { get; set; }

		public string NewPassword { get; set; }
		
	}

	     
}
