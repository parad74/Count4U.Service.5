using System;
using System.Collections.Generic;
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

        public string Error { get; set; }
        public string Message { get; set; }
        public SuccessfulEnum Successful { get; set; }

    }
}
