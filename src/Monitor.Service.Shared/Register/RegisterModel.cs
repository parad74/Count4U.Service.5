using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Monitor.Service.Model
{
	public class RegisterModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; } = "";

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; } = "";

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; } = "";

		private string _userCustomerCode = "";
		[Display(Name = "User Customer Code")]
		public string UserCustomerCode
		{
			get { return _userCustomerCode; }
			set
			{
				_userCustomerCode = value;
			}
		}


		private string _customerCode = "";
		[Display(Name = "Customer Code")]
		public string CustomerCode
		{
			get { return _customerCode; }
			set
			{
				_customerCode = value;
			}
		}


		[JsonIgnore]
		public string CustomerCodeNew
		{
			get { return _customerCode; }
			set
			{
				this._customerCode = value;
				this.Email = value + @"@customer.com";
				this.Password = value + @"@customer.com";
				this.ConfirmPassword = value + @"@customer.com";
				this.InheritProfile = InheritProfileString.Default;
				this.CustomerExist = false;
				if (CustomerProfileCodesFromDB.CodeDictionary.ContainsKey(value))
				{
					CustomerExist = true;
					InheritProfile = InheritProfileString.Exist;
				}
				else
				{
					
				}
			}
		}

		[JsonIgnore]
		[Display(Name = "Customer Ecxist")]
		public bool CustomerExist { get; set; } = false;

		[Display(Name = "User Description")]
		public string UserDescription { get; set; } = "";

		private string _customerName = "";

		[Display(Name = "Customer Name")]
		public string CustomerName
		{
			get { return _customerName; }
			set
			{
				_customerName = value;
			}
		}

		private string _customerDescription = "";

		[Display(Name = "Customer Description")]
		public string CustomerDescription
		{
			get { return _customerDescription; }
			set
			{
				_customerDescription = value;
			}
		}



		[Display(Name = "Use Android")]
		public bool IsWorker { get; set; } = true;

		[Display(Name = "Manage Profile")]
		public bool IsManager { get; set; } = false;

		[Display(Name = "Database")]
		public bool IsOwner { get; set; } = false;

		public string UserID { get; set; } = "";

		[JsonIgnore]
		public CustomerProfileModel CustomerProfileCodesFromDB { get; set; }

		[JsonIgnore]
		public string InheritProfile { get; set; } = InheritProfileString.Default;

		public string DateCreated { get; set; } = "";
		public RegisterModel RefreshRegisterModel(UserViewModel userViewModel)
		{
			if (userViewModel != null)
			{
				this.UserID = userViewModel.UserID;
				this.Email = userViewModel.Email;
				this.CustomerCode = userViewModel.CustomerCode;
				this.DateCreated = userViewModel.DateCreated.ToString("dd-MM-yyyy HH:mm");
				Console.WriteLine($"userViewModel.DateCreated {userViewModel.DateCreated}");
				Console.WriteLine($"DateCreated {DateCreated}");
				//this.CustomerDescription = userViewModel.Description;
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
			return this;
		}

		public RegisterModel()
		{
			CustomerProfileCodesFromDB = new CustomerProfileModel();
		}

	}
}
