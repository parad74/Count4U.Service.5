using System.ComponentModel.DataAnnotations;

namespace Monitor.Service.Model
{
	public class DeleteModel
	{
		[Display(Name = "ApplicationUserID")]
		public string ApplicationUserID { get; set; }

		public string Email { get; set; }
	}
}
