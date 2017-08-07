using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agroin4.Models
{
    public class article
    {
        public int id { get; set; }
        [Display(Name = "Article Name")]
        public string article_name { get; set; }
        [Display(Name = "Crop Name")]
        public int crop_id { get; set; }
        [Display(Name = "Published On")]
        public DateTime date_time { get; set; }
        public int rating { get; set; }
        public  Guid expert_id { get; set; }
        [Display(Name = "Email")]
        
        public string expert_email { get; set; }
        [Display(Name = "Article Description")]
        [DataType(DataType.MultilineText)]
        public string article_description { get; set; }

        //public virtual ICollection<comment> comments { get; set; }

    }
    
}