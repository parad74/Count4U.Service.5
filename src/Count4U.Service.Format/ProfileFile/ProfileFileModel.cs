using System.ComponentModel.DataAnnotations;

namespace Count4U.Service.Format
{
	public interface IProfileFileModel
	{
		string ID { get; set; }
		string AuditCode { get; set; }
		string CustomerCode { get; set; }
		string BranchCode { get; set; }
		string InventorCode { get; set; }
		string DomainObject { get; set; }
		string CurrentPath { get; set; }
		string ProfileText { get; set; }
	}


	public class ProfileFileModel : IProfileFileModel
	{
		[Display(Name = "ID")]
		public string ID { get; set; }

		[Display(Name = " Audit Code")]
		public string AuditCode { get; set; }


		[Display(Name = "Customer Code")]
		public string CustomerCode { get; set; }

		[Display(Name = "Branch Code")]
		public string BranchCode { get; set; }

		[Display(Name = "Inventor Code")]
		public string InventorCode { get; set; }

		[Display(Name = "Domain Object")]
		public string DomainObject { get; set; }

		[Display(Name = "Current Path")]
		public string CurrentPath { get; set; }

		[Display(Name = "Profile Text")]
		public string ProfileText { get; set; }


		public ProfileFileModel()
		{
			this.ID = "";
			this.AuditCode = "";
			this.CustomerCode = "";
			this.BranchCode = "";
			this.InventorCode = "";
			this.DomainObject = "";
			this.CurrentPath = "";
			this.ProfileText = "";

		}


	}
}
