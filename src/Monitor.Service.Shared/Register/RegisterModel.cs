using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class RegisterModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Customer Code")]
		public string CustomerCode { get; set; }


		[Display(Name = "User Description")]
		public string UserDescription { get; set; }


		[Display(Name = "Use Android")]
		public bool IsWorker { get; set; }

		[Display(Name = "Manage Profile")]
		public bool IsManager { get; set; }

		[Display(Name = "Database")]
		public bool IsOwner { get; set; }

	}
}
