using System.ComponentModel.DataAnnotations;

namespace Count4U.Service.Shared
{
	public interface IProfileModel
	{
		string ID { get; set; }
		string DataServerAddress { get; set; }
		string DataServerPort { get; set; }
		string AccessKey { get; set; }
		string CustomerCode { get; set; }
		string BranchCode { get; set; }
		string InventorCode { get; set; }
		string DBPath { get; set; }
	}


	public class ProfileModel : IProfileModel
	{
		//Email - ключ для поиска пользователя, его менять нельзя
		//[Required]
		//[EmailAddress]
		[Display(Name = "ID")]
		public string ID { get; set; }

		[DataType(DataType.Url)]
		//[Required]
		[Display(Name = " Data Server Address")]
		public string DataServerAddress { get; set; }

		[Display(Name = "Data Server Port")]
		public string DataServerPort { get; set; }

		//[Range(10000, 99999, ErrorMessage = "Port can be number 10000 - 99999")]
		//public int DataServerPort { get; set; }

		[Display(Name = "Access Key")]
		public string AccessKey { get; set; }

		[Display(Name = "Customer Code")]
		public string CustomerCode { get; set; }

		[Display(Name = "Branch Code")]
		public string BranchCode { get; set; }

		[Display(Name = "Inventor Code")]
		public string InventorCode { get; set; }

		[Display(Name = "DB Path")]
		public string DBPath { get; set; }
		//public string Name { get; set; }
		//public bool IsAuthenticated { get; set; }
		//public string ProfileImage { get; set; }
		//[Required]
		//[Range(typeof(bool), "true", "true",
		//ErrorMessage = "This form disallows unapproved ships.")]
		//public bool IsValidatedDesign { get; set; }


		public ProfileModel()
		{
			this.ID = "";
			this.DataServerAddress = "";
			this.DataServerPort = "";
			this.AccessKey = "";
			this.CustomerCode = "";
			this.BranchCode = "";
			this.InventorCode = "";
			this.DBPath = "";
		}


	}
}
