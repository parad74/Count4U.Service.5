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
		public bool IsWorker { get; set; } = true;

		[Display(Name = "Manage Profile")]
		public bool IsManager { get; set; } = false;

		[Display(Name = "Database")]
		public bool IsOwner { get; set; } = false;

		public string UserID { get; set; }


		public RegisterModel(UserViewModel userViewModel)
		{
			if (userViewModel != null)
			{
				this.UserID = userViewModel.UserID;
				this.Email = userViewModel.Email;
				this.CustomerCode = userViewModel.CustomerCode;
				this.UserDescription = userViewModel.Description;
				IsOwner = false;
				IsWorker = false;
				IsManager = false;
				foreach (string role in userViewModel.InRoles)
				{
					if (role == "Owner") IsOwner = true;
					else if (role == "Worker") IsWorker = true;
					else if (role == "Manager") IsManager = true;
				}
			}
		}

		public RegisterModel()
		{
		}

	}
}
