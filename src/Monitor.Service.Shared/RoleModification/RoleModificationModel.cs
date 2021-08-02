using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Monitor.Service.Model
{
	public class RoleModificationModel
	{
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
	}

   
}
