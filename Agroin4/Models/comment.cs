using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class comment
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int article_id { get; set; }
        public string comment_text { get; set; }
        public bool status { get; set; }
     //   public string Userid { get; set; }
        public int? parentComment { get; set; }
         
        [ForeignKey("parentComment")]
        public virtual comment Comment { get; set; }

        //[ForeignKey("article_id")]
        //public virtual article article { get; set; }

    }
}