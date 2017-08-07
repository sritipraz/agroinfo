using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class topography
    {
        public int id { get; set; }
        [Display(Name = "Topography Name")]
        public string topography_name { get; set; }
         
        public virtual ICollection<crop>crops { get; set; }
    }
}