using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class UserRolesViewModel
    {
        public UserRolesViewModel()
        {
            this.RoleName = new List<string>();
        }
        public string UserName { get; set; }
        public List<string> RoleName { get; set; }
        public string UserId { get; set; }
       
    }


}