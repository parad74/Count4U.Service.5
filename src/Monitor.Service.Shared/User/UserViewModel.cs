using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Service.Model
{
    public class UserViewModel
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string CustomerCode { get; set; }
        public string Description { get; set; }
        public bool ToAdd { get; set; } = false;
        public bool ToDelete { get; set; } = false;
         public List<string> InRoles { get; set; }
       // public override string ToString() => string.Join(" ", this.InRoles.Select(x => x.RoleName).ToList());
        public string Error { get; set; }
        public string Message { get; set; }
        public SuccessfulEnum Successful { get; set; }

        [Display(Name = "Use Android")]
        public bool IsWorker { get; set; } = false;

        [Display(Name = "Manage Profile")]
        public bool IsManager { get; set; } = false;

        [Display(Name = "Database")]
        public bool IsOwner { get; set; } = false;

    }
}
