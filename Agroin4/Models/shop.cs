using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class shop
    {
        public int id { get; set; }
        [Display(Name = "Shop Name")]
        public string shop_name { get; set; }
        [Display(Name = "District Name")]

        public int district_id { get; set; }
        [Display(Name = "Shop Address")]
        public string address { get; set; }
        [Display(Name = "Shop Contact")]
        public long contact { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }

        [ForeignKey("district_id")]
        public virtual district districts { get; set; }
    }
}