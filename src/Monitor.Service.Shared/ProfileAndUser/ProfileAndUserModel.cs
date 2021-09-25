using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class ProfileAndUserModel
	{
		public RegisterModel RegisterModel { get; set; }
		public ProfileFile ProfileFile { get; set; }
		public bool UseExistingProfile { get; set; } = false;
		public string InheritProfile { get; set; } = InheritProfileString.Default;
	//	public CustomerProfileModel CustomerProfileCodesFromDB { get; set; }

		public ProfileAndUserModel(RegisterModel registerModel, ProfileFile profileFile)
		{
			RegisterModel = registerModel;
			ProfileFile = profileFile;
			//CustomerProfileCodesFromDB = new CustomerProfileModel();
		}

		//public RegisterModel()
		//{
		//}



	}

	public static class InheritProfileString
	{
		public static string Exist = "Exist";
		public static string Default = "Default";
		public static string File = "File";
		public static string Customer = "Customer";

	}
}
