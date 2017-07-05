using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class article
    {
        public int id { get; set; }
        public string article_name { get; set; }
        public int crop_id { get; set; }
        public DateTime date_time { get; set; }
        public int rating { get; set; }
        public  int expert_id { get; set; }
    
    }
}