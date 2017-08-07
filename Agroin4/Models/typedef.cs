using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class typedef
    {
        public int id { get; set; }
        [Display(Name = "Type Name")]
        public string type_name { get; set; }
        public virtual ICollection<registration_tb> registrations { get; set; }
    }
}