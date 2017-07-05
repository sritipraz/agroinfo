using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agroin4.Models
{
    public class shop
    {
        public int id { get; set; }
        public string shop_name { get; set; }
        public int district_id { get; set; }
        public string address { get; set; }
        public long contact { get; set; }
        public string email { get; set; }
    }
}