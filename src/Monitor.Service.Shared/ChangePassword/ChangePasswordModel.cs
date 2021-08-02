using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class ChangePasswordModel
	{
		[Display(Name = "ApplicationUserID")]
		public string ApplicationUserID { get; set; }	   //first

		[Display(Name = "E-mail")]
		public string Email { get; set; }						//second

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Current password")]
		public string OldPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "New password")]
		// [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "The password should have one lower case character, one upper case character, one number, one special character and at least 8 characters.")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm new password")]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		public string StatusMessage { get; set; }
	}
}
