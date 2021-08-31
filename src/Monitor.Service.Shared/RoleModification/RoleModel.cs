using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Monitor.Service.Model
{
	 ////public class RoleEditModel
  ////  {
  ////      public string RoleID { get; set; } = "";
  ////      public string RoleName { get; set; }   = "";
  ////      public List<UserViewModel> Members { get; set; } = new List<UserViewModel>();
  ////      public List<UserViewModel> NonMembers { get; set; } = new List<UserViewModel>();
  ////      public override string ToString() => string.Join(" ",this.Members.Select(x=>x.Email).ToList());
  ////  }

    public class RoleModel
    {
        public string RoleID { get; set; } = "";
        public string RoleName { get; set; } = "";
        public List<UserViewModel> Members { get; set; }
        public List<UserViewModel> NonMembers { get; set; } = new List<UserViewModel>();
        public override string ToString() => string.Join(" ",this.Members.Select(x=>x.Email).ToList());
    }

  
}
