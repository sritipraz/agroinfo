using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class seasondef
    {
        public int id{ get; set; }
        [Display(Name = "Season Name")]
        public string season_name { get; set; }
        public virtual ICollection<crop> cropss { get; set; }

    }
}